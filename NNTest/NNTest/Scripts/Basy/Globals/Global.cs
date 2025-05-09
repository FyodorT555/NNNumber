using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace DrawNumber.Scripts.Basy.Globals
{
    public static class Global
    {
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static MouseState MouseState { get; set; }
        public static MouseState LastMouseState { get; set; }
        public static bool Clicked { get; set; }
        public static Rectangle MouseCursor { get; set; }

        public delegate void Event();

        public static void Update()
        {
            LastMouseState = MouseState;
            MouseState = Mouse.GetState();


            Clicked = (MouseState.LeftButton == ButtonState.Released) && (LastMouseState.LeftButton == ButtonState.Pressed);
            MouseCursor = new Rectangle(MouseState.Position, new Point(1, 1));
        }
    }
}
