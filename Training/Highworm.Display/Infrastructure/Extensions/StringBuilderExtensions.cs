using System;
using System.Linq;
using System.Linq.Expressions;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm {
    /// <summary>
    /// Methods for working with <see cref="System.Text.StringBuilder"/>.
    /// </summary>
    public static partial class StringBuilderExtensions {
        /// <summary>
        /// Compose and build an entity that implements <see cref="Highworm.IMayPaint"/>, translating
        /// all of the <see cref="System.Text.StringBuilder"/> into a string.
        /// </summary>
        /// <param name="source">The <see cref="System.Text.StringBuilder"/> to use for painting.</param>
        /// <param name="paintable">The view that implements <see cref="Highworm.IMayPaint"/>.</param>
        /// <returns>
        /// Returns the results as a string of text.
        /// </returns>
        public static string Paint(this StringBuilder source, IMayPaint paintable) {
            paintable.Compose(paintable.ViewState.Current); return source.ToString();
        }
    }
}