

using AutoMapper;
using BMCore.Application.ApplicationLogic.BranchLogic.Model;
using BMCore.Manager.Contracts;
using BMCore.Shared.ErrorMessages;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BMCore.Application.ApplicationLogic.BranchLogic.Command
{
    public class UpdateBranchCommand : BranchUpdateModel, IRequest<BranchUpdateModel>
    {
        public class Handler : IRequestHandler<UpdateBranchCommand, BranchUpdateModel>
        {
            private readonly IBranchManager _branchManager;
            private readonly IMapper _mapper;

            public Handler(IBranchManager branchManager, IMapper mapper)
            {
                _branchManager = branchManager;
                _mapper = mapper;
            }

            public async Task<BranchUpdateModel> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
            {
                var getExistBranch = await _branchManager.GetByIdAsync(request.Id);

                if (getExistBranch is null)
                    throw new BadHttpRequestException(ProvideErrorMessage.BranchIdNotFound);
                getExistBranch = _mapper.Map((BranchUpdateModel)request, getExistBranch);
                getExistBranch.UpdatedById = Guid.NewGuid().ToString();
                getExistBranch.UpdatedDateTime = DateTime.UtcNow;

                getExistBranch = await _branchManager.UpdateAsync(getExistBranch);
                return request;
            }
        }
    }
}
