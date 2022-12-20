using System.Security.Cryptography;

namespace EdwardSFlores.BusinessLogic.Tools;

public interface IPasswordHasher
{
    public string HashPassword(string password);
    
    bool VerifyHashedPassword(string hashedPassword, string providedPassword);
    
}

public class PasswordHasherOptions
{
    public int SaltSize { get; set; } = 16;
    public int Iterations { get; set; } = 10000;
    public HashAlgorithmName HashAlgorithmName { get; set; } = HashAlgorithmName.SHA1;
    
    public int KeySize { get; set; } = 256;
    
    public int HashSize { get; set; } = 256;
}