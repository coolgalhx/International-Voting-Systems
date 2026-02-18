using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace International_Voting_Systems
{
    class LogInFacade
    {
        public bool LogIn (int voterid)
        {
            

            using (var db = new MainDatabaseContext())
            {
               bool exists= db.Voters.Any(v =>
                v.VoterID == voterid &&
                v.IsApproved == true &&
                v.IsSuspended == false); 
                return exists;

            }
            


        }
          

    }
}
