using Grogged.ECS.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Linq;
using Grogged.ECS.Systems;
using Grogged.Prefebs;
namespace Grogged
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static ECSCoordinator _ecsCoordinator;

        public static int cameraId;
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


            // Create an example entity using the Dummy prefab
            _ecsCoordinator._EntityManager.CreateEntity<Dummy>();
            myPlayer = _ecsCoordinator._EntityManager.CreateEntity<PlayerPrefab>();

            cameraId = _ecsCoordinator._EntityManager.CreateEntity<CameraPrefab>();

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
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

            var cameraPosition = _ecsCoordinator._EntityManager.GetComponent<CameraComponent>(cameraId);

            _spriteBatch.Begin();

            foreach (var kvp in _ecsCoordinator._EntityManager.GetAllComponents<PositionComponent>())
            {
                var position = kvp.component;
                var screenPosition = new Vector2(position.X - cameraPosition.X, position.Y - cameraPosition.Y);
                var hasSpriteComponent = _ecsCoordinator._EntityManager.TryGetComponent<SpriteComponent>(kvp.entityId, out var spriteComponent);

                if (!hasSpriteComponent)
                {
                    _spriteBatch.DrawRectangle(new Rectangle((int)screenPosition.X, (int)screenPosition.Y, 32, 32), Color.Red);
                }
                else
                {
                    var sprite = spriteComponent.sprite;
                    var sourceRect = spriteComponent.sourceRect == Rectangle.Empty ? new Rectangle(0, 0, 32, 32) : spriteComponent.sourceRect;
                    var color = spriteComponent.color;

                    if (sprite == null)
                    {
                        _spriteBatch.DrawRectangle(new Rectangle((int)screenPosition.X, (int)screenPosition.Y, sourceRect.Width, sourceRect.Height), color);
                    }
                    else
                    {
                        _spriteBatch.Draw(sprite, position: screenPosition, sourceRectangle: sourceRect, color: color);
                    }
                }
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
