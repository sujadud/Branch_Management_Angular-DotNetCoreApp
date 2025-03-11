using AutoMapper;
using ExamCore.Application.ApplicationLogic.CountryLogic.Model;
using ExamCore.Manager.Contracts;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.CountryLogic.Queries
{
    public class GetAllCountryQuery : IRequest<ICollection<CountryGridModel>>
    {
        public class Handler : IRequestHandler<GetAllCountryQuery, ICollection<CountryGridModel>>
        {
            private readonly ICountryManager _countryManager;
            private readonly IMapper _mapper;

            public Handler(ICountryManager countryManager, IMapper mapper)
            {
                _countryManager = countryManager;
                _mapper = mapper;
            }

            public async Task<ICollection<CountryGridModel>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
            {
                var getCountries = await _countryManager.GetAllAsync();
                var mapGetCountries = _mapper.Map<ICollection<CountryGridModel>>(getCountries);

                return mapGetCountries;
            }
        }
    }
}