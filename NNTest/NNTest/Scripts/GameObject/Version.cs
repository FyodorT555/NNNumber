using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DrawNumber.Scripts.Basy.Component;
using DrawNumber.Scripts.Basy.Globals;

namespace DrawNumber.Scripts.GameObject
{
    public class Version
    {
        public Transform transform;
        private Transform globalTransform;
        private Transform objectTransform;
        public bool Active { get; set; }

        public SpriteFont font;
        public Text version;

        public Version(Vector2 v, string ver)
        {
            transform = new Transform(v);
            objectTransform = new Transform();
            globalTransform = objectTransform + transform;

            font = Global.Content.Load<SpriteFont>("Font");
            version = new Text(globalTransform, font, ver);

            Active = true;
            
        }

        public void Update()
        {
            if (Active)
            {
                globalTransform = objectTransform + transform;
                version.Update(globalTransform);
            }
        }
        public void Draw()
        {
            if (Active)
            {
                version.Draw();
            }
        }
    }
}
