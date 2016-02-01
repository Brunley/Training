using System.Collections.Generic;

namespace Highworm.ViewModels {
    /// <summary>
    /// A participant in an encounter.
    /// </summary>
    [Identity("players")]
    public class Participant: IMayEncounter, IHasIdentity {
        /// <summary>
        /// The <see cref="Highworm.IMayEncounter"/> that is participating.
        /// </summary>
        public IMayParticipate Who { get; set; }

        /// <summary>
        /// The <see cref="Highworm.IMayEncounter"/>'s sortable turn order.
        /// </summary>
        public decimal Order { get; set; }

        /// <summary>
        /// The unique identity assigned by the identity generator.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A simple indexer for quickly accessing the entities statistical data.
        /// </summary>
        /// <param name="statistic">The name of the statistic to access.</param>
        /// <returns>
        /// The value of a statistic as a <see cref="System.Decimal"/>.
        /// </returns>
        public decimal this[string statistic] {
            get { return Who.Statistics[statistic]; }
            set { Who.Statistics[statistic] = value; }
        }
    }
}