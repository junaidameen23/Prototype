using BlogTest.Business.GenericBusiness;
using BlogTest.Data.Model.Entities;
using BlogTest.Model.Entities;
using BlogTest.WebApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BlogTest.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class BlogTestController : ApiController
    {
        private IGenericBusiness _genericBusiness;

        public BlogTestController()
        {
            _genericBusiness = new GenericBusiness();
        }


        [Route("test")]
        public string Get()
        {
            return "test api";
        }

        [HttpGet]
        [Route("GetAllGenders")]
        public async Task<IHttpActionResult> GetAllGenders()
        {
            var allGenders = await _genericBusiness.GetAllGenders();
            if (allGenders == null || !allGenders.Any())
            {
                return NotFound();
            }
            return Ok(allGenders);
        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<IHttpActionResult> GetEmployeeById(int employeeId)
        {
            var employee = await _genericBusiness.GetEmployeeById(employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IHttpActionResult> GetAllEmployees()
        {
            var allEmployee = await _genericBusiness.GetAllEmployees();
            if (allEmployee == null || !allEmployee.Any())
            {
                return NotFound();
            }
            return Ok(allEmployee);
        }

        [HttpGet]
        [Route("DeleteEmployeeById")]
        public async Task<IHttpActionResult> DeleteEmployeeById(int employeeId)
        {
            var isDeleted = await _genericBusiness.DeleteEmployeeById(employeeId);
            return Ok(isDeleted);
        }

        [HttpPost]
        [Route("SubmitEmployee")]
        public async Task<IHttpActionResult> SubmitEmployee(Employee employee)
        {
            bool isSubmited;
            if (employee.Id == 0)
            {
                isSubmited = await _genericBusiness.CreateEmployee(employee);
            }
            else
            {
                isSubmited = await _genericBusiness.UpdateEmployee(employee);
            }
            return Ok(isSubmited);
        }
    }
}