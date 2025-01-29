using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grogged.ECS.Components
{
    public struct SpriteComponent
    {
        public Texture2D sprite;
        public Rectangle sourceRect;
        public Color color;
        public float scale;
        public float rotation;
        public string texturePath;

        public SpriteComponent(Texture2D sprite, Rectangle sourceRect, Color color, float scale, float rotation, string texturePath)
        {
            this.sprite = sprite;
            this.sourceRect = sourceRect;
            this.color = color;
            this.scale = scale;
            this.rotation = rotation;
            this.texturePath = texturePath;
        }

        public static SpriteComponent Create(
            Texture2D sprite,
            Rectangle rectangle,
            Color color,
            float scale,
            float rotation,
            string texturePath)
        {
            return new SpriteComponent(sprite, rectangle, color, scale, rotation, texturePath);
        }
    }
}