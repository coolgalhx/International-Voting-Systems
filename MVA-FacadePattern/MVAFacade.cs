using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems
{
    public class MVAFacade
    {
        public List<Voter> ListAllVoters()
        {
            
            using (var db= new MainDatabaseContext())
            {
                return db.Voters.ToList();
            }
        }
        public void RejectVoter(int voterid)
        {
            using (var db = new MainDatabaseContext())
            {
                var voter=db.Voters.Find(voterid);

               if(voter!= null )
               {
                    db.Voters.Remove(voter);
                    db.SaveChanges();
               }

            }
        }
        
    }

    
}
