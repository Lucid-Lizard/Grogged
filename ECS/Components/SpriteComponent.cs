using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grogged.ECS.Components
{
    public struct SpriteComponent
    {
        public Texture2D sprite = null;
        public Rectangle sourceRect;
        public Color color;
        public float scale;
        public float rotation;
        public string texturePath;
    }
}
