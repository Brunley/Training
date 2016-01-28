using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;


namespace Highworm.Controllers {
    public class EncounterController {
        /// <summary>
        /// Create a new encounter.
        /// </summary>
        /// <typeparam name="T">
        /// The type of encounter to create.
        /// </typeparam>
        /// <returns></returns>
        public IEncounter<IMayEncounter> Create<T>() where T : IEncounter<IMayEncounter> {
            return default(T);
        }

        /// <summary>
        /// Sort and order the participants based on their initiative.
        /// </summary>
        /// <typeparam name="T">
        /// The type of entities to sort.
        /// </typeparam>
        /// <param name="participants">
        /// The participants to sort.
        /// </param>
        /// <param name="modifier">
        /// The statistic to use as a modifier.
        /// </param>
        /// <returns></returns>
        public IList<T> Sort<T>(IList<T> participants, string modifier) where T : IMayEncounter {
            // roll initiative for each participant
            foreach (var participant in participants)
                participant.Order = new Roll(1, 20).Next().First() + (participant.Character.Statistics[modifier]);
            // return the adjusted collection, sorted
            return participants.OrderBy(n => n.Order).ToList();
        }
    }
}