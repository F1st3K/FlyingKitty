using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace FlyingKitty
{
    internal class Game
    {
        public const double FPS = 120;
        public const double G = 9.8;
        public const double TICKRATE = 128;
        static public int Tick { get; private set; } = 0;
        
        private bool IsGameOver = false;
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private DispatcherTimer renderTimer = new DispatcherTimer();
        private Player _player;
        public Game(Player player)
        {
            _player = player;
            Start();
        }
        private void Start()
        {
            ObstacleControler.CreateMap();
            _player.SetPosition(75, 300);
            //create game ticrate timer   
            gameTimer.Interval = TimeSpan.FromSeconds(1 / TICKRATE);
            gameTimer.Tick += new EventHandler(Update);
            gameTimer.Start();
            //create render FPS timer
            renderTimer.Interval = TimeSpan.FromSeconds(1 / FPS);
            renderTimer.Tick += new EventHandler(Render);
            renderTimer.Start();
            //create map
            
        }
        private void Update(object sender, EventArgs e)
        {
            _player.Update();
            ObstacleControler.Update();

            if (_player.IsAlive == false)
                EndGame(_player.DeathСode);

            Tick++;
        }
        private void Render(object sender, EventArgs e)
        {
            _player.RenderPosition();
            ObstacleControler.Render();
        }
        private void EndGame(byte deathCode)
        {
            _player.SetPosition(100, 100);
        }
    }
}
