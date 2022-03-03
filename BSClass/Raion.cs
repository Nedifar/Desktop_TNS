using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSClass
{
    public class Raion
    {
        [Key]
        public int idRaion { get; set; }
        public string name { get; set; }
        public double area { get; set; }
        public double population { get; set; }
        public int countMentro { get; set; }
        public string typeBuild { get; set; }
    }
}
