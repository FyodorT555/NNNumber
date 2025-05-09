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
using System.ComponentModel;

namespace DrawNumber.Scripts.GameObject
{
    public class TextAnswer
    {
        public Transform transform;
        private Transform globalTransform;
        private Transform objectTransform;
        public bool Active { get; set; }

        public SpriteFont font;
        public Text predMax;

        private double max;
        private int ind;

        public TextAnswer(Vector2 v)
        {
            transform = new Transform(v);
            objectTransform = new Transform();
            globalTransform = objectTransform + transform;

            font = Global.Content.Load<SpriteFont>("Font");
            
            max = SceneMainManager.pred[0];
            ind = 0;

            for(int i = 0; i < 10; i++)
            {
                if (SceneMainManager.pred[i] > max)
                {
                    max = SceneMainManager.pred[i];
                    ind = i;
                }
            }

            predMax = new Text(globalTransform, font, "Ответ: " + ind.ToString());

            Active = true;

        }

        public void Update()
        {
            if (Active)
            {
                globalTransform = objectTransform + transform;
                
                max = SceneMainManager.pred[0];
                ind = 0;

                for (int i = 0; i < 10; i++)
                {
                    if (SceneMainManager.pred[i] > max)
                    {
                        max = SceneMainManager.pred[i];
                        ind = i;
                    }
                }

                predMax.text = "Ответ: " + ind.ToString();
                predMax.Update(globalTransform);
            }
        }
        public void Draw()
        {
            if (Active)
            {
                predMax.Draw();
            }
        }
    }
}
