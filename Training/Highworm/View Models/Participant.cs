using System.Collections.Generic;

namespace Highworm.ViewModels {
    /// <summary>
    /// A participant in an encounter.
    /// </summary>
    public class Participant: IMayEncounter {
        /// <summary>
        /// The character that is participating.
        /// </summary>
        public IMayParticipate Character {
            get;
            set;
        }

        /// <summary>
        /// The character's turn order.
        /// </summary>
        public decimal Order {
            get;
            set;
        }

        /// <summary>
        /// Shortcut indexer for statistics
        /// </summary>
        /// <param name="statistic"></param>
        /// <returns></returns>
        public decimal this[string statistic] {
            get { return Character.Statistics[statistic]; }
            set { Character.Statistics[statistic] = value; }
        }
    }
}