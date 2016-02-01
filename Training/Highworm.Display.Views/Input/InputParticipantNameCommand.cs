using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;


namespace Highworm.Displays.Views.Inputs {
    /// <summary>
    /// A command to accept the name of a new participant.
    /// </summary>
    public class InputParticipantNameCommand : Input {
        /// <summary>
        /// The specific name and path of the input command.
        /// </summary>
        protected override string Name => "input.participant.name";

        /// <summary>
        /// The printable component's output text.
        /// </summary>
        /// <returns>
        /// A string to write at the component's cursor position.
        /// </returns>
        public override void Compose(string displayState) {
            ViewBuilder.Append($"Please enter a character name: ")
                .Write()
                .Read(OnConsoleRead)
                .Clear();
        }
    }
}