using ApiNominas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiNominas.Controllers
{
    public class DepartmentController : ApiController
    {
        // GET: api/Department
        public IEnumerable<Department> Get()
        {
            CRUDDepartment CRUDDepartment_ = new CRUDDepartment();
            return CRUDDepartment_.getDepartment();
        }

        // GET: api/Department/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Department
        public bool Post([FromBody] Department Department_)
        {
            CRUDDepartment CRUDDepartment_ = new CRUDDepartment();
            bool result = CRUDDepartment_.addDepartment(Department_);

            return result;
        }

        // PUT: api/Department/5
        public bool Put(int id, [FromBody] Department Department_)
        {
            CRUDDepartment CRUDDepartment_ = new CRUDDepartment();
            bool result = CRUDDepartment_.updateDepartment(id, Department_);

            return result;
        }

        // DELETE: api/Department/5
        public bool Delete(int id)
        {
            CRUDDepartment CRUDDepartment_ = new CRUDDepartment();
            bool result = CRUDDepartment_.deleteDepartment(id);

            return result;
        }
    }
}
