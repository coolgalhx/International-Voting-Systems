using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems.CandObserverPattern
{
    public interface ICandidateSubject
    {
        void Attatch(ICandidateObserver observer);
        void Detach(ICandidateObserver observer);
        void Notify();
    }
}
