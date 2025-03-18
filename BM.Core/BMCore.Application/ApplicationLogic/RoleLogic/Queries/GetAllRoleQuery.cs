using AutoMapper;
using BMCore.Application.ApplicationLogic.RoleLogic.Model;
using BMCore.Manager.Contracts;
using MediatR;

namespace BMCore.Application.ApplicationLogic.RoleLogic.Queries
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
