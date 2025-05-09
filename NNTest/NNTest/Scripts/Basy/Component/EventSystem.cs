using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DrawNumber.Scripts.Basy.Globals;

namespace DrawNumber.Scripts.Basy.Component
{
    public class EventSystem
    {
        public Transform transform;
        private Transform objectTransform;
        private Transform globalTransform;
        public bool Active { get; set; }

        public Rectangle rectangle;

        public Global.Event click;
        public Global.Event pressed;
        public Global.Event intersect;

        public EventSystem(Transform o, Rectangle r, Global.Event cl)
        {
            objectTransform = o;
            rectangle = r;
            click = cl;

            transform = new Transform();
            globalTransform = objectTransform + transform;
            pressed = delegate () { };
            intersect = delegate () { };
            Active = true;
        }
        public EventSystem(Transform o, Image i, Global.Event cl)
        {
            objectTransform = o;
            rectangle = new Rectangle(i.rectangle.X, i.rectangle.Y, i.rectangle.Width, i.rectangle.Height);
            click = cl;

            transform = new Transform();
            globalTransform = objectTransform + transform;
            pressed = delegate () { };
            intersect = delegate () { };
            Active = true;
        }
        public EventSystem(Transform o, Rectangle r, Global.Event cl, Global.Event press, Global.Event inter)
        {
            objectTransform = o;
            rectangle = r;
            click = cl;
            pressed = press;
            intersect = inter;

            transform = new Transform();
            globalTransform = objectTransform + transform;
            Active = true;
        }
        public EventSystem(Transform o, Image i, Global.Event cl, Global.Event press, Global.Event inter)
        {
            objectTransform = o;
            rectangle = new Rectangle(i.rectangle.X, i.rectangle.Y, i.rectangle.Width, i.rectangle.Height);
            click = cl;
            pressed = press;
            intersect = inter;

            transform = new Transform();
            globalTransform = objectTransform + transform;
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
                        pressed();
                    }
                    else
                    {
                        intersect();
                    }
                }
            }
        }
    }
}
