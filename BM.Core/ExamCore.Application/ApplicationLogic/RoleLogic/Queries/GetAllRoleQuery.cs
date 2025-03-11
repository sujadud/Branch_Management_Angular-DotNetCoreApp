using AutoMapper;
using ExamCore.Application.ApplicationLogic.RoleLogic.Model;
using ExamCore.Manager.Contracts;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.RoleLogic.Queries
{
    public class GetAllRoleQuery : IRequest<ICollection<RoleGridModel>>
    {
        public class Handler : IRequestHandler<GetAllRoleQuery, ICollection<RoleGridModel>>
        {
            private readonly IRoleManager _roleManager;
            private readonly IMapper _mapper;
            public Handler(IRoleManager roleManager, IMapper mapper)
            {
                _roleManager = roleManager;
                _mapper = mapper;
            }
            public async Task<ICollection<RoleGridModel>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
            {
                var getRoles = await _roleManager.GetAllAsync();
                var mapGet = _mapper.Map<ICollection<RoleGridModel>>(getRoles);
                return mapGet;
            }
        }
    }
}
