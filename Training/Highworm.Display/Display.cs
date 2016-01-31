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
            Views = new List<View>(); State = new State(); State.Change += this.OnStateChange;
        }
        /// <summary>
        /// Create a new dictionary compatible key-value pair for a printable component.
        /// </summary>
        /// <typeparam name="T">
        /// The type of <see cref="View"/> to create.
        /// </typeparam>
        /// <returns></returns>
        public static T Create<T>() where T : View, new() {
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

        /// <summary>
        /// Raised whenever a view tries to draw.
        /// </summary>
        /// <param name="view"></param>
        public void OnPaintingView(View view) {
            if (view.Pass == Pass)
                view.Draw(State.Current);
        }

        /// <summary>
        /// Paint the entire display to the screen.
        /// </summary>
        public void Paint() {
            // clear the console first
            Console.Clear();
            // sort all of the components to make sure
            // they are displayed in the desired order
            // and then draw each component in order
            Views.Where(n => n.State.Paintable(State.Current)).ForEach(view => { 
                view.Paint();
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

        /// <summary>
        /// Indicates what the refresh is.
        /// </summary>
        public int Pass {
            get;
            set;
        }
    }
}