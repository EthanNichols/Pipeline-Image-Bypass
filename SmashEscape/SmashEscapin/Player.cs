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
    class Player
    {
        //The grid location of the player
        //The actual position of the player
        private Vector2 gridPos;
        private Vector2 precisePos;

        //Random function
        //The last keyboard state
        private Random random = new Random();
        private KeyboardState prevState;

        public void load()
        {
            //Get a random tile on the map
            //Set the location of the player to that tile
            int num = random.Next(MapGrid.mapTiles.Count);
            gridPos = MapGrid.mapTiles.ElementAt(num).Key;
            precisePos = MapGrid.mapTiles.ElementAt(num).Value;
        }

        public void update()
        {
            //Get keyboard inputes
            //Set the last position of the player
            KeyboardState keyPress = Keyboard.GetState();
            Vector2 lastPos = gridPos;

            //Test if the last keyboard state is different from the new keyboard state
            //Move the player in a direction
            if (keyPress != prevState)
            {
                if (keyPress.IsKeyDown(Keys.I))
                {
                    gridPos.X--;
                    gridPos.Y--;
                }
                else if (keyPress.IsKeyDown(Keys.O))
                {
                    gridPos.X++;
                    gridPos.Y--;
                }
                else if (keyPress.IsKeyDown(Keys.K))
                {
                    gridPos.X--;
                    gridPos.Y++;
                }
                else if (keyPress.IsKeyDown(Keys.L))
                {
                    gridPos.X++;
                    gridPos.Y++;
                }
            }

            //Set the previous keyboard state to the current state
            prevState = keyPress;

            //Test if the tile the player moved to exists
            //Move the player to the new grid tile and move the camera
            //Else move the player back to their original position
            if (MapGrid.mapTiles.ContainsKey(gridPos))
            {
                precisePos = MapGrid.mapTiles[gridPos];
                Game1.camera.setPosition(MapGrid.mapTiles[gridPos]);
            }
            else
            {
                gridPos = lastPos;
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            //Draw the player on the map
            Texture2D image = LoadSprites.sprite["player"];
            spriteBatch.Draw(image, new Vector2(precisePos.X - image.Width / 2, precisePos.Y - image.Height), Color.White);
        }
    }
}
