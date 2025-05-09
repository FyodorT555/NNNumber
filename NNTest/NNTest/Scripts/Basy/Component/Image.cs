using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DrawNumber.Scripts.Basy.Globals;

namespace DrawNumber.Scripts.Basy.Component
{
    public class Image
    {
        public Transform transform;
        private Transform objectTransform;
        private Transform globalTransform;
        public bool Active { get; set; }

        public Texture2D texture;
        public Rectangle rectangle;
        public Color color;

        public Image(Transform o, Texture2D t)
        {
            objectTransform = o;
            texture = t;

            transform = new Transform();
            globalTransform = objectTransform + transform;
            rectangle = new Rectangle((int)globalTransform.position.X, (int)globalTransform.position.Y, (int)(t.Width * globalTransform.scale.X), (int)(t.Height * globalTransform.scale.Y));
            color = Color.White;

            Active = true;
        }
        public Image(Transform o, Texture2D t, Vector2 p)
        {
            objectTransform = o;
            transform = new Transform(p);
            texture = t;

            globalTransform = objectTransform + transform;
            rectangle = new Rectangle((int)globalTransform.position.X, (int)globalTransform.position.Y, (int)(t.Width * globalTransform.scale.X), (int)(t.Height * globalTransform.scale.Y));
            color = Color.White;

            Active = true;
        }
        public Image(Transform o, Texture2D t, Vector2 p, Color c)
        {
            objectTransform = o;
            transform = new Transform(p);
            texture = t;

            globalTransform = objectTransform + transform;
            rectangle = new Rectangle((int)globalTransform.position.X, (int)globalTransform.position.Y, (int)(t.Width * globalTransform.scale.X), (int)(t.Height * globalTransform.scale.Y));
            color = c;

            Active = true;
        }
        public Image(Transform o, Texture2D t, Vector2 p, float r, Vector2 s)
        {
            objectTransform = o;
            transform = new Transform(p, r, s);
            texture = t;

            globalTransform = objectTransform + transform;
            rectangle = new Rectangle((int)globalTransform.position.X, (int)globalTransform.position.Y, (int)(t.Width * globalTransform.scale.X), (int)(t.Height * globalTransform.scale.Y));
            color = Color.White;

            Active = true;
        }
        public Image(Transform o, Texture2D t, Vector2 p, float r, Vector2 s, Color c)
        {
            objectTransform = o;
            transform = new Transform(p, r, s);
            texture = t;

            globalTransform = objectTransform + transform;
            rectangle = new Rectangle((int)globalTransform.position.X, (int)globalTransform.position.Y, (int)(t.Width * globalTransform.scale.X), (int)(t.Height * globalTransform.scale.Y));
            color = c;

            Active = true;
        }
        public Image(Transform o, Texture2D t, Transform tr, Color c)
        {
            objectTransform = o;
            transform = new Transform(tr);
            texture = t;

            globalTransform = objectTransform + transform;
            rectangle = new Rectangle((int)globalTransform.position.X, (int)globalTransform.position.Y, (int)(t.Width * globalTransform.scale.X), (int)(t.Height * globalTransform.scale.Y));
            color = c;

            Active = true;
        }


        public void Update(Transform t)
        {
            if (Active)
            {
                globalTransform = t + transform;
                rectangle = new Rectangle((int)globalTransform.position.X, (int)globalTransform.position.Y, (int)(texture.Width * globalTransform.scale.X), (int)(texture.Height * globalTransform.scale.Y));
            }
        }
        public void Draw()
        {
            if (Active)
            {
                Global.SpriteBatch.Draw(texture, rectangle, null, color, globalTransform.rotation, new Vector2(0, 0), SpriteEffects.None, 1);
            }
        }
    }
}
