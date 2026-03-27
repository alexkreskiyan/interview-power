export default function Loading() {
  return (
    <div className="flex flex-col items-center justify-center min-h-screen gap-4">
      <div className="w-12 h-12 border-4 border-white/10 border-t-indigo-500 rounded-full animate-spin" />
      <p className="text-slate-400">Loading weather data...</p>
    </div>
  );
}
