using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Employee
    {
        [Key]
        public int idEmployee { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string login { get; set; }
        public string pwd { get; set; }
        public int idEmployeeType { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
        public string imagePath { get; set; }
        public string fullName
        {
            get
            {
                return lastName + " " + firstName + " " + middleName;
            }
        }
        public virtual List<DateTable> DateTables { get; set; } = new List<DateTable>();
        public virtual List<Event> Events { get; set; } = new List<Event>();
        public string getColor
        {
            get
            {
                if(Events.Where(p=>p.date ==FrFame.dateT && p.begin==p.end).Count() !=0)
                {
                    return "отпуск";
                }
                //else if(Events.Where(p => p.CRM.Abonent.AbonentAddress.idRaion == FrFame.crmT.Abonent.AbonentAddress.idRaion).Count() != 0) !!!!!!!!!!!!!!!!!!!!!!!!!!
                //{
                //    return "инженер";
                //}
                else
                {
                    return "обычный";
                }
            }
        }
    }
}
