using AutoMapper;
using ExamCore.Application.ApplicationLogic.RoleLogic.Model;
using ExamCore.Manager.Contracts;
using ExamCore.Shared.ErrorMessages;
using ExamCore.Shared.Exceptions;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.RoleLogic.Command
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
