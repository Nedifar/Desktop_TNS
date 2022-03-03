using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Tarif
    {
        [Key]
        public int idTarif { get; set; }
        public string name { get; set; }
        public string condition { get; set; }
        public double cost { get; set; }
        public virtual List<Service> Services { get; set; } = new List<Service>();
        public virtual List<AbonentTarif> AbonentTarifs { get; set; } = new List<AbonentTarif>();
    }
}
