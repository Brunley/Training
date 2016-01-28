using System.Collections.Generic;

namespace Highworm.ViewModels {
    /// <summary>
    /// A participant in an encounter.
    /// </summary>
    public class Participant {
        /// <summary>
        /// The character that is participating.
        /// </summary>
        public Character Character {
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
    }
}