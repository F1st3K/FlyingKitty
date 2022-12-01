using System;
using System.Windows.Media;
using System.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows;

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
        private Scene scene;
        private Player player;
        private GameWindow _window;
        private int tick;

        public Game(Level level)
        {
            player = new Player(level.MassPlayer * G / TICKRATE,
                                level.PushTimePlayer,
                                level.SizePlayer.Width,
                                level.SizePlayer.Height,
                                level.SizePlayer.Width,
                                level.SizePlayer.Height,
                                new BitmapImage(TexturePack.PlayerTexture),
                                new BitmapImage(TexturePack.PlayerSkinTexture));
            scene = new Scene(level, player);
            _window = new GameWindow();
            _window.KeyDown += PressDown;
            gameTimer.Interval = TimeSpan.FromSeconds(1 / TICKRATE);
            frameTimer.Interval = TimeSpan.FromSeconds(1 / FPS);
        }
        public void Start()
        {
            //set scene
            scene.CreateObjects((int)_window.Width, (int)_window.Height);
            scene.LoadModel(_window);
            scene.SetObjects();
            //
            _window.Show();
            //set game timer   
            gameTimer.Tick += new EventHandler(Update);
            gameTimer.Start();
            //set render timer
            frameTimer.Tick += new EventHandler(Render);
            frameTimer.Start();
            //play sound
            LoadSound();
            gameSound.Play();
        }

        private void LoadSound()
        {
            pressDownSound.Stream = Properties.Resources.pressDownSound;
            loseGameSound.Stream = Properties.Resources.loseGameSound;
            gameSound.Open(new Uri("../../media/GameSound.wav", UriKind.Relative));
        }
        private void PressDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Space || e.Key == Key.Down) &&
               (player.DirectionY == -1 && player.IsAlive))
            {
                player.IsPushDown = true;
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
            tick = 0;
        }
        private void Update(object sender, EventArgs e)
        {
            scene.Update();
            //check player is alive
            if (player.IsAlive == false)
                EndGame(player.DeathСode);
            tick++;
        }
        private void Render(object sender, EventArgs e)
        {
            scene.Render();
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
