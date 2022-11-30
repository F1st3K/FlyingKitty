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

        private void LoadLevel()
        {
            //load map settings
            ObstacleControler.GameSpeed = 500 / Game.TICKRATE;
            ObstacleControler.WidthObjects = 80;
            ObstacleControler.GapObjects = 10;
            ObstacleControler.HeigthWin = 200;
            ObstacleControler.ApetureWin = 50;
            game.LoadMap("_______12_34_56_78_98_7_6_5_4_3_2_1___");
            CreateModel();
            LoadModel();
        }
        private void LoadModel()
        {
            //add obstacle on MainCanvas
            for (int i = 0; i < ObstacleControler.Ground.Length; i++)
                MainCanvas.Children.Add(ObstacleControler.Ground[i]);
            MainCanvas.Children.Add(ObstacleControler.Sky);
            MainCanvas.Children.Add(ObstacleControler.Finish);
            for (int i = 0; i < ObstacleControler.Map.Length; i++)
                MainCanvas.Children.Add(ObstacleControler.Map[i]);
            MainCanvas.Children.Add(game._player);
        }
        private void CreateModel()
        {
            //Create obstacle
            ObstacleControler.SetGround((int)Width, 50, "../../media/graund.jpg");
            ObstacleControler.SetSky((int)Width, 10, "../../media/sky.jpg");
            ObstacleControler.SetFinish(350, (int)Height, "../../media/finish.jpg");
            ObstacleControler.SetMap(75, (int)Height, "../../media/obstacle.png");
            //load model player
            game.CreatePlayer(70, 200, 50, 105, 50, 44, "../../media/kitty.png", "../../media/boll.png");
        }
        private void RestartGame()
        {
            MainCanvas.Children.Clear();
            game.Stop();
            game = new Game();
            LoadLevel();
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
