using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Magistral
    {
        [Key]
        public int idMagistral { get; set; }
        public string serialNumber { get; set; }
        public virtual Equipment Equipment { get; set; }
        public string frequince { get; set; }
        public string zatuhanie { get; set; }
        public string technology { get; set; }
        public virtual List<Location> Locations { get; set; } = new List<Location>(); 
        public string getLocations
        {
            get
            {
                string txt = String.Empty;
                if(Locations.Count !=0)
                foreach(var l in Locations)
                {
                    if(l!=null)
                    {
                        txt += l.address + " ";
                    }
                }
                return txt;
            }
        }
    }
}
