using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiNominas.Models
{
    public class Salary
    {
        public int EmpId { get; set; }
        public string FullName { get; set; }
        public decimal Qty { get; set; }
        public int PayId { get; set; }
        public string PayDesc { get; set; }

        public Salary() { }

        public Salary(int EmpId_, string FullName_, decimal Qty_, int PayId_, string PayDesc_)
        {
            EmpId = EmpId_;
            FullName = FullName_;
            Qty = Qty_;
            PayId = PayId_;
            PayDesc = PayDesc_;
        }

    }
}