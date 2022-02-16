using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Employee
    {
        [Key]
        public int idEmployee { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string login { get; set; }
        public string pwd { get; set; }
        public int idEmployeeType { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
        public string imagePath { get; set; }
    }
}
