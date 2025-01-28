using Grogged.ECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grogged.Prefebs
{
    public class TestTile : TileDummy
    {
        public override void SetTileDefaults(TileComponent tileComponent)
        {
            tileComponent.tileId = 0;
            /*  Tile collision is handled with 9 pins.
             *  0 = no collision
             *  1 = solid collision
             *  2+ will be programmed to be handled as collision event triggers.
             *  Ex. 2 could trigger fire debuff on player, 3 low friction on player, etc.
             *
             */
            tileComponent.collisionPins = new int[9]
            {
                0,0,0,
                0,0,0,
                0,0,0
            };
        }
    }
}
