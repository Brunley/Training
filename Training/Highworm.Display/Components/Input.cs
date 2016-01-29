using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;


namespace Highworm.Displays {
    /// <summary>
    /// An input aware command
    /// </summary>
    public abstract class Input : Printable<string> {
        /// <summary>
        /// The printable component's output text.
        /// </summary>
        /// <returns>
        /// A string to write at the component's cursor position.
        /// </returns>
        protected abstract override void Paint();
    
        /// <summary>
        /// The specific name and path of the input command.
        /// </summary>
        protected abstract string Name { get; }
    }
}