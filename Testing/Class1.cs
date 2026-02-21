using International_Voting_Systems.VoterRegObserver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems
{
    public class ObserverTest: IVoterObserver
    {
        public bool Notified=false;

        //tests if the notification occured
        public void Update(IVoterSubject subject)
        {
            Notified=true;
            Console.WriteLine("Observer Recieved Update");
        }
       
    }
    
}

