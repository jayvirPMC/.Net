using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;

public class Employee {
    public int Id { get; set; }
    public string Name {get; set; }
    public string Email {get; set; }
    public long Salary {get; set; }
    public DateTime DateOfBirth {get; set; }
    public string Department {get; set; }
}


public class EmployeeDbContext : DbContext {
    public DbSet<Employee> Employees { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=PMCLAP1248;database=RazorPagesDemo;user id=sa; password=PmcIndia@123;TrustServerCertificate=True;");
    }
}

public class Program {
    static void Main(string[] args) {
        // Program.create();
        // Program.select();
        // Program.selectLinq();
        // Program.update();
        Program.select();
        Program.delete();
        Program.select();
        
    }

    public static void create() {
        using (var context = new EmployeeDbContext())
        {
            // create 
            var newEmp = new Employee{
                Name = "jayvirsinh",
                Email = "jayvir@gmail.com",
                Salary = 9000000,
                DateOfBirth = new DateTime(2004, 02, 15),
                Department = "MS"
            };

            context.Employees.Add(newEmp);
            context.SaveChanges();

            Console.WriteLine("inserted success");
        }
    }

    public static void select() {
        using (var context = new EmployeeDbContext())
        {
            var empList = context.Employees.ToList();
            Console.WriteLine("\nAll the Employees: \n");
            foreach (var emp in empList)
            {
                Console.WriteLine("Id: " + emp.Id + " Name: " +emp.Name + " Email: " + emp.Email + " Salary: " + emp.Salary + " DOB: " + emp.DateOfBirth.ToString("dd/MM/yyyy") + " Department: " + emp.Department );
            }
        }
    }

    public static void selectLinq() {
        using (var context = new EmployeeDbContext())
        {
            var empList = context.Employees.Where(s => s.Salary >= 9000000);

            Console.WriteLine("\nEmployees with salary >= 9000000: \n");

            foreach(var emp in empList) {
                Console.WriteLine("Id: " + emp.Id + " Name: " +emp.Name + " Email: " + emp.Email + " Salary: " + emp.Salary + " DOB: " + emp.DateOfBirth.ToString("dd/MM/yyyy") + " Department: " + emp.Department );
            }
            
        }
    }

    public static void update() {
        using (var context = new EmployeeDbContext())
        {
            var emp = from e in context.Employees 
                      where e.Id == 4
                      select e;
            var employee = emp.FirstOrDefault();
            employee.Name = "mithashu";
            context.SaveChanges();
        }
    }
    public static void delete() {
        using (var context = new EmployeeDbContext())
        {
            var emp = from e in context.Employees 
                      where e.Id == 1
                      select e;
            var employee = emp.FirstOrDefault();
            context.Employees.Remove(employee);
            context.SaveChanges();
        }
    }
}

