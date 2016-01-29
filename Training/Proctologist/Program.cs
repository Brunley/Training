using System;
using System.Linq;

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

            var display = new Highworm.Scoreboard.Display {
                Components = new Dictionary<int, Printable> {
                    { 1, new Scoreboard.Header() },
                    { 2, new Scoreboard.Inputs.InputParticipantNameCommand() }
                }
            };

            // register behavior for when a character name is given
            display.Components[2].Input += OnCharacterNameIsGiven;

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
