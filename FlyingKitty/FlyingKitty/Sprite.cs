using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FlyingKitty
{
    internal class Sprite : Canvas
    {
        private protected double _posX;
        private protected double _posY;
        private protected double _speedY;
        private protected double _speedX;

        public Rect Hitbox    { get; private protected set; }
        public int DirectionY { get; private protected set; }
        public int DirectionX { get; private protected set; }

        public virtual void Update()
        {
            Fly();
            Move();
            UpdateHitbox();
        }
        public void SetPosition(double x, double y)
        {
            _posX = x;
            _posY = y;
        }
        public void RenderPosition()
        {
            Canvas.SetLeft(this, _posX);
            Canvas.SetTop(this, _posY);
        }
        private protected virtual void UpdateHitbox()
        {
            Hitbox = new Rect(_posX, _posY, Width, Height);
        }
        private protected void Fly()
        {
            _posY += _speedY * DirectionY;
        }
        private protected void Move()
        {
            _posX += _speedX * DirectionX;
        }
    }
}
