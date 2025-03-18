using BMCore.Application.ApplicationLogic.CityLogic.Command;
using BMCore.Application.ApplicationLogic.CityLogic.Model;
using BMCore.Application.ApplicationLogic.CityLogic.Queries;
using BMCore.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace BMCore.Api.Controllers
{
    public class CityController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<CityGridModel>>> GetAllAsync()
        {
            var getCities = await Mediator.Send(new GetAllCityQuery());
            return Ok(getCities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityViewModel>> GetByIdAsync(int id)
        {
            var cvm = new CityViewModel
            {
                UpdateModel = await Mediator.Send(new GetCityDetailsQuery { Id = id })
            };
            return Ok(cvm);
        }

        [HttpPost]
        public async Task<ActionResult<CityCreateModel>> CreateAsync(CreateCityCommand model)
        {
            if (ModelState.IsValid)
            {
                var createCity = await Mediator.Send(model);
                return Ok(createCity);
            }
            return BadRequest(model);
        }

        [HttpPut]
        public async Task<ActionResult<CityUpdateModel>> UpdateAsync(CityUpdateCommand model)
        {
            if (ModelState.IsValid)
            {
                var updateCity = await Mediator.Send(model);
                return Ok(updateCity);
            }
            return BadRequest(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            var deleteCity = await Mediator.Send(new CityDeleteCommand { Id = id });
            return Ok(deleteCity);
        }
    }
}
