using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Models;
using Employee.Service.Implementation;
using Employee.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Web.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        #region [ Variables ]

        private readonly IEmployeeService employeeService;

        #endregion

        #region [ Constructor ]
        public EmployeeController()
        {
            employeeService = new EmployeeService();
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Get list employees
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            return employeeService.GetEmployees();
        }

        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public EmployeeDTO GetEmployeeById(int id)
        {
            return employeeService.GetEmployeeById(id);
        }

        #endregion
    }
}