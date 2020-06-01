using br.com.ustj.FoodPantryControl.Application.Boudaries;
using br.com.ustj.FoodPantryControl.Application.Boudaries.Item;
using Microsoft.AspNetCore.Mvc;

namespace br.com.ustj.FoodPantryControl.Webapi.UseCases.Delete
{
    public class ItemDeletePresenter : IOutputPort<ItemOutput>
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetail = new ProblemDetails
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetail);
        }

        public void NotFound(string message)
         => ViewModel = new NotFoundObjectResult(message);


        public void Standard(ItemOutput output)
            => ViewModel = new OkObjectResult(new DeleteItemResponse(output.IdItem, output.BarCode, output.Name));

    }
}
