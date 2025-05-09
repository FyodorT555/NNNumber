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
using NeuralNetwork;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DrawNumber.Scripts.GameObject
{
    public class ButtonNNGet
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

        public ButtonNNGet(Vector2 v)
        {
            transform = new Transform(v, 0, new Vector2(2, 2));
            objectTransform = new Transform();
            globalTransform = objectTransform + transform;

            texture = Global.Content.Load<Texture2D>("Button5");
            font = Global.Content.Load<SpriteFont>("Font");

            image = new Image(globalTransform, texture);
            text = new Text(globalTransform, font, "Загрузить нейросеть из файла", new Vector2(30, 21));
            button = new button(globalTransform, image, delegate ()
            {
                if(SceneMainManager.fileName != "")
                {
                    try
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(NN));
                        using (StreamReader sr = new StreamReader(SceneMainManager.fileName))
                        {
                            SceneMainManager.nNetwork.nn = (NN)xmlSerializer.Deserialize(sr);
                        }
                        SceneMainManager.TFLoad = 1;
                    }
                    catch(Exception)
                    {
                        SceneMainManager.TFLoad = 2;
                    }
                }
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
