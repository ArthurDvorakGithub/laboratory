using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab2._2_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string number;
            string pattern = @"\b[a-zA-Zа-яА-Я]\w*\b";

            Regex regex = new Regex(pattern);
            
            Console.WriteLine("Введите число:");

            number = Console.ReadLine();

            Match match = regex.Match(number);//проверка на кирилицу и латиницу, можно еще добавить другие символы по желанию

            if (match.Success == false)
            {
                double newnumber = double.Parse(number);
                if (newnumber > 0)
                {
                    Convert(newnumber);
                }
                else
                {
                    Console.WriteLine("Неверный ввод.Введите число больше нуля:");
                    number = Console.ReadLine();
                    double newnumber1 = double.Parse(number);
                    Convert(newnumber1);
                }
            }
            else
            {
                Console.WriteLine("Требуется ввести числовое значение!");
                Console.WriteLine("Введите число:");
                number = Console.ReadLine();
                double newnumber = double.Parse(number);
                Convert(newnumber);
            }
            

            //19 / 2 = 9 с остатком 1
            //9 / 2 = 4 c остатком 1
            //4 / 2 = 2 без остатка 0
            //2 / 2 = 1 без остатка 0
            //1 / 2 = 0 с остатком 1
            // В результате получаем число 19 в двоичной записи: 10011.

        }

        public static void Convert(double newnumber)
        {
            
            double residual;
            var operationStack = new Stack<double>(); // создаем коллекцию для стека

            do
            {
                residual = newnumber % 2; // получаем остаток

                newnumber = Math.Floor(newnumber / 2); // окруляем в меньшую сторону

                operationStack.Push(residual); // ложим в стек 

            }
            while (newnumber >= 1);

            for (int i = 0; i < operationStack.Count;) // достаем из стека и выводим на консоль даннные
            {
                Console.Write(operationStack.Pop().ToString());
            }
        }



    }
        

}
