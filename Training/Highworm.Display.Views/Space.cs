using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm.Displays.Views {
    /// <summary>
    /// Display an entire blank row.
    /// </summary>
    public class Space : View<string> {
        /// <summary>
        /// The printable component's output text.
        /// </summary>
        /// <returns>
        /// A string to write at the component's cursor position.
        /// </returns>

        public override void Compose(string displayState) {
            ViewBuilder.Append($" \n ");
        }
    }
}