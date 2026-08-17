using crud_sharp.App.Data;
using crud_sharp.App.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_sharp.App.Services;

public interface IEmployeeService
{
    Task<PagedResult<EmployeeResponse>> GetAllAsync(int page, int pageSize, string? search);
    Task<EmployeeResponse?> GetByIdAsync(int id);
    Task<EmployeeResponse> CreateAsync(CreateEmployeeRequest request);
    Task<EmployeeResponse?> UpdateAsync(int id, UpdateEmployeeRequest request);
    Task<bool> DeleteAsync(int id, string? deletedBy = null);
    Task<List<EmployeeResponse>> GetForExportAsync(string? search, int limit);
}

public class EmployeeService(IssDbContext db, PortalDbContext portalDb) : IEmployeeService
{
    public async Task<PagedResult<EmployeeResponse>> GetAllAsync(int page, int pageSize, string? search)
    {
        var query = db.Employees.Where(e => e.DeletedDate == null);

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(e =>
                (e.Name != null && e.Name.Contains(search)) ||
                (e.BadgeNo != null && e.BadgeNo.Contains(search)));
        }

        var totalCount = await query.CountAsync();
        var employees = await query
            .OrderBy(e => e.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var items = await EnrichAsync(employees);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        return new PagedResult<EmployeeResponse>(items, totalCount, page, pageSize, totalPages);
    }

    public async Task<List<EmployeeResponse>> GetForExportAsync(string? search, int limit)
    {
        var query = db.Employees.Where(e => e.DeletedDate == null);

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(e =>
                (e.Name != null && e.Name.Contains(search)) ||
                (e.BadgeNo != null && e.BadgeNo.Contains(search)));
        }

        var employees = await query
            .OrderBy(e => e.Id)
            .Take(limit)
            .ToListAsync();

        return await EnrichAsync(employees);
    }

    public async Task<EmployeeResponse?> GetByIdAsync(int id)
    {
        var employee = await db.Employees
            .FirstOrDefaultAsync(e => e.Id == id && e.DeletedDate == null);

        return employee is null ? null : (await EnrichAsync([employee]))[0];
    }

    public async Task<EmployeeResponse> CreateAsync(CreateEmployeeRequest request)
    {
        var employee = new Employee
        {
            BadgeNo = request.BadgeNo,
            Name = request.Name,
            CompanyId = request.CompanyId,
            ProjectId = request.ProjectId,
            DeptId = request.DeptId,
            Designation = request.Designation,
            StatusActive = request.StatusActive,
            CreatedBy = request.CreatedBy,
            CreatedDate = DateTime.Now
        };

        db.Employees.Add(employee);
        await db.SaveChangesAsync();

        return (await EnrichAsync([employee]))[0];
    }

    public async Task<EmployeeResponse?> UpdateAsync(int id, UpdateEmployeeRequest request)
    {
        var employee = await db.Employees.FindAsync(id);
        if (employee is null || employee.DeletedDate is not null) return null;

        employee.BadgeNo = request.BadgeNo;
        employee.Name = request.Name;
        employee.CompanyId = request.CompanyId;
        employee.ProjectId = request.ProjectId;
        employee.DeptId = request.DeptId;
        employee.Designation = request.Designation;
        employee.StatusActive = request.StatusActive;
        employee.UpdatedBy = request.UpdatedBy;
        employee.UpdatedDate = DateTime.Now;

        await db.SaveChangesAsync();

        return (await EnrichAsync([employee]))[0];
    }

    public async Task<bool> DeleteAsync(int id, string? deletedBy = null)
    {
        var employee = await db.Employees.FindAsync(id);
        if (employee is null || employee.DeletedDate is not null) return false;

        employee.DeletedBy = deletedBy;
        employee.DeletedDate = DateTime.Now;

        await db.SaveChangesAsync();

        return true;
    }

    private async Task<List<EmployeeResponse>> EnrichAsync(List<Employee> employees)
    {
        if (employees.Count == 0) return [];

        var companyIds = employees.Where(e => e.CompanyId.HasValue).Select(e => e.CompanyId!.Value).Distinct().ToList();
        var projectIds = employees.Where(e => e.ProjectId.HasValue).Select(e => e.ProjectId!.Value).Distinct().ToList();
        var deptIds = employees.Where(e => e.DeptId.HasValue).Select(e => e.DeptId!.Value).Distinct().ToList();

        var companies = companyIds.Count > 0
            ? await portalDb.MasterCompanies.Where(c => companyIds.Contains(c.Id)).ToDictionaryAsync(c => c.Id)
            : [];

        var projects = projectIds.Count > 0
            ? await portalDb.MasterProjects.Where(p => projectIds.Contains(p.Id)).ToDictionaryAsync(p => p.Id)
            : [];

        var depts = deptIds.Count > 0
            ? await portalDb.MasterDepts.Where(d => deptIds.Contains(d.Id)).ToDictionaryAsync(d => d.Id)
            : [];

        return employees
            .Select(e => new EmployeeResponse(
                e.Id,
                e.BadgeNo,
                e.Name,
                e.CompanyId,
                e.CompanyId.HasValue && companies.TryGetValue(e.CompanyId.Value, out var company) ? company.CompanyName : null,
                e.ProjectId,
                e.ProjectId.HasValue && projects.TryGetValue(e.ProjectId.Value, out var project) ? project.ProjectCode : null,
                e.ProjectId.HasValue && projects.TryGetValue(e.ProjectId.Value, out var projectInfo) ? projectInfo.ProjectName : null,
                e.DeptId,
                e.DeptId.HasValue && depts.TryGetValue(e.DeptId.Value, out var dept) ? dept.DeptName : null,
                e.Designation,
                e.StatusActive,
                e.CreatedBy,
                e.CreatedDate,
                e.UpdatedBy,
                e.UpdatedDate))
            .ToList();
    }
}
