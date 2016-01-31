using System.Collections.Generic;

namespace Highworm.Models {
    /// <summary>
    /// A character that may participate in encounters.
    /// </summary>
    public class Character : IMayParticipate {
        /// <summary>
        /// Initialize a new character.
        /// </summary>
        public Character() {
            Statistics = new Dictionary<string, decimal>();
        }

        /// <summary>
        /// The character's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The character's statistical data.
        /// </summary>
        public IDictionary<string, decimal> Statistics { get; set; }
    }
}