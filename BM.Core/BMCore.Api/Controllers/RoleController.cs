using BMCore.Application.ApplicationLogic.CountryLogic.Model;
using BMCore.Application.ApplicationLogic.RoleLogic.Command;
using BMCore.Application.ApplicationLogic.RoleLogic.Model;
using BMCore.Application.ApplicationLogic.RoleLogic.Queries;
using BMCore.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace BMCore.Api.Controllers
{
    public class RoleController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<RoleGridModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<RoleGridModel>>> GetAllAsync()
        {
            var getRoles = await Mediator.Send(new GetAllRoleQuery());
            return Ok(getRoles);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RoleViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<RoleViewModel>> GetByIdAsync(int id)
        {
            var vm = new RoleViewModel
            {
                UpdateModel = await Mediator.Send(new GetRoleDetailsQuery { Id = id })
            };
            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RoleCreateModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<RoleCreateModel>> CreateAsync(CreateRoleCommand model)
        {
            if (ModelState.IsValid)
            {
                var createRole = await Mediator.Send(model);
                return Ok(createRole);
            }
            return BadRequest(model);
        }

        [HttpPut]
        [ProducesResponseType(typeof(RoleUpdateModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<RoleUpdateModel>> UpdateAsync(UpdateRoleCommand model)
        {
            if (ModelState.IsValid)
            {
                var updateRole = await Mediator.Send(model);
                return Ok(updateRole);
            }
            return BadRequest(model);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            var deleteRole = await Mediator.Send(new DeleteRoleCommand { Id = id });
            return Ok(deleteRole);
        }
    }
}
