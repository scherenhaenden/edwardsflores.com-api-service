using EdwardSFlores.DataAccess.Models;

namespace EdwardSFlores.DataAccess.Services.SingUp;

public interface ISingUpDataAccess
{
    
    Task<List<string>> ProValidationSingUp(SingUpModelDataAccess singUpModel);
    
    Task<bool> SingUp(SingUpModelDataAccess singUpModel);
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