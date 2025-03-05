using AutoMapper;
using ExamCore.Application.ApplicationLogic.BranchLogic.Model;
using ExamCore.Manager.Contracts;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.BranchLogic.Queries
{
    public class GetBranchDetailsQuery : IRequest<BranchUpdateModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetBranchDetailsQuery, BranchUpdateModel>
        {
            private readonly IBranchManager _branchManager;
            private readonly IMapper _mapper;
            public Handler(IBranchManager branchManager, IMapper mapper)
            {
                _branchManager = branchManager;
                _mapper = mapper;
            }
            public async Task<BranchUpdateModel> Handle(GetBranchDetailsQuery request, CancellationToken cancellationToken)
            {
                var getExist = await _branchManager.GetByIdAsync(request.Id);
                if (getExist is null)
                    return null!;
                var mapExitBranch = _mapper.Map<BranchUpdateModel>(getExist);
                return mapExitBranch;
            }
        }
    }
}
