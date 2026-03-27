export interface Condition {
  text: string;
  icon: string;
}

export interface CurrentWeather {
  city: string;
  temp: number;
  feelsLike: number;
  condition: Condition;
  windKph: number;
  windDir: string;
  humidity: number;
  pressureMb: number;
  cloud: number;
  uv: number;
  isDay: boolean;
}

export interface Hour {
  time: string;
  timeEpoch: number;
  temp: number;
  condition: Condition;
  windKph: number;
  windDir: string;
  humidity: number;
  chanceOfRain: number;
  isDay: boolean;
}

export interface DayInfo {
  maxTemp: number;
  minTemp: number;
  avgTemp: number;
  maxWindKph: number;
  avgHumidity: number;
  chanceOfRain: number;
  condition: Condition;
}

export interface ForecastDay {
  date: string;
  day: DayInfo;
  hours: Hour[];
}

export interface Forecast {
  city: string;
  current: CurrentWeather;
  days: ForecastDay[];
}
