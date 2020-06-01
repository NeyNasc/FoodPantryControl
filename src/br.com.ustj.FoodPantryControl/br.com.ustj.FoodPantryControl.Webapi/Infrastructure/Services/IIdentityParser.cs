using System.Security.Principal;

namespace br.com.ustj.FoodPantryControl.Webapi.Infrastructure.Services
{
    public interface IIdentityParser<T>
    {
        T Parse(IPrincipal principal);
    }
}
