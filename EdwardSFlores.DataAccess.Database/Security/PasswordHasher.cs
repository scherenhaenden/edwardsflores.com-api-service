using System.Security.Cryptography;

namespace EdwardSFlores.BusinessLogic.Tools;

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
    
        byte[] result = new byte[_options.HashSize + _options.SaltSize];
        Buffer.BlockCopy(hashBuffer, 0, result, 0, _options.HashSize);
        Buffer.BlockCopy(saltBuffer, 0, result, _options.HashSize, _options.SaltSize);
        return Convert.ToBase64String(result);
    }
    
    public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        // convert string to base64
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(hashedPassword);
        var rehasshed = System.Convert.ToBase64String(plainTextBytes);
        
        byte[] hashedPasswordBytes = Convert.FromBase64String(rehasshed);
        if (hashedPasswordBytes.Length != _options.HashSize + _options.SaltSize)
        {
            return false;
        }

        byte[] hashBytes = new byte[_options.HashSize];
        Buffer.BlockCopy(hashedPasswordBytes, 0, hashBytes, 0, _options.HashSize);
        byte[] saltBytes = new byte[_options.SaltSize];
        Buffer.BlockCopy(hashedPasswordBytes, _options.HashSize, saltBytes, 0, _options.SaltSize);

        byte[] providedHashBytes;
        using (var keyDerivation = new Rfc2898DeriveBytes(providedPassword, saltBytes, _options.Iterations, _options.HashAlgorithmName))
        {
            providedHashBytes = keyDerivation.GetBytes(_options.HashSize);
        }

        return hashBytes.SequenceEqual(providedHashBytes);
    }
}