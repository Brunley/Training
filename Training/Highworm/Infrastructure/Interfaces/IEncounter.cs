using System.Collections.Generic;

namespace Highworm {
    /// <summary>
    /// A contract for anything that might be an encounter.
    /// </summary>
    public interface IEncounter<T> {
        /// <summary>
        /// The participants of the encounter.
        /// </summary>
        IList<T> Participants {
            get;
            set;
        }
    }
}