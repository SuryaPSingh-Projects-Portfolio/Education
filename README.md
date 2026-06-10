# Education

> **QuizMaster** — interactive browser quizzes with timer, scoring, and explanations.  
> **OnlineTestAI** — work in progress (API scaffold + Blazor shell).

## Featured: QuizMaster

Interactive quiz app for C#, SQL, Python, Docker, AI, JavaScript, Git, and more.

- **25+ curated MCQs per topic** — works offline from a local question bank
- **Custom topics** — AI-generated questions when the bank has no match
- **Timer, scoring, and explanations** — review answers after each run
- **No build step** — static HTML, CSS, and JavaScript

### Quick start

```bash
cd QuizMaster
npx --yes serve .
```

Open the URL shown (e.g. `http://localhost:3000`). Full usage and topics: **[QuizMaster/README.md](QuizMaster/README.md)**.

## Work in progress: OnlineTestAI

Foundation for an online testing platform (ASP.NET Core API, EF Core, PostgreSQL, Blazor UI). Models, migrations, and Swagger are in place; controllers and test-taking UI are not finished yet.

See **[TestAI/README.md](TestAI/README.md)** for current scope and local setup if you want to explore the scaffold.

## Project structure

```
Education/
├── QuizMaster/          # Interactive quiz app (ready to run)
├── TestAI/              # OnlineTestAI — WIP
│   ├── OnlineTestAI.Api/
│   └── OnlineTestAI.Web/
├── README.md
└── LICENSE
```
