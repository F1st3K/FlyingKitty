using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace FlyingKitty
{
    internal class Player : Sprite
    {
        private Image _imagePlayer;
        private Image _imageSkin;
        private DispatcherTimer PushDownTimer;
        private double _pushDownMSTime;

        public bool GodeMode { get; private set; } = false;
        public bool IsAlive { get; set; }
        public byte DeathСode { get; set; }
        public bool IsPushDown { private get; set; }

        public Player(double speedY,
                      double timeJump,
                      int width,
                      int height,
                      int widthSkin,
                      int heightSkin,
                      ImageSource soursePlayer,
                      ImageSource sourseSkin)
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
            _imagePlayer = new Image();
            _imagePlayer.Source = soursePlayer;
            _imagePlayer.Width = Width;
            _imagePlayer.Height = Height;
            Children.Add(_imagePlayer);
            _imageSkin = new Image();
            _imageSkin.Source = sourseSkin;
            _imageSkin.Width = widthSkin;
            _imageSkin.Height = heightSkin;
            SetTop(_imageSkin, -height);
            Children.Add(_imageSkin);
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
            double percentOf = 70.01 / 100;
            Hitbox = new Rect(
                _posX+Width*(1-percentOf)/2,
                _posY+Height*(1 - percentOf)/2,
                Width*percentOf,
                Height*percentOf);
        }
        private void Colision()
        {
            
        }
    }
}
