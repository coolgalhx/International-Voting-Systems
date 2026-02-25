using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace International_Voting_Systems
{
    public class Candidate
    {
        public int CandidateID { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        public string CandidateFullName { get; set; }
        public string CandidateEmail { get; set; }
        public string CandidateAddress { get; set; }
        public DateOnly CandidateDOB { get; set; }
        public string CandidateCity { get; set; }
        public string CandidateNationalInsuranceNumber { get; private set; }

        public string CandidateConstituency { get; set; }


      
    }
}
