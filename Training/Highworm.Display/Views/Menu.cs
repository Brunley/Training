using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm.Views {
    /// <summary>
    /// Represents a view of the main menu.
    /// </summary>
    public class Menu : View<string> {
        /// <summary>
        /// The content that will be presented.
        /// </summary>
        public override string Content {
            get;
            set;
        }

        /// <summary>
        /// Custom logic to display the content
        /// </summary>
        public override StringBuilder Compose() {
            // create the top line by repeating '-' for the entire width
            Builder.Append($"-- Menu {new string('-', 20)}\n");
            Builder.Append($"  [A]:\tAdd Participants\n");

            return Builder;
        }
    }
}