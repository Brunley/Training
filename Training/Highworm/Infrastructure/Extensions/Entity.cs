using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;


namespace Highworm {
    /// <summary>
    /// Methods for extending behaviors on <see cref="System.Object"/>
    /// </summary>
	public static class EntityExtensions {
        /// <summary>
        /// Unwraps a class and casts it to another type.
        /// </summary>
        /// <typeparam name="T">The proxied class</typeparam>
        /// <returns>
        /// A class that is unproxied and unwrapped.
        /// </returns>
        public static T As<T>(this object source) where T : class {
            return source as T;
        }

        /// <summary>
        /// Attempt to parse the value of a given index in a <see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/>
        /// </summary>
        /// <param name="source"><see cref="System.Collections.Generic.IDictionary{TKey, TValue}"/></param>
        /// <param name="value">The key to parse.</param>
        /// <returns>
        /// Returns the boolean value of the string, if it is not null; Otherwise false.
        /// </returns>
        public static Boolean TryParse(this IDictionary<string, string> source, string value) {
            if (source?[value] == null)
                return false;
            return Boolean.Parse(source[value]);
        }

        /// <summary>
		/// Get a specific attribute from an entity.
		/// </summary>
		/// <typeparam name="TAttribute">The attribute to look for.</typeparam>
		/// <typeparam name="TValue">The type to return from the delegate.</typeparam>
		/// <param name="type">The type to look for an attribute on.</param>
		/// <param name="value">A delegate used for finding the attribute. </param>
		/// <returns>
		/// Returns the value of the attribute, if it is found.
		/// </returns>
        public static TValue Get<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> value)
            where TAttribute : Attribute {

            // try to get the first occurance of the requested attribute
            var attributes = type
                .GetCustomAttributes(typeof(TAttribute), true);

            // if we discover an attribute, perform the value selector
            if (attributes.Length != 0)
                return value(attributes.FirstOrDefault().As<TAttribute>());
            // if we did not, then return a default or null value
            return default(TValue); // this needs work.
        }

        /// <summary>
        /// Get an instance and value of <see cref="Highworm.IdentityAttribute"/> from a given type.
        /// </summary>
        /// <typeparam name="TType">A type that implements <see cref="Highworm.IdentityAttribute"/></typeparam>
        /// <param name="type">The <typeparamref name="TType"/></param>.
        /// <returns>The <see cref="Highworm.IdentityAttribute.Name"/> field.</returns>
        public static string Identity<TType>(this Type type) where TType: IHasIdentity {
            return typeof(TType).Get<IdentityAttribute, string>(attribute => attribute.Name);
        }
    }
}