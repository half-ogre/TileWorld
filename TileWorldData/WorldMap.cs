using System;
using Microsoft.Xna.Framework;

namespace TileWorld
{
    public class WorldMap
    {
        public int[] GroundTiles { get; set; }
        public Point Size { get; set; }

        public int GetGroundTileIndex(Point point)
        {
            if ((point.Y < 0) || (point.Y >= Size.X) ||
                (point.X < 0) || (point.X >= Size.Y))
            {
                throw new ArgumentOutOfRangeException("point");
            }

            return GroundTiles[point.Y * Size.X + point.X];
        }
    }
}
