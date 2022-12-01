using System.Windows;
using System.Windows.Input;

namespace FlyingKitty
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double speed;
        public MainWindow()
        {
            InitializeComponent();
            Difficults.SelectedIndex = 0;
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void level1_Click(object sender, RoutedEventArgs e)
        {
            Level level = new Level("_______0_1_2_3_4_5_6_7_8_9_____");
            level.GameSpeed = speed;
            Game game = new Game(level);
            this.Hide();
            game.Start();
        }

        private void level2_Click(object sender, RoutedEventArgs e)
        {
            Level level = new Level("_______4444444444444444____");
            level.GameSpeed = speed;
            Game game = new Game(level);
            this.Hide();
            game.Start();
        }

        private void level3_Click(object sender, RoutedEventArgs e)
        {
            Level level = new Level("_______9_8_7_6_5_4_3_2_1_0_____");
            level.GameSpeed = speed;
            Game game = new Game(level);
            this.Hide();
            game.Start();
        }

        private void level4_Click(object sender, RoutedEventArgs e)
        {
            Level level = new Level("_______0000_1111_2222_3333_4444_5555_6666_7777_8888_9999_8888_7777_6666_5555_4444_3333_2222_1111_0000");
            level.GameSpeed = speed;
            Game game = new Game(level);
            this.Hide();
            game.Start();
        }

        private void level5_Click(object sender, RoutedEventArgs e)
        {
            Level level = new Level("_______9_8_7_6_5_4_3_2_1_0_1_2_3_4_5_6_7_8_9");
            level.GameSpeed = speed;
            Game game = new Game(level);
            this.Hide();
            game.Start();
        }

        private void Difficults_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ;
            switch (Difficults.SelectedIndex)
            {
                case 0: speed = 300; break;
                case 1: speed = 500; break;
                case 2: speed = 700; break;
                default:
                    break;
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Level level = new Level(HashMap.Text);
            level.GameSpeed = speed;
            Game game = new Game(level);
            this.Hide();
            game.Start();
        }
    }
}
