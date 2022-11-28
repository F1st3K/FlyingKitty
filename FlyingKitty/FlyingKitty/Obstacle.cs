using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace FlyingKitty
{
    internal class Obstacle : Sprite
    {
        private Image _image;
        public Obstacle(double speedX, double speedY, int width, int height, ImageSource sourse)
        {
            //constructor
            Width = width;
            Height = height;
            _speedX = speedX;
            _speedY = speedY;
            DirectionY = 0;
            DirectionX = -1;
            //load image
            _image = new Image();
            _image.Source = sourse;
            _image.Width = Width;
            _image.Height = Height;
            Children.Add(_image);
        }
        public override void Update()
        {
            Move();
            UpdateHitbox();
        }
    }
}
