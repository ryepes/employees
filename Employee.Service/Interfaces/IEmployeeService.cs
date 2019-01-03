using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployeeById(int id);
    }
}
