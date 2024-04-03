using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using CountryInterfaceSPA.Server.Models;

namespace CountryInterfaceSPA.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        //   private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<CountryController> _logger;
        private readonly IMemoryCache _cache;
        public CountryController(ILogger<CountryController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var client = new HttpClient();
            var cacheKey = "countryList";
            if (!_cache.TryGetValue(cacheKey, out List<Country> countryList))
            {
                var response = await client.GetAsync("https://restcountries.com/v3.1/all");
                if (response.IsSuccessStatusCode)
                {
                    var countries = await response.Content.ReadAsStringAsync();
                    if (countries != null)
                    {
                        countryList = JsonSerializer.Deserialize<List<Country>>(countries);
                        var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)); // Cache for 1 hour
                        _cache.Set(cacheKey, countryList, cacheEntryOptions);
                    }
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            return Ok(countryList);
        }

                // Get country by name
                [HttpGet("{name}")]
        public async Task<IActionResult> GetCountryByName(string name)
        {
            var client = new HttpClient();
            var cacheKey = $"country_{name}";
            if (!_cache.TryGetValue(cacheKey, out List<Country> country))
            {
                var response = await client.GetAsync($"https://restcountries.com/v3.1/name/{name}");
                if (response.IsSuccessStatusCode)
                {
                    var countryJson = await response.Content.ReadAsStringAsync();
                    if (countryJson != null)
                    {
                        country = JsonSerializer.Deserialize<List<Country>>(countryJson);
                        var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)); // Cache for 1 hour
                        _cache.Set(cacheKey, country, cacheEntryOptions);
                    }
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            return Ok(country);
        }
    }
}
