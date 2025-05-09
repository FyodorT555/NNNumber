using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DrawNumber.Scripts.Basy.Component
{
    public class Transform
    {
        public Vector2 position {  get; set; }
        public float rotation { get; set; }
        public Vector2 scale { get; set; }

        public Transform()
        {
            position = new Vector2();
            rotation = new float();
            scale = new Vector2(1, 1);
        }
        public Transform(Vector2 p)
        {
            position = p;
            rotation = new float();
            scale = new Vector2(1, 1);
        }
        public Transform(Vector2 p, float r, Vector2 s)
        {
            position = p;
            rotation = r;
            scale = s;
        }
        public Transform(Transform tr)
        {
            position = tr.position;
            rotation = tr.rotation;
            scale = tr.scale;
        }

        public static Transform operator +(Transform a, Transform b)
        {
            Transform ans = new Transform();
            ans.position = a.position + b.position;
            ans.rotation = a.rotation + b.rotation;
            ans.scale = a.scale * b.scale; 

            return ans;
        }
    }
}
