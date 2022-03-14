using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System;

namespace Lab1_WpfAppNew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }

            }

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

                        textFromFile = "X:" + firstAndSecondNumber[0].Replace(".", ",") + " Y:" + firstAndSecondNumber[1].Replace(".", ",") + "\n";

                        // преобразуем строку в байты
                        byte[] input = Encoding.Default.GetBytes(textFromFile);
                        // запись массива байтов в файл
                        fstream.Write(input, 0, input.Length);

                    }
                }

            }
        }

        /// <summary>
        /// обработчик событий для кнопки
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
            string str = (string)((Button)e.OriginalSource).Content;

            if (str == "AC")
            {
                textLabel.Text = "";
                str = "";
            }

            if (textLabel1.Text != null)
            {
                textLabel1.Text = null;

            }


            if (str == "Запись в файл")
            {
                if (textLabel1.Text == "")
                {
                    string textFromFile1 = textLabel.Text;

                    //запись в файл 
                    using (FileStream fstream = new FileStream(@"C:\SortFolder\outputLaba1.txt", FileMode.Append))
                    {

                        string[] numsOfInputText = textLabel.Text.Split(new char[] { ',' }, StringSplitOptions.None);

                        if (numsOfInputText[0] != "")
                        {

                            textFromFile1 = "X:" + numsOfInputText[0].Replace(".", ",") + " Y:" + numsOfInputText[1].Replace(".", ",") + "\n";

                            // преобразуем строку в байты
                            byte[] input = Encoding.Default.GetBytes(textFromFile1);
                            // запись массива байтов в файл
                            fstream.Write(input, 0, input.Length);

                        }

                        textLabel.Text = "";
                        textLabel1.Text = "Текст записан в файл!"; 

                    }


                }

            }

            else
            {

                textLabel.Text += str;
            }

        }

       
    }
}
