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
    public class TextFileName
    {
        public Transform transform;
        private Transform globalTransform;
        private Transform objectTransform;
        public bool Active { get; set; }

        public SpriteFont font;
        public Text fileName;

        public TextFileName(Vector2 v)
        {
            transform = new Transform(v);
            objectTransform = new Transform();
            globalTransform = objectTransform + transform;

            font = Global.Content.Load<SpriteFont>("SmallFont");
            fileName = new Text(globalTransform, font, SceneMainManager.fileName);

            Active = true;

        }

        public void Update()
        {
            if (Active)
            {
                globalTransform = objectTransform + transform;
                if(SceneMainManager.TFLoad == 0)
                {
                    fileName.text = SceneMainManager.fileName;
                }
                else if(SceneMainManager.TFLoad == 1)
                {
                    fileName.text = "Данные нейросети успешно загружены";
                }
                else
                {
                    fileName.text = "Не удалось загрузить данные нейросети";
                }
                fileName.Update(globalTransform);
            }
        }
        public void Draw()
        {
            if (Active)
            {
                fileName.Draw();
            }
        }
    }
}
