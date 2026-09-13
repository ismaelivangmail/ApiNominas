using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiNominas.Models
{
    public class Department
    {
        public int DeptId { get; set; }
        public string DeptDesc { get; set; }

        public Department() { }

        public Department(int DeptId_, string DepDesc_)
        {
            DeptId = DeptId_;
            DeptDesc = DepDesc_;
        }

    }
}