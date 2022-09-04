using CityInfo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers;

[ApiController]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CityDto>> GetCities()
    {
        var result = CitiesDataStore.Current.Cities;

        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<CityDto> GetCity(int id)
    {
        var result = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}