
using AutoMapper;
using ExamCore.Application.ApplicationLogic.CityLogic.Model;
using ExamCore.Manager.Contracts;
using ExamCore.Model.Models;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.CityLogic.Command
{
    public class CreateCityCommand : CityCreateModel, IRequest<CityCreateModel>
    {
        public class Handler : IRequestHandler<CreateCityCommand, CityCreateModel>
        {
            private readonly ICityManager _cityManager;
            private readonly IMapper _mapper;

            public Handler(ICityManager cityManager, IMapper mapper)
            {
                _cityManager = cityManager;
                _mapper = mapper;
            }

            public async Task<CityCreateModel> Handle(CreateCityCommand request, CancellationToken cancellationToken)
            {
                var createdCity = _mapper.Map<City>(request);
                createdCity.CreatedById = Guid.NewGuid().ToString();
                createdCity.CreatedDateTime = DateTime.UtcNow;

                createdCity = await _cityManager.CreateAsync(createdCity);

                return request;
            }
        }
    }
}
