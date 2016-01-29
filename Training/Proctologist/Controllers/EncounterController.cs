using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;


namespace Highworm.Controllers {
    public class EncounterController {
        /// <summary>
        /// Create a new encounter.
        /// </summary>
        /// <typeparam name="T">
        /// The type of encounter to create.
        /// </typeparam>
        /// <returns></returns>
        public IEncounter<IMayEncounter> Create<T>() where T : IEncounter<IMayEncounter> {
            return default(T);
        }

        
    }
}