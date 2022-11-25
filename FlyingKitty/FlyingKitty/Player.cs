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
        private int posX, poxY;
        public Player(string name, int width, int hight, ImageSource sourse)
        {
            Name = name;
            Width = width;
            Height = hight;
            //load image
            _image = new Image();
            _image.Source = sourse;
            _image.Width = Width;
            _image.Height = Height;
            Children.Add(_image);
        }
        public void SetPosition(int x, int y)
        {
            Canvas.SetLeft(this, x);
            Canvas.SetTop(this, y);
            posX = x;
            poxY = y;
        }
    }
}
