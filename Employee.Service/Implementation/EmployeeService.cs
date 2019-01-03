using Employee.Models;
using Employee.Service.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        #region [ Variables ]

        private readonly string url = @"https://masglobaltestapi.azurewebsites.net/api/Employees";

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Return list of employees
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDTO> GetEmployees()
        {
            var emp = new List<EmployeeDTO>();

            try
            {
                string html = string.Empty;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                    emp = JsonConvert.DeserializeObject<List<EmployeeDTO>>(html);
                }

                return emp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <returns></returns>
        public EmployeeDTO GetEmployeeById(int id)
        {
            var emp = new EmployeeDTO();

            try
            {
                string html = string.Empty;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                    var employees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(html);

                    emp = employees.Where(x => x.id == id).FirstOrDefault();
                }

                return emp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
