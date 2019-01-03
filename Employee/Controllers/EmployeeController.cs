using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : ControllerBase
    {
        Models.EmployeeDataAccessLayer objemployee = new Models.EmployeeDataAccessLayer();

        [HttpGet("[action]")]
        [Route("api/Employee/Index")]
        public IEnumerable<Models.Employee> Index()
        {
            return objemployee.GetAllEmployees();
        }

        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create([FromBody] Models.Employee employee)
        {
            return objemployee.AddEmployee(employee);
        }

        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public Models.Employee Details(int id)
        {
            return objemployee.GetEmployeeData(id);
        }

        [HttpPut]
        [Route("api/Employee/Edit")]
        public int Edit([FromBody] Models.Employee employee)
        {
            return objemployee.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public int Delete(int id)
        {
            return objemployee.DeleteEmployee(id);
        }
    }

}