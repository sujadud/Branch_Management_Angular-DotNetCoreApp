using ExamCore.Model.Models;
using ExamCore.Repository.Base;
using ExamCore.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ExamCore.Repository.Repository
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