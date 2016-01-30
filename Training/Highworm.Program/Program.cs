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
                Components = new List<View> {
                    Displays.Display.Create<Header>(),
                    Displays.Display.Create<Menu>(),
                    Displays.Display.Create<Participants>().Using(encounter.Participants),
                    Displays.Display.Create<InputMenuCommand>(component => {
                    }),
                    Displays.Display.Create<InputParticipantNameCommand>(component => {
                        component.Read += encounter.Register<Character>;
                    })
                    
                }
            };


            do {
                display.Paint();
            }
            while (true);
        }

        internal Controllers.EncounterController EncounterController { get; set; }
    }
}
