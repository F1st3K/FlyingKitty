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
        }

        private void LoadModel()
        {
            //Create obstacle
            ObstacleControler.GameSpeed = 500 / Game.TICKRATE;
            ObstacleControler.SetGround(3, (int)Width, 50, "../../media/graund.jpg");
            ObstacleControler.SetSky((int)Width, 10, "../../media/sky.jpg");
            ObstacleControler.SetFinish(350, (int)Height, "../../media/finish.jpg");
            ObstacleControler.SetMap(24, 75, (int)Height, "../../media/obstacle.png");
            //add obstacle on MainCanvas
            for (int i = 0; i < ObstacleControler.Ground.Length; i++)
                MainCanvas.Children.Add(ObstacleControler.Ground[i]);
            MainCanvas.Children.Add(ObstacleControler.Sky);
            MainCanvas.Children.Add(ObstacleControler.Finish);
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
            game.SetMap("_______1_2_3_4_5_4_3_2_1___");
        }
        private void RestartGame()
        {
            MainCanvas.Children.Clear();
            game.Stop();
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
    }
}
