using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Введення чисел
            Console.WriteLine("Розміри фігур:\n");
            Console.Write("\tВисота = ");
            int h = int.Parse(Console.ReadLine());
            Console.WriteLine();

            #region виведення прямокутника
            Console.WriteLine("\n\tПрямокутник:\n");

            for (int i = 0; i < h; i++)
            {
                Console.Write("\t");

                for (int j = 0; j < 4 * h; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
            #endregion

            #region виведення пряммокутного трикутника
            Console.WriteLine("\n\tПрямокутний трикутник:\n");

            // локальні функції
            bool pryamTric(int i, int j)
            {
                bool xBool = (j <= 4.0 * i) ? true : false,
                    yBool = (i >= 0.25 * j) ? true : false;

                return xBool && yBool;
            }

            for (int i = 0; i < h; i++)
            {
                Console.Write("\t");

                for (int j = 0; j < 4 * h; j++)
                {
                    if (pryamTric(i, j))
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
            #endregion

            #region виведення рівностороього трикутника
            Console.WriteLine("\n\tРівносторонній трикутник:\n");

            // локальні функції
            bool rivnosTric(int i, int j)
            {
                bool xBool = ((j >= -3 * (i + h) / Math.PI) &&
                    (j >= 3 * i / Math.PI - h)) ? true : false,
                    yBool = ((i >= h -  j *Math.PI / 3) &&
                    (i >= (j - h) * Math.PI / 3)) ? true : false;

                return xBool && yBool;
            }

            for (int i = 0; i < h; i++)
            {
                Console.Write("\t");

                for (int j = 0; j < 4 * h; j++)
                {
                    if (rivnosTric(i, j))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            #endregion

            #region ромб
            Console.WriteLine("\n\tРомб:\n");

            // локальні функції
            bool Romb(int i, int j)
            {
                double dh = h * Math.Sqrt(3) / 2;
                bool y1Bool = (i <= -Math.Abs(j - dh) + dh) ? true : false,
                    y2Bool = (i >= Math.Abs(j - dh)) ? true : false;

                return y1Bool && y2Bool;
            }

            for (int i = 0; i < h; i++)
            {
                Console.Write("\t");

                for (int j = 0; j < 4 * h; j++)
                {
                    if (Romb(i, j))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            #endregion

            #region Повторення
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
            }
            #endregion
        }
    }
}
