using BMCore.Model.Models;
using BMCore.Repository.Base;
using BMCore.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BMCore.Repository.Repository
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public override async Task<ICollection<City>> GetAllAsync()
        {
            var cities = await dbContext.Cities
                                        .AsNoTracking()
                                        .Include(c => c.Country)
                                        .Where(c => !c.IsDeleted)
                                        .ToListAsync();
            return cities;
        }
    }
}
