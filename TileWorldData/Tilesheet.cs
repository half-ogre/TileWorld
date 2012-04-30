using Microsoft.Xna.Framework;

namespace TileWorld
{
    public class Tilesheet
    {
        public string TextureName { get; set; }
        public int TilesPerRow { get; set; }
        public Point TileSize { get; set; }

        public Rectangle GetGroundTileRectangle(int index)
        {
            // TODO: add guard for out of bounds
            
            return new Rectangle(
                (index % TilesPerRow) * TileSize.X,
                (index / TilesPerRow) * TileSize.Y,
                TileSize.X, 
                TileSize.Y);
        }
    }
}
