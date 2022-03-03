using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class AbonentPayment
    {
        [Key]
        public int idAbonentPayment { get; set; }
        public DateTime datePayment { get; set; }
        public double sumPayment { get; set; }
        public double balans { get; set; }
        public DateTime dateBalans { get; set; }
        public double? arrears { get; set; }
        public string AbonentNumber { get; set; }
        public virtual Abonent Abonent { get; set; }
        public string balansPosle
        {
            get
            {
                if (datePayment > dateBalans)
                    return (sumPayment + balans).ToString() + " рублей";
                else
                    return (balans).ToString() + " рублей";
            }
        }
        public string arrearsPosle
        {
            get
            {
                if (arrears != null)
                {
                    if (sumPayment - arrears >= 0)
                    {
                        return "0";
                    }
                    else
                        return (arrears - sumPayment).ToString() + " рублей";
                }
                return "0";

            }
        }
    }
}
