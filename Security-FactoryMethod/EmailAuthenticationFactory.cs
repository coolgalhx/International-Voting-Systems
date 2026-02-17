using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems.Security
{
    public class EmailAuthenticationFactory : AuthenticationFactory

    {

        public override IAuthenticator FactoryMethod()

        {

            return new EmailAuthenticator();

        }

    }
}
