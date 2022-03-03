using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class AbonentEquipment
    {
        [Key]
        public int idAbonentEquipment { get; set; }
        public string serialNumber { get; set; }
        public virtual Equipment Equipment { get; set; }
        public string ports { get; set; }
        public string standart { get; set; }
        public string speed { get; set; }
        public virtual List<AbonentAddress> AbonentAddresses { get; set; } = new List<AbonentAddress>();
        public string getAddress
        {
            get
            {
                string txt = String.Empty;
                foreach(var l in AbonentAddresses)
                {
                    if (l != null)
                        txt += l.prefix + " " + l.house + "\n";
                }
                return txt;
            }
        }
    }
}
