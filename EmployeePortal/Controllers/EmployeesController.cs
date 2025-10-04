using EmployeePortal.Models;
using EmployeePortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Controllers
{
    //localhost xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(ApplicationDbContext dbContext) : ControllerBase
    {
        private readonly ApplicationDbContext dbContext = dbContext;

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            //var allEmployees = dbContext.Employees.ToList();
            return Ok(dbContext.Employees.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                phoneNumber = addEmployeeDto.phoneNumber,
                Salary = addEmployeeDto.Salary
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }
    }
}
