using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grogged.Core
{
    public struct TileData
    {
        public short Id;
        public short localX;
        public short localY;
        public bool[] pins = new bool[9];

        public TileData()
        {
            this.Id = 0;
            this.localX = 0;
            this.localY = 0;
            this.pins = new bool[9];
        }
    }

    public static class TileDataExtensions
    {
        public static void ModifyTile(ref TileData tile, short? id = null, short? x = null, short? y = null, bool[] pins = null)
        {
            if (id.HasValue) tile.Id = id.Value;
            if (x.HasValue) tile.localX = x.Value;
            if (y.HasValue) tile.localY = y.Value;
            if (pins != null && pins.Length == 9) tile.pins = pins;
        }
    }

}
