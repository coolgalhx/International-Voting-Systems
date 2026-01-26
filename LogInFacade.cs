using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static International_Voting_Systems.MainDBConext;

namespace International_Voting_Systems
{
    class LogInFacade
    {
        public bool LogIn (int voterid)
        {
            if (voterid==voterid)
            {
                return false;
            }

            using (var db = new MainDatabaseContext())
            {
               bool exists= db.Voters.Any(u=> u.VoterID == voterid);
                return exists;

            }
            


        }
          

    }
}
