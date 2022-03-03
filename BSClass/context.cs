using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSClass
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
        public DbSet<BaseStation> BaseStations { get; set; }
        public DbSet<Raion> Raions { get; set; }
    }
}
