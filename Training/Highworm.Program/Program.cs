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
            // design a new encounter
            var encounter = Factory.ForEncounters.Create<ViewModels.Battle>();

            Screen = new Displays.Display()
                .Then()
                .Initialize("root");

            Screen
                .Then()
                .IncludeViews(new List<View> {
                    Displays.Display.Create<Header>(),
                    Displays.Display.Create<Menu>(),
                    Displays.Display.Create<Participants>()
                        .Using(encounter.Participants),
                    Displays.Display.Create<InputMenuCommand>()
                        .OnEmpty(Screen.DisplayState.Empty)
                        .OnRead(Screen.DisplayState.Currently)
                        .IncludeVisibleState(new[] { String.Empty, "root", "menu" }),
                    Displays.Display.Create<InputParticipantNameCommand>()
                        .OnEmpty(Screen.DisplayState.Empty)
                        .OnRead(encounter.Register<Models.Character>)
                        .IncludeVisibleState(new[] { "add" })
                })
                .Then()
                .Initialize();

            do { Screen.Increment().Synchronize().Paint(); }
            while (true);
        }
    
        private Displays.Display Screen { get; set; }
    }
}
