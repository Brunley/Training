using System;
using System.Linq;
using System.Linq.Expressions;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm {
    /// <summary>
    /// Methods used to interact with classes that implement <see cref="System.Collections.IEnumerable"/>.
    /// </summary>
    public static class EnumerableExtensions {
        /// <summary>
        /// Performs the specified action on each element of the <see cref="System.Collections.IList"/>
        /// </summary>
        /// <typeparam name="T">The type to enumerate.</typeparam>
        /// <param name="source">The List to enumerate.</param>
        /// <param name="action">The action to perform.</param>
        /// <returns>
        /// The collection that implements <see cref="System.Collections.IList"/>.
        /// </returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            var enumerable = source.ToList<T>(); enumerable.ForEach(action); return enumerable;
        }

        /// <summary>
        /// Performs the specified action on each element of the <see cref="System.Collections.IList"/>
        /// </summary>
        /// <typeparam name="T">The type to enumerate.</typeparam>
        /// <param name="source">The List to enumerate.</param>
        /// <param name="action">The action to perform.</param>
        /// <returns>
        /// The collection that implements <see cref="System.Collections.IList"/>.
        /// </returns>
        public static IList<T> EachNotNull<T>(this IList<T> source, Action<T> action) {
            if (source.Count > 0) foreach (var i in source) action(i); return source;
        }

        /// <summary>
        /// Performs the specified action on each element of the <see cref="System.Collections.IList"/>
        /// </summary>
        /// <typeparam name="T">The type to enumerate.</typeparam>
        /// <param name="source">The List to enumerate.</param>
        /// <param name="action">The action to perform.</param>
        /// <returns>
        /// The collection that implements <see cref="System.Collections.IList"/>.
        /// </returns>
        public static IList<T> NotNull<T>(this IList<T> source, Action action) {
            if (source.Count > 0) action(); return source;
        }

        /// <summary>
        /// Append text to a <see cref="System.Text.StringBuilder"/> if a collection is not empty.
        /// </summary>
        /// <typeparam name="T">The type to enumerate.</typeparam>
        /// <param name="source">The List to enumerate.</param>
        /// <param name="stringBuilder">The <see cref="System.Text.StringBuilder"/> to append to.</param>
        /// <param name="append">The text to append.</param>
        /// <returns></returns>
        public static IList<T> Append<T>(this IList<T> source, StringBuilder stringBuilder, string append) {
            if (source.Count > 0) stringBuilder.Append(append); return source;
        }
    }
}