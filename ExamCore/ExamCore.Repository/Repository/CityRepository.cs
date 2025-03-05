using ExamCore.Model.Models;
using ExamCore.Repository.Base;
using ExamCore.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ExamCore.Repository.Repository
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
