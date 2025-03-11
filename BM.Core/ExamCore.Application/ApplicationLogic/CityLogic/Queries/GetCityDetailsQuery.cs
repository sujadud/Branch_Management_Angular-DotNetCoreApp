
using AutoMapper;
using ExamCore.Application.ApplicationLogic.CityLogic.Model;
using ExamCore.Manager.Contracts;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.CityLogic.Queries
{
    public class GetCityDetailsQuery : IRequest<CityUpdateModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCityDetailsQuery, CityUpdateModel>
        {
            private readonly ICityManager _cityManager;
            private readonly IMapper _mapper;

            public Handler(ICityManager cityManager, IMapper mapper)
            {
                _cityManager = cityManager;
                _mapper = mapper;
            }

            public async Task<CityUpdateModel> Handle(GetCityDetailsQuery request, CancellationToken cancellationToken)
            {
                var getExistCity = await _cityManager.GetByIdAsync(request.Id);
                if (getExistCity is null)
                    return null!;
                var mapExitCity = _mapper.Map<CityUpdateModel>(getExistCity);
                return mapExitCity;
            }
        }
    }
}
