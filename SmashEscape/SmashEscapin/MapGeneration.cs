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
    class MapGeneration
    {

        //Dictionary for the map images
        //The starting number for loading the map files
        //Random function
        //The format of the map
        private Dictionary<int, Texture2D> maps = new Dictionary<int, Texture2D>();
        private int fileStartingNum;
        private Random random = new Random();
        private mapFormat format = mapFormat.topDown;

        //List of tiles that will visibly show the map
        public static Dictionary<Vector2, Texture2D> Tiles = new Dictionary<Vector2, Texture2D>();

        //The different formats for the map
        public enum mapFormat
        {
            topDown,
            isometric,
        }

        public void loadRooms(int mapStartingNum, mapFormat setFormat)
        {
            //The current map number that is being tested
            //The path to acess the map files
            int mapNum = mapStartingNum;
            fileStartingNum = mapStartingNum;
            format = setFormat;

            string pathDirectory = Directory.GetCurrentDirectory() + "\\Content\\Maps\\map";


            //Make sure that the file exists
            while (File.Exists(pathDirectory + mapNum + ".png"))
            {

                //Open the image using a file stream
                using (FileStream fileStream = new FileStream(pathDirectory + mapNum + ".png", FileMode.Open))
                {
                    //Set the texture of the image from the file stream
                    //Add the name of the map and the texture to a dictionary
                    Texture2D image = Texture2D.FromStream(new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, new PresentationParameters()), fileStream);
                    maps.Add(mapNum, image);

                    fileStream.Close();
                }

                //Increase the map number that is being added
                mapNum++;
            }
        }

        private Texture2D randomMap()
        {
            //Pick a random map from the dictionary
            //Return the map texture
            int randomMap = random.Next(fileStartingNum, maps.Count + fileStartingNum);
            return maps[randomMap];
        }

        public void generateMap()
        {
            //Get a ranom map from the dictionary
            //Create an array the size of the map
            //Set all the pixel values into the array
            //Clear the map that is currently visible
            Texture2D map = randomMap();
            Color[] pixelColors = new Color[map.Width * map.Height];
            map.GetData<Color>(pixelColors);
            Tiles.Clear();

            //The X and Y position of the pixel
            int pixelX = 0;
            int pixelY = 0;

            //Get information about each pixel
            foreach (Color pixelColor in pixelColors)
            {
                //Make sure the pixel isn't transparent
                if (pixelColor.A != 0)
                {
                    //Whether a tile should be added to the list of not
                    bool newTile = false;

                    //Test the format of the map
                    //Test if the pixel being tested should be places
                    switch (format)
                    {
                        case mapFormat.topDown:
                            newTile = true;
                            break;

                        case mapFormat.isometric:
                            if ((pixelX - (pixelY % 2)) % 2 == 0)
                            {
                                newTile = true;
                            }
                            break;
                    }

                    //Test to add a new tile then add a new tile
                    if (newTile)
                    {
                        Tiles.Add(new Vector2(pixelX, pixelY), null);
                    }
                }

                //Increase the X position of the pixel
                //Test if the X position is greater than the map width
                //Reset the X position to 0
                //Increase the Y postition
                pixelX++;
                if (pixelX >= map.Width)
                {
                    pixelX = 0;
                    pixelY++;
                }
            }
        }

        public void setTiles(Texture2D[] tileSprites)
        {
            //Take the tiles' position and turn them into an array
            //Select one texture out of the sprite array
            Vector2[] tilePos = Tiles.Keys.ToArray();
            Texture2D tile = tileSprites[random.Next(0, tileSprites.Count())];

            //Go through each tile position and set the texture of the tile
            foreach (Vector2 pos in tilePos)
            {
                Tiles[pos] = tile;
            }
        }

        public void drawMap(SpriteBatch spriteBatch)
        {
            //Get information about all of the tiles
            foreach (KeyValuePair<Vector2, Texture2D> info in Tiles)
            {
                //Quick variable defining for simplcity
                float x = info.Key.X;
                float y = info.Key.Y;
                float width = info.Value.Width;
                float height = info.Value.Height;

                //Make sure there is an image to draw
                if (info.Value != null)
                {
                    //Test the format of the map
                    //Draw each tiles in the right position in the right map format
                    switch (format)
                    {
                        case mapFormat.topDown:
                            spriteBatch.Draw(info.Value, new Vector2(x * width, y * height), Color.White);
                            break;

                        case mapFormat.isometric:
                            spriteBatch.Draw(info.Value, new Vector2(x * (width / 2), y * (width / 4)), Color.White);
                            break;
                    }
                }
            }
        }
    }
}
