using Microsoft.AspNetCore.Mvc;
using WeatherApp.Server.Services;

namespace WeatherApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly WeatherApiService _weather;

    public WeatherController(WeatherApiService weather)
    {
        _weather = weather;
    }

    [HttpGet("current")]
    public async Task<IActionResult> GetCurrent()
    {
        try
        {
            var result = await _weather.GetCurrentAsync();
            return Ok(result);
        }
        catch (HttpRequestException)
        {
            return StatusCode(502, new { error = "Weather API is unavailable" });
        }
    }

    [HttpGet("forecast")]
    public async Task<IActionResult> GetForecast()
    {
        try
        {
            var result = await _weather.GetForecastAsync();
            return Ok(result);
        }
        catch (HttpRequestException)
        {
            return StatusCode(502, new { error = "Weather API is unavailable" });
        }
    }
}
