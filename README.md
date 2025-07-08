# LogParking

A clean, modular .NET 8 solution following a three-tier architecture.

## Projects
- **LogParking.Api**: ASP.NET Core Web API (Presentation Layer)
- **LogParking.AppService**: Application logic and business services (Application Layer)
- **LogParking.Infrastructure**: Data access and persistence (Infrastructure Layer)
- **LogParking.Utility**: Shared utilities and extensions (Helper Layer)

## Folder Structure
- **Api**: `Controllers/`, `Extensions/`, `appsettings.Development.json`, `appsettings.QA.json`
- **AppService**: `Contracts/`, `DTOs/`, `Services/`, `Extensions/`
- **Infrastructure**: `Contracts/`, `Repositories/`, `Entities/`, `Data/`, `Extensions/`
- **Utility**: `Extensions/`

## Project References
- Infrastructure ➝ AppService
- AppService ➝ Api

## Getting Started
1. Open the solution in Visual Studio or VS Code.
2. Build the solution: `dotnet build`
3. Run the API: `dotnet run --project LogParking.Api`

---
This solution is ready for further development following best practices for modular .NET applications.
