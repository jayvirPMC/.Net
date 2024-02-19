using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestApi.Context;
using TestApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TestApi.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeController(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET all employees
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _dbContext.Employees.ToList();
        }

        // GET employee by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            return Ok(employee);
        }

        // POST to insert new employee
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return Ok("Employee added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // PUT to update an existing employee
        [HttpPut("{id}")]
        public IActionResult Put(int id, Employee employee)
        {
            try
            {
                if (id != employee.Id)
                {
                    return BadRequest("Invalid employee ID");
                }

                _dbContext.Entry(employee).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return Ok("Employee updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // DELETE employee by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            try
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
                return Ok("Employee deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
