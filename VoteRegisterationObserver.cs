using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static International_Voting_Systems.MainDBContext;
using System.Windows;
using System.Xml.Linq;
using System.Net.Mail;
using static International_Voting_Systems.VoteRegisterationObserver;
using System.Net;
using System.Runtime.InteropServices.JavaScript;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;



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

                this.RegisteredVoter = voter;

                this.Notify();
            }
        }

        // Concrete Observers react to the updates issued by the Subject they had
        // been attached to.

        public class EmailService : IVoterObserver
        {
            public void Update(IVoterSubject subject)
            {

                //I--> concrete class to access its data
                Subject VoterSubject = subject as Subject;

                if (VoterSubject == null || VoterSubject.RegisteredVoter == null)
                    return;

                SendEmail(VoterSubject.RegisteredVoter.Email);
            }
            public void SendEmail(string votersemail)

            //https://github.com/jstedfast/MailKit?tab=readme-ov-file
            {
                try
                {
                    var sender = "Hanatheapprentice@gmail.com";
                    var apppass = "owrknppmatzfhfhk";


                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("International Voting System", sender));
                    message.To.Add(new MailboxAddress("", votersemail));
                    message.Subject = "Voter Registered";

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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                

            }
        }
    }
}