using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grogged.ECS.Components
{
    public struct CameraComponent
    {
        public float X;
        public float Y;
        public float Zoom;

        public int EntityTarget;
        public Vector2 CameraPosition => new(X, Y);

        public static CameraComponent Create()
        {
            return new CameraComponent()
            {
                X = 0,
                Y = 0,
                Zoom = 1f
            };
        }
    }
}
