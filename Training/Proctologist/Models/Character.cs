using System.Collections.Generic;

namespace Highworm {
    public class Character {
        public Character() {
            Statistics = new List<Statistic>();
        }

        public IList<Statistic> Statistics {
            get;
            set;
        }
    }
}