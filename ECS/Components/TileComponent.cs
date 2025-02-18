﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grogged.ECS.Components
{
    public struct TileComponent
    {
        public int tileId;
        public int[] collisionPins;

        public static TileComponent Create(int tileId, int[] collisionPins)
        {
            return new TileComponent
            {
                tileId = tileId,
                collisionPins = collisionPins
            };
        }

    }
}
