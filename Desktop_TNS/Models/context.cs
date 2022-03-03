using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class context : DbContext
    {
        private static context _context;
        public context() : base("sql") { }
        public static context aGetContext()
        {
            if (_context == null)
                _context = new context();
            return _context;
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Abonent> Abonents { get; set; }
        public DbSet<AbonentAddress> AbonentAddresses { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<CRM> CRMs { get; set; }
        public DbSet<EmployeeInformation> EmployeeInformations { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Raion> Raions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Magistral> Magistrals { get; set; }
        public DbSet<AccsesNetwork> AccsesNetworks { get; set; }
        public DbSet<AbonentEquipment> AbonentEquipments { get; set; }
        public DbSet<BaseStation> BaseStations { get; set; }
        public DbSet<DateTable> DateTables { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }
        public DbSet<AbonentTarif> AbonentTarifs { get; set; }
        public DbSet<AbonentPayment> AbonentPayments { get; set; }
    }
}
