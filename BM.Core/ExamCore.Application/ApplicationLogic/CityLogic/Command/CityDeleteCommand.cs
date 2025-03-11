
using ExamCore.Manager.Contracts;
using ExamCore.Shared.ErrorMessages;
using ExamCore.Shared.Exceptions;
using MediatR;

namespace ExamCore.Application.ApplicationLogic.CityLogic.Command
{
    public class CityDeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<CityDeleteCommand, bool>
        {
            private readonly ICityManager _cityManager;

            public Handler(ICityManager cityManager)
            {
                _cityManager = cityManager;
            }

            public async Task<bool> Handle(CityDeleteCommand request, CancellationToken cancellationToken)
            {
                var isDelete = false;
                var existCity = await _cityManager.GetByIdAsync(request.Id);

                if (existCity != null)
                {
                    existCity.IsDeleted = true;
                    existCity.DeletedDateTime = DateTime.UtcNow;
                    var updatedCity = await _cityManager.UpdateAsync(existCity);
                    isDelete = true;
                }
                else
                {
                    throw new BadRequestException(ProvideErrorMessage.CityIdNotFound);
                }

                return isDelete;
            }
        }
    }
}
