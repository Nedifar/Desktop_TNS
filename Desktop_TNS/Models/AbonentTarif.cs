using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class AbonentTarif
    {
        [Key]
        public int idAbonentTarif { get; set; }
        public string AbonentNumber { get; set; }
        public virtual Abonent Abonent { get; set; }
        public virtual List<Tarif> Tarifs { get; set; } = new List<Tarif>();
        public string listTarifs
        {
            get
            {
                string txt = String.Empty;
                foreach (var l in Tarifs)
                    txt += l.name + " ";
                return txt;
            }
        }
        public double listTarifscost
        {
            get
            {
                double txt = 0;
                foreach (var l in Tarifs)
                    txt += l.cost;
                return txt;
            }
        }
        public string zadol
        {
            get
            {
                if (Abonent.AbonentPayments.Count != 0)
                {
                    var saicol = Abonent.AbonentPayments.Where(p => p.dateBalans < FrFame.selectedDate).OrderByDescending(p => p.dateBalans);
                    if (saicol != null)
                        return (saicol.FirstOrDefault().arrearsPosle == "") ? "0" : saicol.FirstOrDefault().arrearsPosle;
                    return "0";
                }
                else
                    return "0";
            }
        }
    }
}
