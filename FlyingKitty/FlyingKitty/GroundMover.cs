using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlyingKitty
{
    internal class GroundMover
    {
        private Obstacle[] _ground;
        private int idLastGround;

        public GroundMover(Obstacle[] ground)
        {
            _ground = ground;
            idLastGround = _ground.Length-1;
        }
        public void CheckShift()
        {
            for (int i = 0; i < _ground.Length; i++)
                if (_ground[i].Hitbox.Right < 0)
                {
                    _ground[i].SetPosition(_ground[idLastGround].Hitbox.Right, _ground[i].Hitbox.Y);
                    idLastGround = i;
                }
        }
    }
}
