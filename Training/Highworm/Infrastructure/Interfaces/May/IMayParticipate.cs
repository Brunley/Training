using System.Collections.Generic;

namespace Highworm {
    /// <summary>
    /// A contract for defining an entity that may participate in an <see cref="Highworm.IEncounter{T}"/>.
    /// </summary>
    public interface IMayParticipate {
        /// <summary>
        /// The name of the participant.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The participant's statistical data.
        /// </summary>
        IDictionary<string, decimal> Statistics { get; set; }
    }
}