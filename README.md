# Education

Learning and assessment applications.

## Projects

| Project | Description | Tech stack | Details |
|---------|-------------|------------|---------|
| **[QuizMaster](QuizMaster/)** | Interactive browser quizzes (C#, SQL, Python, Docker, AI, …) with timer, scoring, and explanations | HTML, CSS, JavaScript | [QuizMaster/README.md](QuizMaster/README.md) |
| **[OnlineTestAI](TestAI/)** | Online testing platform API and Blazor web UI | ASP.NET Core 9, EF Core, PostgreSQL, Swagger | [TestAI/OnlineTestAI.sln](TestAI/OnlineTestAI.sln) |

## Local configuration

For **OnlineTestAI**, set your PostgreSQL connection string in `TestAI/OnlineTestAI.Api/appsettings.json` or a local `appsettings.Development.json` (gitignored). Do not commit real passwords.

**QuizMaster** runs as static files — use `npx serve .` from the `QuizMaster` folder (see project README).
