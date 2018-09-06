using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private readonly ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _cityInfoRepository.GetCitiesAsync();

            var result = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cities);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);

            if (city == null)
                return NotFound();

            if (includePointsOfInterest)
            {
                var cityResult = Mapper.Map<CityDto>(city);
                return Ok(cityResult);
            }

            var cityWithoutPointsOfInterestResult = Mapper.Map<CityWithoutPointsOfInterestDto>(city);
            return Ok(cityWithoutPointsOfInterestResult);
        }

    }
}
