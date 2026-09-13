using ApiNominas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiNominas.Controllers
{

    public class SalaryController : ApiController
    {
        // GET: api/Salary
        public IEnumerable<Salary> Get()
        {
            CRUDSalary CRUDSalary_ = new CRUDSalary();
            return CRUDSalary_.getSalary();
        }

        // GET: api/Salary/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Salary
        public bool Post([FromBody] Salary Salary_)
        {
            CRUDSalary CRUDSalary_ = new CRUDSalary();
            bool result = CRUDSalary_.addSalary(Salary_);

            return result;
        }

        // PUT: api/Salary/5
        public bool Put(int id, [FromBody] Salary Salary_)
        {
            CRUDSalary CRUDSalary_ = new CRUDSalary();
            bool result = CRUDSalary_.updateSalary(id, Salary_);

            return result;
        }

        // DELETE: api/Salary/5
        public bool Delete(int id)
        {
            CRUDSalary CRUDSalary_ = new CRUDSalary();
            bool result = CRUDSalary_.deleteSalary(id);

            return result;
        }
    }

}
