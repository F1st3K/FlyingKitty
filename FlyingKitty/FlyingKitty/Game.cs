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

        private DispatcherTimer gameTimer = new DispatcherTimer();
        private DispatcherTimer frameTimer = new DispatcherTimer();
        private MediaPlayer gameSound = new MediaPlayer();
        private SoundPlayer loseGameSound = new SoundPlayer();
        private SoundPlayer pressDownSound = new SoundPlayer();
        private Level _level;
        private GameWindow _window;

        public int Tick { get; private set; }
        public Player _player { get; private set; }

        public Game(Level level)
        {
            _level = level;
            _window = new GameWindow();
            _window.KeyDown += PressDown;
            _player = new Player(_level.MassPlayer,
                                 _level.PushTimePlayer,
                                 _level.SizePlayer.Width,
                                 _level.SizePlayer.Height,
                                 _level.SizePlayer.Width,
                                 _level.SizePlayer.Height,
                                 new BitmapImage(_window.PlayerTexture),
                                 new BitmapImage(_window.PlayerSkinTexture));
            LoadSound();
        }
        public void CreatePlayer()
        {
            
        }
        public void Start()
        {
            _window.MainCanvas.Children.Clear();
            _window.LoadModel();
            //create map
            
            
            _window.Show();
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
        public void LoadSound()
        {
            pressDownSound.Stream = Properties.Resources.pressDownSound;
            loseGameSound.Stream = Properties.Resources.loseGameSound;
            gameSound.Open(new Uri("../../media/GameSound.wav", UriKind.Relative));
        }
        public void PressDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Space ||e.Key == Key.Down) && 
               (_player.DirectionY == -1 && _player.IsAlive))
            {
                _player.IsPushDown = true;
                pressDownSound.Play();
            }

            if (e.Key == Key.Enter)
            { 

            }
        }
        public void Stop()
        {
            gameSound.Stop();
            gameTimer.Stop();
            frameTimer.Stop();
        }
        private void Update(object sender, EventArgs e)
        {
            //update objects
            _player.Update();
            SceneObjectController.Update();
            //check player is alive 
            if (_player.IsAlive == false)
                EndGame(_player.DeathСode);
            //
            Tick++;
        }
        private void Render(object sender, EventArgs e)
        {
            _player.RenderPosition();
            SceneObjectController.Render();
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
