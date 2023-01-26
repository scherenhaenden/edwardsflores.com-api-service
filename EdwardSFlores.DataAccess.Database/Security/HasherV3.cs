using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Generators;

namespace EdwardSFlores.DataAccess.Database.Security;

public class HasherV3: IPasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
    }
}

public class HasherV4: IPasswordHasher
{
    public string HashPassword(string password)
    {
        //STEP 1 Create the salt value with a cryptographic PRNG:

        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
        
        //STEP 2 Create the Rfc2898DeriveBytes and get the hash value:

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
        var hash = pbkdf2.GetBytes(20);
        
        //STEP 3 Combine the salt and password bytes for later use:

        var hashBytes = new byte[36];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);
        
        //STEP 4 Turn the combined salt+hash into a string for storage

        var savedPasswordHash = Convert.ToBase64String(hashBytes);
           return savedPasswordHash;
    }

    public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        
/* Extract the bytes */
        var hashBytes = Convert.FromBase64String(hashedPassword);
/* Get the salt */
        var salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);
/* Compute the hash on the password the user entered */
        var pbkdf2 = new Rfc2898DeriveBytes(providedPassword, salt, 100000);
        var hash = pbkdf2.GetBytes(20);
/* Compare the results */
        for (var i=0; i < 20; i++)
            if (hashBytes[i + 16] != hash[i])
                return false;
        
        return true;
    }
}

public class HasherV5 : IPasswordHasher
{
    public string HashPassword(string password)
    {
        return SecurePasswordHasher.Hash(password);
    }

    public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        return SecurePasswordHasher.Verify(providedPassword, hashedPassword);
    }
}

public static class SecurePasswordHasher
{
    /// <summary>
    /// Size of salt.
    /// </summary>
    private const int SaltSize = 16;

    /// <summary>
    /// Size of hash.
    /// </summary>
    private const int HashSize = 20;

    /// <summary>
    /// Creates a hash from a password.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="iterations">Number of iterations.</param>
    /// <returns>The hash.</returns>
    public static string Hash(string password, int iterations)
    {
        // Create salt
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] salt;
            rng.GetBytes(salt = new byte[SaltSize]);
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                var hash = pbkdf2.GetBytes(HashSize);
                // Combine salt and hash
                var hashBytes = new byte[SaltSize + HashSize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
                // Convert to base64
                var base64Hash = Convert.ToBase64String(hashBytes);

                // Format hash with extra information
                return $"$HASH|V1${iterations}${base64Hash}";
            }
        }

    }

    /// <summary>
    /// Creates a hash from a password with 10000 iterations
    /// </summary>
    /// <param name="password">The password.</param>
    /// <returns>The hash.</returns>
    public static string Hash(string password)
    {
        return Hash(password, 10000);
    }

    /// <summary>
    /// Checks if hash is supported.
    /// </summary>
    /// <param name="hashString">The hash.</param>
    /// <returns>Is supported?</returns>
    public static bool IsHashSupported(string hashString)
    {
        return hashString.Contains("HASH|V1$");
    }

    /// <summary>
    /// Verifies a password against a hash.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <param name="hashedPassword">The hash.</param>
    /// <returns>Could be verified?</returns>
    public static bool Verify(string password, string hashedPassword)
    {
        // Check hash
        if (!IsHashSupported(hashedPassword))
        {
            throw new NotSupportedException("The hashtype is not supported");
        }

        // Extract iteration and Base64 string
        var splittedHashString = hashedPassword.Replace("$HASH|V1$", "").Split('$');
        var iterations = int.Parse(splittedHashString[0]);
        var base64Hash = splittedHashString[1];

        // Get hash bytes
        var hashBytes = Convert.FromBase64String(base64Hash);

        // Get salt
        var salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        // Create hash with given salt
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
        {
            var hash = pbkdf2.GetBytes(HashSize);

            // Get result
            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}