using AutoMapper;
using BMCore.Application.ApplicationLogic.RoleLogic.Model;
using BMCore.Manager.Contracts;
using BMCore.Shared.ErrorMessages;
using BMCore.Shared.Exceptions;
using MediatR;

namespace BMCore.Application.ApplicationLogic.RoleLogic.Command
{
    public class UpdateRoleCommand : RoleUpdateModel, IRequest<RoleUpdateModel>
    {
        public class Handler : IRequestHandler<UpdateRoleCommand, RoleUpdateModel>
        {
            private readonly IRoleManager _roleManager;
            private readonly IMapper _mapper;

            public Handler(IRoleManager roleManager, IMapper mapper)
            {
                _roleManager = roleManager;
                _mapper = mapper;
            }

            public async Task<RoleUpdateModel> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
            {
                var getExist = await _roleManager.GetByIdAsync(request.Id);
                if (getExist != null)
                {
                    getExist = _mapper.Map((RoleUpdateModel)request, getExist);
                    getExist.UpdatedById = Guid.NewGuid().ToString();
                    getExist.UpdatedDateTime = DateTime.UtcNow;
                    getExist = await _roleManager.UpdateAsync(getExist);
                    return request;
                }
                else
                {
                    throw new BadRequestException(ProvideErrorMessage.RoleIdNotFound);
                }
            }
        }
    }
}
