using System;
using System.Windows.Media.Imaging;
using System.Windows;

namespace FlyingKitty
{
    internal class Scene
    {
        
        private Obstacle sky;
        private Obstacle finish;
        private Obstacle[] tubes;
        private Obstacle[] ground;
        private GroundMover groundMover;
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

            finish = new Obstacle(_level.GameSpeed / Game.TICKRATE, 0, 400, heigth, new BitmapImage(TexturePack.FinishTexture));

            ground = new Obstacle[3];
            for (int i = 0; i < ground.Length; i++)
                ground[i] = new Obstacle(_level.GameSpeed / Game.TICKRATE, 0, heigth, 50, new BitmapImage(TexturePack.GroundTexture));
            groundMover = new GroundMover(ground);

            tubes = new Obstacle[_level.CountTubes];
            for (int i = 0; i < tubes.Length; i++)
                tubes[i] = new Obstacle(_level.GameSpeed / Game.TICKRATE, 0, _level.WidthTubes, _level.HeightTubes, new BitmapImage(TexturePack.TubeTexture));
        }
        public void LoadModel(GameWindow window)
        {
            //add obstacle
            window.MainCanvas.Children.Add(sky);
            window.MainCanvas.Children.Add(finish);
            for (int i = 0; i < ground.Length; i++)
                window.MainCanvas.Children.Add(ground[i]);
            for (int i = 0; i < tubes.Length; i++)
                window.MainCanvas.Children.Add(tubes[i]);
            //add player
            window.MainCanvas.Children.Add(_player);
        }
        public void SetObjects()
        {
            sky.SetPosition(0, -50);
            sky.RenderPosition();
            ground[0].SetPosition(0, 650);
            ground[1].SetPosition(500, 650);
            ground[2].SetPosition(1000, 650);
            _player.SetPosition(_level.StartPlayerPosition.X, _level.StartPlayerPosition.Y);
        }
        public void Update()
        {
            //update objects
            _player.Update();
            sky.Update();
            for (int i = 0; i < ground.Length; i++)
                ground[i].Update();
            for (int i = 0; i < tubes.Length; i++)
                tubes[i].Update();
            finish.Update();
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
    }
}
