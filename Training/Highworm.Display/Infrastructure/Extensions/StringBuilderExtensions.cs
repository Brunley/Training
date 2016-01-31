using System;
using System.Linq;
using System.Linq.Expressions;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm {
    public static partial class StringBuilderExtensions {
        /// <summary>
        /// Take a step before another operation.
        /// </summary>
        /// <param name="source">
        /// The <see cref="System.Text.StringBuilder"/>.
        /// </param>
        /// <param name="paintable">
        /// A paintable view.
        /// </param>
        /// <returns></returns>
        public static string Paint(this StringBuilder source, IMayPaint paintable) {
            paintable.OnPaint(paintable.State.Current); return source.ToString();
        }
    }
}