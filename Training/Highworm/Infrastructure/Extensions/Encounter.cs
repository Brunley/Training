using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

namespace Highworm {
    /// <summary>
    /// Methods used to interact with encounters.
    /// </summary>
    public static class EncounterExtensions {
        /// <summary>
        /// Register a participant for an encounter
        /// </summary>
        /// <typeparam name="T"> The type of participants.</typeparam>
        /// <param name="encounter">The encounter to register a participant for.</param>
        /// <param name="name">The name of a participant to register.</param>
        public static void Register<T>(this IEncounter<IMayEncounter> encounter, string name) where T : IMayParticipate, new() {
            encounter.Register(Models.Character.Create<T>(name));
        }

        /// <summary>
        /// Register a participant for an encounter
        /// </summary>
        /// <typeparam name="T"> The type of participants.</typeparam>
        /// <param name="encounter">The encounter to register a participant for.</param>
        /// <param name="participant">The participant to register.</param>
        public static void Register<T>(this IEncounter<IMayEncounter> encounter, T participant) where T : IMayParticipate {
            encounter.Participants.Add(new ViewModels.Participant {
                Who = participant,
                Order = 0,
                Id = encounter.Identity<T>().Next()
            });
        }

        /// <summary>
        /// Sort and order the participants based on their initiative.
        /// </summary>
        /// <typeparam name="T">The type of entities to sort.</typeparam>
        /// <param name="encounter">The encounter to sort.</param>
        /// <param name="modifier">The statistic to use as a modifier.</param>
        /// <returns>
        /// The collection of <see cref="Highworm.ViewModels.Participant"/>s.
        /// </returns>
        public static IList<T> Sort<T>(this IEncounter<T> encounter, string modifier) where T: class, IMayEncounter {
            // roll initiative for each participant
            encounter.Participants.ForEach(participant => {
                participant.Order = new Roll(1, 20).Next().First() + (participant[modifier]);
            });
            // return the adjusted collection, sorted
            return encounter.Participants.OrderBy(n => n.Order).ToList();
        }
    }
}