using ExamCore.Application.ApplicationLogic.CountryLogic.Command;
using ExamCore.Application.ApplicationLogic.CountryLogic.Model;
using ExamCore.Application.ApplicationLogic.CountryLogic.Queries;
using ExamCore.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace ExamCore.Api.Controllers
{
    public class CountryController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<CountryGridModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<CountryGridModel>>> GetAllAsync()
        {
            var getCountries = await Mediator.Send(new GetAllCountryQuery());
            return Ok(getCountries);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CountryViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<CountryViewModel>> GetByIdAsync(int id)
        {
            var cvm = new CountryViewModel
            {
                UpdateModel = await Mediator.Send(new GetCountryDetailsQuery { Id = id })
            };

            // Select list

            return Ok(cvm);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CountryCreateModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<CountryCreateModel>> CreateAsync(CreateCountryCommand countryCreateModel)
        {
            if (ModelState.IsValid)
            {
                var createCountry = await Mediator.Send(countryCreateModel);
                return Ok(createCountry);
            }

            return BadRequest(countryCreateModel);
        }

        [HttpPut]
        [ProducesResponseType(typeof(CountryUpdateModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<CountryUpdateModel>> UpdateAsync(UpdateCountryCommand countryUpdateModel)
        {
            if (ModelState.IsValid)
            {
                var updateCountry = await Mediator.Send(countryUpdateModel);
                return Ok(updateCountry);
            }

            return BadRequest(countryUpdateModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var deletedCountry = await Mediator.Send(new DeleteCountryCommand { Id = id });
            return Ok(deletedCountry);
        }
    }
}