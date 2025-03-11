using ExamCore.Manager.Contracts;
using ExamCore.Shared.Models;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.RoleLogic.Queries
{
    public class SelectListRoleQuery : IRequest<List<SelectModel>>
    {
        public class Handler : IRequestHandler<SelectListRoleQuery, List<SelectModel>>
        {
            private readonly IRoleManager _roleManager;
            public Handler(IRoleManager roleManager)
            {
                _roleManager = roleManager;
            }
            public async Task<List<SelectModel>> Handle(SelectListRoleQuery request, CancellationToken cancellationToken)
            {
                var getRoles = await _roleManager.GetAllAsync();
                var roleSelectList = getRoles
                    .Select(r => new SelectModel()
                    {
                        Id = r.Id,
                        Name = r.Name
                    }).ToList();
                return roleSelectList;
            }
        }
    }
}
