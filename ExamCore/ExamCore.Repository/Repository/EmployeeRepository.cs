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
            var empList = await dbContext.Employees
                                        .AsNoTracking()
                                        .Include(e => e.BranchEmployees)
                                        .Where(c => !c.IsDeleted)
                                        .ToListAsync();
            return empList;
        }

        public override async Task<Employee> GetByIdAsync(int id)
        {
            var emp = await dbContext.Employees
                                        .Include(e => e.BranchEmployees.FirstOrDefault(e => e.EmployeeId == id))
                                        .FirstOrDefaultAsync(e => e.Id == id);
            return emp;
        }
    }
}
