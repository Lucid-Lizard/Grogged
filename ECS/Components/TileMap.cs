using Grogged.Core;
using Microsoft.Xna.Framework;
using System;

namespace Grogged.ECS.Components
{
    public struct TileMap
    {
        public TileData[,] tiles;
        public int offsetX; // Tracks how much the map has shifted left
        public int offsetY; // Tracks how much the map has shifted up

        public static TileMap Create(int width = 1, int height = 1)
        {
            return new TileMap()
            {
                tiles = new TileData[width, height],
                offsetX = 0,
                offsetY = 0
            };
        }
    }

    public static class TileMapHelper
    {
        /// <summary>
        /// Adds a tile to the tilemap. Expands if needed.
        /// </summary>
        /// <param name="map">Reference to the tilemap.</param>
        /// <param name="position">Position where the tile should be placed.</param>
        /// <param name="tile">The tile data to place.</param>
        public static void AddTile(ref TileMap map, Point position, TileData tile)
        {
            int width = map.tiles.GetLength(0);
            int height = map.tiles.GetLength(1);

            // Convert world position to local array index
            int localX = position.X + map.offsetX;
            int localY = position.Y + map.offsetY;

            // Check if out of bounds and resize if necessary
            if (localX < 0 || localX >= width || localY < 0 || localY >= height)
            {
                ResizeTileMap(ref map, position);

                // Recalculate local position after resizing
                localX = position.X + map.offsetX;
                localY = position.Y + map.offsetY;
            }

            // Place the tile
            map.tiles[localX, localY] = tile;
        }

        /// <summary>
        /// Resizes the tilemap to fit the given position.
        /// </summary>
        private static void ResizeTileMap(ref TileMap map, Point position)
        {
            int oldWidth = map.tiles.GetLength(0);
            int oldHeight = map.tiles.GetLength(1);

            // Determine new required bounds
            int minX = Math.Min(position.X, -map.offsetX);
            int minY = Math.Min(position.Y, -map.offsetY);
            int maxX = Math.Max(position.X, oldWidth - 1 - map.offsetX);
            int maxY = Math.Max(position.Y, oldHeight - 1 - map.offsetY);

            int newWidth = maxX - minX + 1;
            int newHeight = maxY - minY + 1;

            // Create new expanded tilemap
            TileData[,] newTiles = new TileData[newWidth, newHeight];

            // Copy old tiles into the new array with the correct offset
            for (int x = 0; x < oldWidth; x++)
            {
                for (int y = 0; y < oldHeight; y++)
                {
                    int newX = x + (-minX - map.offsetX);
                    int newY = y + (-minY - map.offsetY);

                    newTiles[newX, newY] = map.tiles[x, y];
                }
            }

            // Update map with new size and offset
            map.tiles = newTiles;
            map.offsetX = -minX;
            map.offsetY = -minY;
        }
    }
}
