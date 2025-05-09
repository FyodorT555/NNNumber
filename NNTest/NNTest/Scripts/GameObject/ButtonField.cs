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
    public class ButtonField
    {
        public Transform transform;
        private Transform globalTransform;
        private Transform objectTransform;
        public bool Active { get; set; }

        public Rectangle rectangle;
        public EventSystem eventSystem;

        public ButtonField(Vector2 v)
        {
            transform = new Transform(v);
            objectTransform = new Transform();
            globalTransform = objectTransform + transform;

            rectangle = new Rectangle((int)globalTransform.position.X, (int)globalTransform.position.X, 335, 335);
            eventSystem = new EventSystem(globalTransform, rectangle, delegate () { }, delegate()
            {
                Vector2 pos = new Vector2(Global.MouseCursor.X - 10, Global.MouseCursor.Y - 10);
                SceneMainManager.DrawField(pos);
                SceneMainManager.TFLoad = 0;
            }, delegate () { });

            Active = true;
        }

        public void Update()
        {
            if (Active)
            {
                eventSystem.Update(globalTransform);
            }
        }
        public void Draw()
        {
        }
    }
}
