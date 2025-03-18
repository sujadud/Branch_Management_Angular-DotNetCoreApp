using BMCore.Manager.Base;
using BMCore.Manager.Contracts;
using BMCore.Model.Models;
using BMCore.Repository.Contracts;

namespace BMCore.Manager.Manager
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
