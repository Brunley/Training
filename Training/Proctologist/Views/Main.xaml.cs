using System.Windows;

namespace Highworm {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window {
        public Main() {
            InitializeComponent();

            // initialize controllers
            EncounterController = new Controllers.EncounterController();
            SetupController = new Controllers.SetupController();
        }

        public Controllers.EncounterController EncounterController {
            get;
            set;
        }

        public Controllers.SetupController SetupController {
            get;
            set;
        }
    }
}