using System.Collections.Generic;

namespace Highworm {
    public class Character {
        public Character() {
            Statistics = new List<Statistic>();
        }

        /// <summary>
        /// The character's name.
        /// </summary>
        public string Name {
            get;
            set;
        }

        public IList<Statistic> Statistics {
            get;
            set;
        }
    }
}