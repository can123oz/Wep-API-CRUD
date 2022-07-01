//using RestApiCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Context;
using Entity.Models;

namespace RestApiCrud.Data
{
    public class MarkEmployee : IEmployeeData
    {

        private DatabaseContext _db;

        public MarkEmployee(DatabaseContext db)
        {
            _db = db;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Code = Guid.NewGuid().ToString();
            _db.Add(employee);
            return employee;
        }

        public bool DeleteEmployee(int id)
        {
            var deletedEmployee = _db.Employee.FirstOrDefault(p => p.Id == id);
            if(deletedEmployee != null)
            {
                _db.Remove(deletedEmployee);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Employee EditEmployee(Employee employee)
        {
            var existedEmployee = _db.Employee.FirstOrDefault(p => p.Id == employee.Id);
            var existedEmployee11 = _db.Employee.Find(employee.Id);
            if(existedEmployee != null)
            {
                existedEmployee.Name = employee.Name;
                existedEmployee.Code = Guid.NewGuid().ToString();
                return existedEmployee;
            }
            return null;
        }

        public Employee GetSingle(int id)
        {
            var emlooyeReturn = _db.Employee.FirstOrDefault(p => p.Id == id);
            return emlooyeReturn;
        }

        public List<Employee> GetEmployees()
        {
            return _db.Employee.ToList();
        }

    }
}
