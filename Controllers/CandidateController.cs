using International_Voting_Systems.CandObserverPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems.Controllers
{
    class CandidateController
    {
        private Subject subject;

        public CandidateController(Subject subject)
        {
            this.subject = subject;
        }
        public string RegisterCand(Candidate candidate)
        {
            

            subject.RegisterCandidate(candidate); 

            return "Candidate registered successfully";
        }

    }
}
