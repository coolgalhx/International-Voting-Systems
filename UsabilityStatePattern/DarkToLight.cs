using Dark.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems.UsabilityStatePattern
{
    public class DarkToLight : ThemeState
    {

        public override void ApplyTheme(System.Windows.Window window)
        {
            DarkNet.Instance.SetWindowThemeWpf(window, Theme.Light);


        }

        public override void Handle2()
        {

            _context.TransitionTo(new LightToDark());

        }

    }
}
