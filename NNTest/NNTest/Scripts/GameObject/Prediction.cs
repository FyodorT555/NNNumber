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
    public class Prediction
    {
        public Transform transform;
        private Transform globalTransform;
        private Transform objectTransform;
        public bool Active { get; set; }

        int n;
        public Texture2D texture0;
        public Texture2D texture1;
        public SpriteFont spriteFont;
        public Image image0;
        public Image image1;
        public Text text;

        public Prediction(Transform o, Vector2 v, int num)
        {
            transform = new Transform(v);
            transform.scale = new Vector2(0.8f, 0.8f);
            objectTransform = new Transform(o);
            globalTransform = objectTransform + transform;

            n = num;
            texture0 = Global.Content.Load<Texture2D>("g1");
            texture1 = Global.Content.Load<Texture2D>("g2");
            spriteFont = Global.Content.Load<SpriteFont>("Font");

            image0 = new Image(globalTransform, texture0, new Vector2(-7.1f, -70));
            image0.transform.scale = new Vector2(1.1f, 1.1f);
            image1 = new Image(globalTransform, texture1, new Vector2(-14f, -70));

            text = new Text(globalTransform, spriteFont, num.ToString());
            Active = true;
        }

        public void Update()
        {
            if (Active)
            {
                if(image0.transform.position.Y > (SceneMainManager.pred[n] * 51) - 13)
                {
                    image0.transform.position = new Vector2(-7.1f, (-(SceneMainManager.pred[n] * 51) - 13) + (image0.transform.position.Y - (-(SceneMainManager.pred[n] * 51) - 13)) / 5f);
                }
                else
                {
                    image0.transform.position = new Vector2(-7.1f, image0.transform.position.Y + ((-(SceneMainManager.pred[n] * 51) - 13) - image0.transform.position.Y) / 5f);
                }
                
                image0.Update(globalTransform);
                image1.Update(globalTransform);
                text.Update(globalTransform);
            }
        }
        public void Draw()
        {
            if (Active)
            {
                image0.Draw();
                image1.Draw();
                text.Draw();
            }
        }
    }
}
