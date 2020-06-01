using br.com.ustj.FoodPantryControl.Application.UseCases.GetAll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace br.com.ustj.FoodPantryControl.Webapi.UseCases.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllController : ControllerBase
    {
        private readonly ItemGetAllPresenter presenter;
        private readonly IGetAllItemUseCase usecase;
        public GetAllController(ItemGetAllPresenter pres, IGetAllItemUseCase getall)
        {
            this.presenter = pres;
            this.usecase = getall;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetAllItemResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Route("GetAllLegalNature")]
        public IActionResult GetAll()
        {
            usecase.Execute(new GetAllItemRequest());
            return presenter.ViewModel;
        }
    }
}
