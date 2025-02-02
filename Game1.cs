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

        public static int myPlayer;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _ecsCoordinator = new ECSCoordinator();

            Globals.SpriteBatch = this._spriteBatch;
            Globals.Content = this.Content;
            Globals.windowSize = Window.ClientBounds.Size;
            
            // Create an example entity using the Dummy prefab
            _ecsCoordinator._EntityManager.CreateEntity<Dummy>();
            myPlayer = _ecsCoordinator._EntityManager.CreateEntity<PlayerPrefab>();

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            Globals.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Pass delta time to ECS update
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _ecsCoordinator.Update(deltaTime);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach(var kvp in _ecsCoordinator._EntityManager.GetAllComponents<SpriteComponent>())
            {

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
