import type { CurrentWeather as CurrentWeatherData } from '../types/weather';
import WeatherIcon from './WeatherIcon';

interface Props {
  data: CurrentWeatherData;
}

export default function CurrentWeather({ data }: Props) {
  return (
    <section className="bg-gradient-to-br from-slate-800 to-blue-950 rounded-2xl p-6">
      <h2 className="text-lg font-medium text-slate-400 mb-4">{data.city}</h2>
      <div className="flex items-center gap-4 mb-5">
        <WeatherIcon icon={data.condition.icon} text={data.condition.text} size={96} />
        <div className="flex flex-col">
          <span className="text-6xl font-bold leading-none">{Math.round(data.temp)}°C</span>
          <span className="text-lg text-slate-400 mt-1">{data.condition.text}</span>
        </div>
      </div>
      <div className="grid grid-cols-3 max-sm:grid-cols-2 gap-3">
        <Detail label="Feels like" value={`${Math.round(data.feelsLike)}°C`} />
        <Detail label="Wind" value={`${data.windKph} km/h ${data.windDir}`} />
        <Detail label="Humidity" value={`${data.humidity}%`} />
        <Detail label="Pressure" value={`${data.pressureMb} mb`} />
        <Detail label="Cloud" value={`${data.cloud}%`} />
        <Detail label="UV" value={`${data.uv}`} />
      </div>
    </section>
  );
}

function Detail({ label, value }: { label: string; value: string }) {
  return (
    <div className="flex flex-col gap-0.5">
      <span className="text-xs text-slate-500 uppercase tracking-wide">{label}</span>
      <span className="text-sm">{value}</span>
    </div>
  );
}
