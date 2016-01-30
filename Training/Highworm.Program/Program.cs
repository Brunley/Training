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

        private void Run() {
            Screen              = new Displays.Display().ToState("menu"); 

            // design a new encounter
            var encounter = Factory.ForEncounters.Create<ViewModels.Battle>();

            Screen.Views = new List<View> {
                Displays.Display.Create<Header>(),
                Displays.Display.Create<Menu>(),
                Displays.Display.Create<Participants>().Using(encounter.Participants),
                Displays.Display.Create<InputMenuCommand>()
                    .OnEmpty(Screen.State.Empty)
                    .OnRead(Screen.State.Set)
                    .Visible("menu"),
                Displays.Display.Create<InputParticipantNameCommand>()
                    .OnEmpty(Screen.State.Empty)
                    .OnRead(encounter.Register<Character>)
                    .Visible("add")
            };

            do { Screen.Paint(); }
            while (true);
        }
    
        private Displays.Display Screen { get; set; }
    }
}
