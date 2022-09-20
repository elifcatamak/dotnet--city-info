using CityInfo.Api.DbContexts;
using CityInfo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Api.Services;

public class CityInfoRepository : ICityInfoRepository
{
    private readonly CityInfoContext _context;

    public CityInfoRepository(CityInfoContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<City>> GetCitiesAsync()
    {
        var result = await _context.Cities.OrderBy(c => c.Name).ToListAsync();

        return result;
    }

    public async Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest)
    {
        City? result;

        if (includePointsOfInterest)
        {
            result = await _context.Cities.Include(c => c.PointsOfInterest)
                .FirstOrDefaultAsync(c => c.Id == cityId);
        }
        else
        {
            result = await _context.Cities.FirstOrDefaultAsync(c => c.Id == cityId);
        }

        return result;
    }

    public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCity(int cityId)
    {
        var result = await _context.PointsOfInterest.Where(p => p.CityId == cityId)
            .ToListAsync();

        return result;
    }

    public async Task<PointOfInterest?> GetPointOfInterestForCity(int cityId, int pointOfInterestId)
    {
        var result = await _context.PointsOfInterest.FirstOrDefaultAsync(
            p => p.CityId == cityId && p.Id == pointOfInterestId);

        return result;
    }
}