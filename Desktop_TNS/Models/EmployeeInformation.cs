using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class EmployeeInformation
    {
        [Key]
        public int idEmployeeInformation { get; set; }
        public string info { get; set; }
        public int idEmployeeType { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
        public DateTime date { get; set; }
    }
}
