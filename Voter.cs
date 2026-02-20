using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems
{    

    //THE MODEL
    public class Voter
    {
        public int VoterID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public int Age { get; set; }
        public string Gender { get; set; }

        public DateTime DOB { get; set; }

        public double ContactNumber { get; set; }

        public string PostCode { get; set; }
        public string City { get; set; }

        public string Country { get; set; }

        public bool IsApproved { get; set; } = true;
        public bool IsSuspended { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
