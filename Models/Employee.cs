using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiNominas.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string FullName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime BirthDate { get; set; }
        public int DeptId { get; set; }
        public string DeptDesc { get; set; }

        public Employee() {}

        public Employee(int EmpId_, string FullName_, DateTime JoinDate_, DateTime BirthDate_, int DepId_, string DeptDesc_)
        {
            EmpId = EmpId_;
            FullName = FullName_;
            JoinDate = JoinDate_;
            BirthDate = BirthDate_;
            DeptId = DepId_;
            DeptDesc = DeptDesc_;
        }

        public Employee(string FullName_, DateTime JoinDate_, DateTime BirthDate_, int DepId_)
        {
            FullName = FullName_;
            JoinDate = JoinDate_;
            BirthDate = BirthDate_;
            DeptId = DepId_;
        }
    }
}