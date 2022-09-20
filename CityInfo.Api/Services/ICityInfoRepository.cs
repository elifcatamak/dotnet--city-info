using CityInfo.Api.Entities;

namespace CityInfo.Api.Services;

public interface ICityInfoRepository
{
    Task<IEnumerable<City>> GetCitiesAsync();
    Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest);
    Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCity(int cityId);
    Task<PointOfInterest?> GetPointOfInterestForCity(int cityId, int pointOfInterestId);
}