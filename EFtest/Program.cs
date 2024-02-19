using Microsoft.EntityFrameworkCore;
using System.Linq;
using EFtest.Model;
using EFtest.Context;


namespace EFtest
{
    public class Program
    {
        // private static EFContext _context;
        // public Program(EFContext context) {
        //     _context = context;
        // }
        static void Main(string[] args)
        {

            Program.addDetails();
        }

        public static void addDetails()
        {

            using (var context = new EFContext())
            {

                var newStudent = new Student
                {
                    Name = "Jayvir",
                    Email = "jayvir@gmail.com",
                    Age = 21
                };

                var newTeacher = new Teacher
                {
                    Name = "Gajendra",
                    Subject = "chemistry"
                };

                context.Students.Add(newStudent);
                context.Teachers.Add(newTeacher);
                context.SaveChanges();

            }

        }
    }

}
