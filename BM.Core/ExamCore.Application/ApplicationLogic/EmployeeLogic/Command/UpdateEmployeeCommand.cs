using AutoMapper;
using ExamCore.Application.ApplicationLogic.EmployeeLogic.Model;
using ExamCore.Manager.Contracts;
using ExamCore.Model.Models;
using ExamCore.Shared.ErrorMessages;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ExamCore.Application.ApplicationLogic.EmployeeLogic.Command
{
    public class UpdateEmployeeCommand : EmployeeUpdateModel, IRequest<EmployeeUpdateModel>
    {
        public class Handler : IRequestHandler<UpdateEmployeeCommand, EmployeeUpdateModel>
        {
            private readonly IEmployeeManager _employeeManager;
            private readonly IMapper _mapper;
            public Handler(IEmployeeManager employeeManager, IMapper mapper)
            {
                _employeeManager = employeeManager;
                _mapper = mapper;
            }
            public async Task<EmployeeUpdateModel> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                string updatedBy = Guid.NewGuid().ToString();
                var getExistEmployee = await _employeeManager.GetByIdAsync(request.Id);
                if (getExistEmployee is null)
                    throw new BadHttpRequestException(ProvideErrorMessage.EmployeeIdNotFound);

                var branchEmp = getExistEmployee.BranchEmployees.FirstOrDefault();
                if (branchEmp is not null)
                {
                    //employee data update
                    branchEmp.Employee.Name = request.Name;
                    branchEmp.Employee.Code = request.Code;
                    branchEmp.BranchId = request.BranchId;
                    branchEmp.RoleId = request.RoleId;
                }
                else
                {
                    //employee data update
                    branchEmp.Employee.Name = request.Name;
                    branchEmp.Employee.Code = request.Code;

                    //branch employee data update
                    branchEmp.BranchId = request.BranchId;
                    branchEmp.RoleId = request.RoleId;
                }

                //getExistEmployee = _mapper.Map((EmployeeUpdateModel)request, getExistEmployee);
                getExistEmployee.UpdatedById = updatedBy;
                getExistEmployee.UpdatedDateTime = DateTime.UtcNow;
                getExistEmployee = await _employeeManager.UpdateAsync(getExistEmployee);
                return request;
            }
        }
    }
}
