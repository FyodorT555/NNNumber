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
    public class Text
    {
        public Transform transform;
        private Transform objectTransform;
        private Transform globalTransform;
        public bool Active { get; set; }

        public SpriteFont font;
        public Color color;
        public string text;

        public Text(Transform o, SpriteFont f, string tx)
        {
            objectTransform = o;
            font = f;
            text = tx;

            transform = new Transform();
            globalTransform = objectTransform + transform;
            color = Color.Black;

            Active = true;
        }
        public Text(Transform o, SpriteFont f, string tx, Vector2 p)
        {
            objectTransform = o;
            transform = new Transform(p);
            font = f;
            text = tx;

            globalTransform = objectTransform + transform;
            color = Color.Black;

            Active = true;
        }
        public Text(Transform o, SpriteFont f, string tx, Vector2 p, Color c)
        {
            objectTransform = o;
            transform = new Transform(p);
            font = f;
            text = tx;

            globalTransform = objectTransform + transform;
            color = Color.Black;

            Active = true;
        }
        public Text(Transform o, SpriteFont f, string tx, Vector2 p, float r, Vector2 s)
        {
            objectTransform = o;
            transform = new Transform(p, r, s);
            font = f;
            text = tx;

            globalTransform = objectTransform + transform;
            color = Color.Black;

            Active = true;
        }
        public Text(Transform o, SpriteFont f, string tx, Vector2 p, float r, Vector2 s, Color c)
        {
            objectTransform = o;
            transform = new Transform(p, r, s);
            font = f;
            text = tx;

            globalTransform = objectTransform + transform;
            color = c;

            Active = true;
        }
        public Text(Transform o, SpriteFont f, string tx, Transform tr, Color c)
        {
            objectTransform = o;
            transform = new Transform(tr);
            font = f;
            text = tx;

            globalTransform = objectTransform + transform;
            color = c;

            Active = true;
        }


        public void Update(Transform t)
        {
            if (Active)
            {
                globalTransform = t + transform;
            }
        }
        public void Draw()
        {
            if (Active)
            {
                Global.SpriteBatch.DrawString(font, text, globalTransform.position, color, globalTransform.rotation, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            }
        }
    }
}
