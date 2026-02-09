using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace International_Voting_Systems.VoterAdapterPattern
{
    public interface ITranslationService
    {
        Task TranslateToFrench(params Label[] labels);
    }
}
