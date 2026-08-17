# CRUD Sharp (`crud_sharp`)

`crud_sharp` is a clean, modern, and high-performance Web API built using **.NET 10**. It features a multi-database setup using PostgreSQL and Entity Framework Core, handles master data CRUD operations, exports data to Excel (`ClosedXML`) and PDF (`QuestPDF`), and includes interactive API documentation powered by Scalar.

---

## 🚀 Key Features

*   **.NET 10 & Minimal APIs**: Implements lightweight and high-performance endpoints.
*   **Multi-Database Architecture**:
    *   `IssDbContext`: Manages employee data (using the `Iss` database connection).
    *   `PortalDbContext`: Manages master data like companies, departments, and projects (using the `Portal` database connection).
*   **PostgreSQL with EF Core**: Uses `Npgsql.EntityFrameworkCore.PostgreSQL` for ORM database operations.
*   **Advanced PDF Generation (`QuestPDF`)**:
    *   Generates multi-page PDF documents.
    *   Custom layout with logos, multi-level headers, page-spanning tables, and dynamic header/footer page numbers (e.g., `Page X of Y`).
*   **Excel Export (`ClosedXML`)**: Fast and native Excel generation for employee lists.
*   **Scalar Interactive UI**: Rich and interactive API documentation instead of the classic Swagger UI.

---

## 🛠️ Technology Stack

*   **Runtime**: .NET 10.0
*   **Database Provider**: Npgsql Entity Framework Core PostgreSQL (v10.0.3)
*   **PDF Engine**: QuestPDF (v2026.7.3)
*   **Excel Writer**: ClosedXML (v0.105.1)
*   **API Docs Engine**: Scalar (v2.16.19)

---

## 📁 Project Structure

```text
crud_sharp/
├── App/
│   ├── Config/
│   │   └── ServiceCollectionExtensions.cs    # Database and Service registrations
│   ├── Data/
│   │   ├── IssDbContext.cs                   # DbContext for Employee
│   │   ├── PortalDbContext.cs                # DbContext for Master Data
│   │   └── Migrations/                       # Database Migration files
│   │       ├── Iss/                          # Iss database migrations
│   │       └── Portal/                       # Portal database migrations
│   ├── Endpoints/
│   │   ├── EmployeeEndpoints.cs              # Employee CRUD & Export API routes
│   │   ├── MasterEndpoints.cs                # Master Data CRUD routes
│   │   └── ReportEndpoints.cs                # PDF Report generation routes
│   ├── Models/
│   │   ├── Employee.cs                       # Employee entity & validation
│   │   ├── MasterCompany.cs                  # Company entity
│   │   ├── MasterDept.cs                     # Department entity
│   │   ├── MasterProject.cs                  # Project entity
│   │   └── Dtos.cs                           # Request & Response DTOs
│   └── Services/
│       ├── EmployeeService.cs                # Employee CRUD business logic
│       ├── EmployeeExportService.cs          # Excel & PDF generation service
│       └── SampleReportService.cs            # Complex QuestPDF sample report generator
├── Program.cs                                # Main entry point
├── appsettings.json                          # Main configuration and connection strings
├── appsettings.Development.json              # Development-specific settings
└── crud_sharp.csproj                         # Project dependencies and properties
```

---

## ⚙️ Configuration & Database Setup

The application connects to two PostgreSQL databases. Configure the connection strings in [`appsettings.json`](file:///C:/Users/LENOVO/Documents/crud_sharp/appsettings.json):

```json
"ConnectionStrings": {
  "Iss": "Host=localhost;Port=5432;Database=iss;Username=postgres;Password=YOUR_PASSWORD",
  "Portal": "Host=localhost;Port=5432;Database=portal;Username=postgres;Password=YOUR_PASSWORD"
}
```

### Running Database Migrations

Ensure the global Entity Framework Core CLI tool (`dotnet-ef`) is installed.

To apply migrations to your databases:

1.  **Apply Employee database migrations** (`iss` database):
    ```bash
    dotnet ef database update --context IssDbContext
    ```

2.  **Apply Master Data database migrations** (`portal` database):
    ```bash
    dotnet ef database update --context PortalDbContext
    ```

If you modify the models in [`App/Models`](file:///C:/Users/LENOVO/Documents/crud_sharp/App/Models), you can create new migrations:

*   **For Employee changes**:
    ```bash
    dotnet ef migrations add <MigrationName> --context IssDbContext --output-dir App/Data/Migrations/Iss
    ```
*   **For Master Data changes**:
    ```bash
    dotnet ef migrations add <MigrationName> --context PortalDbContext --output-dir App/Data/Migrations/Portal
    ```

---

## 🛣️ API Endpoints Summary

### 👤 Employee Endpoints (`/api/employee`)
*   `GET /api/employee` - Get paginated list of employees with search filters.
*   `GET /api/employee/{id}` - Get a single employee by ID.
*   `POST /api/employee` - Add a new employee.
*   `PUT /api/employee/{id}` - Update employee details.
*   `DELETE /api/employee/{id}` - Delete employee.
*   `GET /api/employee/export/excel` - Export employees to Excel (`.xlsx`).
*   `GET /api/employee/export/pdf` - Export employees to a simple PDF table.

### 🏢 Master Data Endpoints
*   **Company (`/api/company`)**: CRUD endpoints for companies.
*   **Department (`/api/dept`)**: CRUD endpoints for departments.
*   **Project (`/api/project`)**: CRUD endpoints for projects.

### 📄 Report Endpoints (`/api/report`)
*   `GET /api/report/sample/pdf` - Generates a highly detailed QuestPDF radiographic test report containing structured metadata, checkboxes, and a weld map joint table.

---

## 🏃 Running the Application

1.  Clone the repository and navigate to the project directory:
    ```bash
    cd crud_sharp
    ```
2.  Restore dependencies:
    ```bash
    dotnet restore
    ```
3.  Build and run the project:
    ```bash
    dotnet run
    ```
4.  Open your browser and navigate to:
    *   **Interactive API Docs (Scalar)**: `https://localhost:<port>/scalar/v1`
    *   **OpenAPI JSON Spec**: `https://localhost:<port>/openapi/v1.json`
