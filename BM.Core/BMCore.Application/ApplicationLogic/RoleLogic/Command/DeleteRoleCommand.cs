using BMCore.Manager.Contracts;
using BMCore.Shared.ErrorMessages;
using BMCore.Shared.Exceptions;
using MediatR;

namespace BMCore.Application.ApplicationLogic.RoleLogic.Command
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteRoleCommand, bool>
        {
            private readonly IRoleManager _roleManager;
            public Handler(IRoleManager roleManager)
            {
                _roleManager = roleManager;
            }
            public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
            {
                var isDelete = false;
                var exist = await _roleManager.GetByIdAsync(request.Id);
                if (exist is null)
                    throw new BadRequestException(ProvideErrorMessage.RoleIdNotFound);
                if (exist is not null)
                {
                    exist.IsDeleted = true;
                    exist.DeletedDateTime = DateTime.UtcNow;
                    var updatedRole = await _roleManager.UpdateAsync(exist);
                    isDelete = true;
                }
                return isDelete;
            }
        }
    }
}
