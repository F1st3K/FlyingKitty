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

namespace FlyingKitty
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player _player;
        private ObstacleControler _obsControler;
        public MainWindow()
        {
            InitializeComponent();
            //load model player
            Uri uriImage = new Uri("../../images/player.png", UriKind.Relative);
            _player = new Player("player", 75, 75, new BitmapImage(uriImage));
            MainCanvas.Children.Add(_player);
            _player.SetPosition(75, 300);
            //initialize obs controler and generate map
            _obsControler = new ObstacleControler();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
