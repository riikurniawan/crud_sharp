using crud_sharp.App.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_sharp.App.Data;

public class IssDbContext(DbContextOptions<IssDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees => Set<Employee>();
}
