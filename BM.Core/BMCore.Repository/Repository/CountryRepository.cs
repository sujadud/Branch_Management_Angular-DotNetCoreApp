using BMCore.Model.Models;
using BMCore.Repository.Base;
using BMCore.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BMCore.Repository.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public override async Task<ICollection<Country>> GetAllAsync()
        {
            var countries = await dbContext.Countries.Where(c => !c.IsDeleted).ToListAsync();
            return countries;
        }
    }
}