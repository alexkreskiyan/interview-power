interface Props {
  icon: string;
  text: string;
  size?: number;
}

export default function WeatherIcon({ icon, text, size = 48 }: Props) {
  const src = icon.startsWith('//') ? `https:${icon}` : icon;
  return <img src={src} alt={text} width={size} height={size} />;
}
