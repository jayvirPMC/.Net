using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TestApi.Model;


namespace TestApi.Context
{
    public class EmployeeDbContext : DbContext
    {

        public DbSet<Employee> Employees {get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("server=PMCLAP1248;database=RazorPagesDemo;user id=sa; password=PmcIndia@123;TrustServerCertificate=True;");
        }

    }
}