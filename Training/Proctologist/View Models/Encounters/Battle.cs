using System;
using System.Collections.Generic;

namespace Highworm.ViewModels {
    /// <summary>
    /// A combat encounter
    /// </summary>
    public class Battle : IEncounter<IMayEncounter> {
        public IList<IMayEncounter> Participants {
            get;
            set;
        }

        /// <summary>
        /// Initialize a new Battle
        /// </summary>
        public Battle() {
            Participants = new List<IMayEncounter>();
        }

        public void Register<T>(T participant) where T : IMayParticipate {
            Participants.Add(new Participant {
                Character = participant,
                Order = 0
            });
        }
    }
}