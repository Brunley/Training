using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

namespace Highworm {
    /// <summary>
    /// The factory produces new entities with initialized settings and properties.
    /// </summary>
    public partial class Factory {
        /// <summary>
        /// A static class used to create and manage entities that inherit from <see cref="Highworm.IEncounter{T}"/>.
        /// </summary>
        public static class ForEncounters {
            /// <summary>
            /// Create a new, empty <see cref="Highworm.IEncounter{T}"/> with no participants.
            /// </summary>
            /// <typeparam name="T">The type of <see cref="Highworm.IEncounter{T}"/> to create.</typeparam>
            /// <returns>
            /// The created <see cref="Highworm.IEncounter{T}"/>.
            /// </returns>
            public static IEncounter<IMayEncounter> Create<T>() where T : IEncounter<IMayEncounter>, new() {
                return new T();
            }
        }
    }
}