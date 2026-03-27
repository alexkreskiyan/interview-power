interface Props {
  message: string;
  onRetry: () => void;
}

export default function Error({ message, onRetry }: Props) {
  return (
    <div className="flex flex-col items-center justify-center min-h-screen gap-4">
      <p className="text-red-400 text-lg">{message}</p>
      <button
        onClick={onRetry}
        className="px-7 py-2.5 bg-indigo-600 text-white rounded-lg hover:bg-indigo-700 transition-colors cursor-pointer"
      >
        Retry
      </button>
    </div>
  );
}
