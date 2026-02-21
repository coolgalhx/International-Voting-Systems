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
        public void ApproveVoter(int voterid)
        {
            using (var db = new MainDatabaseContext())
            {
                var voter = db.Voters.Find(voterid);

                if (voter != null)
                {
                    voter.IsApproved = true;
                    voter.IsSuspended = false;
                    db.SaveChanges();
                }

            }
        }
        public void SuspendVoter(int voterid)
        {
            using (var db = new MainDatabaseContext())
            {
                var voter = db.Voters.Find(voterid);

                if (voter != null)
                {
                   // voter.IsApproved = false;
                    voter.IsSuspended = true;
                    db.SaveChanges();
                }

            }
        }
        public void UpdateVoter(Voter updated)
        {
            using (var db = new MainDatabaseContext())
            {
                var voter = db.Voters.Find(updated.VoterID);
                if (voter != null)
                {

                    voter.IsApproved = updated.IsApproved;
                    voter.IsSuspended = updated.IsSuspended;

                    db.SaveChanges();
                }
            }
        }

        public void ClearOldData(int voterid)
        {
            DataRetension dr = DataRetension.GetInstance();
            dr.DeleteVotersOlderthan6Months();
            //using var db = new MainDatabaseContext();

            

        }
    }

    
}
