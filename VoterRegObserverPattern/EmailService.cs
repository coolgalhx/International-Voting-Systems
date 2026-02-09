using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace International_Voting_Systems.VoterRegObserver
{
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
