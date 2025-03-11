using AutoMapper;
using ExamCore.Application.ApplicationLogic.CountryLogic.Model;
using ExamCore.Manager.Contracts;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.CountryLogic.Queries
{
    public class GetCountryDetailsQuery : IRequest<CountryUpdateModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetCountryDetailsQuery, CountryUpdateModel>
        {
            private readonly ICountryManager _countryManager;
            private readonly IMapper _mapper;

            public Handler(ICountryManager countryManager, IMapper mapper)
            {
                _countryManager = countryManager;
                _mapper = mapper;
            }

            public async Task<CountryUpdateModel> Handle(GetCountryDetailsQuery request, CancellationToken cancellationToken)
            {
                var getExistCountry = await _countryManager.GetByIdAsync(request.Id);

                if (getExistCountry is null)
                    return null!;

                var mapExitCountry = _mapper.Map<CountryUpdateModel>(getExistCountry);

                return mapExitCountry;
            }
        }
    }
}