using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTest.Data.Model.Entities;
using BlogTest.Data.UnitOfWork;
using System.Linq;
using BlogTest.Core;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using BlogTest.Model.Entities;

namespace BlogTest.Business.GenericBusiness
{
    public class GenericBusiness : IGenericBusiness
    {
        readonly IUnitOfWork _unitOfWork;

        public GenericBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        public async Task<IEnumerable<Gender>> GetAllGenders()
        {
            return await _unitOfWork.Gender.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await _unitOfWork.Employee.GetAsync(x => x.Id == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _unitOfWork.Employee.GetAllAsync();
        }

        public async Task<bool> DeleteEmployeeById(int employeeId)
        {
            _unitOfWork.Employee.Delete(employeeId);
            return (await _unitOfWork.CommitAsync() > 0);
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            _unitOfWork.Employee.Insert(employee);
            return (await _unitOfWork.CommitAsync() > 0);
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var employeeToUpdate = await GetEmployeeById(employee.Id);
            employeeToUpdate.DateOfBirth = employee.DateOfBirth;
            employeeToUpdate.EmployeeName = employee.EmployeeName;
            employeeToUpdate.Gender = employee.Gender;
            employeeToUpdate.Salary = employee.Salary;
            _unitOfWork.Employee.Update(employeeToUpdate);
            return (await _unitOfWork.CommitAsync() > 0);
        }
    }
}
