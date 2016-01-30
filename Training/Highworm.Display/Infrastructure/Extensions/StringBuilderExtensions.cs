using System;
using System.Linq;
using System.Linq.Expressions;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace System.Text {
    public static partial class StringBuilderExtensions {
        /// <summary>
        /// Take a step before another operation.
        /// </summary>
        /// <param name="source">
        /// The <see cref="System.Text.StringBuilder"/>.
        /// </param>
        /// <param name="method">
        /// The method to perform.
        /// </param>
        /// <returns></returns>
        public static string Paint(this StringBuilder source, IMayPaint paintable) {
            paintable.OnPaint(); return source.ToString();
        }
    }
}