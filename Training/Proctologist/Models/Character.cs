using System.Collections.Generic;

namespace Highworm {
    public class Character {
        public Character() {
            Statistics = new Dictionary<string, decimal>();
        }

        /// <summary>
        /// The character's name.
        /// </summary>
        public string Name {
            get;
            set;
        }

        public IDictionary<string, decimal> Statistics {
            get;
            set;
        }
    }
}