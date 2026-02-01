using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static International_Voting_Systems.MainDBConext;

namespace International_Voting_Systems
{
    internal class CandidateRegistrationObserver
    {
        public interface ICandidateObserver
        {
            void Update(ICandidateSubject candidate);
        }
        public interface ICandidateSubject
        {
            void Attcatch(ICandidateObserver observer);
            void Detach(ICandidateObserver observer);
            void Notify();
        }

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

        class EmailService : ICandidateObserver
        {
            public void Update(ICandidateSubject subject)
            {
                Subject candidateSubject = subject as Subject;
                if (candidateSubject == null || candidateSubject.RegisteredCandidate == null)
                    return;
                SendEmailtoCandidate(candidateSubject.RegisteredCandidate.CandidateEmail);

            }

            private void SendEmailtoCandidate(string candidateEmail)
            {
                var sender = "Hanatheapprentice@gmail.com";
                var apppass = " ";


                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(sender, apppass)
                };

                var actualEmailtocandidate = new MailMessage
                {
                    From = new MailAddress(sender),

                    Subject = "Voter Confirmation",
                    Body = "Thank you for registering to stand as a Candidate for you Constituent",
                    IsBodyHtml = true
                };

                actualEmailtocandidate.To.Add(candidateEmail);
                client.Send(actualEmailtocandidate);
            }



        }
    }
}

