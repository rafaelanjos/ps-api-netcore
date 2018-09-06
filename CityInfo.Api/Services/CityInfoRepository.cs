using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }

        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(o => o.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            var citiesQuery = _context.Cities.AsQueryable();
            if (includePointsOfInterest)
                citiesQuery = citiesQuery.Include(i => i.PointsOfInterest);

            return citiesQuery.Where(c => c.Id == cityId).FirstOrDefault();
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointsOfInterest.Where(x => x.CityId == cityId && x.Id == pointOfInterestId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointsOfInterest.Where(x => x.CityId == cityId).ToList();
        }

        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId, false);
            city.PointsOfInterest.Add(pointOfInterest);
        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<City> GetCityAsync(int cityId, bool includePointsOfInterest)
        {
            var citiesQuery = _context.Cities.AsQueryable();
            if (includePointsOfInterest)
                citiesQuery = citiesQuery.Include(i => i.PointsOfInterest);

            return await citiesQuery.Where(c => c.Id == cityId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(o => o.Name).ToListAsync();
        }

    }
}
