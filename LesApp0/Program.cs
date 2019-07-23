using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Введення чисел
            Console.WriteLine("Введіть цілі числа:\n");
            Console.Write("\tA = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("\tB = ");
            int b = int.Parse(Console.ReadLine());

            // Визначення більшого і меншого чисел, для відповідності до умови
            int minA = Math.Min(a, b),
                maxB = Math.Max(a, b),
                sum = default;  // сума чисел

            #region Перша умова:
#if true
            // шкільна задачка, з використанням формули Арифметичної прогресії
            // https://uk.wikipedia.org/wiki/Арифметична_прогресія
            // яка при великому діапазоні суттєво пришвидшує розрахунки
            // S = (a_1 + a_n) * n / 2 = (2 * a_1 + d * (n - 1)) * n / 2;
            // де S - сума елементів, a_1 і a_n перший і останній елемент відповідно,
            // d - крок, або різниця між двома сусідніми числами, n - кількість елементів в ряду;
            // якщо нам невідомо кількість елементів, то їх можна визначити із
            // формули a_n = a_1 + d * (n - 1) => n = (a_n - a_1) / d + 1;
            // Підставляючи формулу n в формулу Арифметичної прогресії, отримаємо
            // S = (a_n^2 - a_1^2 + d * (a_n + a_1)) / (2 * d), а згыдно нашої умови d = 1, то
            // S = (a_n^2 - a_1^2 + a_n + a_1) / 2 - спрощена формула з кроком 1

            // сума цілих чисел - завжди ціле число, тому немає необхідності в переході до double
            sum = (maxB * maxB - minA * minA + maxB + minA) / 2;
#endif

            // але так як тема пов'язана з циклами, то реалізуємо це за їх допомогою
#if false
            for (int i = minA; i <= maxB; i++)
            {
                sum += i; 
            }
#endif

#if false
            // скористаємося формулою з раніше виведеної арифметичної прогресії: n = (a_n - a_1) / d + 1 =>
            // n = a_n - a_1 + 1 - згідно наших умов
            {
                var temp = Enumerable.Range(minA, maxB - minA + 1).ToArray();

                foreach (int i in temp)
                {
                    sum += i;
                }
            }
#endif

#if false
            {
                int i = minA;
                while (i <= maxB)
                {
                    sum += i;
                    i++;
                }
            }
#endif

#if false
            {
                int i = minA;
                do
                {
                    sum += i;
                    i++;
                } while (i <= maxB);
            }
#endif

#if false
            // те, що не рекомендується робити
            {
                int i = minA;

            Label:

                sum += i;
                i++;

                if (i <= maxB)
                {
                    goto Label;
                }
            }
#endif

            // Виведення результату суми
            Console.WriteLine($"\nСума ряду чисел: {sum:N0};");

            #endregion

            #region Друга умова:
            Console.WriteLine("\nВсі непарні числа:\n\t");

            if (maxB - minA == 0)
            {
                if (minA % 2 == 1)
                {
                    Console.WriteLine("\t" + minA);
                }
                else
                {
                    Console.WriteLine("\tНепарні числа відсутні.");
                }
            }
            else
            {
                int i = (minA % 2 == 1) ? minA : minA + 1;
                Console.Write("\t");

#if true
            for (; i <= maxB; i += 2)
            {
                    Console.Write(i + "\t"); 
            }
#endif

#if false
                // скористаємося формулою з раніше виведеної арифметичної прогресії: n = (a_n - a_1) / d + 1 =>
                // де d = 2, n = (a_n - a_1) / 2 + 1
                {
                    var temp = Enumerable.Repeat(minA, (maxB - minA) / 2 + 1).Select(t => (i += 2) - 2).ToArray();

                    foreach (int j in temp)
                    {
                        Console.Write(j + "\t");
                    }
                }
#endif

#if false
                while (i <= maxB)
                {
                    Console.Write(i + "\t");
                    i += 2;
                }
#endif

#if false
                do
                {
                    Console.Write(i + "\t");
                    i += 2;
                } while (i <= maxB);
#endif

#if false
            // те, що не рекомендується робити
            Label:

                Console.Write(i + "\t");
                i += 2;

                if (i <= maxB)
                {
                    goto Label;
                }
#endif
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
