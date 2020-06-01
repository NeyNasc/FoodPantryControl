using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace br.com.ustj.FoodPantryControl.Webapi.Pipeline
{
    /// <summary>
    ///     Apply <see cref="NotFoundResultAttribute" /> to all Api controllers
    /// </summary>
    public class NotFoundResultApiConvention : ApiConventionBase
    {
        protected override void ApplyControllerConvention(ControllerModel controller)
        {
            controller.Filters.Add(new NotFoundResultAttribute());
        }
    }

}
