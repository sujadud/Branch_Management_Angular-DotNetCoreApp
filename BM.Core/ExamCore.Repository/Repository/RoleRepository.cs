
using ExamCore.Model.Models;
using ExamCore.Repository.Base;
using ExamCore.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ExamCore.Repository.Repository
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
