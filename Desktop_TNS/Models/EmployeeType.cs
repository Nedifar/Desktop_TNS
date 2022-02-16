using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class EmployeeType
    {
        [Key]
        public int idEmployeeType { get; set; }
        public string name { get; set; }
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
        public virtual List<EmployeeInformation> EmployeeInformations { get; set; } = new List<EmployeeInformation>();
    }
}
