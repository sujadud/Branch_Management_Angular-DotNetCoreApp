
using BMCore.Manager.Contracts;
using BMCore.Shared.Models;
using MediatR;

namespace BMCore.Application.ApplicationLogic.CityLogic.Queries
{
    public class SelectListCityQuery : IRequest<List<SelectModel>>
    {
        public class Handler : IRequestHandler<SelectListCityQuery, List<SelectModel>>
        {
            private readonly ICityManager _cityManager;

            public Handler(ICityManager cityManager)
            {
                _cityManager = cityManager;
            }

            public async Task<List<SelectModel>> Handle(SelectListCityQuery request, CancellationToken cancellationToken)
            {
                var getCities = await _cityManager.GetAllAsync();
                var citySelectList = getCities
                                        .Select(c => new SelectModel()
                                        {
                                            Id = c.Id,
                                            Name = c.Name,
                                            ValueOne = c.Country.Name
                                        }).ToList();
                return citySelectList;
            }
        }
    }
}
