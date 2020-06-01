using br.com.ustj.FoodPantryControl.Application.UseCases.Delete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace br.com.ustj.FoodPantryControl.Webapi.UseCases.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteItemController : ControllerBase
    {
        private readonly ItemDeletePresenter presenter;
        private readonly IDeleteItemUseCase useCase;

        public DeleteItemController(ItemDeletePresenter pres, IDeleteItemUseCase usecase)
        {
            this.presenter = pres;
            this.useCase = usecase;
        }

        [HttpDelete]
        [ProducesResponseType(typeof(List<DeleteItemResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Route("DeleteItem")]
        public IActionResult DeleteItem([FromBody] ItemDeleteRequest request)
        {
            useCase.Execute(new DeleteItemRequest(request.BarCode));
            return presenter.ViewModel;
        }
    }
}
