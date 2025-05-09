using System;

namespace NeuralNetwork
{
    public class DataSet
    {
        // Запросы и правильные ответы к ним
        public double[] data;
        public double[] answer;

        public DataSet(double[] dt, double[] ans)
        {
            data = new double[dt.Length];
            answer = new double[ans.Length];

            // Заполнение массива data данными
            for (int i = 0; i < dt.Length; i++)
            {
                data[i] = dt[i];
            }

            // Заполнение массива answer данными
            for (int i = 0; i < ans.Length; i++)
            {
                answer[i] = ans[i];
            }
        }
    }
}
