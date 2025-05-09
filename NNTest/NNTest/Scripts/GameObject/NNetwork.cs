using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;
using SharpDX.MediaFoundation;

namespace DrawNumber.Scripts.GameObject
{
    public class NNetwork
    {
        public NN nn;
        public double[] data;
        double[] ans;
        public NNetwork()
        {
            nn = new NN();
            data = new double[784];
            ans = new double[10];
        }
        
        public void Update()
        {
            int count = 0;

            for (int i = 0; i < 28;i++)
            {
                for(int j = 0; j < 28;j++)
                {
                    data[count] = SceneMainManager.pixel[j][i];
                    count++;
                }
            }

            ans = nn.Start(data);
            for(int i = 0; i < 10; i++)
            {
                SceneMainManager.pred[i] = (float)ans[i];
            }
        }
    }
}
