using System.Windows;

using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

namespace Highworm {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window {
        public Main() {
            InitializeComponent();

            // initialize controllers
            Encounter = new Controllers.EncounterController();
            Setup = new Controllers.CharacterController();

            // begin creating characters
            var characters = new List<Character>();

            // use the controller to add new characters
            characters.Add(Setup.Create("Amelia"));
            characters.Add(Setup.Create("Daniel"));
        }
        // Doesn't line 29 already start an encounter?        
        public Controllers.EncounterController Encounter {
            get;
            set;
        }

        public Controllers.CharacterController Setup {
            get;
            set;
        }
    }
}