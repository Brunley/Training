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
    public class Participants : Printable<IList<IMayEncounter>, Views.Participants> {
        /// <summary>
        /// The printable component's output text.
        /// </summary>
        /// <returns>
        /// A string to write at the component's cursor position.
        /// </returns>
        protected override void Paint() {
            // Write the View
            Builder.Append(View);
            // print the component
            Console.Write(Builder);
        }
    }
}