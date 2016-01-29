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
        /// The participants factory creates and manages characters.
        /// </summary>
        public static class ForParticipants {
            /// <summary>
            /// Create a new participation elligible entity.
            /// </summary>
            /// <param name="name">
            /// The name of the participation elligible entity to create.
            /// </param>
            /// <returns></returns>
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