using EmployeePortal.Models.Entities;

namespace Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
}
