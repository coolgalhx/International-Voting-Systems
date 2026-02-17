using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems.UsabilityStatePattern
{
    // The base State class declares methods that all Concrete State should 
    // implement and also provides a backreference to the Context object, 
    // associated with the State. This backreference can be used by States to 
    // transition the Context to another State. 

    abstract class ThemeState
    {

        protected ThemeContext _context;

        public void SetContext(ThemeContext context)
        {

            _context = context;

        }

        public abstract void ApplyTheme(System.Windows.Window window);

        public abstract void Handle2();

    }
}
