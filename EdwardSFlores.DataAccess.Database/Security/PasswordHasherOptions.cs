using System.Security.Cryptography;

namespace EdwardSFlores.DataAccess.Database.Security;

public class PasswordHasherOptions
{
    public int SaltSize { get; set; } = 16;
    public int Iterations { get; set; } = 8192;
    public HashAlgorithmName HashAlgorithmName { get; set; } = HashAlgorithmName.SHA1;
    
    public int KeySize { get; set; } = 256;
    
    public int HashSize { get; set; } = 256;
}