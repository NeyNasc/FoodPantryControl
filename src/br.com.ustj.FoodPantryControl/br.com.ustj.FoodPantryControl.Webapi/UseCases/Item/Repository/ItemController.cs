using br.com.ustj.FoodPantryControl.Application.UseCases.Item.Repository;
using Microsoft.AspNetCore.Mvc;

namespace br.com.ustj.FoodPantryControl.Webapi.UseCases.Gedoc.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemUseCase ItemUseCase;
        private readonly ItemPresenter presenter;

        public ItemController(IItemUseCase itemUseCase, ItemPresenter presenter)
        {
            this.ItemUseCase = itemUseCase;
            this.presenter = presenter;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ItemResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Route("InsertItem")]
        public IActionResult CreateRepository([FromBody] ItemRequest input)
        {
            ItemUseCase.Execute(
                new Application.UseCases.Item.Repository.ItemRequest(
                    input.BarCode,
                    input.Quantity,
                    input.Name,
                    input.ExpirationDate));

            return presenter.ViewModel;
        }
    }
}
