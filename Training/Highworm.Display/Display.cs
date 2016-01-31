using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;



namespace Highworm.Displays {
    /// <summary>
    /// Displays all information about the current game.
    /// </summary>
    public class Display {

        /// <summary>
        /// Initialize a new game display
        /// </summary>
        public Display() {
            Views = new List<View>(); State = new State(); State.Change += OnStateChange;
        }

        /// <summary>
        /// Repaint the screen when state changes.
        /// </summary>
        /// <param name="state"></param>
        private Display OnStateChange(string state) {
            Increment();  Paint();  return this;
        }

        /// <summary>
        /// Create a new dictionary compatible key-value pair for a printable component.
        /// </summary>
        /// <typeparam name="T">
        /// The type of <see cref="View"/> to create.
        /// </typeparam>
        /// <returns></returns>
        public static T Create<T>() where T : View, new() {
            // create the new printable component
            return new T();
        }

        /// <summary>
        /// Create a new dictionary compatible key-value pair for a printable component.
        /// </summary>
        /// <typeparam name="T">
        /// The type of <see cref="View"/> to create.
        /// </typeparam>
        /// <param name="action">
        /// A custom expression to execute against the <see cref="View"/>
        /// </param>
        /// <returns></returns>
        public static T Create<T>(Action<T> action) where T : View, new() {
            var printable = Create<T>(); action(printable); return printable;
        }

    
        public Display Initialize() {
            this.Views.ForEach(n => {
                n.Draw += OnDrawView;
            }); return this;
        }

        private void OnDrawView(View view) {
            if (view.Pass == Pass)
                view.OnDraw(State.Current);
        }

        /// <summary>
        /// Initialize the state and default state
        /// </summary>
        /// <param name="state">
        /// The state to initialize and set.
        /// </param>
        /// <returns></returns>
        public Display ToState(string state) {
            State.Reset(state); return OnStateChange(state);
        }

        public Display Synchronize() {
            Views.ForEach(n => { n.Pass = Pass; }); return this;
        }

        public Display Increment() {
            Pass++; return this;
        }
        /// <summary>
        /// Paint the entire display to the screen.
        /// </summary>
        /// <param name="clear">
        /// Determines whether the entire display should be cleared first
        /// </param>
        public void Paint(bool clear = true) {
            // if we need to, clear the console first
            if (clear) Console.Clear();
            // sort all of the components to make sure
            // they are displayed in the desired order
            // and then draw each component in order
            Views.Where(n => n.State.Paintable(State.Current)).ForEach(view => { 
                view.Write();
            });
        }

        /// <summary>
        /// All of the components for building the scoreboard display
        /// </summary>
        public List<View> Views {
            get;
            set;
        }

        /// <summary>
        /// The current state of the display.
        /// </summary>
        public State State {
            get;
            set;
        }

        public int Pass {
            get;
            set;
        }
    }
}