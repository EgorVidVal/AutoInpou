using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Playback
    {
        // Читает текстовый докусент
        public string[] Start(string path)
        {
            
            string[] x = new string[6000];
      
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                int counter = 0;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    x[counter] = line;
                    counter++;
                }
            }

            return x;
        }

        static void TxtFile(string[] x) 
        {
            string path = @"D:\macross.txt";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                int counter = 0;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    x[counter] = line;
                    counter++;

                }
            }
        }

        // добавляет файл в новую троку документа
        public void Write(string x,string way)
        {  
            using (var writer = new StreamWriter(way, true))
            {
                //Добавляем к старому содержимому файла
                writer.WriteLine(x);
            }
        }
        public void StartPotok()
        {           
            Form3 f3 = new Form3();
            f3.ShowDialog();//в модальном режиме ,стабильная работа :)
        }
        public void TextPotok()
        {
            Form2 f3 = new Form2();
            f3.ShowDialog();
        }

        public void test()
        {
            Form1 form = new Form1();
            string Path = form.richTextBox3.Text;
            Console.WriteLine(Path);
        }
    }
}
