using crud_sharp.App.Data;
using crud_sharp.App.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_sharp.App.Services;

public interface IMasterCompanyService
{
    Task<List<MasterCompany>> GetAllAsync();
    Task<MasterCompany?> GetByIdAsync(int id);
    Task<MasterCompany> CreateAsync(CreateCompanyRequest request);
    Task<MasterCompany?> UpdateAsync(int id, UpdateCompanyRequest request);
    Task<bool> DeleteAsync(int id);
}

public class MasterCompanyService(PortalDbContext db) : IMasterCompanyService
{
    public async Task<List<MasterCompany>> GetAllAsync() =>
        await db.MasterCompanies.OrderBy(c => c.Id).ToListAsync();

    public async Task<MasterCompany?> GetByIdAsync(int id) =>
        await db.MasterCompanies.FindAsync(id);

    public async Task<MasterCompany> CreateAsync(CreateCompanyRequest request)
    {
        var entity = new MasterCompany
        {
            CompanyName = request.CompanyName,
            StatusActive = request.StatusActive,
            CreatedBy = request.CreatedBy,
            CreatedDate = DateTime.Now
        };

        db.MasterCompanies.Add(entity);
        await db.SaveChangesAsync();

        return entity;
    }

    public async Task<MasterCompany?> UpdateAsync(int id, UpdateCompanyRequest request)
    {
        var entity = await db.MasterCompanies.FindAsync(id);
        if (entity is null) return null;

        entity.CompanyName = request.CompanyName;
        entity.StatusActive = request.StatusActive;

        await db.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.MasterCompanies.FindAsync(id);
        if (entity is null) return false;

        db.MasterCompanies.Remove(entity);
        await db.SaveChangesAsync();

        return true;
    }
}
