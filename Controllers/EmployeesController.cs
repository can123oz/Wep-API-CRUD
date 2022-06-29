using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCrud.Data;
using RestApiCrud.Model;
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
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
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
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/" + employee.Id, employee);
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public bool Delete(int id)
        {
            return _employeeData.DeleteEmployee(id);
        }


        [HttpPut("Update")]
        public Employee Update(Employee employee)
        {
            var updatedEmployee = _employeeData.EditEmployee(employee);
            return updatedEmployee;
        }
    }
}

