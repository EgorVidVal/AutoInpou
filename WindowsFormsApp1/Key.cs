using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Key
    {

        Form1 q = new Form1();
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int keys);

        private const UInt32 MouseEventLeftDown = 0x0002;
        private const UInt32 MouseEventLeftUp = 0x0004;

        private const UInt32 MouseEventRightDown = 0x0008;
        private const UInt32 MouseEventRightUp = 0x0010;

        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);

        public void LeftMouse()
        {

            mouse_event(MouseEventLeftDown, 0x0002, 0x0004, 0, new System.IntPtr());
            mouse_event(MouseEventLeftUp, 0x0002, 0x0004, 0, new System.IntPtr());
        }
        public void RightMouse()
        {

            mouse_event(MouseEventRightDown, 0x0008, 0x0010, 0, new System.IntPtr());
            mouse_event(MouseEventRightUp, 0x0008, 0x0010, 0, new System.IntPtr());
        }
        // Ввод текста
        public void Text(string text)
        {
            SendKeys.SendWait(text);
        }
        public void MousePosition(int x,int y)
        {
            Cursor.Position = new Point(x, y);
        }
        public void MousePositiwon()
        {

            Cursor.Position = new Point(-744, 57);


            mouse_event(MouseEventLeftDown, 0x0002, 0x0004, 0, new System.IntPtr());
            mouse_event(MouseEventLeftUp, 0x0002, 0x0004, 0, new System.IntPtr());

            Thread.Sleep(3000);



            for (int i = 0; i < 1; i++)
            {
                SendKeys.SendWait(q.richTextBox1.Text);
            }

            Thread.Sleep(3000);

            SendKeys.Send("{ENTER}");
            Thread.Sleep(1000);
            Cursor.Position = new Point(-1334, 447);
            Thread.Sleep(3000);

            mouse_event(MouseEventLeftDown, 0x0002, 0x0004, 0, new System.IntPtr());
            mouse_event(MouseEventLeftUp, 0x0002, 0x0004, 0, new System.IntPtr());

            for (int i = 0; i < 1; i++)
            {
                SendKeys.SendWait(q.richTextBox2.Text);
            }

            Thread.Sleep(3000);

            SendKeys.Send("{ENTER}");
        }
        public void Time(int time)
        {
            Thread.Sleep(time);
        }
        public void Enter()
        {
            SendKeys.Send("{ENTER}");
        }

        //Автоматическая запись действий с клавиатуры и мыши.
        public void DirectDlick(string way)
        {
            // чтобы первое нажатие на записолось
            bool tim = false;
            try
            {
                using (var writer = new StreamWriter(way, true))
                {
                    //проверяет раскладку
                    int time = 100;
                    string q = File.ReadAllText("Language.txt");


                    for (int i = 0; ; i++)
                    {

                        Thread QQQ = new Thread(new ThreadStart(MyCurrentInputLanguage));
                        QQQ.IsBackground = true;
                        QQQ.Start(); // запускаем поток

                        Thread.Sleep(time);
                        if(GetAsyncKeyState(117) != 0)
                        {
                            writer.WriteLine("мutability");
                            Thread.Sleep(time);
                        }
                        if (GetAsyncKeyState(115) != 0)
                        {
                            writer.WriteLine("end");
                            Thread.Sleep(time);
                        }
                        if (GetAsyncKeyState(17) != 0)
                        {
                            Console.WriteLine("CTRL");

                            Thread.Sleep(time);
                        }
                        if (GetAsyncKeyState(9) != 0)
                        {
                            writer.WriteLine("TAB\nqwe");
                            //Thread.Sleep(time);
                        }
                        if (GetAsyncKeyState(27) != 0)
                        {
                            writer.WriteLine("Выход");
                            break;
                        }
                        if (GetAsyncKeyState(1) != 0 && tim == true)
                        {
                            int CursorX = Cursor.Position.X;
                            int CursorY = Cursor.Position.Y;
                            writer.WriteLine("Position");
                            writer.WriteLine(Convert.ToString(CursorX));
                            writer.WriteLine(Convert.ToString(CursorY));
                            writer.WriteLine("Time");
                            writer.WriteLine("100");
                            writer.WriteLine("leftmouse");

                        }
                        if (GetAsyncKeyState(2) != 0)
                        {
                            int CursorX = Cursor.Position.X;
                            int CursorY = Cursor.Position.Y;
                            writer.WriteLine("Position");
                            writer.WriteLine(Convert.ToString(CursorX));
                            writer.WriteLine(Convert.ToString(CursorY));
                            writer.WriteLine("Time");
                            writer.WriteLine("100");
                            writer.WriteLine("RightMouse");

                        }
                        //-32768 &&
                        if (GetAsyncKeyState(13) != 0)
                        {
                            writer.WriteLine("enter");
                            writer.WriteLine("Time");
                            writer.WriteLine("700");
                        }
                        if (GetAsyncKeyState(120) != 0)
                        {
                            Playback playBack = new Playback();
                            Thread qqq = new Thread(new ThreadStart(playBack.TextPotok));
                            qqq.Start();

                            break;
                        }

                        if (GetAsyncKeyState(121) != 0)
                        {
                            Playback playBack = new Playback();

                            Thread qqq = new Thread(new ThreadStart(playBack.StartPotok));
                            qqq.Start();

                            break;

                        }
                        if (GetAsyncKeyState(118) != 0)
                        {
                            writer.WriteLine("Time");
                            writer.WriteLine("1000");

                        }

                        string AbTime = "90";
                        //q й
                        if (GetAsyncKeyState(81) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("q"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("й"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);

                        }
                        //w ц
                        if (GetAsyncKeyState(87) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("w"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("ц"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //e у
                        if (GetAsyncKeyState(69) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("e"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("у"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //r к
                        if (GetAsyncKeyState(82) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("r"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("к"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //t е
                        if (GetAsyncKeyState(84) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("t"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("е"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //y н
                        if (GetAsyncKeyState(89) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("y"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("н"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //u г
                        if (GetAsyncKeyState(85) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("u"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("г"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //i ш
                        if (GetAsyncKeyState(73) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("i"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("ш"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //o щ
                        if (GetAsyncKeyState(79) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("o"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("щ"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //p з
                        if (GetAsyncKeyState(80) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("p"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("з"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //[ х
                        if (GetAsyncKeyState(219) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("["); }
                            if (q == "Russian (Russia)") { writer.WriteLine("х"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //] ъ
                        if (GetAsyncKeyState(221) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("]"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("ъ"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //a ф
                        if (GetAsyncKeyState(65) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("a"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("ф"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //s ы
                        if (GetAsyncKeyState(83) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("s"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("ы"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //d в
                        if (GetAsyncKeyState(68) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("d"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("в"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //f а
                        if (GetAsyncKeyState(70) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("f"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("а"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //g п
                        if (GetAsyncKeyState(71) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("g"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("п"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //h р
                        if (GetAsyncKeyState(72) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("h"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("р"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //j о
                        if (GetAsyncKeyState(74) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("j"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("о"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //k л
                        if (GetAsyncKeyState(75) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("k"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("л"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //l д
                        if (GetAsyncKeyState(76) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("l"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("д"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //; ж
                        if (GetAsyncKeyState(186) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine(";"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("ж"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //' э
                        if (GetAsyncKeyState(222) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("'"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("э"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //\ \ 
                        if (GetAsyncKeyState(220) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("\\"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("\\"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //z я
                        if (GetAsyncKeyState(90) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("z"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("я"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //x ч
                        if (GetAsyncKeyState(88) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("x"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("ч"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //c с
                        if (GetAsyncKeyState(67) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("c"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("с"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //v м
                        if (GetAsyncKeyState(86) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("v"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("м"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //b и
                        if (GetAsyncKeyState(66) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("b"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("и"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //n т
                        if (GetAsyncKeyState(78) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("n"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("т"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //m ь
                        if (GetAsyncKeyState(77) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("m"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("ь"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //, б
                        if (GetAsyncKeyState(188) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine(","); }
                            if (q == "Russian (Russia)") { writer.WriteLine("б"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //. ю
                        if (GetAsyncKeyState(190) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("."); }
                            if (q == "Russian (Russia)") { writer.WriteLine("ю"); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        /// .
                        if (GetAsyncKeyState(191) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine("/"); }
                            if (q == "Russian (Russia)") { writer.WriteLine("."); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //
                        if (GetAsyncKeyState(23452345) != 0)
                        {
                            if (q == "English (United States)") { writer.WriteLine(""); }
                            if (q == "Russian (Russia)") { writer.WriteLine(""); }
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        //
                        if (GetAsyncKeyState(32) != 0)
                        {
                            writer.WriteLine(" ");
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        if (GetAsyncKeyState(8) != 0)
                        {
                            writer.WriteLine("BackSpace");
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }

                        if (GetAsyncKeyState(49) != 0)
                        {
                            writer.WriteLine("1");
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        if (GetAsyncKeyState(50) != 0)
                        {
                            writer.WriteLine("2");
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        if (GetAsyncKeyState(51) != 0)
                        {
                            writer.WriteLine("3");
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        if (GetAsyncKeyState(52) != 0)
                        {
                            writer.WriteLine("4");
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        if (GetAsyncKeyState(53) != 0)
                        {
                            writer.WriteLine("5");
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        if (GetAsyncKeyState(54) != 0)
                        {
                            writer.WriteLine("6");
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        if (GetAsyncKeyState(55) != 0)
                        {
                            writer.WriteLine("7");
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        if (GetAsyncKeyState(56) != 0)
                        {
                            writer.WriteLine("8");
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        if (GetAsyncKeyState(57) != 0)
                        {
                            writer.WriteLine("9");
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }
                        if (GetAsyncKeyState(48) != 0)
                        {
                            writer.WriteLine("0");
                            writer.WriteLine("Time");
                            writer.WriteLine(AbTime);
                        }

                        tim = true;

                    }
                }
            }
            catch
            {
                MessageBox.Show("Не выбран файл");
            }
            
            // для корректной обработки мыши вводится переменная, для обработки только одного нажатия
            
        }

        public void DirectStart(string way)
        {
            // вызов метода в другой поток с дополнительными параметрами в скобке
            Thread MyThread = new System.Threading.Thread(delegate () { DirectDlick(way); });
            MyThread.IsBackground = true;
            MyThread.Start(); // запускаем поток  
        }
     
        static void MyCurrentInputLanguage()
        {  
            InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
            string Language = myCurrentLanguage.Culture.EnglishName;
            string file = Path.Combine(Directory.GetCurrentDirectory(), "Language.txt");

            if (File.ReadAllText("Language.txt") != Language)
            {
                File.WriteAllText(file, Language);
            }
                                
                
                //Console.WriteLine(Language);
        }

        

    }
}
