using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop_TNS.Models
{
    public class Event
    {
        [Key]
        public int idEvent { get; set; }
        public DateTime date { get; set; }
        public virtual DateTable DateTable { get; set; }
        public int? idEmployee { get; set; }
        public virtual Employee Employee { get; set; }
        public string NumberCRM { get; set; }
        public virtual CRM CRM { get; set; }
        public DateTime begin { get; set; }
        public DateTime end { get; set; }
        public string getPeriod
        {
            get
            {
                return begin.ToShortTimeString() + "-" + end.ToShortTimeString();
            }
        }
        public double height
        {
            get
            {
                return (end - begin).Hours * 30 + (end - begin).Minutes * 30.0 / 60.0;
            }
        }
        public Thickness margin
        {
            get
            {
                return new Thickness { Top = begin.Hour * 30 + begin.Minute * 30.0 / 60.0 };
            }
        }
        public bool eve
        {
            get
            {
                if (CRM != null)
                    return FrFame.sup.txt.Text == CRM.AbonentNumber;
                else
                    return false;
            }
        }
        public bool emp
        {
            get
            {
                if (Employee != null)
                    return FrFame.prs.txt.Text == Employee.lastName;
                else
                    return false;
            }
        }
        public DateTime rool
        {
            get
            {
                return end.AddMinutes(30);
            }
        }
        public string getTime
        {
            get
            {
                return (end - begin).TotalMinutes + " минут";
            }
        }
    }
}
