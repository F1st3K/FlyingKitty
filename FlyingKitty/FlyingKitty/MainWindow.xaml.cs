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
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            SceneObjectController.GameSpeed = 700 / Game.TICKRATE;
            SceneObjectController.WidthObjects = 80;
            SceneObjectController.GapObjects = 10;
            SceneObjectController.HeigthWin = 200;
            SceneObjectController.ApetureWin = 50;
            SceneObjectController.LoadMap("_______12_34_56_78_98_7_6_5_4_3_2_1___");
            this.Hide();
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
        }
    }
}
