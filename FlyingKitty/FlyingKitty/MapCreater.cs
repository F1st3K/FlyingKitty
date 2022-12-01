namespace FlyingKitty
{
    internal class MapCreater
    {
        private Obstacle[] _tubes;
        private Level _level;

        public MapCreater(Obstacle[] tubes, Level level)
        {
            _tubes = tubes;
            _level = level;
            Create();
        }

        private void Create()
        {
            int heigth;
            for (int i = 0, j = 0, k = _tubes.Length - 1; i < _level.HashMap.Length; i++)
            {
                switch (_level.HashMap[i])
                {
                    case '0': heigth = 9; break;
                    case '1': heigth = 8; break;
                    case '2': heigth = 7; break;
                    case '3': heigth = 6; break;
                    case '4': heigth = 5; break;
                    case '5': heigth = 4; break;
                    case '6': heigth = 3; break;
                    case '7': heigth = 2; break;
                    case '8': heigth = 1; break;
                    case '9': heigth = 0; break;
                    default:
                        continue;
                }
                    PutWall(i, j, k, _level.DistanceBetweenWindows * heigth);
                j++;
                k--;
            }
        }
        private void PutWall(int i, int up, int down, int startWin)
        {
            _tubes[up].SetPosition((_level.DistanceBetweenObjects + _level.WidthTubes) * i, -_tubes[up].Height + startWin);
            _tubes[down].SetPosition((_level.DistanceBetweenObjects + _level.WidthTubes) * i, _level.HeightWindows + startWin);
        }
    }
}
