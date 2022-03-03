using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Location
    {
        [Key]
        public int idLocation { get; set; }
        public string address { get; set; }
        public int idMagistral { get; set; }
        public virtual Magistral Magistral { get; set; }
    }
}
