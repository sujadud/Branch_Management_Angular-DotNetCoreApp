
using AutoMapper;
using ExamCore.Application.ApplicationLogic.CityLogic.Model;
using ExamCore.Manager.Contracts;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.CityLogic.Queries
{
    public class GetAllCityQuery : IRequest<ICollection<CityGridModel>>
    {
        public class Handler : IRequestHandler<GetAllCityQuery, ICollection<CityGridModel>>
        {
            private readonly ICityManager _cityManager;
            private readonly IMapper _mapper;

            public Handler(ICityManager cityManager, IMapper mapper)
            {
                _cityManager = cityManager;
                _mapper = mapper;
            }

            public async Task<ICollection<CityGridModel>> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
            {
                var getAll = await _cityManager.GetAllAsync();
                var mapGetAll = _mapper.Map<ICollection<CityGridModel>>(getAll);
                return mapGetAll;
            }
        }
    }
}
