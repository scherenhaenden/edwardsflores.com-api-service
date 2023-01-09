namespace EdwardSFlores.BusinessLogic.Services.SingUp;

public interface ISingUpServiceBusinessLogic
{
    Task<List<string>> ProValidationSingUp(SingUpModelBusinessLogic singUpModel);
    
    Task<bool> SingUp(SingUpModelBusinessLogic singUpModel);
}