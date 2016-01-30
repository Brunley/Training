using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm {
    /// <summary>
    /// A view is used to design the display behavior
    /// of a data-backed entity.
    /// </summary>
    /// <typeparam name="T">
    /// The entity that is being interpreted
    /// </typeparam>
    public abstract class View<T> {
        /// <summary>
        /// Initialize a new Interpreter
        /// </summary>
        protected View() {
            Builder = new StringBuilder();
        }

        /// <summary>
        /// The data that is going to be interpreted.
        /// </summary>
        public abstract T Content { get; set; }

        /// <summary>
        /// Paints the value using the interpretation
        /// </summary>
        public abstract StringBuilder Compose();

        /// <summary>
        /// Converts this View to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return Builder.Clear().Then(Compose);
        }

        /// <summary>
        /// A string builder used for presentation.
        /// </summary>
        protected StringBuilder Builder {
            get;
            set;
        }
    }
}