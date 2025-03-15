using ExamCore.Manager.Contracts;
using ExamCore.Shared.ErrorMessages;
using ExamCore.Shared.Exceptions;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.EmployeeLogic.Command
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteEmployeeCommand, bool>
        {
            private readonly IEmployeeManager _employeeManager;
            public Handler(IEmployeeManager employeeManager)
            {
                _employeeManager = employeeManager;
            }
            public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var isDeleteEmployee = false;
                var existEmployee = await _employeeManager.GetByIdAsync(request.Id);
                if (existEmployee is null)
                    throw new BadRequestException(ProvideErrorMessage.EmployeeIdNotFound);
                if (existEmployee is not null)
                {
                    existEmployee.IsDeleted = true;
                    existEmployee.DeletedDateTime = DateTime.UtcNow;
                    var updatedEmployee = await _employeeManager.UpdateAsync(existEmployee);
                    isDeleteEmployee = true;
                }
                return isDeleteEmployee;
            }
        }
    }
}
