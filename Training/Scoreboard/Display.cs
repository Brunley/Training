using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;


namespace System.Display {
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
        /// Create a new dictionary compatible key-value pair for a printable component.
        /// </summary>
        /// <typeparam name="T">
        /// The type of <see cref="System.Printable"/> to create.
        /// </typeparam>
        /// <returns></returns>
        public static T Create<T>() where T : Printable, new() {
            // create the new printable component
            return new T();
        }

        /// <summary>
        /// Create a new dictionary compatible key-value pair for a printable component.
        /// </summary>
        /// <typeparam name="T">
        /// The type of <see cref="System.Printable"/> to create.
        /// </typeparam>
        /// <param name="action">
        /// A custom expression to execute against the <see cref="System.Printable"/>
        /// </param>
        /// <returns></returns>
        public static T Create<T>(Action<T> action) where T : Printable, new() {
            var printable = Create<T>();
            // perform any needed context actions with the new component
            action(printable);
            // return the newly created and wired component
            return printable;
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