using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

namespace Highworm {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            new 
                Program().Run();
                Console.ReadLine();
        }

        public void Run() {
            EncounterController = new Controllers.EncounterController();
            CharacterController = new Controllers.CharacterController();

            // design a new encounter
            var encounter = EncounterController.Create<ViewModels.Battle>();

            // begin creating characters
            var characters = new List<Character>();

            // use the controller to add new characters
            characters.Add(CharacterController.Create("Amelia"));
            characters.Add(CharacterController.Create("Daniel"));

            // register the characters for the encounter
            characters.ForEach(character => { encounter.Register(character); });

            // roll initiative for the encounter
            encounter.Sort("Initiative");
        }

        internal Controllers.EncounterController EncounterController { get; set; }
        internal Controllers.CharacterController CharacterController { get; set; }
    }
}
