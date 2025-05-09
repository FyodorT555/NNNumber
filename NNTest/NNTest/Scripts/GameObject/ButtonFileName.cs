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
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace DrawNumber.Scripts.GameObject
{
    public class ButtonFileName
    {
        public Transform transform;
        private Transform globalTransform;
        private Transform objectTransform;
        public bool Active { get; set; }

        public Texture2D texture;
        public SpriteFont font;

        public Image image;
        public Text text;
        public button button;

        public ButtonFileName(Vector2 v)
        {
            transform = new Transform(v, 0, new Vector2(2, 2));
            objectTransform = new Transform();
            globalTransform = objectTransform + transform;

            texture = Global.Content.Load<Texture2D>("Button7");
            font = Global.Content.Load<SpriteFont>("Font");

            image = new Image(globalTransform, texture);
            text = new Text(globalTransform, font, ". . .", new Vector2(30, 21));
            button = new button(globalTransform, image, delegate ()
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                
                if(openFileDialog.FileName != "")
                {
                    SceneMainManager.fileName = openFileDialog.FileName;

                    using (StreamWriter streamWriter = new StreamWriter(Environment.CurrentDirectory + "\\Data.dat"))
                    {
                        streamWriter.Write(openFileDialog.FileName);
                    }
                }
                SceneMainManager.TFLoad = 0;
            }, Color.LightBlue, Color.LightGray);

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
