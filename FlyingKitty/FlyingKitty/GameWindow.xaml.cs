using System.Windows;
using System.Windows.Input;

namespace FlyingKitty
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
        }        
        private new void KeyDownEvent(object sender, KeyEventArgs e)
        {
            
        }
        private void Window_Closed(object sender, System.EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
        private void BackButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

