using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MorningSession_WebAPI.Data;
using MorningSession_WebAPI.Models;
using MorningSession_WebAPI.Repository;

namespace MorningSession_WebAPI.DataManager
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        public readonly EmployeeContext _employeeContext;

        public EmployeeManager(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public void Add(Employee entity)
        {
            _employeeContext.Employees.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public Employee Get(long id)
        {
            return _employeeContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employees.ToList();
        }

        public void Update(Employee employee, Employee entity)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.Email = entity.Email;
            employee.DateOfBirth = entity.DateOfBirth;
            employee.PhoneNumber = entity.PhoneNumber;
            _employeeContext.SaveChanges();
        }
    }
}
