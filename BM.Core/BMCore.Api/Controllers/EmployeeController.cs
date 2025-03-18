using BMCore.Application.ApplicationLogic.EmployeeLogic.Command;
using BMCore.Application.ApplicationLogic.EmployeeLogic.Model;
using BMCore.Application.ApplicationLogic.EmployeeLogic.Queries;
using BMCore.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace BMCore.Api.Controllers
{
    public class EmployeeController : BaseController
    {
        [HttpGet]        
        public async Task<ActionResult<ICollection<EmployeeGridModel>>> GetAllAsync()
        {
            var getAll = await Mediator.Send(new GetAllEmployeesQuery());
            return Ok(getAll);
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<EmployeeViewModel>> GetByIdAsync(int id)
        {
            var bvm = new EmployeeViewModel
            {
                EmployeeUpdate = await Mediator.Send(new GetEmployeeDetailsQuery { Id = id })
            };
            return Ok(bvm);
        }

        [HttpPost]        
        public async Task<ActionResult<EmployeeCreateModel>> CreateAsync(CreateEmployeeCommand model)
        {
            if (ModelState.IsValid)
            {
                var create = await Mediator.Send(model);
                return Ok(create);
            }

            return BadRequest();
        }

        [HttpPut]        
        public async Task<ActionResult<EmployeeUpdateModel>> UpdateAsync(UpdateEmployeeCommand model)
        {
            if (ModelState.IsValid)
            {
                var update = await Mediator.Send(model);
                return Ok(update);
            }

            return BadRequest(model);
        }

        [HttpDelete("{id}")]        
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var delete = await Mediator.Send(new DeleteEmployeeCommand { Id = id });
            return Ok(delete);
        }
    }
}
