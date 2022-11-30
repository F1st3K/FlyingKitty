using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlyingKitty
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private Game game;

        public GameWindow()
        {
            InitializeComponent();
            game = new Game();
        }

        private void LoadModel()
        {
            //add obstacle on MainCanvas
            for (int i = 0; i < SceneObjectController.Ground.Length; i++)
                MainCanvas.Children.Add(SceneObjectController.Ground[i]);
            MainCanvas.Children.Add(SceneObjectController.Sky);
            MainCanvas.Children.Add(SceneObjectController.Finish);
            for (int i = 0; i < SceneObjectController.Map.Length; i++)
                MainCanvas.Children.Add(SceneObjectController.Map[i]);
            MainCanvas.Children.Add(game._player);
        }
        private void CreateModel()
        {
            //Create obstacle
            SceneObjectController.SetGround((int)Width, 50, "../../media/graund.jpg");
            SceneObjectController.SetSky((int)Width, 10, "../../media/sky.jpg");
            SceneObjectController.SetFinish(350, (int)Height, "../../media/finish.jpg");
            SceneObjectController.SetMap(75, (int)Height, "../../media/obstacle.png");
            //load model player
            game.CreatePlayer(70, 200, 50, 105, 50, 44, "../../media/kitty.png", "../../media/boll.png");
        }
        private void RestartGame()
        {
            MainCanvas.Children.Clear();
            game.Stop();
            game = new Game();
            CreateModel();
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

