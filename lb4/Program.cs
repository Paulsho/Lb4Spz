using System;
using System.IO;

//    Дан файл дійсних чисел. Створити файл цілих чисел, що містить довжини всіх монотонних 
//    послідовностей елементів вихідного файлу. Наприклад, для 
//    вихідного файлу з елементами 1.7, 4.5, 3.4, 2.2, 8.5, 1.2 вміст 
//    результуючого файлу повинна бути наступним: 2, 3, 2, 2.Результат 
//    вивести в файл з таким же ім'ям, як і вихідний, але з розширенням «.out».

namespace lb4
{
    class Program
    {
        const int min = 10, max = 20, maxIntValue = 10;
        const string inPath = "numbers";
        const string outPath = inPath + ".out";

        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Random random = new Random();

            string strNumbers = null;

            for (int i = 0; i < random.Next(min, max); i++)
            {
                strNumbers += (random.Next(maxIntValue) + Math.Round(random.NextDouble(), 1, MidpointRounding.AwayFromZero)).ToString() + " ";
            }
            File.WriteAllText(inPath, strNumbers);
            Console.WriteLine(strNumbers);

            string inputNumbers = File.ReadAllText(inPath);

            string[] splitNumbers = inputNumbers.Split(new char[] { ' ' });

            double[] floatNumbers = new double[splitNumbers.Length];

            int counter = 0;

            foreach (string s in splitNumbers)
            {
                if (!String.IsNullOrEmpty(s))
                {
                    Double.TryParse(s, out floatNumbers[counter]);
                    counter++;
                }
            }

            int length = 0;

            string outNumbers = "";

            for (int i = 0; i < floatNumbers.Length - 1; ++i)
            {
                while (floatNumbers[i] < floatNumbers[i + 1] && i < floatNumbers.Length - 2)
                {
                    length++;
                    i++;
                }
                if (length > 0)
                {
                    length++;
                    outNumbers += length + " ";
                    length = 0;
                    i--;
                }
                while (floatNumbers[i] > floatNumbers[i + 1] && i < floatNumbers.Length - 2)
                {
                    length++;
                    i++;
                }
                if (length > 0)
                {
                    length++;
                    outNumbers += length + " ";
                    length = 0;
                    i--;
                }
            }
            Console.WriteLine(outNumbers);
            File.WriteAllText(outPath, outNumbers);
        }
    }
}