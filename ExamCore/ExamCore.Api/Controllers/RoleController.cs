using ExamCore.Application.ApplicationLogic.RoleLogic.Command;
using ExamCore.Application.ApplicationLogic.RoleLogic.Model;
using ExamCore.Application.ApplicationLogic.RoleLogic.Queries;
using ExamCore.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace ExamCore.Api.Controllers
{
    public class RoleController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<RoleGridModel>>> GetAllAsync()
        {
            var getRoles = await Mediator.Send(new GetAllRoleQuery());
            return Ok(getRoles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleViewModel>> GetByIdAsync(int id)
        {
            var vm = new RoleViewModel
            {
                UpdateModel = await Mediator.Send(new GetRoleDetailsQuery { Id = id })
            };
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<RoleCreateModel>> CreateAsync(CreateRoleCommand roleCreateModel)
        {
            if (ModelState.IsValid)
            {
                var createRole = await Mediator.Send(roleCreateModel);
                return Ok(createRole);
            }
            return BadRequest(roleCreateModel);
        }

        [HttpPut]
        public async Task<ActionResult<RoleUpdateModel>> UpdateAsync(UpdateRoleCommand roleUpdateModel)
        {
            if (ModelState.IsValid)
            {
                var updateRole = await Mediator.Send(roleUpdateModel);
                return Ok(updateRole);
            }
            return BadRequest(roleUpdateModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            var deleteRole = await Mediator.Send(new DeleteRoleCommand { Id = id });
            return Ok(deleteRole);
        }
    }
}
