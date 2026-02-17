using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems.Security
{
    public interface IAuthenticator

    {

        Task<bool> AuthenticateAsync(string voterId, string code = "");

    }
}
