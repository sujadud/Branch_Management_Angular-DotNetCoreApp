using AutoMapper;
using BMCore.Application.ApplicationLogic.RoleLogic.Model;
using BMCore.Manager.Contracts;
using BMCore.Model.Models;
using MediatR;

namespace BMCore.Application.ApplicationLogic.RoleLogic.Command
{
    public class CreateRoleCommand : RoleCreateModel, IRequest<RoleCreateModel>
    {
        public class Handler : IRequestHandler<CreateRoleCommand, RoleCreateModel>
        {
            private readonly IRoleManager _roleManager;
            private readonly IMapper _mapper;

            public Handler(IRoleManager roleManager, IMapper mapper)
            {
                _roleManager = roleManager;
                _mapper = mapper;
            }

            public async Task<RoleCreateModel> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
            {
                var createdRole = _mapper.Map<Role>(request);
                createdRole.CreatedById = Guid.NewGuid().ToString();
                createdRole.CreatedDateTime = DateTime.UtcNow;
                createdRole = await _roleManager.CreateAsync(createdRole);
                return request;
            }
        }
    }
}
