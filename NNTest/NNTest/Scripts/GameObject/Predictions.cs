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
    public class Predictions
    {
        public Transform transform;
        private Transform globalTransform;
        private Transform objectTransform;
        public bool Active { get; set; }

        public Prediction[] prediction;

        public Predictions(Vector2 v)
        {
            transform = new Transform(v);
            objectTransform = new Transform();
            globalTransform = objectTransform + transform;

            prediction = new Prediction[10];
            for (int i = 0; i < 10; i++)
            {
                prediction[i] = new Prediction(globalTransform, new Vector2(i * 45, 0), i);
            }

            Active = true;
        }

        public void Update()
        {
            if (Active)
            {
                foreach (var item in prediction)
                {
                    item.Update();
                }
            }
        }
        public void Draw()
        {
            if (Active)
            {
                foreach (var item in prediction)
                {
                    item.Draw();
                }
            }
        }
    }
}
