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
            /*The tile has no collision. basically, ive divided a tiles collision up into 9 parts of the tile called "pins". 
              0 = no collision, 1 = solid collision. There may be more types in the future, or maybe even collision types could
            act as triggers for methods. so if the player is colliding with a "2" pin, they could take damage or something. 
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
