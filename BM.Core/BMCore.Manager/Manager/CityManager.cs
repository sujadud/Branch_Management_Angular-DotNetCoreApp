
using BMCore.Manager.Base;
using BMCore.Manager.Contracts;
using BMCore.Model.Models;
using BMCore.Repository.Contracts;

namespace BMCore.Manager.Manager
{
    public class CityManager : BaseManager<City>, ICityManager
    {
        private readonly ICityRepository _cityRepository;
        public CityManager(ICityRepository cityRepository) : base(cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public override Task<ICollection<City>> GetAllAsync()
        {
            return _cityRepository.GetAllAsync();
        }
    }
}
