using crud_sharp.App.Data;
using crud_sharp.App.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_sharp.App.Services;

public interface IMasterProjectService
{
    Task<List<MasterProject>> GetAllAsync();
    Task<MasterProject?> GetByIdAsync(int id);
    Task<MasterProject> CreateAsync(CreateProjectRequest request);
    Task<MasterProject?> UpdateAsync(int id, UpdateProjectRequest request);
    Task<bool> DeleteAsync(int id);
}

public class MasterProjectService(PortalDbContext db) : IMasterProjectService
{
    public async Task<List<MasterProject>> GetAllAsync() =>
        await db.MasterProjects.OrderBy(p => p.Id).ToListAsync();

    public async Task<MasterProject?> GetByIdAsync(int id) =>
        await db.MasterProjects.FindAsync(id);

    public async Task<MasterProject> CreateAsync(CreateProjectRequest request)
    {
        var entity = new MasterProject
        {
            ProjectCode = request.ProjectCode,
            ProjectName = request.ProjectName,
            StatusActive = request.StatusActive,
            CreatedBy = request.CreatedBy,
            CreatedDate = DateTime.Now
        };

        db.MasterProjects.Add(entity);
        await db.SaveChangesAsync();

        return entity;
    }

    public async Task<MasterProject?> UpdateAsync(int id, UpdateProjectRequest request)
    {
        var entity = await db.MasterProjects.FindAsync(id);
        if (entity is null) return null;

        entity.ProjectCode = request.ProjectCode;
        entity.ProjectName = request.ProjectName;
        entity.StatusActive = request.StatusActive;

        await db.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.MasterProjects.FindAsync(id);
        if (entity is null) return false;

        db.MasterProjects.Remove(entity);
        await db.SaveChangesAsync();

        return true;
    }
}
