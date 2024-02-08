using System;
using System.Linq;

public class Student{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Program
{
    static void Main(string[] args) {
        Student[] studentsArray = {
            new Student() {Id = 1, Name = "jay", Email = "jay@gmail.com"},
            new Student() {Id = 2, Name = "jayvir", Email = "jayvir@gmail.com"},
            new Student() {Id = 3, Name = "meet", Email = "meet@gmail.com"},
            new Student() {Id = 4, Name = "tarun", Email = "tarun@gmail.com"},
            new Student() {Id = 5, Name = "parth", Email = "parth@gmail.com"},
        };

        var evenStu = from student in studentsArray
                      where student.Id % 2 == 0 && student.Name.Contains('j')
                      select student;

        foreach (var student in evenStu)
        {
            Console.WriteLine("id: " + student.Id + " name: " + student.Name + " email: " + student.Email);
        }
        
    }
}