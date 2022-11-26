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
    internal class Player : Canvas
    {
        private Image _image;
        private double _posX;
        private double _posY;
        private double _mass;
        private DispatcherTimer PushDownTimer;
        private double PushDownMSTime;

        public int DirectionY { get; private set; }
        public int DirectionX { get; private set; }
        public bool IsPushDown { private get; set; }

        public Player(int mass, int width, int hight, ImageSource sourse)
        {
            //constructor
            Width = width;
            Height = hight;
            _mass = mass;
            PushDownTimer = new DispatcherTimer();
            PushDownMSTime = _mass * 4;
            DirectionY = -1;
            DirectionX = 1;
            IsPushDown = false;
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
        public void Update()
        {
            PushDown();
            Fly();
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

        public void Fly()
        {
            _posY += MainWindow.Gtick * _mass * DirectionY;
            DirectionY = -1;
        }
        public void RenderPosition()
        {
            Canvas.SetLeft(this, _posX);
            Canvas.SetTop(this, _posY);
        }
        public void SetPosition(double x, double y)
        {
            _posX = x;
            _posY = y;
        }
        
    }
}
