using AutoMapper;
using BMCore.Application.ApplicationLogic.EmployeeLogic.Model;
using BMCore.Manager.Contracts;
using BMCore.Model.Models;
using MediatR;

namespace BMCore.Application.ApplicationLogic.EmployeeLogic.Command
{
    public class CreateEmployeeCommand : EmployeeCreateModel, IRequest<EmployeeCreateModel>
    {
        public class Handler : IRequestHandler<CreateEmployeeCommand, EmployeeCreateModel>
        {
            private readonly IEmployeeManager _employeeManager;
            private readonly IMapper _mapper;
            public Handler(IEmployeeManager employeeManager, IMapper mapper)
            {
                _employeeManager = employeeManager;
                _mapper = mapper;
            }
            public async Task<EmployeeCreateModel> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = _mapper.Map<Employee>(request);
                string createdBy = Guid.NewGuid().ToString();

                // relational data to BranchEmployee
                employee.BranchEmployees = new List<BranchEmployee>
                {
                    new BranchEmployee
                    {
                        Employee = employee,
                        BranchId = request.BranchId,
                        RoleId = request.RoleId,
                        CreatedById = createdBy,
                        CreatedDateTime = DateTime.UtcNow
                    }
                };
                employee.CreatedById = createdBy;
                employee.CreatedDateTime = DateTime.UtcNow;
                employee = await _employeeManager.CreateAsync(employee);
                return request;
            }
        }
    }
}
