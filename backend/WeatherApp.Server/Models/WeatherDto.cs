namespace WeatherApp.Server.Models;

// DTOs returned to frontend (camelCase by default in System.Text.Json)

public record CurrentWeatherDto(
    string City,
    double Temp,
    double FeelsLike,
    ConditionDto Condition,
    double WindKph,
    string WindDir,
    int Humidity,
    double PressureMb,
    int Cloud,
    double Uv,
    bool IsDay
);

public record ForecastDto(
    string City,
    CurrentWeatherDto Current,
    List<ForecastDayDto> Days
);

public record ForecastDayDto(
    string Date,
    DayInfoDto Day,
    List<HourDto> Hours
);

public record DayInfoDto(
    double MaxTemp,
    double MinTemp,
    double AvgTemp,
    double MaxWindKph,
    int AvgHumidity,
    int ChanceOfRain,
    ConditionDto Condition
);

public record HourDto(
    string Time,
    long TimeEpoch,
    double Temp,
    ConditionDto Condition,
    double WindKph,
    string WindDir,
    int Humidity,
    int ChanceOfRain,
    bool IsDay
);

public record ConditionDto(
    string Text,
    string Icon
);
