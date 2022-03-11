using System;
using System.IO;
using System.Text;

namespace Lab1_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string textFromFile;

            // создаем каталог для файла
            string path = @"C:\SortFolder";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            // чтение из файла
            using (FileStream fstream = File.OpenRead(@"C:\SortFolder\inputLaba1.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string text = System.Text.Encoding.Default.GetString(array);

                textFromFile = text;

            }

           

            //запись в файл 
            using (FileStream fstream = new FileStream(@"C:\SortFolder\outputLaba1.txt", FileMode.Create))
            {
                //разбиваем на массив строк 
                string[] nums = textFromFile.Split(separator: new string[] { "\r", "\n" }, StringSplitOptions.None);

                for (int i = 0; i < nums.Length; i++)
                {
                    // разбиваем строку на массив из 2х элементов
                    string[] firstAndSecondNumber = nums[i].Split(new char[] { ',' }, StringSplitOptions.None);

                    if (firstAndSecondNumber[0] != "")
                    {

                        textFromFile = "X:" + firstAndSecondNumber[0].Replace(".",",") + " Y:" + firstAndSecondNumber[1].Replace(".", ",") + "\n";

                        // преобразуем строку в байты
                        byte[] input = Encoding.Default.GetBytes(textFromFile);
                        // запись массива байтов в файл
                        fstream.Write(input, 0, input.Length);

                    }
                }
                
                Console.WriteLine("Текст записан в файл");
            }
        }
    }
}
