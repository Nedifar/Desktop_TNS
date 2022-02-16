﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Contract
    {
        [Key]
        public string idContract { get; set; }
        public string AbonentNumber { get; set; }
        public virtual Abonent Abonent { get; set; }
        public DateTime dateConclude { get; set; }
        public string typeContract { get; set; }
        public string reasin { get; set; }
        public string lc { get; set; }
        public virtual List<Service> Services { get; set; } = new List<Service>();
        public DateTime dateClosed { get; set; }
        public string description { get; set; }
        public string serialNumber { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
