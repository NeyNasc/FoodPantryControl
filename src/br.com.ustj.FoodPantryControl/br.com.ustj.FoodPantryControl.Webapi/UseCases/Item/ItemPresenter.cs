using br.com.ustj.FoodPantryControl.Application.Boudaries;
using br.com.ustj.FoodPantryControl.Application.Boudaries.Item;
using br.com.ustj.FoodPantryControl.Webapi.UseCases.Gedoc.Repository;
using Microsoft.AspNetCore.Mvc;

namespace br.com.ustj.FoodPantryControl.Webapi.UseCases.Gedoc
{
    public class ItemPresenter : IOutputPort<ItemOutput>
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(ItemOutput output)
            => ViewModel = new OkObjectResult(new ItemResponse(output.IdItem, output.BarCode, output.Quantity, output.Name, output.ExpirationDate, output.InsertDate));
    }
}
