using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Dark.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace International_Voting_Systems.UsabilityStatePattern
{
    // The Context defines the interface of interest to clients. It also 
    // maintains a reference to an instance of a State subclass, which 
    // represents the current state of the Context. 

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

    // Concrete States implement various behaviors, associated with a state of 
    // the Context. 

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

    class DarkToLight : ThemeState
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
