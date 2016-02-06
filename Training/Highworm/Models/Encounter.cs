using System;
using System.Collections.Generic;

namespace Highworm.Models {
    /// <summary>
    /// An encounter that may be treated as adventurous, exploration, etc.
    /// </summary>
    public abstract class Encounter : IEncounter<IMayEncounter> {
        /// <summary>
        /// A collection of sortable participants.
        /// </summary>
        public IList<IMayEncounter> Participants { get; set; } = new List<IMayEncounter>();

        /// <summary>
        /// A collection of identity generators.
        /// </summary>
        private IDictionary<string, HiLo> HiLo { get; set; } = new Dictionary<string, HiLo>();

        /// <summary>
        /// Retrieve a new identity for the given type.
        /// </summary>
        /// <returns>
        /// A new identity for the given type.
        /// </returns>
        public HiLo Identity<T>() => HiLo?[typeof(T).Get<IdentityAttribute, string>(attribute => attribute.Name)];

        /// <summary>
        /// Create a new, empty <see cref="Highworm.Models.Encounter"/> with no participants.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Highworm.Models.Encounter"/> to create.</typeparam>
        /// <typeparam name="U">The type of <see cref="Highworm.IMayEncounter"/> to use.</typeparam>
        /// <returns>
        /// The created <see cref="Highworm.Models.Encounter"/>.
        /// </returns>
        public static Encounter Create<T, U>() where T : Encounter, new() where U : IMayEncounter, IHasIdentity => new T() {
            HiLo = new Dictionary<string, HiLo> {
                [typeof(U).Identity<U>()] = new HiLo<U>(typeof(U).Identity<U>()) 
            },
            Participants = new List<IMayEncounter>()
        };
    }
}