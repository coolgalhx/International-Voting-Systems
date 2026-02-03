using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static International_Voting_Systems.MainDBConext;
using MimeKit;
using System.Windows;

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
                try
                {
                    var sender = "hanatheapprentice@gmail.com";
                    var apppass = "owrknppmatzfhfhk";

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("International Voting System", candidateEmail));
                    message.To.Add(new MailboxAddress("", candidateEmail));
                    message.Subject = "Candidate Registered";

                    message.Body = new TextPart("plain")
                    {
                        Text = @"Voter registeration confirmed",


                    };
                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {

                        //https://stackoverflow.com/questions/76153404/i-get-an-error-when-using-mailkit-to-send-a-gmail-email
                        client.CheckCertificateRevocation = false;
                        client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);


                        // Note: only needed if the SMTP server requires authentication
                        client.Authenticate(sender, apppass);
                        client.Send(message);
                        client.Disconnect(true);

                    }

                    MessageBox.Show("Email successfully sent");

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }




            }



        }
    }
}

