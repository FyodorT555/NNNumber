using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using NeuralNetwork;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace NNNumber
{
    public static class Program
    {
        public static void Main()
        {
            // Создание и инициализация нейросети
            NN nn = new NN();

            // Выяснение нахождение файла, куда будут сохраняться данные нейросети
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Вставьте путь к файлу, куда будут сохраняться данные нейросети, или нажмите Enter, чтобы использовать сохранённый путь");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("> ");
            string str;
            str = Console.ReadLine();

            string file;
            if (str != "")
            {
                if(File.Exists(str))
                {
                    file = str;
                    using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\file.dat"))
                    {
                        sw.Write(str);
                    }
                    Console.WriteLine("Использован путь к файлу ({0})", str);
                }
                else
                {
                    Console.WriteLine("Данный данный путь к файлу не существует");
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\file.dat"))
                {
                    file = sr.ReadToEnd();
                }
                if (File.Exists(file))
                {
                    Console.WriteLine("Использован сохранённый путь к файлу ({0})", file);
                }
                else
                {
                    Console.WriteLine("Cохранённый путь к файлу ({0}) не существует", file);
                    Console.ReadKey();
                    return;
                }
                
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // Получение всех необходимых файлов для обучения
            Console.WriteLine("Нажмите Enter, чтобы получить список имён файлов из папки " + Directory.GetCurrentDirectory() + "\\..\\..\\..\\..\\MNIST\\Train");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> ");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            IEnumerable<string> IETrF = Directory.EnumerateFiles(Directory.GetCurrentDirectory() + "\\..\\..\\..\\..\\MNIST\\Train");
            string[] TrainFiles = new string[IETrF.Count()];
            int cnt = 0;
            foreach (string file1 in IETrF)
            {
                TrainFiles[cnt] = file1;
                Console.WriteLine(file1);
                cnt++;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Список имён файлов получен успешно");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // Получение всех необходимых файлов для тестирования
            Console.WriteLine("Нажмите Enter, чтобы получить список имён файлов из папки " + Directory.GetCurrentDirectory() + "\\..\\..\\..\\..\\MNIST\\Test");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> ");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            IEnumerable<string> IETeF = Directory.EnumerateFiles(Directory.GetCurrentDirectory() + "\\..\\..\\..\\..\\MNIST\\Test");
            string[] TestFiles = new string[IETeF.Count()];
            cnt = 0;
            foreach (string file1 in IETeF)
            {
                TestFiles[cnt] = file1;
                Console.WriteLine(file1);
                cnt++;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Список имён файлов получен успешно");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // Формирование датасета для обучения нейросети
            Console.WriteLine("Нажмите Enter, чтобы сформировать датасет для обучения нейросети");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> ");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            int trFCount = TrainFiles.Length;
            double[][] data = new double[trFCount][];
            double[][] answer = new double[trFCount][];
            for (int i = 0; i < trFCount; i++)
            {
                string name = TrainFiles[i];

                // Получение данных об изображении
                Bitmap bit = new Bitmap(name);

                // Инициализация и заполнение массива data данными
                data[i] = new double[784];
                Color col;
                int count = 0;
                for (int q = 0; q < 28; q++)
                {
                    for (int w = 0; w < 28; w++)
                    {
                        col = bit.GetPixel(w, q);
                        if (col.R != 0)
                        {
                            data[i][count] = 1;
                        }
                        else
                        {
                            data[i][count] = 0;
                        }
                        count++;
                    }
                }

                // Инициализация и заполнение массива answer данными
                answer[i] = new double[10];
                for (int q = 0; q < 10; q++)
                {
                    answer[i][q] = 0d;
                }
                answer[i][Convert.ToInt32(name[Directory.GetCurrentDirectory().Length + 35].ToString())] = 1d;

                // Вывод информации
                if (i % 600 == 0)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write("Датасет для обучения нейросети сформирован на {0}%", Math.Round((double)i / 600, 0) + 1);
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Датасет для обучения нейросети успешно сформирован");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // Формирование датасета для тестирования нейросети
            Console.WriteLine("Нажмите Enter, чтобы сформировать датасет для тестирования нейросети");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> ");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            int teFCount = TestFiles.Length;
            double[][] dataT = new double[teFCount][];
            double[][] answerT = new double[teFCount][];
            for (int i = 0; i < teFCount; i++)
            {
                string name = TestFiles[i];

                // Получение данных об изображении
                Bitmap bit = new Bitmap(name);

                // Инициализация и заполнение массива data данными
                dataT[i] = new double[784];
                Color col;
                int count = 0;
                for (int q = 0; q < 28; q++)
                {
                    for (int w = 0; w < 28; w++)
                    {
                        col = bit.GetPixel(w, q);
                        if (col.R != 0)
                        {
                            dataT[i][count] = 1;
                        }
                        else
                        {
                            dataT[i][count] = 0;
                        }
                        count++;
                    }
                }

                // Инициализация и заполнение массива answer данными
                answerT[i] = new double[10];
                for (int q = 0; q < 10; q++)
                {
                    answerT[i][q] = 0d;
                }
                answerT[i][Convert.ToInt32(name[Directory.GetCurrentDirectory().Length + 34].ToString())] = 1d;

                // Вывод информации
                if (i % 100 == 0)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write("Датасет для тестирования нейросети сформирован на {0}%", Math.Round((double)i / 100, 0) + 1);
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Датасет для тестирования нейросети успешно сформирован");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // Очистка консоли
            Console.WriteLine("Нажмите Enter, чтобы продолжить");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> ");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            // Промежуточное сохранение данных нейросети
            Save();

            // Процесс обучения
            Console.WriteLine("Нажмите Enter, чтобы начать обучение");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> ");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // Измерение времени обучения
            Stopwatch spw = new Stopwatch();
            spw.Start();

            // Количество эпох
            int era = 16;

            // Количество итераций в одной эпохе
            int iteration = trFCount;

            for (int i = 0; i < era; i++)
            {
                for (int j = 0; j < iteration; j++)
                {
                    // Обучение
                    DataSet dts = new DataSet(data[j], answer[j]);
                    nn.Train(dts);

                    // Вывод информации
                    if(j % 1000 == 0)
                    {
                        Console.WriteLine("Эпоха {0}; Итерация {1}; Вероятность правильного ответа неизвестна (для ускорения обучения)", i, i * iteration + j); // Math.Round(test, 1)
                    }
                }

                // Сохранение данных нейросети
                Save();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Данные нейросети сохранены");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Обучение успешно завершено");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // Вывод информации
            spw.Stop();
            Console.WriteLine("Время обучения: " + spw.ElapsedMilliseconds + " миллисекунд (" + Math.Round((1000 / (double)spw.ElapsedMilliseconds) * era * iteration, 1) + " изоб/сек)");

            Console.WriteLine("Нажмите Enter, чтобы протестировать нейросеть");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> ");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // Тестирование нейросети
            int prob = 0;
            for (int i = 0; i < teFCount; i++)
            {
                // Предсказание нейросети
                double[] ans = nn.Start(dataT[i]);

                // Нахождения максимального значения
                double max = 0d;
                for (int q = 0; q < 10; q++)
                {
                    if (ans[q] > max)
                    {
                        max = ans[q];
                    }
                }

                // Проверка на правильный ответ
                if (answerT[i][Array.IndexOf(ans, max)] == 1d)
                {
                    prob = prob + 1;
                }

                // Вывод информации
                if (i % 100 == 0)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write("Тестирование нейросети завершено на {0}%", Math.Round((double)i / 100, 0) + 1);
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Тестирование успешно завершено");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine("Вероятность правильного ответа нейросети: {0}%", Math.Round((double)prob / 100, 2));
            Console.WriteLine();

            // Завершение программы
            Console.WriteLine("Нажмите Enter, чтобы завершить программу");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> ");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            // Метод, который сохраняет данные нейросети в файл
            void Save()
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(NN));
                string xml;
                using (StringWriter stringWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(stringWriter, nn);
                    xml = stringWriter.ToString();
                }
                File.WriteAllText(file, xml, Encoding.Default);
            }
        }
    }
}



