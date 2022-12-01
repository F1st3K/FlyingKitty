using System.Windows;
using System.Windows.Input;

namespace FlyingKitty
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void level1_Click(object sender, RoutedEventArgs e)
        {
            Level level = new Level("_______12_34_56_78_98_7_6_5_4_3_2_1___");
            Game game = new Game(level);
            this.Hide();
            game.Start();
        }
    }
}
