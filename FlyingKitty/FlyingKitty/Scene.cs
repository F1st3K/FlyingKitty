using System.CodeDom;
using System.Windows.Media.Imaging;

namespace FlyingKitty
{
    internal class Scene
    {
        
        private Obstacle sky;
        private Obstacle finish;
        private Obstacle[] tubes;
        private Obstacle[] ground;
        private GroundMover groundMover;
        private MapCreater mapCreater;
        private CollisionChecker CheckerGround;
        private CollisionChecker CheckerSky;
        private CollisionChecker CheckerTubes;
        private CollisionChecker CheckerFinish;
        private Player _player;
        private Level _level;

        public Scene(Level level, Player player)
        {
            _level = level;
            _player = player;
        }
        public void CreateObjects(int width, int heigth)
        {
            sky = new Obstacle(0, 0, width, 10, new BitmapImage(TexturePack.SkyTexture));

            finish = new Obstacle(_level.GameSpeed / Game.TICKRATE, 0, width, heigth, new BitmapImage(TexturePack.FinishTexture));

            ground = new Obstacle[3];
            for (int i = 0; i < ground.Length; i++)
                ground[i] = new Obstacle(_level.GameSpeed / Game.TICKRATE, 0, heigth, 50, new BitmapImage(TexturePack.GroundTexture));

            tubes = new Obstacle[_level.CountTubes];
            for (int i = 0; i < tubes.Length; i++)
                tubes[i] = new Obstacle(_level.GameSpeed / Game.TICKRATE, 0, _level.WidthTubes, _level.HeightTubes, new BitmapImage(TexturePack.TubeTexture));

            groundMover = new GroundMover(ground);
            CheckerGround = new CollisionChecker(ground);
            CheckerSky = new CollisionChecker(sky);
            CheckerTubes = new CollisionChecker(tubes);
            CheckerFinish = new CollisionChecker(finish);
        }
        public void LoadModel(GameWindow window)
        {
            window.MainCanvas.Children.Add(sky);
            window.MainCanvas.Children.Add(finish);
            for (int i = 0; i < ground.Length; i++)
                window.MainCanvas.Children.Add(ground[i]);
            for (int i = 0; i < tubes.Length; i++)
                window.MainCanvas.Children.Add(tubes[i]);
            window.MainCanvas.Children.Add(_player);
        }
        public void SetObjects()
        {
            sky.SetPosition(0, -50);
            sky.RenderPosition();
            ground[0].SetPosition(0, 650);
            ground[1].SetPosition(500, 650);
            ground[2].SetPosition(1000, 650);
            mapCreater = new MapCreater(tubes, _level);
            finish.SetPosition(_level.HashMap.Length * (_level.DistanceBetweenObjects + _level.WidthTubes), 0);
            _player.SetPosition(_level.StartPlayerPosition.X, _level.StartPlayerPosition.Y);
        }
        public void Update()
        {
            _player.Update();
            sky.Update();
            for (int i = 0; i < ground.Length; i++)
                ground[i].Update();
            for (int i = 0; i < tubes.Length; i++)
                tubes[i].Update();
            finish.Update();
            Collision();
            groundMover.CheckShift();
        }
        public void Render()
        {
            _player.RenderPosition();
            for (int i = 0; i < ground.Length; i++)
                ground[i].RenderPosition();
            for (int i = 0; i < tubes.Length; i++)
                tubes[i].RenderPosition();
            finish.RenderPosition();
        }
        private void Collision()
        {
            if (CheckerFinish.IsCollision(_player))
            {
                _player.IsAlive = false;
                _player.DeathСode = 0;
                return;
            }
            if (_player.GodeMode)
                return;
            if (CheckerSky.IsCollision(_player))
            {
                _player.IsAlive = false;
                _player.DeathСode = 2;
                return;
            }
            if (CheckerGround.IsCollision(_player) || CheckerTubes.IsCollision(_player))
            {
                _player.IsAlive = false;
                _player.DeathСode = 1;
                return;
            }
        }
    }
}
