using System;
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
    public class LoadSprites
    {
        //A public dictionary of sprites that can be drawn
        public static Dictionary<string, Texture2D> sprite = new Dictionary<string, Texture2D>();
        public static SpriteFont font;
        public static Vector2 screenSize;

        Random random = new Random();

        public LoadSprites(ContentManager Content, GraphicsDeviceManager graphics)
        {
            font = Content.Load<SpriteFont>("Font");

            //Set where images will be loaded from
            Content.RootDirectory = "Content";

            //Set the size of the screen
            screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            string subDir = "Tiles/";

            //Add the images into the dictionary
            sprite.Add("marble", Content.Load<Texture2D>(subDir + "Marble"));
            sprite.Add("metallic", Content.Load<Texture2D>(subDir + "Metallic"));
            sprite.Add("pat", Content.Load<Texture2D>(subDir + "Pat"));
            sprite.Add("wood1", Content.Load<Texture2D>(subDir + "Wood1"));
            sprite.Add("wood2", Content.Load<Texture2D>(subDir + "Wood2"));
            sprite.Add("player", Content.Load<Texture2D>("Player"));
        }

        public void drawSprites(SpriteBatch spriteBatch)
        {
            //This is for testing sprites only
            //Do not call any function in this function

            //spriteBatch.Draw(sprite["marble"], new Vector2(100, 100), Color.White);

            //Texture2D randomTile = sprite.ElementAt(random.Next(0, sprite.Count)).Value;

            //Texture2D image = sprite["pat"];

            //mapGeneration.drawMap(spriteBatch, sprite["wood1"]);
        }
    }
}
