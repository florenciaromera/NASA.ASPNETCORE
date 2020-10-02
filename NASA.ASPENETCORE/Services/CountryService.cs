using Microsoft.EntityFrameworkCore;
using NASA.Entities;
using NASA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASA.Services
{
    public class CountryService
    {
        // los repos que sean private o protected xq sino expongo el repo
        private readonly NASAContext _repo;

        public CountryService(NASAContext repo)
        {
            this._repo = repo;
        }

        public async Task<bool> CreateNewCountryAsync(Country country)
        {
            await _repo.AddAsync(country);
            int result = await _repo.SaveChangesAsync();
            return (result > 0);
        }

        public async Task<Country> CreateNewCountryAsync(int countryCode, string name)
        {
            Country country = new Country
            {
                CountryCode = countryCode,
                Name = name
            };

            bool countryCreated = await CreateNewCountryAsync(country);
            return (countryCreated) ? country : null;
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            return await _repo.Countries.Include(e => e.Temperatures).ToListAsync();
        }

        public async Task<Country> FindByIdAsync(int id, bool fullObject = false)
        {
            if (fullObject)
                return await _repo.Countries.Include(e => e.Temperatures).Where(e => e.CountryCode == id).FirstOrDefaultAsync();
            else
                return await _repo.Countries.FindAsync(id);
        }

        public async Task<Country> UpdateCountryAsync(Country country)
        {
            _repo.Entry(country).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            int result = await _repo.SaveChangesAsync();
            return (result > 0) ? country : null;
        }
    }
}
