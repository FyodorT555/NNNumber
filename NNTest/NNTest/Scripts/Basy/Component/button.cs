using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawNumber.Scripts.Basy.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DrawNumber.Scripts.Basy.Component
{
    public class button
    {
        public Transform transform;
        private Transform objectTransform;
        private Transform globalTransform;
        public bool Active { get; set; }

        public Rectangle rectangle;
        public Global.Event click;

        public Color color;
        public Color pressedColor;
        public Color intersectColor;
        public Color normalColor;
        public button(Transform o, Rectangle r, Global.Event ev)
        {
            objectTransform = o;
            rectangle = r;
            click = ev;

            transform = new Transform();
            globalTransform = objectTransform + transform;
            normalColor = Color.White;
            pressedColor = Color.White;
            intersectColor = Color.White;
            Active = true;
        }
        public button(Transform o, Image i, Global.Event ev)
        {
            objectTransform = o;
            rectangle = new Rectangle(i.rectangle.X, i.rectangle.Y, i.rectangle.Width, i.rectangle.Height);
            click = ev;
            
            transform = new Transform();
            globalTransform = objectTransform + transform;
            normalColor = Color.White;
            pressedColor = Color.White;
            intersectColor = Color.White;
            Active = true;
        }
        public button(Transform o, Rectangle r, Global.Event ev, Color pressed, Color intersect)
        {
            objectTransform = o;
            rectangle = r;
            click = ev;
            pressedColor = pressed;
            intersectColor = intersect;

            transform = new Transform();
            globalTransform = objectTransform + transform;
            normalColor = Color.White;
            Active = true;
        }
        public button(Transform o, Image i, Global.Event ev, Color pressed, Color intersect)
        {
            objectTransform = o;
            rectangle = new Rectangle(i.rectangle.X, i.rectangle.Y, i.rectangle.Width, i.rectangle.Height);
            click = ev;
            pressedColor = pressed;
            intersectColor = intersect;

            transform = new Transform();
            globalTransform = objectTransform + transform;
            normalColor = Color.White;
            Active = true;
        }

        public void Update(Transform t)
        {
            if (Active)
            {
                objectTransform = t;
                globalTransform = objectTransform + transform;
                rectangle = new Rectangle((int)globalTransform.position.X, (int)globalTransform.position.Y, rectangle.Width, rectangle.Height);

                if (Global.MouseCursor.Intersects(rectangle))
                {
                    if (Global.Clicked)
                    {
                        click();
                    }

                    if (Global.MouseState.LeftButton == ButtonState.Pressed)
                    {
                        color = pressedColor;
                    }
                    else
                    {
                        color = intersectColor;
                    }
                }
                else
                {
                    color = normalColor;
                }
            }
        }
    }
}
