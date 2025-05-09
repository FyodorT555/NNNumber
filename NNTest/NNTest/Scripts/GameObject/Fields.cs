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
    public class Fields
    {
        public Transform transform;
        private Transform globalTransform;
        private Transform objectTransform;
        public bool Active { get; set; }

        public Texture2D texture;
        public Image[][] field;

        public Fields(Vector2 v)
        {
            transform = new Transform(v);
            objectTransform = new Transform();
            globalTransform = objectTransform + transform;

            texture = Global.Content.Load<Texture2D>("Field");
            field = new Image[28][];
            for(int i = 0; i < 28; i++)
            {
                field[i] = new Image[28];
            }

            for(int i = 0;i < 28; i++)
            {
                for(int j = 0; j < 28; j++)
                {
                    field[i][j] = new Image(globalTransform, texture, new Vector2(i * 12f, j * 12f), 0f, new Vector2(0.35f, 0.35f));
                }
            }

            Active = true;
        }

        public void Update()
        {
            if (Active)
            {
                for(int i = 0; i < 28; i++)
                {
                    for(int j = 0; j < 28; j++)
                    {
                        field[i][j].color = new Color(SceneMainManager.pixel[i][j], SceneMainManager.pixel[i][j], SceneMainManager.pixel[i][j]);
                        field[i][j].Update(globalTransform);
                    }
                }
            }
        }
        public void Draw()
        {
            if (Active)
            {
                foreach(var item in field)
                {
                    foreach (var item2 in item)
                    {
                        item2.Draw();
                    }
                }
            }
        }
    }
}
