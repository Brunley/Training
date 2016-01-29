using System;
using System.Collections.Generic;

namespace Highworm.ViewModels {
    /// <summary>
    /// An exploration
    /// </summary>
    public class Exploration : IEncounter<IMayEncounter> {
        public IList<IMayEncounter> Participants {
            get;
            set;
        }

        /// <summary>
        /// Initialize a new adventure
        /// </summary>
        public Exploration() {
            Participants = new List<IMayEncounter>();
        }
    }
}