using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using Highworm.Displays;
using Highworm.Displays.Inputs;


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

            var display = new Displays.Display {
                Components = new Dictionary<int, Printable> {
                    { 1, Displays.Display.Create<Header>().Using(encounter.Participants) },
                    { 2, Displays.Display.Create<InputParticipantNameCommand>(component => {
                            // register the component input behavior
                            component.Read += encounter.Register<Character>;
                        })
                    }
                }
            };


            do { display.Paint(true); }
            while (true);
        }

        internal Controllers.EncounterController EncounterController { get; set; }
    }
}
