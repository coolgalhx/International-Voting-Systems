using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems.CandObserverPattern
{
    public class Subject : ICandidateSubject
    {
        public Candidate RegisteredCandidate { get; private set; }

        private List<ICandidateObserver> _observers = new List<ICandidateObserver>();


        void ICandidateSubject.Attcatch(ICandidateObserver observer)
        {
            _observers.Add(observer);
        }

        void ICandidateSubject.Detach(ICandidateObserver observer)
        {
            _observers.Remove(observer);
        }

        void ICandidateSubject.Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
        public void RegisterCandidate(Candidate candidate)
        {
            using (var db = new MainDatabaseContext())
            {
                db.Database.EnsureCreated();
                db.Candidates.Add(candidate);
                db.SaveChanges();

            }
            RegisteredCandidate = candidate;
            ((ICandidateSubject)this).Notify();
        }
    }

}
