using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using International_Voting_Systems.VoterRegObserver;

namespace International_Voting_Systems.VoterRegObserver
{
    public interface IVoterObserver
    {
        // Receive update from subject
        void Update(IVoterSubject subject);
    }
}
