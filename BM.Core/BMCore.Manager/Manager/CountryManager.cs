using BMCore.Manager.Base;
using BMCore.Manager.Contracts;
using BMCore.Model.Models;
using BMCore.Repository.Contracts;

namespace BMCore.Manager.Manager
{
    public class CountryManager : BaseManager<Country>, ICountryManager
    {
        private readonly ICountryRepository _countryRepository;

        public CountryManager(ICountryRepository countryRepository) : base(countryRepository) => _countryRepository = countryRepository;

        public override async Task<ICollection<Country>> GetAllAsync()
        {
            return await _countryRepository.GetAllAsync();
        }
    }
}