using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Abonent
    {
        [Key]
        public string AbonentNumber { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string gender { get; set; }
        public DateTime birth { get; set; }
        public string idContract { get; set; }
        public virtual Contract Contract { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string addressPropiski { get; set; }
        public string idAbonentAddress { get; set; }
        public virtual AbonentAddress AbonentAddress { get; set; }
        public string passport_s { get; set; }
        public string passport_n { get; set; }
        public string code { get; set; }
        public string issue { get; set; }
        public DateTime dateIssue { get; set; }
        public virtual List<CRM> CRMs { get; set; } = new List<CRM>();
        public string fullName
        {
            get
            {
                return lastName + " " + firstName + " " + middleName;
            }
        }
        public string crmsList
        {
            get
            {
                string res = String.Empty;
                foreach(var l in CRMs)
                {
                    if(l!=null)
                    {
                        res += l.NumberCRM + ": " + l.dateCreated + "\n";
                    }
                }
                return res;
            }
        }
    }
}
