using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class DateTable
    {
        [Key]
        public DateTime date { get; set; }
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
        public virtual List<Event> Events { get; set; } = new List<Event>();
        public List<Event> getList()
        {
            return Events.OrderByDescending(p => p.begin).ToList();
        }
        [NotMapped]
        public List<Event> GetEvents
        {
            get
            {
                return Events.OrderByDescending(p => p.begin).ToList();
            }
        }
    }
}
