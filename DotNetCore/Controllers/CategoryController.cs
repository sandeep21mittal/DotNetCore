using DotNetCore.Data;
using DotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Employees);
        }


        [HttpPost]
        public IActionResult Insert(Employee emp)
        {
            var Emp = new Employee()
            {
                Id = emp.Id,
                EmployeeName = emp.EmployeeName,
                Email = emp.Email,
                EmployeeAge = emp.EmployeeAge,
                Address = emp.Address

            };
            _context.Employees.Add(Emp);
            _context.SaveChanges();
            return Ok(emp);
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, Employee emp)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                emp.EmployeeName = employee.EmployeeName;
                emp.Email = employee.Email;
                emp.EmployeeAge = employee.EmployeeAge;
                emp.Address = employee.Address;
                _context.SaveChanges();
                return Ok(employee);
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
                return Ok(emp);
            }
            return NotFound();
            
        }
    }
}
