using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class BaseStation
    {
        [Key]
        public int idBaseStation { get; set; }
        public string name { get; set; }
        public double area { get; set; }
        public double frequince { get; set; }
        public string type { get; set; }
        public int begin { get; set; }
        public int end { get; set; }
        public string standart { get; set; }
        public string installCoordinate { get; set; }
        public double radius { get; set; }
    }
}
