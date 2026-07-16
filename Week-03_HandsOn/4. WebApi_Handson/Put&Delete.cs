using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApiDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new()
        {
            new Employee
            {
                Id = 1,
                Name = "John",
                Salary = 5000,
                Permanent = true,
                Department = new Department { DeptName = "HR" },
                Skills = new List<Skill> { new Skill { SkillName = "C#" } },
                DateOfBirth = new DateTime(1990, 1, 1)
            }
        };

        [HttpGet]
        public ActionResult<List<Employee>> Get() => employees;

        [HttpPost]
        public IActionResult Post([FromBody] Employee emp)
        {
            employees.Add(emp);
            return Ok(emp);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee emp)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var existing = employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return BadRequest("Invalid employee id");

            existing.Name = emp.Name;
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return NotFound();

            employees.Remove(existing);
            return NoContent();
        }
    }
}
