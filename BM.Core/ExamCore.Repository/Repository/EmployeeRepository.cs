using ExamCore.Model.Models;
using ExamCore.Repository.Base;
using ExamCore.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ExamCore.Repository.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public override async Task<ICollection<Employee>> GetAllAsync()
        {   
            return await dbContext.Employees
                                    .AsNoTracking()
                                    .Include(be => be.BranchEmployees)
                                        .ThenInclude(b => b.Branch)
                                    .Include(e => e.BranchEmployees)
                                        .ThenInclude(r => r.Role)
                                    .Where(c => !c.IsDeleted)
                                    .ToListAsync();
        }

        public override async Task<Employee> GetByIdAsync(int id)
        {
            return await dbContext.Employees
                                        .Include(be => be.BranchEmployees)
                                        //    .ThenInclude(b => b.Branch)
                                        //.Include(be => be.BranchEmployees)
                                        //    .ThenInclude(r => r.Role)
                                        .FirstOrDefaultAsync(e => e.Id == id);            
        }
    }
}
