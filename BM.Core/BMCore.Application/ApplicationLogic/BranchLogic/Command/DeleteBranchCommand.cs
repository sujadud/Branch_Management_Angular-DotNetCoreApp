using BMCore.Manager.Contracts;
using BMCore.Shared.ErrorMessages;
using BMCore.Shared.Exceptions;
using MediatR;

namespace BMCore.Application.ApplicationLogic.BranchLogic.Command
{
    public class DeleteBranchCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteBranchCommand, bool>
        {
            private readonly IBranchManager _branchManager;
            public Handler(IBranchManager branchManager)
            {
                _branchManager = branchManager;
            }
            public async Task<bool> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
            {
                var isDeleteBranch = false;
                var existBranch = await _branchManager.GetByIdAsync(request.Id);
                if (existBranch is null)
                    throw new BadRequestException(ProvideErrorMessage.BranchIdNotFound);
                if (existBranch is not null)
                {
                    existBranch.IsDeleted = true;
                    existBranch.DeletedDateTime = DateTime.UtcNow;
                    var updatedEmployee = await _branchManager.UpdateAsync(existBranch);
                    isDeleteBranch = true;
                }
                return isDeleteBranch;
            }
        }
    }
}
