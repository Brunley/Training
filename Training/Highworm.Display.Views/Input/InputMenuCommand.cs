﻿using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;


namespace Highworm.Displays.Views.Inputs {
    /// <summary>
    /// A command to accept the name of a new participant.
    /// </summary>
    public class InputMenuCommand : Displays.Input {
        /// <summary>
        /// The specific name and path of the input command.
        /// </summary>
        protected override string Name => "input.menu.command";

        /// <summary>
        /// The printable component's output text.
        /// </summary>
        /// <returns>
        /// A string to write at the component's cursor position.
        /// </returns>
        public override void Compose(string displayState) {
            ViewBuilder.Append($"Please enter a command: ")
                .Write()
                .Read(OnConsoleRead)
                .Clear();
        }
    }
}