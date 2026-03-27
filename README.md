# Weather App

Weather dashboard for Moscow — current conditions, hourly and 3-day forecast.

**Stack**: ASP.NET Core (backend), React + TypeScript + Vite + Tailwind CSS (frontend)

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) 10+
- [Node.js](https://nodejs.org/) 18+
- [just](https://github.com/casey/just) command runner

## Setup

```bash
just install
```

## Run

```bash
just dev
```

Backend starts on http://localhost:5000, frontend on http://localhost:5173.

Open http://localhost:5173 in the browser.

## Available commands

```
just dev        # run backend and frontend concurrently
just backend    # backend only
just frontend   # frontend only
just install    # restore all dependencies
```
