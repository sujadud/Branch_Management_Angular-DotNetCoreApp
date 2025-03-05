
using ExamCore.Manager.Base;
using ExamCore.Manager.Contracts;
using ExamCore.Model.Models;
using ExamCore.Repository.Contracts;

namespace ExamCore.Manager.Manager
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
