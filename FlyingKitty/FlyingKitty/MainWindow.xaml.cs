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

        private void start_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
        }
    }
}
