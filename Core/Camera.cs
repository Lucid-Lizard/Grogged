using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework; 

namespace Grogged.Core
{
    public class Camera
    {
        public Vector2 pos;

        public Camera(Vector2 pos)
        {
            this.pos = pos;
        }

        public void follow(Rectangle player, Vector2 screenSize)
        {
            pos=new Vector2 (-player.X +(screenSize.X /2 - player.Width /2), -player.Y + (screenSize.Y / 2 - player.Height / 2)); //formula for follow camera
        }
    }
}
