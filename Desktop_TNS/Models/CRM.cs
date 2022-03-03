using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class CRM
    {
        [Key]
        public string NumberCRM { get; set; }
        public DateTime dateCreated { get; set; }
        public string AbonentNumber {get; set;}
        public virtual Abonent Abonent { get; set; }
        public int? idService { get; set; }
        public virtual Service Service { get; set; }
        public string serviceType { get; set; }
        public string serviceView { get; set; }
        public string status { get; set; }
        public string equipmentType { get; set; }
        public string problem { get; set; }
        public DateTime? dateClosed { get; set; }
        public string typeProblem { get; set; }
        public virtual List<Event> Events { get; set; } = new List<Event>();
        public string imagePath { get; set; }
    }
}
