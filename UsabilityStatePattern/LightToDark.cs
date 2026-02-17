using Dark.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems.UsabilityStatePattern
{
    class LightToDark : ThemeState
    {

        public override void ApplyTheme(System.Windows.Window window)
        {

            DarkNet.Instance.SetWindowThemeWpf(window, Theme.Dark);
            // _context.TransitionTo(new DarkToLight());
        }

        public override void Handle2()
        {

            this._context.TransitionTo(new LightToDark());
        }

    }
}
