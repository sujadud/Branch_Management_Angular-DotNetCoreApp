using ExamCore.Application.ApplicationLogic.EmployeeLogic.Command;
using ExamCore.Application.ApplicationLogic.EmployeeLogic.Model;
using ExamCore.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace ExamCore.Api.Controllers
{
    public class EmployeeController : BaseController
    {
        [HttpGet]        
        public async Task<ActionResult<ICollection<EmployeeGridModel>>> GetAllAsync()
        {
            
            return Ok();
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<EmployeeViewModel>> GetByIdAsync(int id)
        {
            return Ok();
        }

        [HttpPost]        
        public async Task<ActionResult<EmployeeCreateModel>> CreateAsync(CreateEmployeeCommand createEmployee)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]        
        public async Task<ActionResult<EmployeeUpdateModel>> UpdateAsync(UpdateEmployeeCommand countryUpdateModel)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]        
        public async Task<ActionResult<bool>> Delete(int id)
        {            
            return Ok();
        }
    }
}
