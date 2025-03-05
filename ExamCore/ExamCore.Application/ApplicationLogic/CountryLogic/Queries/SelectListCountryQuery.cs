using ExamCore.Manager.Contracts;
using ExamCore.Shared.Models;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.CountryLogic.Queries
{
    internal class SelectListCountryQuery : IRequest<List<SelectModel>>
    {
        public class Handler : IRequestHandler<SelectListCountryQuery, List<SelectModel>>
        {
            private readonly ICountryManager _countryManager;

            public Handler(ICountryManager countryManager)
            {
                _countryManager = countryManager;
            }

            public async Task<List<SelectModel>> Handle(SelectListCountryQuery request, CancellationToken cancellationToken)
            {
                var getCountries = await _countryManager.GetAllAsync();

                var countrySelectList = getCountries
                    .Select(c => new SelectModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();

                return countrySelectList;
            }
        }
    }
}