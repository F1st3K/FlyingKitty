using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace FlyingKitty
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;

        public MainWindow()
        {
            InitializeComponent();
            game = new Game();
            LoadModel();
            game.LoadSound();
            //game.Start();
        }

        private void LoadModel()
        {
            //Create obstacle
            ObstacleControler.GameSpeed = 300 / Game.TICKRATE;
            ObstacleControler.SetGround(3, (int)Width, 50, "../../media/graund.jpg");
            ObstacleControler.SetSky((int)Width, 10, "../../media/sky.jpg");
            ObstacleControler.SetMap(10, 75, (int)Height, "../../media/obstacle.png");
            //add obstacle on MainCanvas
            for (int i = 0; i < ObstacleControler.Ground.Length; i++)
                MainCanvas.Children.Add(ObstacleControler.Ground[i]);
            MainCanvas.Children.Add(ObstacleControler.Sky);
            for (int i = 0; i < ObstacleControler.Map.Length; i++)
                MainCanvas.Children.Add(ObstacleControler.Map[i]);
            //load model player
            game.CreatePlayer(70, 200, 50, 105, 50, 44, "../../media/kitty.png", "../../media/boll.png");
            MainCanvas.Children.Add(game._player);
            //load map
            ObstacleControler.WidthObjects = 75;
            ObstacleControler.GapObjects = 10;
            ObstacleControler.HeigthWin = 200;
            ObstacleControler.ApetureWin = 50;
            game.SetMap("___1_2_3_4_5__");
        }
        private void RestartGame()
        {
            MainCanvas.Children.Clear();
            game = new Game();
            LoadModel();
            game.LoadSound();
            game.Start();
        }
        private new void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space ||
                e.Key == Key.Down)
                game.PressDown();
            if (e.Key == Key.Enter)
                RestartGame();
        }
        private string GetExeDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            path = Path.GetDirectoryName(path);
            return path;
        }
    }
}
