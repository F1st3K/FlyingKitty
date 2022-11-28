using System;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace FlyingKitty
{
    internal class Game
    {
        public const double FPS = 120;
        public const double G = 9.8;
        public const double TICKRATE = 128;

        private DispatcherTimer gameTimer = new DispatcherTimer();
        private DispatcherTimer frameTimer = new DispatcherTimer();

        static public int Tick { get; private set; } = 0;
        public Player _player { get; private set; }

        public void Start()
        {   
            //create map
            ObstacleControler.CreateMap();
            _player.SetPosition(75, 300);
            //create game ticrate timer   
            gameTimer.Interval = TimeSpan.FromSeconds(1 / TICKRATE);
            gameTimer.Tick += new EventHandler(Update);
            gameTimer.Start();
            //create render FPS timer
            frameTimer.Interval = TimeSpan.FromSeconds(1 / FPS);
            frameTimer.Tick += new EventHandler(Render);
            frameTimer.Start();
        }
        public void CreatePlayer(double mass, int timeJump, int width, int heigth, string pathImage)
        {
            Uri uriImage = new Uri(pathImage, UriKind.Relative);
            _player = new Player(mass * G /TICKRATE, timeJump, width, heigth, new BitmapImage(uriImage));
        }
        public void PressKey()
        {
            if (_player.DirectionY == -1)
                _player.IsPushDown = true;
        }

        private void Update(object sender, EventArgs e)
        {
            //update objects
            _player.Update();
            ObstacleControler.Update();
            //check player is alive 
            if (_player.IsAlive == false)
                EndGame(_player.DeathСode);
            //
            Tick++;
        }
        private void Render(object sender, EventArgs e)
        {
            _player.RenderPosition();
            ObstacleControler.Render();
        }
        private void EndGame(byte deathCode)
        {
            gameTimer.Stop();
            frameTimer.Stop();
        }
    }
}
