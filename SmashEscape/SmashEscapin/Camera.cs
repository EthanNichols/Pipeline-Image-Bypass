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
    public class Camera
    {
        //The view that the camera can see
        //private readonly Viewport view;

        //The position of the camera
        //The zoom of the camera
        //The center of the camera
        public Vector2 position { get; set; }
        public float zoom { get; set; }
        public Vector2 origin { get; set; }

        public Camera(Viewport view)
        {
            //Set the camera's position to 0
            //Set the zoom to 1
            //Set the origin to the center of the camera's view
            position = Vector2.Zero;
            zoom = 1f;
            origin = new Vector2(view.Width / 2, view.Height / 2);
        }

        public Matrix viewMatrix()
        {
            //Return information about where the camera is, and what's visible
            return
                Matrix.CreateTranslation(new Vector3(-position, 0f)) *
                Matrix.CreateTranslation(new Vector3(-origin, 0f)) *
                Matrix.CreateScale(zoom, zoom, 1) *
                Matrix.CreateTranslation(new Vector3(origin, 0f));
        }

        public void setPosition(Vector2 setPosition)
        {
            //Center the camera on the position in the parameter
            position = new Vector2(setPosition.X - LoadSprites.screenSize.X / 2, setPosition.Y - LoadSprites.screenSize.Y / 2);
        }

        /*
        public void move(GameTime gameTime)
        {
            //The time that has passed
            //The state of the keyboard, which buttons are pressed
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var keyboardState = Keyboard.GetState();

            //The speed of the camera
            int speed = 3000;

            //Test for a key to move the camera in a direction
            //Move the camera relative to the direction input and speed of the game
            if (keyboardState.IsKeyDown(Keys.W))
            {
                position -= new Vector2(0, speed) * deltaTime;
            }

            if (keyboardState.IsKeyDown(Keys.A))
            {
                position -= new Vector2(speed, 0) * deltaTime;
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                position += new Vector2(0, speed) * deltaTime;
            }

            if (keyboardState.IsKeyDown(Keys.D))
            {
                position += new Vector2(speed, 0) * deltaTime;
            }

            position = new Vector2((int)position.X, (int)position.Y);
        }
    */
    }
}
