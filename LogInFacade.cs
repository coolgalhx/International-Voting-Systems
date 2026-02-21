using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace International_Voting_Systems
{
    class LogInFacade
    {

        
        public bool LogIn (int voterid)
        {
            

            using (var db = new MainDatabaseContext())
            {
               //bool userexists= db.Voters.Any(v =>
               // v.VoterID == voterid &&
               // v.IsApproved == true &&
               // v.IsSuspended == false);

                
                    var voter = db.Voters.FirstOrDefault(v => v.VoterID == voterid);

                    if (voter == null)
                    {
                        MessageBox.Show("Voter not found");
                         return false;
                    }
                    else if (!voter.IsApproved && voter.IsSuspended)
                    {
                        MessageBox.Show("Your account has been suspended by admin");
                         return false;
                    }
                    //else if (voter.IsApproved && )
                    //{
                    //    MessageBox.Show("Your account has been suspended");
                    //}
                    else
                    {
                        MessageBox.Show("Login Successful");
                    }
                   
                    return true;


            }
            


        }
          

    }
}
