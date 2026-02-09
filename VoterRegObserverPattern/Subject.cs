using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace International_Voting_Systems.VoterRegObserver
{
    public class Subject : IVoterSubject
    {

        public Voter RegisteredVoter { get; private set; }


        private List<IVoterObserver> _observers = new List<IVoterObserver>();


        public void Attach(IVoterObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IVoterObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }


        public void RegisterVoter(Voter voter)
        {
            using (var db = new MainDatabaseContext())
            {

                db.Database.EnsureCreated();
                db.Voters.Add(voter);
                db.SaveChanges();


                MessageBox.Show("New Voter Added!");
            }

            this.RegisteredVoter = voter;

            this.Notify();
        }
    }
}
