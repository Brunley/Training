using System.Collections.Generic;

namespace Highworm {
    /// <summary>
    /// A contract to define the basic data for participation
    /// </summary>
    public interface IMayParticipate {
        /// <summary>
        /// The character's name.
        /// </summary>
        string Name {
            get;
            set;
        }

        IDictionary<string, decimal> Statistics {
            get;
            set;
        }
    }
}