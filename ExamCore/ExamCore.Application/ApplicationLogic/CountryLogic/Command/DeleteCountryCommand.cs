using ExamCore.Manager.Contracts;
using ExamCore.Shared.ErrorMessages;
using ExamCore.Shared.Exceptions;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.CountryLogic.Command
{
    public class DeleteCountryCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteCountryCommand, bool>
        {
            private readonly ICountryManager _countryManager;

            public Handler(ICountryManager countryManager)
            {
                _countryManager = countryManager;
            }

            public async Task<bool> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
            {
                var isDeleteCountry = false;
                var existCountry = await _countryManager.GetByIdAsync(request.Id);

                if (existCountry is null)
                    throw new BadRequestException(ProvideErrorMessage.CountryIdNotFound);

                if (existCountry is not null)
                {
                    existCountry.IsDeleted = true;
                    existCountry.DeletedDateTime = DateTime.UtcNow;

                    var updatedEmployee = await _countryManager.UpdateAsync(existCountry);
                    isDeleteCountry = true;
                }

                return isDeleteCountry;
            }
        }
    }
}