using ExamCore.Manager.Base;
using ExamCore.Manager.Contracts;
using ExamCore.Model.Models;
using ExamCore.Repository.Contracts;

namespace ExamCore.Manager.Manager
{
    public class BranchManager : BaseManager<Branch>, IBranchManager
    {
        private readonly IBranchRepository _branchRepository;

        public BranchManager(IBranchRepository branchRepository) : base(branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<IEnumerable<Branch>> GetAllBranchesWithDetailsAsync()
        {
            return await _branchRepository.GetAllAsync();
        }
    }
}
