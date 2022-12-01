using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingKitty
{
    internal class CollisionChecker
    {
        private Sprite[] _objects;
        public CollisionChecker(params Sprite[] objects)
        {
            _objects = objects;
        }
        public bool IsCollision(Sprite sprite)
        {
            for (int i = 0; i < _objects.Length; i++)
                if (sprite.Hitbox.IntersectsWith(_objects[i].Hitbox))
                    return true;
            return false;
        }
    }
}
