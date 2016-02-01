using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using Highworm.Displays;
using Highworm.Displays.Views;
using Highworm.Displays.Views.Inputs;


namespace Highworm {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            new Program().Run();
        }

        private void Run() {
            // design a new encounter
            var encounter = Factory.ForEncounters.Create<ViewModels.Battle>();

            Screen = new Display()
                .Then()
                .Initialize("root");

            Screen
                .Then()
                .IncludeViews(new List<View> {
                    Display.Create<Header>(),
                    Display.Create<Space>(),
                    Display.Create<Menu>(),
                    Display.Create<Space>(),
                    Display.Create<Participants>()
                        .Using(encounter.Participants),
                    Display.Create<Space>(),
                    Display.Create<InputMenuCommand>()
                        .OnEmpty(Screen.DisplayState.Empty)
                        .OnRead(Screen.DisplayState.Currently)
                        .IncludeVisibleState(new[] { String.Empty, "root", "menu" }),
                    Display.Create<InputParticipantNameCommand>()
                        .OnEmpty(Screen.DisplayState.Empty)
                        .OnRead(encounter.Register<Models.Character>)
                        .IncludeVisibleState(new[] { "add" })
                })
                .Then()
                .Initialize();

            do { Screen.Increment().Synchronize().Paint(); }
            while (true);
        }
    
        private Display Screen { get; set; }
    }
}
