using System;

namespace NeuralNetwork
{
    public class NN
    {
        // Нейроны и веса
        public double[][] neuron;
        public double[][][] weight;

        // Скорость обучения
        public double alpha;

        public NN()
        {
            Random rand = new Random();

            // Инициализация массива neuron
            neuron = new double[4][];
            neuron[0] = new double[784];
            neuron[1] = new double[16];
            neuron[2] = new double[16];
            neuron[3] = new double[10];

            // Инициализация массива weight
            weight = new double[neuron.Length - 1][][];

            for (int i = 0; i < neuron.Length - 1; i++)
            {
                weight[i] = new double[neuron[i].Length][];

                for (int j = 0; j < neuron[i].Length; j++)
                {
                    weight[i][j] = new double[neuron[i + 1].Length];
                }
            }

            // Заполнение массива weight случайными значениями
            for (int i = 0; i < weight.Length; i++)
            {
                for (int j = 0; j < weight[i].Length; j++)
                {
                    for (int q = 0; q < weight[i][j].Length; q++)
                    {
                        weight[i][j][q] = rand.Next(-100, 100) / 100d;
                    }
                }
            }

            // Инициализация переменной alpha
            alpha = 0.1d;
        }

        public double[] Start(double[] data)
        {
            // Заполнение входного слоя данными
            for (int i = 0; i < neuron[0].Length; i++)
            {
                neuron[0][i] = data[i];
            }

            // Вычисление предсказания
            for (int i = 1; i < neuron.Length; i++)
            {
                for (int j = 0; j < neuron[i].Length; j++)
                {
                    neuron[i][j] = 0d;
                    for (int q = 0; q < neuron[i - 1].Length; q++)
                    {
                        neuron[i][j] += neuron[i - 1][q] * weight[i - 1][q][j];
                    }

                    neuron[i][j] = Sigmoida(neuron[i][j]);
                }
            }

            // Возврат предсказания
            double[] prediction = new double[neuron[neuron.Length - 1].Length];

            for (int i = 0; i < neuron[neuron.Length - 1].Length; i++)
            {
                prediction[i] = neuron[neuron.Length - 1][i];
            }

            return prediction;
        }

        public void Train(DataSet data)
        {
            // Создание и инициализация массива delta
            double[][] delta = new double[neuron.Length][];
            for (int i = 0; i < neuron.Length; i++)
            {
                delta[i] = new double[neuron[i].Length];

                for(int j = 0; j < neuron[i].Length; j++)
                {
                    delta[i][j] = 0;
                }
            }

            // Получение предсказания нейросети
            double[] ans = new double[neuron[neuron.Length - 1].Length];
            ans = Start(data.data);

            // Вычисление дельт
            for (int i = neuron.Length - 2; i > -1; i--)
            {
                if (i == neuron.Length - 2)
                {
                    for (int j = 0; j < neuron[neuron.Length - 1].Length; j++)
                    {
                        delta[neuron.Length - 1][j] = (ans[j] - data.answer[j]) * SigmoidaD(ans[j]);
                    }
                }
                else
                {
                    for (int j = 0; j < neuron[i + 1].Length; j++)
                    {
                        for (int q = 0; q < neuron[i + 2].Length; q++)
                        {
                            delta[i + 1][j] += delta[i + 2][q] * weight[i + 1][j][q];
                        }
                        delta[i + 1][j] *= SigmoidaD(neuron[i + 1][j]);
                    }
                }
            }

            // Коррекция весов
            for (int i = neuron.Length - 2; i > -1; i--)
            {
                for (int j = 0; j < neuron[i].Length; j++)
                {
                    for (int q = 0; q < neuron[i + 1].Length; q++)
                    {
                        double deltaWeight = neuron[i][j] * delta[i + 1][q];
                        weight[i][j][q] -= deltaWeight * alpha;
                    }
                }
            }
        }

        // Функция активации и её производная
        public double Sigmoida(double x)
        {
            return 1d / (1d + Math.Pow(Math.E, -x));
        }
        public double SigmoidaD(double x)
        {
            return (1d - x) * x;
        }
    }
}