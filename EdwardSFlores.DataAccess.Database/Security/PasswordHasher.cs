using System.Security.Cryptography;

namespace EdwardSFlores.DataAccess.Database.Security;

public class PasswordHasher : IPasswordHasher
{
    
    private readonly PasswordHasherOptions _options;
    
    public PasswordHasher( )
    {
        _options = new PasswordHasherOptions();
    }

    public PasswordHasher(PasswordHasherOptions options)
    {
        _options = options;
    }
    
    
    public string HashPassword(string password)
    {
        byte[] saltBuffer;
        byte[] hashBuffer;

        
        using (var keyDerivation = new Rfc2898DeriveBytes(password, _options.SaltSize, _options.Iterations, _options.HashAlgorithmName))
        {
            saltBuffer = keyDerivation.Salt;
            hashBuffer = keyDerivation.GetBytes(_options.HashSize);
        }
    
        var result = new byte[_options.HashSize + _options.SaltSize];
        Buffer.BlockCopy(hashBuffer, 0, result, 0, _options.HashSize);
        Buffer.BlockCopy(saltBuffer, 0, result, _options.HashSize, _options.SaltSize);
        return Convert.ToBase64String(result);
    }
    
    public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        // convert string to base64
        var hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
        if (hashedPasswordBytes.Length != _options.HashSize + _options.SaltSize)
        {
            return false;
        }

        var hashBytes = new byte[_options.HashSize];
        Buffer.BlockCopy(hashedPasswordBytes, 0, hashBytes, 0, _options.HashSize);
        var saltBytes = new byte[_options.SaltSize];
        Buffer.BlockCopy(hashedPasswordBytes, _options.HashSize, saltBytes, 0, _options.SaltSize);

        byte[] providedHashBytes;
        using (var keyDerivation = new Rfc2898DeriveBytes(providedPassword, saltBytes, _options.Iterations, _options.HashAlgorithmName))
        {
            providedHashBytes = keyDerivation.GetBytes(_options.HashSize);
        }

        return ByteArrayCompare(hashBytes, providedHashBytes);
    }
    static bool ByteArrayCompare(ReadOnlySpan<byte> a1, ReadOnlySpan<byte> a2)
    {
        return a1.SequenceEqual(a2);
    }
}