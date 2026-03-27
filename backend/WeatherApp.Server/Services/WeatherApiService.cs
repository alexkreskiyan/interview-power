using System.Net.Http;
using System.Text.Json;
using WeatherApp.Server.Models;

namespace WeatherApp.Server.Services;

public class WeatherApiService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;
    private readonly string _apiKey;
    private readonly string _location;

    public WeatherApiService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _baseUrl = config["WeatherApi:BaseUrl"]!;
        _apiKey = config["WeatherApi:ApiKey"]!;
        _location = config["WeatherApi:Location"]!;
    }

    public async Task<CurrentWeatherDto> GetCurrentAsync()
    {
        var url = $"{_baseUrl}/current.json?key={_apiKey}&q={_location}";
        var response = await _http.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var api = await response.Content.ReadFromJsonAsync<ApiCurrentResponse>()
            ?? throw new InvalidOperationException("Failed to deserialize current weather");

        return MapCurrent(api.Location, api.Current);
    }

    public async Task<ForecastDto> GetForecastAsync()
    {
        var url = $"{_baseUrl}/forecast.json?key={_apiKey}&q={_location}&days=3";
        var response = await _http.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var api = await response.Content.ReadFromJsonAsync<ApiForecastResponse>()
            ?? throw new InvalidOperationException("Failed to deserialize forecast");

        return new ForecastDto(
            City: api.Location.Name,
            Current: MapCurrent(api.Location, api.Current),
            Days: api.Forecast.ForecastDay.Select(MapDay).ToList()
        );
    }

    private static CurrentWeatherDto MapCurrent(ApiLocation loc, ApiCurrent c) => new(
        City: loc.Name,
        Temp: c.TempC,
        FeelsLike: c.FeelslikeC,
        Condition: new ConditionDto(c.Condition.Text, c.Condition.Icon),
        WindKph: c.WindKph,
        WindDir: c.WindDir,
        Humidity: c.Humidity,
        PressureMb: c.PressureMb,
        Cloud: c.Cloud,
        Uv: c.Uv,
        IsDay: c.IsDay == 1
    );

    private static ForecastDayDto MapDay(ApiForecastDay fd) => new(
        Date: fd.Date,
        Day: new DayInfoDto(
            MaxTemp: fd.Day.MaxTempC,
            MinTemp: fd.Day.MinTempC,
            AvgTemp: fd.Day.AvgTempC,
            MaxWindKph: fd.Day.MaxWindKph,
            AvgHumidity: fd.Day.AvgHumidity,
            ChanceOfRain: fd.Day.DailyChanceOfRain,
            Condition: new ConditionDto(fd.Day.Condition.Text, fd.Day.Condition.Icon)
        ),
        Hours: fd.Hour.Select(h => new HourDto(
            Time: h.Time,
            TimeEpoch: h.TimeEpoch,
            Temp: h.TempC,
            Condition: new ConditionDto(h.Condition.Text, h.Condition.Icon),
            WindKph: h.WindKph,
            WindDir: h.WindDir,
            Humidity: h.Humidity,
            ChanceOfRain: h.ChanceOfRain,
            IsDay: h.IsDay == 1
        )).ToList()
    );
}
