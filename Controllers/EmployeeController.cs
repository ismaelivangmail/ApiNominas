using ApiNominas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiNominas.Controllers
{

    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            CRUDEmployee CRUDEmployee_ = new CRUDEmployee();
            return CRUDEmployee_.getEmployee();
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        public bool Post([FromBody] Employee Employee_)
        {
            CRUDEmployee CRUDEmployee_ = new CRUDEmployee();
            bool result = CRUDEmployee_.addEmployee(Employee_);

            return result;
        }

        // PUT: api/Employee/5
        public bool Put(int id, [FromBody] Employee Employee_)
        {
            CRUDEmployee CRUDEmployee_ = new CRUDEmployee();
            bool result = CRUDEmployee_.updateEmployee(id, Employee_);

            return result;
        }

        // DELETE: api/Employee/5
        public bool Delete(int id)
        {
            CRUDEmployee CRUDEmployee_ = new CRUDEmployee();
            bool result = CRUDEmployee_.deleteEmployee(id);

            return result;
        }
    }

}
