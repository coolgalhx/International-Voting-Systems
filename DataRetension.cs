using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;





namespace International_Voting_Systems
{
    internal class DataRetension 
    {





        public void DeleteVoterTable()
        {
            using var context = new MainDatabaseContext();

            context.Database.ExecuteSqlRaw("DELETE FROM Voters");


        }
        

    }
    
        
}

