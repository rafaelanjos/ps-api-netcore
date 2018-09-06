using CityInfo.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        bool CityExists(int cityId);
        IEnumerable<City> GetCities();
        City GetCity(int cityId, bool includePointsOfInterest);

        Task<City> GetCityAsync(int cityId, bool includePointsOfInterest);
        Task<IEnumerable<City>> GetCitiesAsync();

        IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId);
        PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);
        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
        bool Save();
    }
}
