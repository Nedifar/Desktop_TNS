using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class AbonentAddress
    {
        [Key]
        public string idAbonentAddress { get; set; }
        public string prefixCode { get; set; }
        public int idRaion { get; set; }
        public virtual Raion Raion { get; set; }
        public string prefix { get; set; }
        public string house { get; set; }
        //public string AbonentNumber { get; set; }
        public virtual List<Abonent> Abonents { get; set; } = new List<Abonent>();
        public string getStreet
        {
            get
            {
                return prefix.Split(',')[1].Trim();
            }
        }
    }
}
