using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace FlyingKitty
{
    internal class Player : Sprite
    {
        private Image _image;
        private DispatcherTimer PushDownTimer;
        private double PushDownMSTime;
        public bool IsPushDown { private get; set; }

        public Player(double speedY, double timeJump, int width, int height, ImageSource sourse)
        {
            //constructor
            Width = width;
            Height = height;
            _speedY = speedY;
            PushDownTimer = new DispatcherTimer();
            PushDownMSTime = timeJump;
            DirectionY = 0;
            DirectionX = 0;
            IsPushDown = false;
            Hitbox = new System.Windows.Rect(Width*0.1, Height*0.1, Width*0.8, Height*0.8);
            //load image
            _image = new Image();
            _image.Source = sourse;
            _image.Width = Width;
            _image.Height = Height;
            Children.Add(_image);
            //change time push down 
            PushDownTimer.Interval = TimeSpan.FromMilliseconds(PushDownMSTime);
            PushDownTimer.Tick += (sender, ards) => { IsPushDown = false; };
        }
        public override void Update()
        {
            PushDown();
            Fly();
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
    }
}
