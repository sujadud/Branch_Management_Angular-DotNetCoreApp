using ExamCore.Manager.Base;
using ExamCore.Manager.Contracts;
using ExamCore.Model.Models;
using ExamCore.Repository.Contracts;

namespace ExamCore.Manager.Manager
{
    public class RoleManager : BaseManager<Role>, IRoleManager
    {
        private readonly IRoleRepository _roleRepository;

        public RoleManager(IRoleRepository roleRepository) : base(roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public override async Task<ICollection<Role>> GetAllAsync()
        {
            return await _roleRepository.GetAllAsync();
        }
    }
}
