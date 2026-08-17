namespace crud_sharp.App.Models;

public record PagedResult<T>(
    List<T> Items,
    int TotalCount,
    int Page,
    int PageSize,
    int TotalPages);

public record EmployeeResponse(
    int Id,
    string? BadgeNo,
    string? Name,
    int? CompanyId,
    string? CompanyName,
    int? ProjectId,
    string? ProjectCode,
    string? ProjectName,
    int? DeptId,
    string? DeptName,
    string? Designation,
    int StatusActive,
    string? CreatedBy,
    DateTime? CreatedDate,
    string? UpdatedBy,
    DateTime? UpdatedDate);

public record CreateEmployeeRequest(
    string? BadgeNo,
    string? Name,
    int? CompanyId,
    int? ProjectId,
    int? DeptId,
    string? Designation,
    int StatusActive = 1,
    string? CreatedBy = null);

public record UpdateEmployeeRequest(
    string? BadgeNo,
    string? Name,
    int? CompanyId,
    int? ProjectId,
    int? DeptId,
    string? Designation,
    int StatusActive = 1,
    string? UpdatedBy = null);

public record CreateCompanyRequest(string? CompanyName, int StatusActive = 1, string? CreatedBy = null);

public record UpdateCompanyRequest(string? CompanyName, int StatusActive = 1, string? UpdatedBy = null);

public record CreateDeptRequest(string? DeptName, int StatusActive = 1, string? CreatedBy = null);

public record UpdateDeptRequest(string? DeptName, int StatusActive = 1, string? UpdatedBy = null);

public record CreateProjectRequest(string? ProjectCode, string? ProjectName, int StatusActive = 1, string? CreatedBy = null);

public record UpdateProjectRequest(string? ProjectCode, string? ProjectName, int StatusActive = 1, string? UpdatedBy = null);
