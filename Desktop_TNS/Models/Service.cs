using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Service
    {
        [Key]
        public int idService { get; set; }
        public string name { get; set; }
        public virtual List<Contract> Contracts { get; set; } = new List<Contract>(); 
        public virtual List<CRM> CRMs { get; set; } = new List<CRM>();
    }
}
