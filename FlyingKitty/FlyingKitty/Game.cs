using System;
using System.Windows.Media;
using System.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Input;

namespace FlyingKitty
{
    internal class Game
    {
        public const double FPS = 120;
        public const double G = 9.8;
        public const double TICKRATE = 128;

        private DispatcherTimer frameTimer = new DispatcherTimer();
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private SoundPlayer pressDownSound = new SoundPlayer();
        private SoundPlayer loseGameSound = new SoundPlayer();
        private MediaPlayer gameSound = new MediaPlayer();
        private GameWindow _window;
        private Player _player;
        private Level _level;
        private int Tick;

        public Game(Level level)
        {
            _level = level;
            _window = new GameWindow();
            _window.KeyDown += PressDown;
            gameTimer.Interval = TimeSpan.FromSeconds(1 / TICKRATE);
            frameTimer.Interval = TimeSpan.FromSeconds(1 / FPS);
            _player = new Player(_level.MassPlayer * G / TICKRATE,
                                 _level.PushTimePlayer,
                                 _level.SizePlayer.Width,
                                 _level.SizePlayer.Height,
                                 _level.SizePlayer.Width,
                                 _level.SizePlayer.Height,
                                 new BitmapImage(_window.PlayerTexture),
                                 new BitmapImage(_window.PlayerSkinTexture));
        }
        public void Start()
        {
            //create map


            
            LoadModel();
            LoadSound();
            _player.SetPosition(_level.StartPlayerPosition.X, _level.StartPlayerPosition.Y);
            _window.Show();
            //create game ticrate timer   
            gameTimer.Tick += new EventHandler(Update);
            gameTimer.Start();
            //create render FPS timer
            frameTimer.Tick += new EventHandler(Render);
            frameTimer.Start();
            //play sound
            gameSound.Play();
        }
        public void LoadModel()
        {
            //add obstacle on MainCanvas

            //add player
            _window.MainCanvas.Children.Add(_player);
        }
        public void LoadSound()
        {
            pressDownSound.Stream = Properties.Resources.pressDownSound;
            loseGameSound.Stream = Properties.Resources.loseGameSound;
            gameSound.Open(new Uri("../../media/GameSound.wav", UriKind.Relative));
        }
        private void PressDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Space ||e.Key == Key.Down) && 
               (_player.DirectionY == -1 && _player.IsAlive))
            {
                _player.IsPushDown = true;
                pressDownSound.Play();
            }
            if (e.Key == Key.Enter)
                Restart();
        }
        private void Restart()
        {
            Stop();
            _window.MainCanvas.Children.Clear();
            Start();
        }
        private void Stop()
        {
            gameSound.Stop();
            gameTimer.Stop();
            gameTimer.Tick -= new EventHandler(Update);
            frameTimer.Tick -= new EventHandler(Render);            
            Tick = 0;
        }
        private void Update(object sender, EventArgs e)
        {
            //update objects
            _player.Update();
            
            //check player is alive 
            if (_player.IsAlive == false)
                EndGame(_player.DeathСode);
            //
            Tick++;
        }
        private void Render(object sender, EventArgs e)
        {
            _player.RenderPosition();
        }
        private void EndGame(byte deathCode)
        {
            if (deathCode != 0)
                loseGameSound.Play();
            if (deathCode == 0)
                gameSound.Volume = 1;
            gameTimer.Stop();
        }
    }
}
