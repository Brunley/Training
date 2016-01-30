﻿using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;


namespace Highworm.Displays.Inputs {
    /// <summary>
    /// A command to accept the name of a new participant.
    /// </summary>
    public class InputParticipantNameCommand : Input {
        /// <summary>
        /// The content that will be presented.
        /// </summary>
        public override string Content {
            get;
            set;
        }

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
        protected override StringBuilder Paint() {
            return Builder.Append($"Please enter a character name: ")
                .Write()
                .Read(OnConsoleRead);
        }
    }
}