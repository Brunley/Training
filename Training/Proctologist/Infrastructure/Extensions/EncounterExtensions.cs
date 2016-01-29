using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

namespace Highworm {
    public static class EncounterExtensions {
        /// <summary>
        /// Register a participant for an encounter
        /// </summary>
        /// <typeparam name="T">
        /// The type of participants.
        /// </typeparam>
        /// <param name="encounter">
        /// The encounter to register a participant for.
        /// </param>
        /// <param name="participant">
        /// The participant to register
        /// </param>
        public static void Register<T>(this IEncounter<IMayEncounter> encounter, T participant) where T : IMayParticipate {
            encounter.Participants.Add(new ViewModels.Participant {
                Character = participant,
                Order = 0
            });
        }
    }
}