using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SmashEscapin
{
    class MapGrid
    {
        public static Dictionary<Vector2, Vector2> mapTiles = new Dictionary<Vector2, Vector2>();
        
        public void createGrid()
        {
            //Clear the grid positions on the map
            mapTiles.Clear();

            //Go through each tile and create four positions on each tile
            foreach(KeyValuePair<Vector2, Texture2D> tile in MapGeneration.Tiles)
            {
                //Top grid position on the tile
                //Bottom grid position on the tile
                //Left grid position on the tile
                //Right grid position on the tile
                mapTiles.Add(new Vector2(tile.Key.X * 2 + 1, tile.Key.Y * 2), new Vector2(tile.Key.X * (tile.Value.Width / 2) + tile.Value.Width / 2, tile.Key.Y * tile.Value.Width / 4 + tile.Value.Width / 8));
                mapTiles.Add(new Vector2(tile.Key.X * 2 + 1, tile.Key.Y * 2 + 2), new Vector2(tile.Key.X * (tile.Value.Width / 2) + tile.Value.Width / 2, tile.Key.Y * tile.Value.Width / 4 + tile.Value.Width / 8 * 3));
                mapTiles.Add(new Vector2(tile.Key.X * 2, tile.Key.Y * 2 + 1), new Vector2(tile.Key.X * (tile.Value.Width / 2) + tile.Value.Width / 4, tile.Key.Y * tile.Value.Width / 4 + tile.Value.Width / 8 * 2));
                mapTiles.Add(new Vector2(tile.Key.X * 2 + 2, tile.Key.Y * 2 + 1), new Vector2(tile.Key.X * (tile.Value.Width / 2) + tile.Value.Width / 4 * 3, tile.Key.Y * tile.Value.Width / 4 + tile.Value.Width / 8 * 2));
            }
        }

        public void draw(SpriteBatch spritbatch)
        {
            //TEMPERARY
            //Draw all of the positions on the map
            foreach(KeyValuePair<Vector2, Vector2> pos in mapTiles)
            {
                //spritbatch.Draw(LoadSprites.sprite["pat"], new Rectangle((int)pos.Key.X - 10, (int)pos.Key.Y - 10, 20, 20), Color.White);
                //spritbatch.DrawString(LoadSprites.font, pos.Key.ToString(), pos.Value, Color.White);
            }
        }
    }
}
