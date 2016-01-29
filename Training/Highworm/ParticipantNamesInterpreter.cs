using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm {
    public class ParticipantNamesInterpreter : Interpreter<IList<string>> {
        public override IList<string> Value {
            get;
            set;
        }

        public override void Paint() {
            throw new NotImplementedException();
        }
    }
}