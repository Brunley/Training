using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;


namespace Highworm.Displays {
    /// <summary>
    /// The Header is printed at the top of the console.
    /// </summary>
    public class Header : Printable<IList<IMayEncounter>, Views.Participants> {
        /// <summary>
        /// The printable component's output text.
        /// </summary>
        /// <returns>
        /// A string to write at the component's cursor position.
        /// </returns>
        protected override void Paint() {

            // create the top line by repeating '-' for the entire width
            Builder.Append($"{new string('-', Console.WindowWidth)}\r");
            Builder.Append($"{"Name",5}{"Statistics",25}\n");
            Builder.Append($"{new string('-', Console.WindowWidth)}\r");
            // print the component
            Console.Write(Builder);
        }
    }
}