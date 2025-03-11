using ExamCore.Model.Models;
using ExamCore.Repository.Base;
using ExamCore.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ExamCore.Repository.Repository
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public override async Task<ICollection<Branch>> GetAllAsync()
        {
            var branches = await dbContext.Branches
                                        .AsNoTracking()
                                        .Include(b => b.City)
                                        .Where(b => !b.IsDeleted)
                                        .ToListAsync();
            return branches;
        }

        public override async Task<Branch> GetByIdAsync(int id)
        {
            var branch = await dbContext.Branches
                                        .AsNoTracking()
                                        .Include(b => b.City)
                                        .FirstOrDefaultAsync(b => b.Id == id);
            return branch;
        }
    }
}
