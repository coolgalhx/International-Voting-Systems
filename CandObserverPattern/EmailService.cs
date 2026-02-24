using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;

namespace International_Voting_Systems.CandObserverPattern
{
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
                var apppass = ConfigurationManager.AppSettings["EmailPassword"]; ;

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("International Voting System", candidateEmail));
                message.To.Add(new MailboxAddress("", candidateEmail));
                message.Subject = "Candidate Registered";

                message.Body = new TextPart("plain")
                {
                    Text = @"Candidate registeration confirmed",


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

