using System;
using System.Collections.Generic;

namespace Highworm.ViewModels {
    /// <summary>
    /// An encounter that may be treated as adventurous, exploration, etc.
    /// </summary>
    public class Adventure : IEncounter<IMayEncounter> {
        /// <summary>
        /// A collection of sortable participants.
        /// </summary>
        public IList<IMayEncounter> Participants { get; set; }

        /// <summary>
        /// Initialize a new adventure with no participants.
        /// </summary>
        public Adventure() {
            Participants = new List<IMayEncounter>();
        }
    }
}