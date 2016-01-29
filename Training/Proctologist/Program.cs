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
            CharacterController = new Controllers.CharacterController();

            // design a new encounter
            var encounter = EncounterController.Create<ViewModels.Battle>();

            // begin creating characters
            var characters = new List<Character> {
                CharacterController.Create("Amelia"),
                CharacterController.Create("Daniel")
            };
        
            // register the characters for the encounter
            characters.ForEach(character => { encounter.Register(character); });

            // roll initiative for the encounter
            encounter.Sort("Initiative");

            var display = new Display {
                Components = new Dictionary<int, Printable> {
                    { 1, Display.Create<Header>() },
                    {
                        2, Display.Create<InputParticipantNameCommand>(component => {
                            // register the component input behavior
                            component.Input += OnCharacterNameIsGiven;
                        })
                    }
                }
            };


            do {
                display.Paint();
            }
            while (display.ReadLine() != "quit");
        }

        private void OnCharacterNameIsGiven(string type, string text) {
            Console.WriteLine($"event: {type}\t{text}");
        }

        internal Controllers.EncounterController EncounterController { get; set; }
        internal Controllers.CharacterController CharacterController { get; set; }
    }
}
