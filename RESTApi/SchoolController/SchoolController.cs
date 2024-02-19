using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RESTApi.Models;

namespace RESTApi.SchoolController
{

    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {

        private readonly SchoolContext _dbcontext;

        public SchoolController(SchoolContext dbcontext) {
            _dbcontext = dbcontext;
        }

        // GET All the Students

        [HttpGet("Student")]
        public IEnumerable<Student> GetStudents() {
            return _dbcontext.Students.ToList();
        }

        // GET Student with ID
        [HttpGet("Student/{id}")]
        public IActionResult GetStudent(int id) {
            var Student = _dbcontext.Students.Find(id);

            if(Student == null) {
                return NotFound("student not found");
            }

            return Ok(Student);
        }

        // GET All the Teacher
        [HttpGet("Teacher")]
        public IEnumerable<Teacher> GetTeachers() {
            return _dbcontext.Teachers.ToList();
        }

        // GET Teacher with ID
        [HttpGet("Teacher/{id}")]
        public IActionResult GetTeacher(int id) {
            var Teacher = _dbcontext.Teachers.Find(id);

            if (Teacher == null)
            {
                return NotFound("Teacher not found");
            }

            return Ok(Teacher);
        }

        // post - Insert into Student
        [HttpPost("Student")]
        public IActionResult PostStudent(Student student) {

            try
            {
                _dbcontext.Students.Add(student);
                _dbcontext.SaveChanges();
                return Ok("Student added");
            }
            catch (Exception e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        // post - Insert into Teacher
        [HttpPost("Teacher")]
        public IActionResult PostTeacher(Teacher teacher) {
            try
            {
                _dbcontext.Teachers.Add(teacher);
                _dbcontext.SaveChanges();
                return Ok("Teacher added successfully");
            }
            catch (Exception e)
            {
                
                return BadRequest($"Error: {e.Message}");
            }
        }

        // put - update student
        [HttpPut("Student/{id}")]
        public IActionResult PutStudent(int id, Student student) {
            try
            {
                if (id != student.Id)
                {
                    return BadRequest("Student Not Found");
                }

                _dbcontext.Entry(student).State = EntityState.Modified;
                _dbcontext.SaveChanges();
                return Ok("Student updated successfully");
            }
            catch (Exception e)
            {
                
                return BadRequest($"Error: {e.Message}");
            }
        }

        // Put - update teacher
        [HttpPut("Teacher/{id}")]
        public IActionResult PutTeacher(int id, Teacher teacher) {
            try
            {
                if (id != teacher.Id)
                {
                    return BadRequest("No Teacher Found");
                }

                _dbcontext.Entry(teacher).State = EntityState.Modified;
                _dbcontext.SaveChanges();
                return Ok("Teacher updated success");
            }
            catch (Exception e)
            {

                return BadRequest($"Error: {e.Message}");
            }
        }

        // Delete - student
        [HttpDelete("Student/{id}")]
        public IActionResult DeleteStudent(int id) {

            var student = _dbcontext.Students.Find(id);
            if (student == null)
            {
                return NotFound("Student Not Found");
            }

            try
            {
                _dbcontext.Students.Remove(student);
                _dbcontext.SaveChanges();
                return Ok("Student deleted successfully");
            }
            catch (Exception e)
            {
                
                return BadRequest($"Error: {e.Message}");
            }
        }

        // Delete - Teacher
        [HttpDelete("Teacher/{id}")]
        public IActionResult DeleteTeacher(int id) {
            var teacher = _dbcontext.Teachers.Find(id);

            if (teacher == null)
            {
                return NotFound("Teacher not found");
            }

            try
            {
                _dbcontext.Teachers.Remove(teacher);
                _dbcontext.SaveChanges();
                return Ok("Teacher deleted successfully");
            }
            catch (Exception e)
            {
                
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}