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
    public static partial class StringExtensions {
        /// <summary>
        /// Write the <see cref="System.Text.StringBuilder"/> to the <see cref="System.Console"/>.
        /// </summary>
        /// <param name="source"> The <see cref="System.Text.StringBuilder"/> to write.</param>
        public static StringBuilder Write(this StringBuilder source) {
            Console.Write(source); return source;
        }

        /// <summary>
        /// A simple step that returns a non-null, initialized <see cref="System.Text.StringBuilder"/>.
        /// </summary>
        /// <param name="source">The <see cref="System.Text.StringBuilder"/> to return.</param>
        /// <returns>
        /// The initialized, non-null <see cref="System.Text.StringBuilder"/> for method chaining.
        /// </returns>
        public static StringBuilder Then(this StringBuilder source) {
            return source;
        }

        /// <summary>
        /// A simple step that returns a non-null, initialized <see cref="System.Text.StringBuilder"/> and
        /// performs an action against it.
        /// </summary>
        /// <param name="source">The <see cref="System.Text.StringBuilder"/> to return.</param>
        /// <param name="method">The action to perform.</param>
        /// <returns>
        /// The initialized, non-null <see cref="System.Text.StringBuilder"/> for method chaining.
        /// </returns>
        public static string Then(this StringBuilder source, Func<StringBuilder> method) {
            return method().ToString();
        }

        /// <summary>
        /// Reads the console input and performs an anonymous method with it.
        /// </summary>
        /// <param name="source">The <see cref="System.Text.StringBuilder"/> to return.</param>
        /// <param name="input">The input from <see cref="System.Console.ReadLine()"/>.</param>
        /// <returns>
        /// The initialized, non-null <see cref="System.Text.StringBuilder"/> for method chaining.
        /// </returns>
        public static StringBuilder Read(this StringBuilder source, Action<string> input) {
            input(Console.ReadLine()); return source;
        }
    }
}