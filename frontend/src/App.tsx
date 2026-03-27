import { useCallback, useEffect, useState } from 'react';
import { fetchForecast } from './api/weather';
import type { Forecast } from './types/weather';
import CurrentWeather from './components/CurrentWeather';
import HourlyForecast from './components/HourlyForecast';
import DailyForecast from './components/DailyForecast';
import Loading from './components/Loading';
import ErrorView from './components/Error';
import './App.css';

export default function App() {
  const [data, setData] = useState<Forecast | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const load = useCallback(async () => {
    setLoading(true);
    setError(null);
    try {
      const forecast = await fetchForecast();
      setData(forecast);
    } catch (e) {
      setError(e instanceof globalThis.Error ? e.message : 'Failed to load weather data');
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => { load(); }, [load]);

  if (loading) return <Loading />;
  if (error || !data) return <ErrorView message={error ?? 'Unknown error'} onRetry={load} />;

  return (
    <div className="max-w-3xl mx-auto px-4 py-6 flex flex-col gap-6">
      <CurrentWeather data={data.current} />
      <HourlyForecast days={data.days} />
      <DailyForecast days={data.days} />
    </div>
  );
}
