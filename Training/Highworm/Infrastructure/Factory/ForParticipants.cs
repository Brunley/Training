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
        /// A static class used to create and manage entities that inherit from <see cref="Highworm.IMayParticipate"/>.
        /// </summary>
        public static class ForParticipants {
            /// <summary>
            /// Create a new, empty <see cref="Highworm.IMayParticipate"/> with default data.
            /// </summary>
            /// <typeparam name="T">A type that inherits from <see cref="Highworm.IMayParticipate"/>.</typeparam>
            /// <returns>
            /// The created <see cref="Highworm.IMayParticipate"/>.
            /// </returns>
            public static T Create<T>(string name) where T : IMayParticipate, new() {
                return new T() {
                    Name = name,
                    Statistics = new Dictionary<string, decimal> {
                        { "Health", 20 },
                        { "Initiative", 0 },
                        { "Mana", 15 },
                        { "Health Replenishment", 5 },
                        { "Mana Replenishment", 5 },
                        { "Energy", 1 },
                        { "Force", 4 }
                    }
                };
            }
        }
    }
}