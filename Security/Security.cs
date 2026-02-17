using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace International_Voting_Systems
{
    public abstract class AuthenticationFactory

    {

        public abstract IAuthenticator FactoryMethod();

    }



    public class CredentialsAuthenticationFactory : AuthenticationFactory

    {

        public override IAuthenticator FactoryMethod()

        {

            return new CredentialAuthenticator();

        }

    }


    public class EmailAuthenticationFactory : AuthenticationFactory

    {

        public override IAuthenticator FactoryMethod()

        {

            return new EmailAuthenticator();

        }

    } 



    public interface IAuthenticator

    {

         Task<bool> AuthenticateAsync(string voterId, string code = "");

    }



    public class CredentialAuthenticator : IAuthenticator

    {

        public async Task <bool> AuthenticateAsync(string voterId, string code = "")

        {

            if (int.TryParse(voterId, out int username))

            {

                var facade = new LogInFacade();

                if (facade.LogIn(username))

                {

                    MessageBox.Show("Welcome");

                    return true;

                }

                else

                {

                    MessageBox.Show("Error: Voter ID incorrect or Account has been Suspended");

                    return false;

                }

            }

             return false;

        }

    }



    public class EmailAuthenticator : IAuthenticator

    {
       

        public async Task<bool> AuthenticateAsync(string voterId, string code = "")

        {

            using (var db = new MainDatabaseContext())

            {

                if (string.IsNullOrEmpty(code))
                {

                    int number = RandomNumberGenerator.GetInt32(100, 999);





                    var voterCode = new Code //model name 

                    {

                        VoterID = Convert.ToUInt16(voterId),

                        OTP = number,

                        ExpiryTime = DateTime.Now.AddMinutes(10),

                        IsUsed = false

                    };



                    db.Database.EnsureCreated();
                    db.Codes.Add(voterCode);

                    db.SaveChanges();





                    return await SendEmailToAuthenticate(voterId, number);

                }

                else

                {

                    var row = await db.Codes.FirstOrDefaultAsync(x =>
                       x.VoterID == Convert.ToInt32(voterId) &&
                         x.OTP == Convert.ToInt32(code) &&
                               x.IsUsed == false
                                        );




                    if (row != null && row.ExpiryTime > DateTime.Now)

                    {

                        row.IsUsed = true;

                        await db.SaveChangesAsync();



                        MessageBox.Show("Code Verified!");

                        return true;

                    }

                    else

                    {

                        MessageBox.Show("Invalid Code");

                        return false;



                    }



                }





            }

        }



        private async Task<bool> SendEmailToAuthenticate(string votersemail, int number)

        {

            try

            {

                var sender = "Hanatheapprentice@gmail.com";

                var apppass = "owrknppmatzfhfhk";



                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("International Voting System", sender));
                message.To.Add(new MailboxAddress("", votersemail));

                message.Subject = "Voter Code";

                message.Body = new TextPart("plain") { Text = $"code is: {number}." };



                using (var client = new MailKit.Net.Smtp.SmtpClient())

                {

                    client.CheckCertificateRevocation = false;

                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate(sender, apppass);

                    client.Send(message);

                    client.Disconnect(true);

                }



                MessageBox.Show("Email successfully sent");

                return true;

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

                return false;

            }

        }

    }
}
