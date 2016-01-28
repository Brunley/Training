using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;


namespace Highworm.Controllers {
    public class EncounterController {
        /// <summary>
        /// Roll initiative.
        /// </summary>
        /// <param name="modifier">
        /// The modifier to apply to an initiative roll.
        /// </param>
        /// <returns></returns>
        private decimal Initiative(decimal modifier) {
            return new Irregular().Next(1, 20) + modifier;
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
        /// <returns></returns>
        public IList<T> Sort<T>(IList<T> participants ) where T : ViewModels.Participant {
            // roll initiative for each participant
            foreach (var participant in participants)
                participant.Order = Initiative(participant.Character.Statistics.Single(n => n.Name == "Initiative").Value);
            // return the adjusted collection, sorted
            return participants.OrderBy(n => n.Order).ToList();
        }
    }
}