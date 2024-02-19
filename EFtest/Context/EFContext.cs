using Microsoft.EntityFrameworkCore;
using EFtest.Model;

namespace EFtest.Context
{
    public class EFContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("server=PMCLAP1248;database=school;user id=sa;password=PmcIndia@123;TrustServerCertificate=True;");
        }

        public void EnsureDatabaseCreated() {
            Database.EnsureCreated();
        }

    }
}