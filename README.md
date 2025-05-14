# TaskTrackr

A simple task management application built with:

- **Frontend:** Angular 19 (standalone components), TypeScript  
- **Backend:** ASP .NET Core 7 Web API, Entity Framework Core  
- **Database:** PostgreSQL  

---

## Prerequisites

Make sure you have installed:

- [.NET 7 SDK](https://dotnet.microsoft.com/download)  
- [Node.js LTS](https://nodejs.org/) & npm  
- [PostgreSQL](https://www.postgresql.org/)  

---

## Initialization

### 1. Clone the repository

```bash
git clone https://github.com/<your-username>/TaskTrackr.git
cd TaskTrackr
```

### 2. Backend
1. Open backend/appsettings.json and set your PostgreSQL connection string:
   json:
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=TaskTrackrDb;Username=<db_user>;Password=<db_password>"
  }
}
2. Create the database and grant privileges:
   bash:
psql -U postgres -c "CREATE DATABASE \"TaskTrackrDb\";"
psql -U postgres -c "GRANT ALL PRIVILEGES ON DATABASE \"TaskTrackrDb\" TO <db_user>;"
3. Run the API:
   bash:
cd backend
dotnet restore
dotnet run

--The Web API will listen on http://localhost:5235 by default.--

### 3. Frontend
1. In a new terminal, navigate to the client folder:
   bash:
cd frontend
2. Install Dependencies:
   bash:
npm i
npm start
3.Open your browser at http://localhost:4200.
  All /api requests will be proxied to your running backend.
