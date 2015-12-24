using StarWarsTFA.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsTFA.Infrastructure.Data
{
    public class SWDatabase : DbContext
    {
        public SWDatabase() : base("name=swtfaDB")
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Side> Sides { get; set; }
    }
}
