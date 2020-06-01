using br.com.ustj.FoodPantryControl.Webapi.Model;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace br.com.ustj.FoodPantryControl.Webapi.Infrastructure.Services
{
    public class IdentityParser : IIdentityParser<ItemModel>
    {
        public ItemModel Parse(IPrincipal principal)
        {
            if (principal is ClaimsPrincipal claims)
            {
                return new ItemModel()
                {
                    
                    Name = claims.Claims.FirstOrDefault(x => x.Type == "Name")?.Value?? "",

                };
            }

            throw new ArgumentException(message: "The principal must be a ClaimsPrincipal", paramName: nameof(principal));
        }
    }
}
