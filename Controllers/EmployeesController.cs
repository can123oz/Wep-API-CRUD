using Entity.Context;
using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCrud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        private DatabaseContext _db;

        public EmployeesController(IEmployeeData employeeData, DatabaseContext db)
        {
            _employeeData = employeeData;
            _db = db;
        }

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet("GetSingle/{id}")]
        public IActionResult GetSingle(int id)
        {
            var employee = _employeeData.GetSingle(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"No Employee with Id = {id}");
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            _db.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public bool Delete(int id)
        {
            bool BOOL = _employeeData.DeleteEmployee(id);
            _db.SaveChanges();
            return BOOL;
        }

        [HttpPut("Update")]
        public Employee Update(Employee employee)
        {
            var updatedEmployee = _employeeData.EditEmployee(employee);
            _db.SaveChanges();
            return updatedEmployee;
        }
    }
}

