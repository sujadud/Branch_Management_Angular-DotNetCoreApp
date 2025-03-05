using ExamCore.Application.ApplicationLogic.BranchLogic.Command;
using ExamCore.Application.ApplicationLogic.BranchLogic.Model;
using ExamCore.Application.ApplicationLogic.BranchLogic.Queries;
using ExamCore.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace ExamCore.Api.Controllers
{
    public class BranchController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<BranchGridModel>>> GetAllAsync()
        {
            var getAll = await Mediator.Send(new GetAllBranchesDetailsQuery());
            return Ok(getAll);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BranchViewModel>> GetByIdAsync(int id)
        {
            var bvm = new BranchViewModel
            {
                UpdateModel = await Mediator.Send(new GetBranchDetailsQuery { Id = id })
            };
            return Ok(bvm);
        }

        [HttpPost]
        public async Task<ActionResult<BranchCreateModel>> CreateAsync(CreateBranchCommand model)
        {
            if (ModelState.IsValid)
            {
                var create = await Mediator.Send(model);
                return Ok(create);
            }
            return BadRequest(model);
        }

        [HttpPut]
        public async Task<ActionResult<BranchUpdateModel>> UpdateAsync(UpdateBranchCommand model)
        {
            if (ModelState.IsValid)
            {
                var update = await Mediator.Send(model);
                return Ok(update);
            }
            return BadRequest(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            var delete = await Mediator.Send(new DeleteBranchCommand { Id = id });
            return Ok(delete);
        }
    }
}
