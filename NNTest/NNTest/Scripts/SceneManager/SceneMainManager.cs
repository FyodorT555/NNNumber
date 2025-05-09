using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawNumber.Scripts.GameObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing;
using System.Xml.Linq;

namespace DrawNumber
{
    public static class SceneMainManager
    {
        public static float[][] pixel;
        public static float[] pred;
        public static bool draw;
        public static string fileName;
        public static int TFLoad;

        public static Fields fields;
        public static ButtonField buttonField;
        public static ButtonsDrawWash buttonDrawWash;
        public static ButtonClear buttonClear;
        public static TextAnswer textAnswer;
        public static ButtonNNCreate buttonNNCreate;
        public static ButtonNNGet buttonNNGet;
        public static ButtonFileName buttonFileName;
        public static TextFileName textFileName;
        public static Predictions predictions;
        public static NNetwork nNetwork;
        public static Scripts.GameObject.Version version;
        public static void Initialize()
        {
            pixel = new float[28][];
            for(int i = 0; i < 28; i++)
            {
                pixel[i] = new float[28];

                for(int j = 0; j < 28; j++)
                {
                    pixel[i][j] = 0f;
                }
            }
            pred = new float[10];

            draw = true;
            fileName = "";
            TFLoad = 0;

            fields = new Fields(new Vector2(10, 10));
            buttonField = new ButtonField(new Vector2(10, 10));
            buttonDrawWash = new ButtonsDrawWash(new Vector2(0, 360));
            buttonClear = new ButtonClear(new Vector2(20, 400));
            textAnswer = new TextAnswer(new Vector2(530, 180));
            buttonNNCreate = new ButtonNNCreate(new Vector2(375, 260));
            buttonNNGet = new ButtonNNGet(new Vector2(375, 350));
            buttonFileName = new ButtonFileName(new Vector2(685, 350));
            textFileName = new TextFileName(new Vector2(380, 415));
            predictions = new Predictions(new Vector2(365, 130));
            nNetwork = new NNetwork();
            version = new Scripts.GameObject.Version(new Vector2(755, 460), "v1.0.0");

            using(StreamReader streamReader = new StreamReader(Environment.CurrentDirectory + "\\Data.dat"))
            {
                fileName = streamReader.ReadToEnd();
            }
        }
        public static void DrawField(Vector2 pos)
        {
            int x = (int)(pos.X / 12f);
            int y = (int)(pos.Y / 12f);
            if (draw)
            {
                if (x >= 0 && x < 28 && y >= 0 && y < 28)
                {
                    pixel[x][y] = 1f;
                }
                if (x > 0)
                {
                    pixel[x - 1][y] = 1f;
                }
                if (x < 27)
                {
                    pixel[x + 1][y] = 1f;
                }
                if (y > 0)
                {
                    pixel[x][y - 1] = 1f;
                }
                if (y < 27)
                {
                    pixel[x][y + 1] = 1f;
                }
            }
            else
            {
                if(x >= 0 && x < 28 && y >= 0 && y < 28)
                {
                    pixel[x][y] = 0;
                }
                
                if (x > 0)
                {
                    if (pixel[x - 1][y] > 0)
                    {
                        pixel[x - 1][y] = 0;
                    }
                }
                if (x < 27)
                {
                    if (pixel[x + 1][y] > 0)
                    {
                        pixel[x + 1][y] = 0;
                    }
                }
                if (y > 0)
                {
                    if (pixel[x][y - 1] > 0)
                    {
                        pixel[x][y - 1] = 0;
                    }
                }
                if (y < 27)
                {
                    if (pixel[x][y + 1] > 0)
                    {
                        pixel[x][y + 1] = 0;
                    }
                }
            }


        }
        public static void Update()
        {
            fields.Update();
            buttonField.Update();
            buttonClear.Update();
            buttonDrawWash.Update();
            textAnswer.Update();
            buttonNNCreate.Update();
            buttonNNGet.Update();
            buttonFileName.Update();
            textFileName.Update();
            predictions.Update();
            nNetwork.Update();
            version.Update();
        }

        public static void Draw()
        {
            fields.Draw();
            buttonField.Draw();
            buttonClear.Draw();
            buttonDrawWash.Draw();
            buttonNNCreate.Draw();
            buttonNNGet.Draw();
            buttonFileName.Draw();
            textFileName.Draw();
            predictions.Draw();
            textAnswer.Draw();
            version.Draw();
        }
    }
}
