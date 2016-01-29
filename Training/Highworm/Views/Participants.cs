using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm.Views {
    /// <summary>
    /// Represents a view of an encounter's participants.
    /// </summary>
    public class Participants : Interpreter<IList<IMayEncounter>> {
        /// <summary>
        /// The content that will be presented.
        /// </summary>
        public override IList<IMayEncounter> Content {
            get;
            set;
        }

        /// <summary>
        /// Custom logic to display the content
        /// </summary>
        public override void Paint() {
            throw new NotImplementedException();
        }
    }
}