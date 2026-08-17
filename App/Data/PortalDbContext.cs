using crud_sharp.App.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_sharp.App.Data;

public class PortalDbContext(DbContextOptions<PortalDbContext> options) : DbContext(options)
{
    public DbSet<MasterCompany> MasterCompanies => Set<MasterCompany>();
    public DbSet<MasterDept> MasterDepts => Set<MasterDept>();
    public DbSet<MasterProject> MasterProjects => Set<MasterProject>();
}
