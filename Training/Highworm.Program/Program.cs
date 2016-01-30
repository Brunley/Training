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
            Screen              = new Displays.Display().AsState("menu");

            // design a new encounter
            var encounter = EncounterController.Create<ViewModels.Battle>();

            Screen.Components = new List<View> {
                Displays.Display.Create<Header>(),
                Displays.Display.Create<Menu>(),
                Displays.Display.Create<Participants>().Using(encounter.Participants),
                Displays.Display.Create<InputMenuCommand>(component => {
                    component.Read += Screen.State.To;
                })
                .OnEmpty(Screen.State.Empty)
                .WhenState("menu"),
                Displays.Display.Create<InputParticipantNameCommand>(component => {
                    component.Read += encounter.Register<Character>;
                })
                .OnEmpty(Screen.State.Empty)
                .WhenState("add")
            };

            do {
                Screen.Paint();
            }
            while (true);
        }

        internal Controllers.EncounterController EncounterController { get; set; }
        internal Displays.Display Screen { get; set; }
    }
}
