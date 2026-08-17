using crud_sharp.App.Data;
using crud_sharp.App.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_sharp.App.Services;

public interface IMasterDeptService
{
    Task<List<MasterDept>> GetAllAsync();
    Task<MasterDept?> GetByIdAsync(int id);
    Task<MasterDept> CreateAsync(CreateDeptRequest request);
    Task<MasterDept?> UpdateAsync(int id, UpdateDeptRequest request);
    Task<bool> DeleteAsync(int id);
}

public class MasterDeptService(PortalDbContext db) : IMasterDeptService
{
    public async Task<List<MasterDept>> GetAllAsync() =>
        await db.MasterDepts.OrderBy(d => d.Id).ToListAsync();

    public async Task<MasterDept?> GetByIdAsync(int id) =>
        await db.MasterDepts.FindAsync(id);

    public async Task<MasterDept> CreateAsync(CreateDeptRequest request)
    {
        var entity = new MasterDept
        {
            DeptName = request.DeptName,
            StatusActive = request.StatusActive,
            CreatedBy = request.CreatedBy,
            CreatedDate = DateTime.Now
        };

        db.MasterDepts.Add(entity);
        await db.SaveChangesAsync();

        return entity;
    }

    public async Task<MasterDept?> UpdateAsync(int id, UpdateDeptRequest request)
    {
        var entity = await db.MasterDepts.FindAsync(id);
        if (entity is null) return null;

        entity.DeptName = request.DeptName;
        entity.StatusActive = request.StatusActive;

        await db.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.MasterDepts.FindAsync(id);
        if (entity is null) return false;

        db.MasterDepts.Remove(entity);
        await db.SaveChangesAsync();

        return true;
    }
}
