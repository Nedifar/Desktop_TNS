using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Equipment
    {
        [Key]
        public string SerialNumber { get; set; }
        public string name { get; set; }
        public virtual List<Contract> Contracts { get; set; } = new List<Contract>();
        public int idEquipmentType { get; set; }
        public bool work { get; set; }
        public virtual EquipmentType EquipmentType { get; set; }
        public virtual List<Magistral> Magistrals { get; set; } = new List<Magistral>();
        public virtual List<AccsesNetwork> AccsesNetworks { get; set; } = new List<AccsesNetwork>();
        public virtual List<AbonentEquipment> AbonentEquipments { get; set; } = new List<AbonentEquipment>();
    }
}
