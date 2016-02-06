using System;
using System.Collections.Generic;

namespace Highworm.Models {
    /// <summary>
    /// A character that may participate in encounters.
    /// </summary>
    [Identity("players")]
    public class Character : IMayParticipate {
        /// <summary>
        /// The character's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The character's statistical data.
        /// </summary>
        public IDictionary<string, decimal> Statistics { get; set; } = new Dictionary<string, decimal>();

        /// <summary>
        /// Create a new, empty <see cref="Highworm.IMayParticipate"/> with default data.
        /// </summary>
        /// <typeparam name="T">A type that inherits from <see cref="Highworm.IMayParticipate"/>.</typeparam>
        /// <returns>
        /// The created <see cref="Highworm.IMayParticipate"/>.
        /// </returns>
        public static T Create<T>(string name) where T : IMayParticipate, new() => new T() {
            Name = name,
            Statistics = new Dictionary<string, decimal> {
                { "Health", 20 },
                { "Initiative", new Irregular().Next(0, 10) },
                { "Mana", 15 },
                { "Health Replenishment", 5 },
                { "Mana Replenishment", 5 },
                { "Energy", 1 },
                { "Force", 4 }
            }
        };
    }
}