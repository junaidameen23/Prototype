using BlogTest.Data.Model.Entities;
using BlogTest.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTest.Business.GenericBusiness
{
    public interface IGenericBusiness
    {
        Task<IEnumerable<Gender>> GetAllGenders();

        Task<Employee> GetEmployeeById(int employeeId);

        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<bool> DeleteEmployeeById(int employeeId);

        Task<bool> CreateEmployee(Employee employee);

        Task<bool> UpdateEmployee(Employee employee);
    }
}
