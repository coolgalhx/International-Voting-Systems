using International_Voting_Systems.CandObserverPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems.Testing
{
    public class ObserverTestforCand : ICandidateObserver
    {
        public bool Notified = false;
        public Candidate ReceivedCandidate;

        //tests if the notification occured
        public void Update(ICandidateSubject subject)
        {
            ReceivedCandidate = ((Subject)subject).RegisteredCandidate;
            Notified = true;
            Console.WriteLine("Observer Recieved Update");
        }

    }
}
