using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;


using Highworm.Displays;
using Highworm.Displays.Views;
using Highworm.Displays.Views.Inputs;

namespace Highworm.Controllers {
    /// <summary>
    /// A controller for interacting with various game functionality and properties.
    /// </summary>
    public class GameController {
        /// <summary>
        /// Initialize a new <see cref="Highworm.Controllers.GameController"/>.
        /// </summary>
        public GameController() {
            Screen = new Display() ;
        }

        /// <summary>
        /// Perform an entire painting cycle.
        /// </summary>
        public void Paint() {
            Screen.Increment().Synchronize().Paint();
        }

        /// <summary>
        /// Perform discriminating and behavioral logic when text is
        /// given to the game system.
        /// </summary>
        /// <param name="input">The text that was given.</param>
        /// <returns>The current <see cref="Highworm.Displays.Display"/></returns>
        public GameController OnRead(string input) {
            if (input == "esc") Environment.Exit(0); return this;
        }

        /// <summary>
        /// The active <see cref="Highworm.Displays.Display"/> that is being drawn to.
        /// </summary>
        public Display Screen { get; set; }

        /// <summary>
        /// The current <see cref="Highworm.Models.Encounter"/> being played out.
        /// </summary>
        public Models.Encounter Encounter { get; set; }
    }
}
