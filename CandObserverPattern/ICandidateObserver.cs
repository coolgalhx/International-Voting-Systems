using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems.CandObserverPattern
{
    public interface ICandidateObserver
    {
        void Update(ICandidateSubject candidate);
    }
    
}
