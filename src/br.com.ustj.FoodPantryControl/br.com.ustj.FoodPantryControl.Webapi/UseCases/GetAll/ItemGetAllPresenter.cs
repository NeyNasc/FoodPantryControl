using br.com.ustj.FoodPantryControl.Application.Boudaries;
using br.com.ustj.FoodPantryControl.Domain.Item;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace br.com.ustj.FoodPantryControl.Webapi.UseCases.GetAll
{
    public class ItemGetAllPresenter : IOutputPort<List<Item>>
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

        public void Standard(List<Item> output)
        {
            var listItemsResponse = new List<GetAllItemResponse>();

            output.ForEach(f => listItemsResponse.Add(new GetAllItemResponse(
                f.Id, f.BarCode, f.Quantity, f.Name, f.ExpirationDate, f.InsertDate
                )));
            ViewModel = new OkObjectResult(listItemsResponse);
        }
    }
}
