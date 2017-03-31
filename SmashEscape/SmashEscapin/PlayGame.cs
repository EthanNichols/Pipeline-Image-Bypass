using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SmashEscapin
{
    class PlayGame
    {
        //Load classes
        MapGeneration mapGeneration = new MapGeneration();
        MapGrid grid = new MapGrid();
        Player player1 = new Player();

        public void loadGame()
        {
            //Load the map images
            //Generate a room for the game
            //Set the sprites that can be used in the map
            mapGeneration.loadRooms(1, MapGeneration.mapFormat.isometric);
            mapGeneration.generateMap();
            mapGeneration.setTiles(LoadSprites.sprite.Values.ToArray());

            //Subdivide the tiles into 4 grid poisitions
            //Create the player
            grid.createGrid();
            player1.load();
        }

        public void updateGame()
        {
            //Get keyboard inputs
            var keyboardState = Keyboard.GetState();

            //TEMPERARY
            //Test for the space bar
            //Generate a new map
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                mapGeneration.generateMap();
                mapGeneration.setTiles(LoadSprites.sprite.Values.ToArray());
                grid.createGrid();
            }

            //Update the player
            player1.update();
        }

        public void drawGame(SpriteBatch spriteBatch)
        {
            //Draw the classes
            mapGeneration.drawMap(spriteBatch);
            grid.draw(spriteBatch);
            player1.draw(spriteBatch);
        }
    }
}
