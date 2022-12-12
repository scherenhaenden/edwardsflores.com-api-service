using EdwardSFlores.BusinessLogic.Tools;
using EdwardSFlores.DataAccess.Services.SingUp;
using Newtonsoft.Json;

namespace EdwardSFlores.BusinessLogic.Services.SingUp;

public interface ISingUpServiceBusinessLogic
{
    Task<List<string>> ProValidationSingUp(SingUpModelBusinessLogic singUpModel);
    
    Task<bool> SingUp(SingUpModelBusinessLogic singUpModel);
}

public class SingUpServiceBusinessLogic: ISingUpServiceBusinessLogic
{
    private readonly ISingUpDataAccess _singUpDataAccess;
    private readonly IPasswordHasher _passwordHasher;


    public SingUpServiceBusinessLogic(ISingUpDataAccess singUpDataAccess, IPasswordHasher passwordHasher)

    {
        _singUpDataAccess = singUpDataAccess;
        _passwordHasher = passwordHasher;
    }

    public Task<List<string>> ProValidationSingUp(SingUpModelBusinessLogic singUpModel)
    {
        // call IPasswordHasher
        singUpModel.Password = _passwordHasher.HashPassword(singUpModel.Password);
        
        
        // convert object to json
        var json = JsonConvert.SerializeObject(singUpModel);
        
        // convert json to object
        var singUpModelDataAccess = JsonConvert.DeserializeObject<SingUpModelDataAccess>(json);
        
        // call data access
        return _singUpDataAccess.ProValidationSingUp(singUpModelDataAccess);

    }

    public Task<bool> SingUp(SingUpModelBusinessLogic singUpModel)
    {
        // call IPasswordHasher
        singUpModel.Password = _passwordHasher.HashPassword(singUpModel.Password);
        
        
        // convert object to json
        var json = JsonConvert.SerializeObject(singUpModel);
        
        // convert json to object
        var singUpModelDataAccess = JsonConvert.DeserializeObject<SingUpModelDataAccess>(json);
        
        // call data access
        return _singUpDataAccess.SingUp(singUpModelDataAccess);
    }
}

public class SingUpModelBusinessLogic
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    
}