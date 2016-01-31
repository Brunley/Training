namespace Highworm {
    /// <summary>
    /// A contract for defining an entity that may become part of an <see cref="Highworm.IEncounter{T}"/>.
    /// </summary>
    public interface IMayEncounter {
        /// <summary>
        /// The entity that may be part of the encounter.
        /// </summary>
        IMayParticipate Character {
            get;
            set;
        }

        /// <summary>
        /// The entities turn order.
        /// </summary>
        decimal Order { get; set; }

        /// <summary>
        /// A simple indexer for quickly accessing the entities statistical data.
        /// </summary>
        /// <param name="statistic">The name of the statistic to access.</param>
        /// <returns>
        /// The value of a statistic as a <see cref="System.Decimal"/>.
        /// </returns>
        decimal this[string statistic] { get; set; }
    }
}