using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

namespace Highworm.Controllers {
    /// <summary>
    /// A controller for interacting with various game functionality and properties.
    /// </summary>
    public class GameController {
        /// <summary>
        /// Initialize a new <see cref="Highworm.Controllers.GameController"/>.
        /// </summary>
        public GameController() {
            
        }

        /// <summary>
        /// The current <see cref="Highworm.Models.Encounter"/> being played out.
        /// </summary>
        public Models.Encounter Encounter { get; set; }
    }
}
