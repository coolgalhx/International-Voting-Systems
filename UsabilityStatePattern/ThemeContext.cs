using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace International_Voting_Systems.UsabilityStatePattern
{
    class ThemeContext
    {
        // A reference to the current state of the Context. 

        private ThemeState _state = null;

        public ThemeContext(ThemeState state)
        {

            TransitionTo(state);
        }

        // The Context allows changing the State object at runtime. 

        public void TransitionTo(ThemeState state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}.");

            _state = state;

            _state.SetContext(this);
        }



        // The Context delegates part of its behavior to the current State 
        // object. 

        public void Request1(System.Windows.Window window)
        {
            _state.ApplyTheme(window);

        }

        public void Request2()
        {

            _state.Handle2();

        }

    }

}
