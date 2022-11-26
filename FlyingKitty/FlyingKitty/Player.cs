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
        public double _mass;

        public int DirectionY = -1;
        public int DirectionX = 1;
        private DispatcherTimer PushDownTimer = new DispatcherTimer();
        private double PushDownMSTime = 500;

        public Player(int mass, int width, int hight, ImageSource sourse)
        {
            Width = width;
            Height = hight;
            _mass = mass;
            //load image
            _image = new Image();
            _image.Source = sourse;
            _image.Width = Width;
            _image.Height = Height;
            Children.Add(_image);

            PushDownTimer.Interval = TimeSpan.FromMilliseconds(PushDownMSTime);
            PushDownTimer.Tick += (sender, ards) => { DirectionY = -1; };
        }
        public void Update()
        {
            if (DirectionY == 1)
                PushDownTimer.Start();
            else PushDownTimer.Stop();

            Fly();
                       
        }
        public void Fly()
        {
            _posY += MainWindow.Gtick * _mass * DirectionY;
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
