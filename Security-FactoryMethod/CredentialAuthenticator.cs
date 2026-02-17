using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace International_Voting_Systems.Security
{
    public class CredentialAuthenticator : IAuthenticator

    {

        public async Task<bool> AuthenticateAsync(string voterId, string code = "")

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
}
