using System;
using System.Windows.Media;
using System.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.IO;
using FlyingKitty.Properties;

namespace FlyingKitty
{
    internal class Game
    {
        public const double FPS = 120;
        public const double G = 9.8;
        public const double TICKRATE = 128;

        private DispatcherTimer gameTimer = new DispatcherTimer();
        private DispatcherTimer frameTimer = new DispatcherTimer();
        private MediaPlayer gameSound = new MediaPlayer();
        private SoundPlayer loseGameSound = new SoundPlayer();
        private SoundPlayer pressDownSound = new SoundPlayer();
        private string _map;

        public int Tick { get; private set; }
        public Player _player { get; private set; }

        public void SetMap(string map)
        {
            _map = map;
        }
        public void Start()
        {   
            //create map
            ObstacleControler.CreateMap(_map);
            _player.SetPosition(75, 300);
            //create game ticrate timer   
            gameTimer.Interval = TimeSpan.FromSeconds(1 / TICKRATE);
            gameTimer.Tick += new EventHandler(Update);
            gameTimer.Start();
            //create render FPS timer
            frameTimer.Interval = TimeSpan.FromSeconds(1 / FPS);
            frameTimer.Tick += new EventHandler(Render);
            frameTimer.Start();
            //
            gameSound.Play();
        }
        public void CreatePlayer(double mass, int timeJump, int width, int heigth, int widthSkin, int heightSkin, string pathPlayer, string pathSkin)
        {
            Uri uriPlayer = new Uri(pathPlayer, UriKind.Relative);
            Uri uriSkin = new Uri(pathSkin, UriKind.Relative);
            _player = new Player(mass * G /TICKRATE, timeJump, width, heigth, widthSkin, heightSkin, new BitmapImage(uriPlayer), new BitmapImage(uriSkin));
        }
        public void LoadSound()
        {
            pressDownSound.Stream = Properties.Resources.pressDownSound;
            loseGameSound.Stream = Properties.Resources.loseGameSound;
            gameSound.Open(new Uri("../../media/GameSound.wav", UriKind.Relative));
        }
        public void PressDown()
        {
            if (_player.DirectionY == -1 && _player.IsAlive)
            {
                _player.IsPushDown = true;
                pressDownSound.Play();
            }
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
            loseGameSound.Play();
            gameTimer.Stop();
            frameTimer.Stop();
            gameSound.Stop();
        }
    }
}
