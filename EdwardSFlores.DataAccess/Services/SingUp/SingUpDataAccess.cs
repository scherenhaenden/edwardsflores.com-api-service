using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;
using EdwardSFlores.DataAccess.Database.Security;
using EdwardSFlores.DataAccess.Models;

namespace EdwardSFlores.DataAccess.Services.SingUp;

public class SingUpDataAccess: ISingUpDataAccess
{
    private readonly IPublicUserUnity _publicUserUnity;
    
    
    public SingUpDataAccess(IDataContextManager dataContextManager, IPasswordHasher passwordHasher)

    {
        _publicUserUnity = new PublicUserUnity(dataContextManager, passwordHasher);
    }
    
    public Task<List<string>>? ProValidationSingUp(SingUpModelDataAccess singUpModel)
    {
        // check if username exists
        var checkUserName = _publicUserUnity?.Users.GetUserByUsername(singUpModel.Username);
        // check if email exists
        var checkEmail = _publicUserUnity?.Users.GetUserByEmail(singUpModel.Email);
        // check if password is valid
        // check if password and confirm password are the same
        
        var errors = new List<string>();
        
        if (checkUserName != null)
        {
            errors.Add("Username already exists");
        }
        
        if (checkEmail != null)
        {
            errors.Add("Email already exists");
        }
        return null;
    }

    public Task<bool> SingUp(SingUpModelDataAccess singUpModel)
    {

        var user = new User
        {
            Username = singUpModel.Username,
            Email = singUpModel.Email,
            Password = singUpModel.Password,

        };

        _publicUserUnity?.Users.Add(user);
        var result =  new Task<bool>(() => _publicUserUnity.Save());
        result.Start();
        result.Wait();
        return result;
    }
}