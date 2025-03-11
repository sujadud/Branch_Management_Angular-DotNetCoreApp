using AutoMapper;
using ExamCore.Application.ApplicationLogic.CountryLogic.Model;
using ExamCore.Manager.Contracts;
using ExamCore.Shared.ErrorMessages;
using ExamCore.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ExamCore.Application.ApplicationLogic.CountryLogic.Command
{
    public class UpdateCountryCommand : CountryUpdateModel, IRequest<CountryUpdateModel>
    {
        public class Handler : IRequestHandler<UpdateCountryCommand, CountryUpdateModel>
        {
            private readonly ICountryManager _countryManager;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public Handler(ICountryManager countryManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _countryManager = countryManager;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<CountryUpdateModel> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
            {
                // Get exist country
                var getExistCountry = await _countryManager.GetByIdAsync(request.Id);

                if (getExistCountry is null)
                    throw new BadRequestException(ProvideErrorMessage.CountryIdNotFound);

                getExistCountry = _mapper.Map((CountryUpdateModel)request, getExistCountry);
                getExistCountry.UpdatedById = Guid.NewGuid().ToString();
                getExistCountry.UpdatedDateTime = DateTime.UtcNow;

                getExistCountry = await _countryManager.UpdateAsync(getExistCountry);
                return request;
            }
        }
    }
}