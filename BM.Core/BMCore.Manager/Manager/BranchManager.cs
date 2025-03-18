using BMCore.Manager.Base;
using BMCore.Manager.Contracts;
using BMCore.Model.Models;
using BMCore.Repository.Contracts;

namespace BMCore.Manager.Manager
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
