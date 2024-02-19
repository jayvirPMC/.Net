using Microsoft.EntityFrameworkCore;
using EFCrudApp.Models;

public class RazorPagesDBContext : DbContext {
    public RazorPagesDBContext(DbContextOptions<RazorPagesDBContext> options) : base(options) {
    
    }

    public DbSet<Employee> Employees { get; set; }
}