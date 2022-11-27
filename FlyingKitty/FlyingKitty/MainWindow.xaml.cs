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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FlyingKitty
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player player;
        private ObstacleControler _obsControler;
        private Game game;

        public MainWindow()
        {
            InitializeComponent();
            //load model player
            Uri uriImage = new Uri("../../images/player.png", UriKind.Relative);
            player = new Player(90*Game.G/Game.TICKRATE, 360, 75, 75, new BitmapImage(uriImage));
            MainCanvas.Children.Add(player);
            player.SetPosition(75, 400);
            player.RenderPosition();
            //initialize obs controler and generate map
            _obsControler = new ObstacleControler();
            //start game
            game = new Game(player);
            game.Start();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private new void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter ||
                e.Key == Key.Space ||
                e.Key == Key.Down)
            {
                if (player.DirectionY == -1)
                    player.IsPushDown = true;
            }
        }
    }
}
