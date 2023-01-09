using Newtonsoft.Json;

namespace EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;

public static class GenericJsonMapper
{
    public static string MapToJson<T>(this T entity) where T : class
    {
        return JsonConvert.SerializeObject(entity);
    }

    public static T MapFromJson<T>(this string json) where T : class
    {
        return JsonConvert.DeserializeObject<T>(json);
    }

    public static Tout MapObjToObj<Tout>(this object obj) where Tout : class
    {


        var json = JsonConvert.SerializeObject(obj);

        return JsonConvert.DeserializeObject<Tout>(json);
    }


}