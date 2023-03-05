using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestPharma.Models
{
    public class Employee
    {
        public int ProfileId { get; set; }
        public int EmpId { get; set; }
        public String EmpCode { get; set; }
        public int DeptId { get; set; }
        public string OfficeEmail { get; set; }
        public string ReportingManager { get; set; }
        public string Designation { get; set; }
    }
}
