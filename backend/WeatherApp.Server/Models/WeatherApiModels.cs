using System.Text.Json.Serialization;

namespace WeatherApp.Server.Models;

// Raw upstream API response models (internal use only)

public record ApiCurrentResponse(
    [property: JsonPropertyName("location")] ApiLocation Location,
    [property: JsonPropertyName("current")] ApiCurrent Current
);

public record ApiForecastResponse(
    [property: JsonPropertyName("location")] ApiLocation Location,
    [property: JsonPropertyName("current")] ApiCurrent Current,
    [property: JsonPropertyName("forecast")] ApiForecast Forecast
);

public record ApiLocation(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("region")] string Region,
    [property: JsonPropertyName("country")] string Country,
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lon")] double Lon,
    [property: JsonPropertyName("localtime")] string Localtime
);

public record ApiCurrent(
    [property: JsonPropertyName("temp_c")] double TempC,
    [property: JsonPropertyName("feelslike_c")] double FeelslikeC,
    [property: JsonPropertyName("condition")] ApiCondition Condition,
    [property: JsonPropertyName("wind_kph")] double WindKph,
    [property: JsonPropertyName("wind_dir")] string WindDir,
    [property: JsonPropertyName("humidity")] int Humidity,
    [property: JsonPropertyName("pressure_mb")] double PressureMb,
    [property: JsonPropertyName("cloud")] int Cloud,
    [property: JsonPropertyName("uv")] double Uv,
    [property: JsonPropertyName("is_day")] int IsDay
);

public record ApiCondition(
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("icon")] string Icon,
    [property: JsonPropertyName("code")] int Code
);

public record ApiForecast(
    [property: JsonPropertyName("forecastday")] List<ApiForecastDay> ForecastDay
);

public record ApiForecastDay(
    [property: JsonPropertyName("date")] string Date,
    [property: JsonPropertyName("day")] ApiDay Day,
    [property: JsonPropertyName("hour")] List<ApiHour> Hour
);

public record ApiDay(
    [property: JsonPropertyName("maxtemp_c")] double MaxTempC,
    [property: JsonPropertyName("mintemp_c")] double MinTempC,
    [property: JsonPropertyName("avgtemp_c")] double AvgTempC,
    [property: JsonPropertyName("maxwind_kph")] double MaxWindKph,
    [property: JsonPropertyName("avghumidity")] int AvgHumidity,
    [property: JsonPropertyName("daily_chance_of_rain")] int DailyChanceOfRain,
    [property: JsonPropertyName("condition")] ApiCondition Condition
);

public record ApiHour(
    [property: JsonPropertyName("time")] string Time,
    [property: JsonPropertyName("time_epoch")] long TimeEpoch,
    [property: JsonPropertyName("temp_c")] double TempC,
    [property: JsonPropertyName("condition")] ApiCondition Condition,
    [property: JsonPropertyName("wind_kph")] double WindKph,
    [property: JsonPropertyName("wind_dir")] string WindDir,
    [property: JsonPropertyName("humidity")] int Humidity,
    [property: JsonPropertyName("chance_of_rain")] int ChanceOfRain,
    [property: JsonPropertyName("is_day")] int IsDay
);
