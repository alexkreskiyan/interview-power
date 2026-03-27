[private]
default:
    @just --list

# Run both backend and frontend concurrently
dev:
    just backend & just frontend & wait

# Backend only (ASP.NET Core on port 5000)
backend:
    cd backend && dotnet run --project WeatherApp.Server

# Frontend only (Vite dev server on port 5173)
frontend:
    cd frontend && npm run dev

# Install/restore all dependencies
install:
    cd backend && dotnet restore
    cd frontend && npm install
