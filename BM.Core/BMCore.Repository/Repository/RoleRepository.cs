
using BMCore.Model.Models;
using BMCore.Repository.Base;
using BMCore.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BMCore.Repository.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public override async Task<ICollection<Role>> GetAllAsync()
        {
            var roles = await dbContext.Roles
                                        .AsNoTracking()
                                        .Where(r => !r.IsDeleted)
                                        .ToListAsync();
            return roles;
        }
    }
}
