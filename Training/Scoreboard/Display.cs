using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;


namespace Highworm.Scoreboard {
    /// <summary>
    /// Displays all information about the current game.
    /// </summary>
    public class Display {

        /// <summary>
        /// Initialize a new game display
        /// </summary>
        public Display() {
            Components = new Dictionary<int, Printable>();
        }

        /// <summary>
        /// Paint the entire display to the screen.
        /// </summary>
        /// <param name="clear">
        /// Determines whether the entire display should be cleared first
        /// </param>
        public void Paint(bool clear = true) {
            // if we need to, clear the console first
            if(clear) Console.Clear();

            // sort all of the components to make sure
            // they are displayed in the desired order
            // and then draw each component in order
            foreach (var component in Components.OrderBy(n => n.Key))
                component.Value.Write();
        }

        /// <summary>
        /// Read a line of input from the console.
        /// </summary>
        /// <returns>
        /// The text that was input
        /// </returns>
        public string ReadLine() {
            return Read = Console.ReadLine();
        }

        /// <summary>
        /// The text read from last input
        /// </summary>
        public string Read {
            get;
            set;
        }

        /// <summary>
        /// All of the components for building the scoreboard display
        /// </summary>
        public IDictionary<int, Printable> Components {
            get;
            set;
        }
    }
}