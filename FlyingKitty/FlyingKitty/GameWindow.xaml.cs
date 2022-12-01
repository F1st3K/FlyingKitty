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
        public readonly Uri PlayerTexture = new Uri("../../media/kitty.png", UriKind.Relative);
        public readonly Uri PlayerSkinTexture = new Uri("../../media/boll.png", UriKind.Relative);
        public readonly Uri TubeTexture = new Uri("../../media/obstacle.png", UriKind.Relative);
        public readonly Uri FinishTexture = new Uri("../../media/finish.jpg", UriKind.Relative);
        public readonly Uri SkyTexture = new Uri("../../media/sky.jpg", UriKind.Relative);
        public readonly Uri GroundTexture = new Uri("../../media/graund.jpg", UriKind.Relative);

        public GameWindow()
        {
            InitializeComponent();
        }

        
        
        private new void KeyDownEvent(object sender, KeyEventArgs e)
        {
            
        }
    }
}

