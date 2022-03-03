using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class AccsesNetwork
    {
        [Key]
        public int idAccsesNetwork { get; set; }
        public string serialNumber { get; set; }
        public virtual Equipment Equipment { get; set; }
        public string ports { get; set; }
        public string standart { get; set; }
        public string frequince { get; set; }
        public string interfaces { get; set; }
        public string speed { get; set; }
        public string location { get; set; }
    }
}
