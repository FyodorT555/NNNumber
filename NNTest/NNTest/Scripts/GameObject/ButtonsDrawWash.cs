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
    public class ButtonsDrawWash
    {
        public Transform transform;
        private Transform globalTransform;
        private Transform objectTransform;
        public bool Active { get; set; }

        public ButtonDrawWash buttonDraw, buttonWash;

        public ButtonsDrawWash(Vector2 v)
        {
            transform = new Transform(v);
            objectTransform = new Transform();
            globalTransform = objectTransform + transform;

            buttonDraw = new ButtonDrawWash(globalTransform, true, new Vector2(30, 0));
            buttonWash = new ButtonDrawWash(globalTransform, false, new Vector2(220, 0));

            Active = true;
        }
        public void Update()
        {
            if(Active)
            {
                buttonDraw.Update();
                buttonWash.Update();
            }
        }

        public void Draw()
        {
            if (Active)
            {
                buttonDraw.Draw();
                buttonWash.Draw();
            }
        }
    }
}
