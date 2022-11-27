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
        static public void CreateGround(int width, int height, string pathImage)
        {
            Uri uri = new Uri(pathImage, UriKind.Relative);
            Ground = new Obstacle(0, 0, width, height, new BitmapImage(uri));
        }
        static public void CreateSky(int width, int height, string pathImage)
        {
            Uri uri = new Uri(pathImage, UriKind.Relative);
            Sky = new Obstacle(0, 0, width, height, new BitmapImage(uri));
        }
        static public void CreateMap(int count, int width, int height, string pathImage)
        {
            Uri uri = new Uri(pathImage, UriKind.Relative);
            Map = new Obstacle[count];
            for (int i = 0; i < count; i++)
                Map[i] = new Obstacle(0, 0, width, height, new BitmapImage(uri));
        }
    }
}
