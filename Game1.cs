using Grogged.ECS.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Linq;
using Grogged.ECS.Systems;
using Grogged.Prefebs;
using Grogged.Core;
namespace Grogged
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static ECSCoordinator _ecsCoordinator;
        private Camera cam; //m

        public static int myPlayer;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            cam=new(Vector2.Zero); //m
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _ecsCoordinator = new ECSCoordinator();

            Globals.SpriteBatch = this._spriteBatch;
            Globals.Content = this.Content;
            Globals.windowSize = new(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            
            myPlayer = _ecsCoordinator._EntityManager.CreateEntity<PlayerPrefab>();

            _ecsCoordinator._EntityManager.CreateEntity<Dummy>();

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            Globals.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _ecsCoordinator.Update(deltaTime);

            var component = myPlayer.Component<SpriteComponent>();  //m
            var pPosition = myPlayer.Component<PositionComponent>();
            cam.follow(
                new Rectangle(
                    (int)pPosition.X,
                    (int)pPosition.Y,
                    component.sourceRect.Width,
                    component.sourceRect.Height), Globals.windowSize.ToVector2());  //m

            base.Update(gameTime);

        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(); //m
            foreach(var kvp in _ecsCoordinator._EntityManager.GetAllComponents<SpriteComponent>())
            {
                //sprite.draw(_spritebatch, new Vector2(.....
                var pos1 = new Vector2(kvp.entityId.Component<PositionComponent>().X, kvp.entityId.Component<PositionComponent>().Y);
                pos1 += kvp.component.sourceRect.Center.ToVector2();
                pos1 -= cam.pos;

                var newRect = new Rectangle(pos1.ToPoint(), kvp.component.sourceRect.Size);

                _spriteBatch.DrawRectangle(newRect, kvp.component.color);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }

    public static class SpriteBatchExtensions
    {
        public static void DrawRectangle(this SpriteBatch spriteBatch, Rectangle rectangle, Color color)
        {
            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}
