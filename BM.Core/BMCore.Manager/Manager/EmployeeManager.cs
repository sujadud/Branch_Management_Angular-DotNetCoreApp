using BMCore.Manager.Base;
using BMCore.Manager.Contracts;
using BMCore.Model.Models;
using BMCore.Repository.Contracts;

namespace BMCore.Manager.Manager
{
    public class EmployeeManager : BaseManager<Employee>, IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesWithDetailsAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }
    }
}
