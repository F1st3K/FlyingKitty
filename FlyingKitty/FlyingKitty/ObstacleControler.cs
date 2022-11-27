using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FlyingKitty
{
    static class ObstacleControler
    {
        static public Obstacle[] Map { get; private set; }
        static public Obstacle Ground { get; private set; }
        static public Obstacle Sky    { get; private set; }
        static public double GameSpeed;
        static public void CreateGround(int width, int height, string pathImage)
        {
            Uri uri = new Uri(pathImage, UriKind.Relative);
            Ground = new Obstacle(GameSpeed, 0, width, height, new BitmapImage(uri));
        }
        static public void CreateSky(int width, int height, string pathImage)
        {
            Uri uri = new Uri(pathImage, UriKind.Relative);
            Sky = new Obstacle(GameSpeed, 0, width, height, new BitmapImage(uri));
        }
        static public void CreateMap(int count, int width, int height, string pathImage)
        {
            Uri uri = new Uri(pathImage, UriKind.Relative);
            Map = new Obstacle[count];
            for (int i = 0; i < count; i++)
                Map[i] = new Obstacle(GameSpeed, 0, width, height, new BitmapImage(uri));
        }
        static public void Update()
        {
            for (int i = 0; i < Map.Length; i++)
                Map[i].Update();
            Ground.Update();
        }
        static public void Render()
        {
            for (int i = 0; i < Map.Length; i++)
                Map[i].RenderPosition();
            Ground.RenderPosition();
        }
    }
}
