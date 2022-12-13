using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Unities;

namespace EdwardSFlores.DataAccess.Services.SingUp;

public interface ISingUpDataAccess
{
    
    Task<List<string>> ProValidationSingUp(SingUpModelDataAccess singUpModel);
    
    Task<bool> SingUp(SingUpModelDataAccess singUpModel);
}

public class SingUpDataAccess: ISingUpDataAccess
{
    private readonly IUnitOfWork _unitOfWork;

    public SingUpDataAccess(IUnitOfWork unitOfWork)

    {
        _unitOfWork = unitOfWork;
    }
    
    public Task<List<string>>? ProValidationSingUp(SingUpModelDataAccess singUpModel)
    {
        // check if username exists
        var checkUserName =_unitOfWork?.User?.Where(x => x.Password == singUpModel.Username)?.Any();
        // check if email exists
        var checkEmail = _unitOfWork?.User?.Where(x => x.Email == singUpModel.Email)?.Any();
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
        _unitOfWork?.User?.Add(new User
        {
            Username = singUpModel.Username,
            Email = singUpModel.Email,
            Password = singUpModel.Password,
            
        });
        var result =  new Task<bool>(() => _unitOfWork.Save());
        result.Start();
        result.Wait();
        return result;
    }
}


public class SingUpModelDataAccess 
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    
}


// create SingUpModel
/*
public class SingUpModelDataAccess : ISingUpDataAccess
{
    //private readonly IHttpClientFactory _httpClientFactory;
    //private readonly IConfiguration _configuration;

    public SingUpModelDataAccess(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task<bool> SingUp(SingUpModel singUpModel)
    {
        var client = _httpClientFactory.CreateClient("IdentityServer");
        var response = await client.PostAsJsonAsync("api/Account", singUpModel);
        return response.IsSuccessStatusCode;
    }
}*/