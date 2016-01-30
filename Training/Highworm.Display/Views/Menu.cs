﻿using System;
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
        public override void Paint() {
            // create the top line by repeating '-' for the entire width
            Builder.Append($"-- Menu {new string('-', 20)}\n");
            Builder.Append($"  [A]:\tAdd Participants\n");
        }
    }
}