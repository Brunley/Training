using System;
using System.Linq;
using System.Linq.Expressions;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace System.Linq {
    public static class EnumerableExtensions {
        /// <summary>
        /// Performs the specified action on each element of the <see cref="System.Collections.IList"/>
        /// </summary>
        /// <typeparam name="T">
        /// The type to enumerate.
        /// </typeparam>
        /// <param name="source">
        /// The List to enumerate.
        /// </param>
        /// <param name="action">
        /// The action to perform.
        /// </param>
        /// <returns></returns>
        public static IList<T> EachNotNull<T>(this IList<T> source, Action<T> action) {
            if (source.Count > 0) foreach (var i in source) action(i); return source;
        }

        /// <summary>
        /// Performs an action if the given collection is not empty.
        /// </summary>
        /// <typeparam name="T">
        /// The type to enumerate.
        /// </typeparam>
        /// <param name="source">
        /// The List to enumerate.
        /// </param>
        /// <param name="action">
        /// The action to perform.
        /// </param>
        /// <returns></returns>
        public static IList<T> NotNull<T>(this IList<T> source, Action action) {
            if (source.Count > 0) action(); return source;
        }

        /// <summary>
        /// Perform an action with a <see cref="System.Text.StringBuilder"/> if the
        /// collection is not empty.
        /// </summary>
        /// <typeparam name="T">
        /// The type to enumerate.
        /// </typeparam>
        /// <param name="source">
        /// The List to enumerate.
        /// </param>
        /// <param name="builder">
        /// The <see cref="System.Text.StringBuilder"/> to use.
        /// </param>
        /// <param name="action">
        /// The action to perform.
        /// </param>
        /// <returns></returns>
        public static IList<T> Append<T>(this IList<T> source, StringBuilder action, string append) {
            if (source.Count > 0) action.Append(append); return source;
        }
    }
}