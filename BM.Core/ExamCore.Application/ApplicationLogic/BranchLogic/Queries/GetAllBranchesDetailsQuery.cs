using AutoMapper;
using ExamCore.Application.ApplicationLogic.BranchLogic.Model;
using ExamCore.Manager.Contracts;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.BranchLogic.Queries
{
    public class GetAllBranchesDetailsQuery : IRequest<IEnumerable<BranchGridModel>>
    {
        public class Handler : IRequestHandler<GetAllBranchesDetailsQuery, IEnumerable<BranchGridModel>>
        {
            private readonly IBranchManager _branchManager;
            private readonly IMapper _mapper;
            public Handler(IBranchManager branchManager, IMapper mapper)
            {
                _branchManager = branchManager;
                _mapper = mapper;
            } 
            public async Task<IEnumerable<BranchGridModel>> Handle(GetAllBranchesDetailsQuery request, CancellationToken cancellationToken)
            {
                var getAll = await _branchManager.GetAllAsync();
                var mapGetAll = _mapper.Map<IEnumerable<BranchGridModel>>(getAll);
                return mapGetAll;
            }
        }
    }
}
