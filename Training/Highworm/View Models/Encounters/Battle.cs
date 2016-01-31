﻿using System;
using System.Collections.Generic;

namespace Highworm.ViewModels {
    /// <summary>
    /// An encounter that may be treated as combat, perilous, etc.
    /// </summary>
    public class Battle : IEncounter<IMayEncounter> {
        /// <summary>
        /// A collection of sortable participants.
        /// </summary>
        public IList<IMayEncounter> Participants { get; set; }

        /// <summary>
        /// Initialize a new Battle with no participants.
        /// </summary>
        public Battle() {
            Participants = new List<IMayEncounter>();
        }
    }
}