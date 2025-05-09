using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawNumber
{
    public static class GameManager
    {
        public static void Initialize()
        {
            SceneMainManager.Initialize();
        }

        public static void  Update()
        {
            SceneMainManager.Update();
        }

        public static void Draw()
        {
            SceneMainManager.Draw();
        }
    }
}
