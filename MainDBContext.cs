using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems
{
   
    
        public class MainDatabaseContext : DbContext
        {
            public DbSet<Voter> Voters { get; set; }
            public DbSet<Candidate> Candidates { get; set; }
            
            public DbSet<Code> Codes { get; set; }
            public DbSet<IDTable> IDs { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseSqlite("Data Source=MainDB.db");
            }
        }
    
}
