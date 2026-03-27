import type { ForecastDay } from '../types/weather';
import WeatherIcon from './WeatherIcon';

interface Props {
  days: ForecastDay[];
}

export default function DailyForecast({ days }: Props) {
  return (
    <section className="bg-slate-800/60 rounded-2xl p-5">
      <h3 className="text-sm font-medium text-slate-400 mb-3">3-Day Forecast</h3>
      <div className="flex flex-col gap-3">
        {days.map(d => {
          const date = new Date(d.date + 'T00:00:00');
          const label = date.toLocaleDateString('en-GB', { weekday: 'short', day: 'numeric', month: 'short' });
          return (
            <div
              key={d.date}
              className="grid grid-cols-[110px_48px_1fr_auto] items-center gap-3 px-4 py-3 rounded-xl bg-white/[0.04]"
            >
              <span className="text-sm">{label}</span>
              <WeatherIcon icon={d.day.condition.icon} text={d.day.condition.text} size={48} />
              <span className="text-sm text-slate-400">{d.day.condition.text}</span>
              <div className="flex gap-2 text-sm">
                <span className="font-semibold">{Math.round(d.day.maxTemp)}°</span>
                <span className="text-slate-500">{Math.round(d.day.minTemp)}°</span>
              </div>
            </div>
          );
        })}
      </div>
    </section>
  );
}
