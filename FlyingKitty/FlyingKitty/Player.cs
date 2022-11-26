using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

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
        }
        public void Update()
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
