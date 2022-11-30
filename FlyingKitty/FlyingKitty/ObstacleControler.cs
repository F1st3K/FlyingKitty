using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FlyingKitty
{
    static class ObstacleControler
    {
        static public double GameSpeed;
        static public int WidthObjects;
        static public int GapObjects;
        static public int HeigthWin;
        static public int ApetureWin;
        static public int CountTubs;
        static public int CountGround;

        static public Obstacle[] Map { get; private set; }
        static public Obstacle[] Ground { get; private set; }
        static public int indLastGround { get; private set; }
        static public Obstacle Sky    { get; private set; }
        static public Obstacle Finish { get; private set; }

        static public void SetGround(int width, int height, string pathImage)
        {
            Uri uri = new Uri(pathImage, UriKind.Relative);
            Ground = new Obstacle[CountGround];
            for (int i = 0; i < Ground.Length; i++)
                Ground[i] = new Obstacle(GameSpeed, 0, width, height, new BitmapImage(uri));
            indLastGround = Ground.Length - 1;
        }
        static public void SetSky(int width, int height, string pathImage)
        {
            Uri uri = new Uri(pathImage, UriKind.Relative);
            Sky = new Obstacle(0, 0, width, height, new BitmapImage(uri));
        }
        static public void SetFinish(int width, int height, string pathImage)
        {
            Uri uri = new Uri(pathImage, UriKind.Relative);
            Finish = new Obstacle(GameSpeed, 0, width, height, new BitmapImage(uri));
        }
        static public void SetMap( int width, int height, string pathImage)
        {
            Uri uri = new Uri(pathImage, UriKind.Relative);
            Map = new Obstacle[CountTubs];
            for (int i = 0; i < Map.Length; i++)
                Map[i] = new Obstacle(GameSpeed, 0, width, height, new BitmapImage(uri));
        }
        static public void CreateMap(string map)
        {
            Sky.SetPosition(0, -50);
            Sky.RenderPosition();
            Ground[0].SetPosition(0, 650);
            Ground[1].SetPosition(500, 650);
            Ground[2].SetPosition(1000, 650);
            for (int i = 0, j = 0, k = Map.Length-1; i < map.Length; i++)
            {
                switch (map[i])
                {
                    case '1': PutWall(i, j, k, ApetureWin * 9); break;
                    case '2': PutWall(i, j, k, ApetureWin*8); break;
                    case '3': PutWall(i, j, k, ApetureWin*7); break;
                    case '4': PutWall(i, j, k, ApetureWin*6); break;
                    case '5': PutWall(i, j, k, ApetureWin*5); break;
                    case '6': PutWall(i, j, k, ApetureWin * 4); break;
                    case '7': PutWall(i, j, k, ApetureWin * 3); break;
                    case '8': PutWall(i, j, k, ApetureWin * 2); break;
                    case '9': PutWall(i, j, k, ApetureWin * 1); break;
                    default:
                        continue;
                }
                j++;
                k--;
            }
            Finish.SetPosition(map.Length*(GapObjects + WidthObjects), 0);
        }
        static public bool IsColision(Rect hitbox)
        {
            for (int i = 0; i < Ground.Length; i++)
                if (hitbox.IntersectsWith(Ground[i].Hitbox))
                    return true;
            for (int i = 0; i < Map.Length; i++)
                if (hitbox.IntersectsWith(Map[i].Hitbox))
                    return true;
            return false;
        }
        static public bool IsFlewAway(Rect hitbox)
        {
            if (hitbox.IntersectsWith(Sky.Hitbox))
                return true;
            return false;
        }
        static public bool IsFinaly(Rect hitbox)
        {
            if (hitbox.IntersectsWith(Finish.Hitbox))
                return true;
            return false;
        }
        static public void Update()
        {
            for (int i = 0; i < Map.Length; i++)
                Map[i].Update();
            for (int i = 0; i < Ground.Length; i++)
                Ground[i].Update();
            Sky.Update();
            Finish.Update();
            GroundShiftCheck();
        }
        static public void Render()
        {
            for (int i = 0; i < Map.Length; i++)
                Map[i].RenderPosition();
            for (int i = 0; i < Ground.Length; i++)
                Ground[i].RenderPosition();
            Finish.RenderPosition();
        }

        static private void GroundShiftCheck()
        {
            for (int i = 0; i < Ground.Length; i++)
                if (Ground[i].Hitbox.Right < 0)
                {
                    Ground[i].SetPosition(Ground[indLastGround].Hitbox.Right, Ground[i].Hitbox.Y);
                    indLastGround = i;
                }
        }
        static private void PutWall(int i, int up, int down, int startWin)
        {
            Map[up].SetPosition((GapObjects + WidthObjects) * i, - Map[up].Height + startWin);
            Map[down].SetPosition((GapObjects + WidthObjects) * i, HeigthWin + startWin);
        }
    }
}
