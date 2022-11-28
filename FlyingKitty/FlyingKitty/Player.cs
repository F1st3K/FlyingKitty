using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace FlyingKitty
{
    internal class Player : Sprite
    {
        private Image _image;
        private DispatcherTimer PushDownTimer;
        private double _pushDownMSTime;

        public bool IsAlive { get; private set; }
        public byte DeathСode { get; private set; }
        public bool IsPushDown { private get; set; }

        public Player(double speedY, double timeJump, int width, int height, ImageSource sourse)
        {
            //constructor
            Width = width;
            Height = height;
            _speedY = speedY;
            PushDownTimer = new DispatcherTimer();
            _pushDownMSTime = timeJump;
            DirectionY = 0;
            DirectionX = 0;
            IsPushDown = false;
            IsAlive = true;
            //load image
            _image = new Image();
            _image.Source = sourse;
            _image.Width = Width;
            _image.Height = Height;
            Children.Add(_image);
            //change time push down 
            PushDownTimer.Interval = TimeSpan.FromMilliseconds(_pushDownMSTime);
            PushDownTimer.Tick += (sender, ards) => { IsPushDown = false; };
        }
        public override void Update()
        {
            PushDown();
            Fly();
            UpdateHitbox();
            Colision();
            DirectionY = -1;
        }
        private void PushDown()
        {
            if (IsPushDown)
            {
                DirectionY = 1;
                PushDownTimer.Start();
            }
            else PushDownTimer.Stop();
        }
        private protected override void UpdateHitbox()
        {
            double percentOf = 70.6667 / 100;
            Hitbox = new Rect(
                _posX+Width*(1-percentOf),
                _posY+Height*(1 - percentOf),
                Width*percentOf,
                Height*percentOf);
        }
        private void Colision()
        {
            if (ObstacleControler.IsColision(Hitbox))
            {
                IsAlive = false;
                DeathСode = 1;
                return;
            }
            if (ObstacleControler.IsFlewAway(Hitbox))
            {
                IsAlive = false;
                DeathСode = 2;
                return;
            }
        }
    }
}
