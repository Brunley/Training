using System;
using System.Linq;

using System.Display;
using System.Display.Inputs;

using System.Collections;
using System.Collections.Generic;

namespace Highworm {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            new Program().Run(); 
        }

        public void Run() {
            EncounterController = new Controllers.EncounterController();

            // design a new encounter
            var encounter = EncounterController.Create<ViewModels.Battle>();

            var display = new Display {
                Components = new Dictionary<int, Printable> {
                    { 1, Display.Create<Header>() },
                    {
                        2, Display.Create<InputParticipantNameCommand>(component => {
                            // register the component input behavior
                            component.Read += encounter.Register<Character>;
                        })
                    }
                }
            };


            do { display.Paint(); }
            while (true);
        }

        internal Controllers.EncounterController EncounterController { get; set; }
    }
}
