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
    public class Header : View<string> {
        /// <summary>
        /// The printable component's output text.
        /// </summary>
        /// <returns>
        /// A string to write at the component's cursor position.
        /// </returns>
        public override void Compose(string displayState) {
            // create the top line by repeating '-' for the entire width
            ViewBuilder.Append($"{new string('-', Console.WindowWidth)}\r");
            ViewBuilder.Append($"{"   "}The Enchanted Hills\n");
            ViewBuilder.Append($"{"   "}Project Highworm v.01\n");
            ViewBuilder.Append($"{new string('-', Console.WindowWidth)}\r");
        }
    }
}