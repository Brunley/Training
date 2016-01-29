using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm {
    public class EncounterInterpreter : Interpreter<IList<IMayEncounter>> {
        public override IList<IMayEncounter> Value {
            get;
            set;
        }

        public override void Paint() {
            throw new NotImplementedException();
        }
    }
}