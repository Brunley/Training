using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm.Views {
    /// <summary>
    /// Represents a view of a simple string.
    /// </summary>
    public class Text : View<string> {
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
            throw new NotImplementedException();
        }
    }
}