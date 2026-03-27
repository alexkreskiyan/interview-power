import type { Forecast } from '../types/weather';

export async function fetchForecast(): Promise<Forecast> {
  const res = await fetch('/api/weather/forecast');
  if (!res.ok) {
    throw new Error(`Weather API error: ${res.status}`);
  }
  return res.json();
}
