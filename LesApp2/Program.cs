using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Введення чисел
            Console.WriteLine("Введіть кількість клієнтів:\n");
            Console.Write("\tN = ");
            int n = int.Parse(Console.ReadLine());

            // кількість варіантів доставки
            int N = 1;

            // розрахунок кількості можливих варіантів доставки

#region за математичною формулою
#if true
            // математично розрахувати факторіал можна за допомогою Гамма функції https://uk.wikipedia.org/wiki/Гамма-функція
            // n! = Г(n+1)
            // та ряду інших формул Стірлінга і Рамануджана https://uk.wikipedia.org/wiki/Факторіал
            // візьмемо найпростішу, не використовуючи розрахунок інтегралу для Гамма функції
            double factor;

            if (n > 1)
            {
                factor = Math.Sqrt(2 * Math.PI * n) * Math.Pow(n / Math.E, n) *
                    Math.Exp((1 / (12.0 * n)) - (1 / (360.0 * n * n * n)));
            }
            else
            {
                factor = 1;
            }

            // необхідно округлювати так як є проблеми з точністю
            N = (int)Math.Round(factor, MidpointRounding.AwayFromZero);
#endif
#endregion

#region за вказаним циклом
#if false
            if (n > 1)
            {
                int i = 2;
                do
                {
                    N *= i++;
                } while (i <= n);
            }
            else
            {
                N = 1;
            }
#endif
#endregion

            // виведення
            Console.WriteLine($"\nКількість можливих варіантів доставки: {N:N0};");

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
