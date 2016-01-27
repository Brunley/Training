using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object display;

        public MainWindow()
        {
            InitializeComponent();
            CalculateButton.Click += CalculateButton_Click;
            EvadeButton.Click += EvadeButton_Click;


            stats CharStats = new stats();
            
            CharStats.Health = Int32.Parse(healthBox.Text);
            CharStats.Mana = Int32.Parse(manaBox.Text);
            CharStats.Defense = Int32.Parse(defenseBox.Text);
            CharStats.Evasions = Int32.Parse(evasionsBox.Text);
            CharStats.AtkPower = Int32.Parse(apBox.Text);

            oppStats OpponentStats = new oppStats();

            OpponentStats.Base = Int32.Parse(baseBox.Text);
            OpponentStats.AP = Int32.Parse(opAPBox.Text);
            OpponentStats.Modifiers = Int32.Parse(modifiersBox.Text);

            int display = ((
                OpponentStats.Base +
                OpponentStats.AP +
                OpponentStats.Modifiers) -
                CharStats.Defense);


        }

        public void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            
            displayLabel.Content =  (display.ToString  );
        }
        public void EvadeButton_Click(object sender, RoutedEventArgs e)
        {
            displayLabel.Content = ("{0}", );
        }
       
    }

    public class stats
    {
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Defense { get; set; }
        public int Evasions { get; set; }
        public int AtkPower { get; set; }
    }
    public class oppStats
    {
        public int Base{ get; set; }
        public int AP { get; set; }
        public int Modifiers { get; set; }

    }
}
