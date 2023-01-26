using EdwardSFlores.DataAccess.Database.Security;
using EdwardSFlores.DataAccess.Models;
using EdwardSFlores.DataAccess.Services.SingUp;
using Newtonsoft.Json;

namespace EdwardSFlores.BusinessLogic.Services.SingUp;

public class SingUpServiceBusinessLogic: ISingUpServiceBusinessLogic
{
    private readonly ISingUpDataAccess _singUpDataAccess;


    public SingUpServiceBusinessLogic(ISingUpDataAccess singUpDataAccess, IPasswordHasher passwordHasher)

    {
        _singUpDataAccess = singUpDataAccess;
    }

    public Task<List<string>> ProValidationSingUp(SingUpModelBusinessLogic singUpModel)
    {
        
        // convert object to json
        var json = JsonConvert.SerializeObject(singUpModel);
        
        // convert json to object
        var singUpModelDataAccess = JsonConvert.DeserializeObject<SingUpModelDataAccess>(json);
        
        // call data access
        return _singUpDataAccess.ProValidationSingUp(singUpModelDataAccess);

    }

    public Task<bool> SingUp(SingUpModelBusinessLogic singUpModel)
    {
        // convert object to json
        var json = JsonConvert.SerializeObject(singUpModel);
        
        // convert json to object
        var singUpModelDataAccess = JsonConvert.DeserializeObject<SingUpModelDataAccess>(json);
        
        // call data access
        return _singUpDataAccess.SingUp(singUpModelDataAccess);
    }
}