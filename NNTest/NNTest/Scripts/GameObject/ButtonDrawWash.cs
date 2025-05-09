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
    public class ButtonDrawWash
    {
        public Transform transform;
        private Transform globalTransform;
        private Transform objectTransform;
        public bool Active { get; set; }

        public Texture2D texture0, texture1;
        public SpriteFont font;
        public Image image;
        public button button;
        public Text text;
        public bool draw;

        public ButtonDrawWash(Transform o, bool d, Vector2 v)
        {
            transform = new Transform(v);
            objectTransform = new Transform(o);
            globalTransform = objectTransform + transform;

            draw = d;

            texture0 = Global.Content.Load<Texture2D>("OffActive");
            texture1 = Global.Content.Load<Texture2D>("OnActive");
            font = Global.Content.Load<SpriteFont>("Font");

            if(d)
            {
                image = new Image(globalTransform, texture1, new Transform(new Vector2(0, 0), 0f, new Vector2(0.3f, 0.3f)), Color.White);
            }
            else
            {
                image = new Image(globalTransform, texture0, new Transform(new Vector2(0, 0), 0f, new Vector2(0.3f, 0.3f)), Color.White);
            }

            button = new button(globalTransform, image, delegate()
            {
                if(d)
                {
                    if(image.texture == texture0)
                    {
                        SceneMainManager.draw = true;
                        SceneMainManager.buttonDrawWash.buttonWash.image.texture = texture0;
                        image.texture = texture1;
                    }
                }
                else
                {
                    if (image.texture == texture0)
                    {
                        SceneMainManager.draw = false;
                        SceneMainManager.buttonDrawWash.buttonDraw.image.texture = texture0;
                        image.texture = texture1;
                    }
                }
                SceneMainManager.TFLoad = 0;
            }, Color.LightBlue, Color.LightGray);

            if(draw)
            {
                text = new Text(globalTransform, font, "карандаш", new Vector2(30, 0));
            }
            else
            {
                text = new Text(globalTransform, font, "ластик", new Vector2(30, 0));
            }

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
            if(Active)
            {
                image.Draw();
                text.Draw();
            }
        }
    }
}
