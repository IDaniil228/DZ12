using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZ12
{
    internal class Program
    {
        static int CalculateFactorial(int a)
        {
            Thread.Sleep(8000);
            int result = 1;
            int count = 1;
            while (count <= a)
            {
                result *= count;
                count++;
            }
            return result;
        }
        static void WriteNumbers()
        {
            int count = 1;
            while (count < 11)
            {
                Console.WriteLine(count);
                count++;
            }
        }
        static int SquareOfNumber(int a)
        {
            return a * a;
        }
        static async void DoExercise2()
        {
            Console.WriteLine("Задача 2  Факториал и  квадрат числа");
            bool flag = int.TryParse(Console.ReadLine(), out int numb);
            if (flag)
            {
                Console.WriteLine($"Квадрат числа = {SquareOfNumber(numb)}");
                int result = await Task.Run(() => CalculateFactorial(numb));
                Console.WriteLine($"факториал = {result}");
            }
            else
            {
                Console.WriteLine("Нужно ввести число");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1  Запустить 3 потока");
            ThreadStart writeNumbers = new ThreadStart(WriteNumbers);
            Thread thread_1 = new Thread(writeNumbers);
            Thread thread_2 = new Thread(writeNumbers);
            Thread thread_3 = new Thread(writeNumbers);
            thread_1.Start();
            thread_2.Start();
            thread_3.Start();
            Console.ReadKey();

            DoExercise2();
            Console.ReadKey();
            Type type = typeof(Refl);
            foreach (MemberInfo info in type.GetMembers())
            {
                if (info.MemberType == MemberTypes.Method)
                {
                    Console.WriteLine($"Названия метода - {info.Name}");
                }

            }
            Console.ReadKey();
        }

    }
}
