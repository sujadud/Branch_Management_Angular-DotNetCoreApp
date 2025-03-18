using AutoMapper;
using BMCore.Application.ApplicationLogic.RoleLogic.Model;
using BMCore.Manager.Contracts;
using MediatR;

namespace BMCore.Application.ApplicationLogic.RoleLogic.Queries
{
    public class GetRoleDetailsQuery : IRequest<RoleUpdateModel>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<GetRoleDetailsQuery, RoleUpdateModel>
        {
            private readonly IRoleManager _roleManager;
            private readonly IMapper _mapper;
            public Handler(IRoleManager roleManager, IMapper mapper)
            {
                _roleManager = roleManager;
                _mapper = mapper;
            }
            public async Task<RoleUpdateModel> Handle(GetRoleDetailsQuery request, CancellationToken cancellationToken)
            {
                var getRole = await _roleManager.GetByIdAsync(request.Id);
                if (getRole is null)
                    return null!;
                var mapGet = _mapper.Map<RoleUpdateModel>(getRole);
                return mapGet;
            }
        }
    }
}
