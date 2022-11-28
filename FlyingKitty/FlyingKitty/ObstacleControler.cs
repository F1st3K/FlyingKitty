using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FlyingKitty
{
    static class ObstacleControler
    {
        static public Obstacle[] Map { get; private set; }
        static public Obstacle[] Ground { get; private set; }
        static public Obstacle Sky    { get; private set; }
        static public double GameSpeed;
        static public void SetGround(int count, int width, int height, string pathImage)
        {
            Uri uri = new Uri(pathImage, UriKind.Relative);
            Ground = new Obstacle[count];
            for (int i = 0; i < count; i++)
                Ground[i] = new Obstacle(GameSpeed, 0, width, height, new BitmapImage(uri));
        }
        static public void SetSky(int width, int height, string pathImage)
        {
            Uri uri = new Uri(pathImage, UriKind.Relative);
            Sky = new Obstacle(0, 0, width, height, new BitmapImage(uri));
        }
        static public void SetMap(int count, int width, int height, string pathImage)
        {
            Uri uri = new Uri(pathImage, UriKind.Relative);
            Map = new Obstacle[count];
            for (int i = 0; i < count; i++)
                Map[i] = new Obstacle(GameSpeed, 0, width, height, new BitmapImage(uri));
        }
        static public void CreateMap()
        {
            Sky.SetPosition(0, -50);
            Sky.RenderPosition();
            Map[0].SetPosition(300, 400);
            Map[1].SetPosition(300, -500);
            Ground[0].SetPosition(0, 650);
            Ground[1].SetPosition(500, 650);
            Ground[2].SetPosition(1000, 650);
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
        static public void Update()
        {
            for (int i = 0; i < Map.Length; i++)
                Map[i].Update();
            for (int i = 0; i < Ground.Length; i++)
                Ground[i].Update();
            Sky.Update();
        }
        static public void Render()
        {
            for (int i = 0; i < Map.Length; i++)
                Map[i].RenderPosition();
            for (int i = 0; i < Ground.Length; i++)
                Ground[i].RenderPosition();
        }
    }
}
