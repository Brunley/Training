using System;
using System.Linq;

namespace System {
    public static class ObjectExtensions {
        /// <summary>
        /// Return an object as requested type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T As<T>(this object source) {
            return (T)source;
        }
    }
}