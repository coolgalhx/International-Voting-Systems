using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems
{
    internal class MVAFacade
    {
        public List<Voter> LoadAllVoters()
        {
            using (var db= new MainDatabaseContext())
            {
                return db.Voters.ToList();
            }
        }
    }
}
