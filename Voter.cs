using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems
{
    public class Voter
    {
        public int VoterID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public DateTime DOB { get; set; }

        public double ContactNumber { get; set; }

        //missing address

        //11 is for voters
        //22 for admin

    }
}
