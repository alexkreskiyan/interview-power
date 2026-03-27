import type { ForecastDay } from '../types/weather';
import WeatherIcon from './WeatherIcon';

interface Props {
  days: ForecastDay[];
}

export default function HourlyForecast({ days }: Props) {
  const now = Date.now() / 1000;

  const hours = [
    ...days[0].hours.filter(h => h.timeEpoch > now),
    ...(days[1]?.hours ?? []),
  ];

  return (
    <section className="bg-slate-800/60 rounded-2xl p-5">
      <h3 className="text-sm font-medium text-slate-400 mb-3">Hourly Forecast</h3>
      <div className="flex gap-2 overflow-x-auto pb-2 scrollbar-thin">
        {hours.map(h => {
          const time = new Date(h.timeEpoch * 1000);
          const label = time.toLocaleTimeString('en-GB', { hour: '2-digit', minute: '2-digit' });
          return (
            <div
              key={h.timeEpoch}
              className="flex flex-col items-center gap-1 min-w-16 py-2.5 px-1.5 rounded-xl bg-white/[0.04]"
            >
              <span className="text-xs text-slate-500">{label}</span>
              <WeatherIcon icon={h.condition.icon} text={h.condition.text} size={36} />
              <span className="text-sm font-semibold">{Math.round(h.temp)}°</span>
            </div>
          );
        })}
      </div>
    </section>
  );
}
