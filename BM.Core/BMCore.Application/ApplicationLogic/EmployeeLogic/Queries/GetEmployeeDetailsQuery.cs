using AutoMapper;
using BMCore.Application.ApplicationLogic.EmployeeLogic.Model;
using BMCore.Manager.Contracts;
using MediatR;

namespace BMCore.Application.ApplicationLogic.EmployeeLogic.Queries
{
    public class GetEmployeeDetailsQuery : IRequest<EmployeeUpdateModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeUpdateModel>
        {
            private readonly IEmployeeManager _employeeManager;
            private readonly IMapper _mapper;
            public Handler(IEmployeeManager employeeManager, IMapper mapper)
            {
                _employeeManager = employeeManager;
                _mapper = mapper;
            }

            public async Task<EmployeeUpdateModel> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
            {
                var getExist = await _employeeManager.GetByIdAsync(request.Id);
                if (getExist != null)
                {
                    return _mapper.Map<EmployeeUpdateModel>(getExist);
                }
                else
                {
                    return null!;
                }
            }
        }
    }
}
