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
            game.Start();
        }

        private void LoadModel()
        {
            //Create obstacle
            ObstacleControler.GameSpeed = 100 / Game.TICKRATE;
            ObstacleControler.SetGround(3, (int)Width, 50, "../../images/graund.jpg");
            ObstacleControler.SetSky((int)Width, 10, "../../images/sky.jpg");
            ObstacleControler.SetMap(2, 75, (int)Height, "../../images/obstacle.png");

            //load model player
            game.CreatePlayer(70, 200, 75, 75, "../../images/player.png");
            MainCanvas.Children.Add(game._player);

            //add obstacle on MainCanvas
            for (int i = 0; i < ObstacleControler.Ground.Length; i++)
                MainCanvas.Children.Add(ObstacleControler.Ground[i]);
            MainCanvas.Children.Add(ObstacleControler.Sky);
            for (int i = 0; i < ObstacleControler.Map.Length; i++)
                MainCanvas.Children.Add(ObstacleControler.Map[i]);
        }
        private void RestartGame()
        {
            MainCanvas.Children.Clear();
            game = new Game();
            LoadModel();
            game.Start();
        }
        private new void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space ||
                e.Key == Key.Down)
                game.PressKey();
            if (e.Key == Key.Enter)
                RestartGame();
        }
    }
}
