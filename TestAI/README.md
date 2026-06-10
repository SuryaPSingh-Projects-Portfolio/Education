# OnlineTestAI (work in progress)

Early scaffold for an online testing platform with an ASP.NET Core API and Blazor web UI.

## Current state

| Done | Not yet |
|------|---------|
| EF Core models (tests, questions, results) | API controllers |
| Initial PostgreSQL migration | Test-taking Blazor UI |
| Swagger + CORS setup | Ollama / file-monitoring integration |

The Blazor app is still the default template. The API registers controllers but none are implemented yet.

## Tech stack (planned)

- **API:** ASP.NET Core 9, EF Core, PostgreSQL, Swagger
- **Web:** Blazor Server, MudBlazor (referenced, not wired yet)

## Local setup (optional)

1. **PostgreSQL** — create a database named `OnlineTestAI`.

2. **Connection string** — copy or edit `OnlineTestAI.Api/appsettings.json`, or add a gitignored `appsettings.Development.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=OnlineTestAI;Username=postgres;Password=your_password"
     }
   }
   ```

3. **Apply migrations:**

   ```bash
   cd OnlineTestAI.Api
   dotnet ef database update
   ```

4. **Run:**

   ```bash
   dotnet run --project OnlineTestAI.Api
   dotnet run --project OnlineTestAI.Web
   ```

API (dev): `http://localhost:5256` · Swagger at `/swagger`

## Solution

Open **[OnlineTestAI.sln](OnlineTestAI.sln)** in Visual Studio or run `dotnet build` from this folder.
