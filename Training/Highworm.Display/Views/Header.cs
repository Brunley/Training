using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;


namespace Highworm.Views {
    /// <summary>
    /// Represents a view of the program header.
    /// </summary>
    public class Header : View<string> {
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
            Builder.Append($"{new string('-', Console.WindowWidth)}\r");
            Builder.Append($"{"   "}The Enchanted Hills\n");
            Builder.Append($"{"   "}Project Highworm v.01\n");
            Builder.Append($"{new string('-', Console.WindowWidth)}\r");
            // print the component
            return Builder;
        }
    }
}