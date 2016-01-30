using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

namespace Highworm {
    /// <summary>
    /// The factory produces new entities.
    /// </summary>
    public partial class Factory {
        /// <summary>
        /// The encounters factory creates and manages encounters.
        /// </summary>
        public static class ForEncounters {
            /// <summary>
            /// Create a new encounter.
            /// </summary>
            /// <typeparam name="T">
            /// The type of encounter to create.
            /// </typeparam>
            /// <returns></returns>
            public static IEncounter<IMayEncounter> Create<T>() where T : IEncounter<IMayEncounter>, new() {
                return new T();
            }
        }
    }
}