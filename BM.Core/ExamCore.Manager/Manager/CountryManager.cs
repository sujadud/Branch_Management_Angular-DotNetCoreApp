using ExamCore.Manager.Base;
using ExamCore.Manager.Contracts;
using ExamCore.Model.Models;
using ExamCore.Repository.Contracts;

namespace ExamCore.Manager.Manager
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