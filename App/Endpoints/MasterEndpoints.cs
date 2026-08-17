using crud_sharp.App.Models;
using crud_sharp.App.Services;

namespace crud_sharp.App.Endpoints;

public static class MasterEndpoints
{
    public static IEndpointRouteBuilder MapMasterEndpoints(this IEndpointRouteBuilder app)
    {
        var company = app.MapGroup("/api/company").WithTags("Master Company");
        company.MapGet("/", GetAllCompanies);
        company.MapGet("/{id:int}", GetCompanyById);
        company.MapPost("/", CreateCompany);
        company.MapPut("/{id:int}", UpdateCompany);
        company.MapDelete("/{id:int}", DeleteCompany);

        var dept = app.MapGroup("/api/dept").WithTags("Master Dept");
        dept.MapGet("/", GetAllDepts);
        dept.MapGet("/{id:int}", GetDeptById);
        dept.MapPost("/", CreateDept);
        dept.MapPut("/{id:int}", UpdateDept);
        dept.MapDelete("/{id:int}", DeleteDept);

        var project = app.MapGroup("/api/project").WithTags("Master Project");
        project.MapGet("/", GetAllProjects);
        project.MapGet("/{id:int}", GetProjectById);
        project.MapPost("/", CreateProject);
        project.MapPut("/{id:int}", UpdateProject);
        project.MapDelete("/{id:int}", DeleteProject);

        return app;
    }

    private static async Task<IResult> GetAllCompanies(IMasterCompanyService service) =>
        Results.Ok(await service.GetAllAsync());

    private static async Task<IResult> GetCompanyById(int id, IMasterCompanyService service)
    {
        var entity = await service.GetByIdAsync(id);
        return entity is null ? Results.NotFound() : Results.Ok(entity);
    }

    private static async Task<IResult> CreateCompany(CreateCompanyRequest request, IMasterCompanyService service)
    {
        var entity = await service.CreateAsync(request);
        return Results.Created($"/api/company/{entity.Id}", entity);
    }

    private static async Task<IResult> UpdateCompany(int id, UpdateCompanyRequest request, IMasterCompanyService service)
    {
        var entity = await service.UpdateAsync(id, request);
        return entity is null ? Results.NotFound() : Results.Ok(entity);
    }

    private static async Task<IResult> DeleteCompany(int id, IMasterCompanyService service)
    {
        var deleted = await service.DeleteAsync(id);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> GetAllDepts(IMasterDeptService service) =>
        Results.Ok(await service.GetAllAsync());

    private static async Task<IResult> GetDeptById(int id, IMasterDeptService service)
    {
        var entity = await service.GetByIdAsync(id);
        return entity is null ? Results.NotFound() : Results.Ok(entity);
    }

    private static async Task<IResult> CreateDept(CreateDeptRequest request, IMasterDeptService service)
    {
        var entity = await service.CreateAsync(request);
        return Results.Created($"/api/dept/{entity.Id}", entity);
    }

    private static async Task<IResult> UpdateDept(int id, UpdateDeptRequest request, IMasterDeptService service)
    {
        var entity = await service.UpdateAsync(id, request);
        return entity is null ? Results.NotFound() : Results.Ok(entity);
    }

    private static async Task<IResult> DeleteDept(int id, IMasterDeptService service)
    {
        var deleted = await service.DeleteAsync(id);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> GetAllProjects(IMasterProjectService service) =>
        Results.Ok(await service.GetAllAsync());

    private static async Task<IResult> GetProjectById(int id, IMasterProjectService service)
    {
        var entity = await service.GetByIdAsync(id);
        return entity is null ? Results.NotFound() : Results.Ok(entity);
    }

    private static async Task<IResult> CreateProject(CreateProjectRequest request, IMasterProjectService service)
    {
        var entity = await service.CreateAsync(request);
        return Results.Created($"/api/project/{entity.Id}", entity);
    }

    private static async Task<IResult> UpdateProject(int id, UpdateProjectRequest request, IMasterProjectService service)
    {
        var entity = await service.UpdateAsync(id, request);
        return entity is null ? Results.NotFound() : Results.Ok(entity);
    }

    private static async Task<IResult> DeleteProject(int id, IMasterProjectService service)
    {
        var deleted = await service.DeleteAsync(id);
        return deleted ? Results.NoContent() : Results.NotFound();
    }
}
