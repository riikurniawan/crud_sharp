using crud_sharp.App.Models;
using crud_sharp.App.Services;

namespace crud_sharp.App.Endpoints;

public static class EmployeeEndpoints
{
    public static IEndpointRouteBuilder MapEmployeeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/employee").WithTags("Employee");

        group.MapGet("/", GetAll);
        group.MapGet("/export/excel", ExportExcel);
        group.MapGet("/export/pdf", ExportPdf);
        group.MapGet("/{id:int}", GetById);
        group.MapPost("/", Create);
        group.MapPut("/{id:int}", Update);
        group.MapDelete("/{id:int}", Delete);

        return app;
    }

    private static async Task<IResult> GetAll(
        IEmployeeService service,
        int page = 1,
        int pageSize = 50,
        string? search = null)
    {
        var result = await service.GetAllAsync(page, pageSize, search);
        return Results.Ok(result);
    }

    private static async Task<IResult> GetById(int id, IEmployeeService service)
    {
        var employee = await service.GetByIdAsync(id);
        return employee is null ? Results.NotFound() : Results.Ok(employee);
    }

    private static async Task<IResult> ExportExcel(
        IEmployeeService service,
        string? search,
        int limit = 10000)
    {
        var employees = await service.GetForExportAsync(search, limit);
        var bytes = EmployeeExportService.BuildExcel(employees);
        return Results.File(bytes, EmployeeExportService.ExcelContentType, "employees.xlsx");
    }

    private static async Task<IResult> ExportPdf(
        IEmployeeService service,
        string? search,
        int limit = 500)
    {
        var employees = await service.GetForExportAsync(search, limit);
        var bytes = EmployeeExportService.BuildPdf(employees);
        return Results.File(bytes, "application/pdf", "employee-report.pdf");
    }

    private static async Task<IResult> Create(CreateEmployeeRequest request, IEmployeeService service)
    {
        var employee = await service.CreateAsync(request);
        return Results.Created($"/api/employee/{employee.Id}", employee);
    }

    private static async Task<IResult> Update(int id, UpdateEmployeeRequest request, IEmployeeService service)
    {
        var employee = await service.UpdateAsync(id, request);
        return employee is null ? Results.NotFound() : Results.Ok(employee);
    }

    private static async Task<IResult> Delete(int id, string? deletedBy, IEmployeeService service)
    {
        var deleted = await service.DeleteAsync(id, deletedBy);
        return deleted ? Results.NoContent() : Results.NotFound();
    }
}
