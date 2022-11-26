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
        private Player _player;
        private ObstacleControler _obsControler;

        private bool IsGameOver = false;
        private DispatcherTimer gameTimer = new DispatcherTimer();
        static public double tickRate = 128;
        private int tick = 0;
        private int KeyTime = 0;
        private DispatcherTimer renderTimer = new DispatcherTimer();
        static private double FPS = 120;

        static public double g = 9.8;


        public MainWindow()
        {
            InitializeComponent();
            //load model player
            Uri uriImage = new Uri("../../images/player.png", UriKind.Relative);
            _player = new Player(90, 75, 75, new BitmapImage(uriImage));
            MainCanvas.Children.Add(_player);
            _player.SetPosition(75, 400);
            _player.RenderPosition();
            //initialize obs controler and generate map
            _obsControler = new ObstacleControler();
            Start();
        }
        private void Start()
        {
            //create game ticrate timer   
            gameTimer.Interval = TimeSpan.FromSeconds(1/tickRate);
            gameTimer.Tick += new EventHandler(Update);
            gameTimer.Start();
            //create render FPS timer
            renderTimer.Interval = TimeSpan.FromSeconds(1 / FPS);
            renderTimer.Tick += new EventHandler(Render);
            renderTimer.Start();
        }

        private void Render(object sender, EventArgs e)
        {
            _player.RenderPosition();
        }

        private void Update(object sender, EventArgs e)
        {
            _player.Update();
            tick++;
        }

        private void End()
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter ||
                e.Key == Key.Space ||
                e.Key == Key.Down)
            {
                if (_player.DirectionY == -1)
                    _player.IsPushDown = true;
            }
        }
    }
}
