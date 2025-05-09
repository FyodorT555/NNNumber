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
    public class ButtonClear
    {
        public Transform transform;
        private Transform globalTransform;
        private Transform objectTransform;
        public bool Active {  get; set; }

        public Texture2D texture;
        public SpriteFont font;
        public Image image;
        public button button;
        public Text text;
        public ButtonClear(Vector2 v)
        {
            transform = new Transform(v, 0, new Vector2(2, 2));
            objectTransform = new Transform();
            globalTransform = objectTransform + transform;

            texture = Global.Content.Load<Texture2D>("Button4");
            font = Global.Content.Load<SpriteFont>("Font");
            image = new Image(globalTransform, texture);

            button = new button(globalTransform, image, delegate
            {
                for(int i = 0; i < 28; i++)
                {
                    for(int j = 0; j < 28; j++)
                    {
                        SceneMainManager.pixel[i][j] = 0;
                    }
                }
                SceneMainManager.TFLoad = 0;
            }, Color.LightBlue, Color.LightGray);
            text = new Text(globalTransform, font, "Очистить", new Vector2(120, 17));
            Active = true;
        }

        public void Update()
        {
            if (Active)
            {
                globalTransform = objectTransform + transform;
                button.Update(globalTransform);
                image.color = button.color;
                image.Update(globalTransform);
                text.Update(globalTransform);
            }
        }
        public void Draw()
        {
            if (Active)
            {
                image.Draw();
                text.Draw();
            }
        }
    }
}
