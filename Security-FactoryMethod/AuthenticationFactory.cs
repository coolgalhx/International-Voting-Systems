using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems.Security
{
    public abstract class AuthenticationFactory

    {

        public abstract IAuthenticator FactoryMethod();

    }
}
