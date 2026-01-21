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
        public int Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }

        public DateOnly DOB { get; set; }

        public double ContactNumber { get; set; }

    }
}
