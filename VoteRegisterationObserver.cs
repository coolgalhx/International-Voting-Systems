using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static International_Voting_Systems.MainDBConext;
using System.Windows;
using System.Xml.Linq;
using System.Net.Mail;
using static International_Voting_Systems.VoteRegisterationObserver;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices.JavaScript;

namespace International_Voting_Systems
{
    internal class VoteRegisterationObserver
    {
        public interface IVoterObserver
        {
            // Receive update from subject
            void Update(IVoterSubject subject);
        }

        public interface IVoterSubject
        {
            // Attach an observer to the subject.
            void Attach(IVoterObserver observer);

            // Detach an observer from the subject.
            void Detach(IVoterObserver observer);

            // Notify all observers about an event.
            void Notify();
        }



        /// <summary>
        /// ////////////////
        /// </summary>

        // The Subject owns some important state and notifies observers when the
        // state changes.
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

                

                this.Notify();
            }
        }

        // Concrete Observers react to the updates issued by the Subject they had
        // been attached to.
       
        class EmailService : IVoterObserver
        {
            public void Update(IVoterSubject subject)
            {   

                //I--> concrete class to access its data
                Subject VoterSubject = subject as Subject;

                if (VoterSubject != null || VoterSubject.RegisteredVoter == null)
                    return;

                SendEmail(VoterSubject.RegisteredVoter.Email);
            }
            private void SendEmail(string votersemail)
            {    
                
                var sender = "Hanatheapprentice@gmail.com";
                var apppass = " ";
               

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(sender, apppass)
                };

                var actualEmail = new MailMessage
                {
                    From = new MailAddress(sender),

                    Subject = "Voter Confirmation",
                    Body = "Thank you for registering to vote, ypur vote makes a difference!",
                    IsBodyHtml = true
                };

                actualEmail.To.Add(votersemail);
                client.Send(actualEmail);


                

               
            }
        }
    }
}
