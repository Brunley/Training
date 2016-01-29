using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm {
    /// <summary>
    /// An interpreter is used to design the display behavior
    /// of a data-backed entity.
    /// </summary>
    /// <typeparam name="T">
    /// The entity that is being interpreted
    /// </typeparam>
    public abstract class Interpreter<T> {
        /// <summary>
        /// The data that is going to be interpreted.
        /// </summary>
        public abstract T Content { get; set; }

        /// <summary>
        /// Paints the value using the interpretation
        /// </summary>
        public abstract void Paint();
    }
}