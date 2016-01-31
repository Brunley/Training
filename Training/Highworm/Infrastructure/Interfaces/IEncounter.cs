using System.Collections.Generic;

namespace Highworm {
    /// <summary>
    /// A contract for defining a type of encounter.
    /// </summary>
    /// <typeparam name="T">A type that implements <see cref="Highworm.IMayEncounter"/></typeparam>
    public interface IEncounter<T> where T : IMayEncounter {
        /// <summary>
        /// The collection of participants.
        /// </summary>
        IList<T> Participants { get; set; }
    }
}