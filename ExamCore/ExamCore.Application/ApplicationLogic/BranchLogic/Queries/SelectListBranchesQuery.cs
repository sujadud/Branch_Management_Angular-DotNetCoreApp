using ExamCore.Manager.Contracts;
using ExamCore.Shared.Models;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.BranchLogic.Queries
{
    public class SelectListBranchesQuery : IRequest<List<SelectModel>>
    {
        public class Handler : IRequestHandler<SelectListBranchesQuery, List<SelectModel>>
        {
            private readonly IBranchManager _branchManager;
            public Handler(IBranchManager branchManager)
            {
                _branchManager = branchManager;
            }
            public async Task<List<SelectModel>> Handle(SelectListBranchesQuery request, CancellationToken cancellationToken)
            {
                var getBranches = await _branchManager.GetAllAsync();
                var branchSelectList = getBranches
                    .Select(b => new SelectModel()
                    {
                        Id = b.Id,
                        Name = b.Name
                    }).ToList();
                return branchSelectList;
            }
        }
    }
}
