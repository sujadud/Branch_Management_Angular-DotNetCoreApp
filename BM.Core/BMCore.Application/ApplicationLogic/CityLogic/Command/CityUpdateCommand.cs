

using AutoMapper;
using BMCore.Application.ApplicationLogic.CityLogic.Model;
using BMCore.Manager.Contracts;
using BMCore.Model.Models;
using BMCore.Shared.ErrorMessages;
using BMCore.Shared.Exceptions;
using MediatR;

namespace BMCore.Application.ApplicationLogic.CityLogic.Command
{
    public class CityUpdateCommand : CityUpdateModel, IRequest<CityUpdateModel>
    {
        public class Handler : IRequestHandler<CityUpdateCommand, CityUpdateModel>
        {
            private readonly ICityManager _cityManager;
            private readonly IMapper _mapper;
            public Handler(ICityManager cityManager, IMapper mapper)
            {
                _cityManager = cityManager;
                _mapper = mapper;
            }

            public async Task<CityUpdateModel> Handle(CityUpdateCommand request, CancellationToken cancellationToken)
            {
                var getExistCity = await _cityManager.GetByIdAsync(request.Id);

                if (getExistCity != null)
                {
                    getExistCity = _mapper.Map<CityUpdateModel, City>(request, getExistCity);
                    getExistCity.UpdatedById = Guid.NewGuid().ToString();
                    getExistCity.UpdatedDateTime = DateTime.UtcNow;
                    getExistCity = await _cityManager.UpdateAsync(getExistCity);
                }
                else
                {
                    throw new BadRequestException(ProvideErrorMessage.CityIdNotFound);
                }

                return request;
            }
        }
    }
}
