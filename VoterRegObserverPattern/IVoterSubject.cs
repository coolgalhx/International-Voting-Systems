using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems.VoterRegObserver
{
    public interface IVoterSubject
    {
        // Attach an observer to the subject.
        void Attach(IVoterObserver observer);

        // Detach an observer from the subject.
        void Detach(IVoterObserver observer);

        // Notify all observers about an event.
        void Notify();
    }

}
