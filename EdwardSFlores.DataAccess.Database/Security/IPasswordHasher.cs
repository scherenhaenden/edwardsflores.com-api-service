namespace EdwardSFlores.DataAccess.Database.Security;

public interface IPasswordHasher
{
    public string HashPassword(string password);
    
    bool VerifyHashedPassword(string hashedPassword, string providedPassword);
    
}