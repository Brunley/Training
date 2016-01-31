using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;


namespace Highworm.Displays {
    /// <summary>
    /// The menu is printed at the top of the console.
    /// </summary>
    public class Menu : View<string> {
        /// <summary>
        /// The printable component's output text.
        /// </summary>
        /// <returns>
        /// A string to write at the component's cursor position.
        /// </returns>
        public override void OnPaint(string state) {
            // create the top line by repeating '-' for the entire width
            ViewBuilder.Append($"-- Menu {new string('-', 30)}\n");
            ViewBuilder.Append($"  {"[ ]",-6}:\tReturn to Menu\n");
            // only print the command to exit the entire program when the
            // state is at the base level.
            OnState("root", builder => {
                builder.Append($"  {"[esc]",-6}:\tExit\n");
            });

            ViewBuilder.Append($"  {"[add]",-6}:\tAdd Participants\n");
        }
    }
}