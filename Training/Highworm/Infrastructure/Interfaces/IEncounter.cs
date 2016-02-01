using System;
using System.Collections.Generic;

namespace Highworm {
    /// <summary>
    /// A contract for defining a type of encounter.
    /// </summary>
    /// <typeparam name="T">A type that implements <see cref="Highworm.IMayEncounter"/></typeparam>
    public interface IEncounter<T> where T : IMayEncounter {
        /// <summary>
        /// The collection of participants.
        /// </summary>
        IList<T> Participants { get; set; }

        /// <summary>
        /// Retrieve a new identity for the given type.
        /// </summary>
        /// <param name="type">The type to retrieve an identity for.</param>
        /// <returns>
        /// A new identity for the given type.
        /// </returns>
        HiLo Identity<T>();
    }
}