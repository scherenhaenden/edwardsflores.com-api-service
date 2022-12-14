using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Unities;

namespace EdwardSFlores.DataAccess.Services.SingUp;

public class SingUpDataAccess: ISingUpDataAccess
{
    private readonly IGenericUnitOfWork _genericUnitOfWork;
    
    public SingUpDataAccess(IDataContextManager dataContextManager)

    {
        _genericUnitOfWork = dataContextManager.GenericUnityOfWork;
    }
    
    public Task<List<string>>? ProValidationSingUp(SingUpModelDataAccess singUpModel)
    {
        // check if username exists
        var checkUserName =_genericUnitOfWork?.Users?.Where(x => x.Password == singUpModel.Username)?.Any();
        // check if email exists
        var checkEmail = _genericUnitOfWork?.Users?.Where(x => x.Email == singUpModel.Email)?.Any();
        // check if password is valid
        // check if password and confirm password are the same
        
        var errors = new List<string>();
        
        if (checkUserName??false)
        {
            errors.Add("Username already exists");
        }
        
        if (checkEmail??false)
        {
            errors.Add("Email already exists");
        }
     



        return null;


    }

    public Task<bool> SingUp(SingUpModelDataAccess singUpModel)
    {

        // add new user
        _genericUnitOfWork?.Users?.Add(new User
        {
            Username = singUpModel.Username,
            Email = singUpModel.Email,
            Password = singUpModel.Password,
            
        });
        var result =  new Task<bool>(() => _genericUnitOfWork.Save());
        result.Start();
        result.Wait();
        return result;
    }
}