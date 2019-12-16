using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public int counter = 0; 
        public string[] makross = new string[550];

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int keys);

     
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }



        public string List;
        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, EventArgs e)
        {
           //Позиция
        }

        bool ThreadON = true;
        private void Button1_Click(object sender, EventArgs e)
        {
            if(checkBox4.Checked == true)
            {
                System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
                // вызов метода в другой поток с дополнительными параметрами в скобке
                Thread MyThread = new System.Threading.Thread(delegate () { PositionDinamic(); });
                MyThread.IsBackground = true;
                MyThread.Start(); // запускаем поток  

                
                if (ThreadON == false)
                {
                    MyThread.Abort();//прерываем поток
                    MyThread.Join(500);//таймаут на завершение
                }

            }
            else
            {
                int CursorX = Cursor.Position.X;

                int CursorY = Cursor.Position.Y;

                if (checkBox1.Checked == true)
                {
                    makross[counter] = "Position";
                    counter++;
                    makross[counter] = Convert.ToString(CursorX);
                    counter++;
                    makross[counter] = Convert.ToString(CursorY);
                    counter++;
                }

                TextBox.Text = CursorX.ToString();
                textBox1.Text = CursorY.ToString();
                // действие 
            }



        }
        private void Stop_Click(object sender, EventArgs e)
        {
            ThreadON = false;
        }
        private void PositionDinamic()
        {
            
            
            do
            {
                Thread.Sleep(25);
                int CursorX = Cursor.Position.X;

                int CursorY = Cursor.Position.Y;

                TextBox.Text = CursorX.ToString();
                textBox1.Text = CursorY.ToString();
            }
            while(ThreadON == true);
           
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                File.WriteAllText(Directory.GetCurrentDirectory(), string.Empty);
            }
            catch
            {
                
            }
            
            string text = richTextBox2.Text;
            string file = Path.Combine(Directory.GetCurrentDirectory(), "file.txt");
            File.WriteAllText(file, text);
        
            Key key = new Key();
            key.DirectStart(text);
        
        
           

            // Создаем поток
            // Второй поток будет завершен при завершении основного потока
            // Запустить поток

        }

        private void Write(string x)
        {
            Playback play = new Playback();

            try
            {
                File.WriteAllText(Directory.GetCurrentDirectory(), string.Empty);
            }
            catch
            {

            }
            string text = richTextBox2.Text + "\\" + richTextBox1.Text + ".txt";
            string file = Path.Combine(Directory.GetCurrentDirectory(), "file.txt");

            File.WriteAllText(file, text);
            play.Write(x, text);
        }
        
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LeftMouse_Click(object sender, EventArgs e)
        {
            makross[counter] = "leftmouse";
            counter++;
        }

        private void Text_Click(object sender, EventArgs e)
        {
            makross[counter] = "Textadd";
            counter++;
            makross[counter] = TextAdd.Text ;
            counter++;

        }

        private void TextAdd_TextChanged(object sender, EventArgs e)
        {

        }

        public void TimeTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Time_Click(object sender, EventArgs e)
        {
            makross[counter] = "Time";
            counter++;
            makross[counter] = TimeTextBox3.Text;
            counter++;
        }

        private void File_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(@"D:\macross.txt", makross);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
             
        }



  
        private void Start_Click(object sender, EventArgs e)
        {
            Star_Read(richTextBox3.Text);

            // вызов метода в другой поток с дополнительными параметрами в скобке          
            
        }

        public string[] Replacement_Instructions;

        public bool zam = false;

        private void Star_Read(string way)
        {
            try
            {
                Key key = new Key();
                Playback play = new Playback();
                //массив с инструкцией
                string[] step = play.Start(way);

                int counter = 0;

                if (Replacement_Instructions != null)
                {
                    for (int i = 0; i < Replacement_Instructions.Length; i++)
                    {
                        if (Replacement_Instructions.Length % 2 == 0)
                        {
                            for (int x = 0; x < step.Length; x++)
                            {
                                if (Replacement_Instructions[i] == step[x] && i % 2 == 0)
                                {
                                    step[x] = Replacement_Instructions[i + 1];
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < step.Length; i++)
                {
                    //
                    if (step[counter] == "мutability") { counter++; }
                    if (step[counter] == "end") { counter++; }
                    if (step[counter] == "Position")
                    {
                        int x = 0;
                        int y = 0;
                        counter++;
                        x = Convert.ToInt32(step[counter]);
                        counter++;
                        y = Convert.ToInt32(step[counter]);
                        counter++;
                        key.MousePosition(x, y);
                    }
                    if (step[counter] == "enter")
                    {
                        key.Enter();
                        counter++;
                    }
                    if (step[counter] == "Textadd")
                    {
                        counter++;

                        //чтобы не путалась раскладка
                        foreach(char x in step[counter])
                        {
                            string s = Convert.ToString(x);

                            Console.WriteLine(step[counter]);

                            byte[] b = System.Text.Encoding.Default.GetBytes(s);

                            foreach (byte bt in b)
                            {
                                if ((bt >= 97) && (bt <= 122)) InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
                                
                                if ((bt >= 192) && (bt <= 239)) InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
                                break;
                            }
                           
                            //Thread.Sleep();
                            SendKeys.Send(s);
                        }
                        
                        counter++;
                    }
                    if (step[counter] == "Time")
                    {
                        counter++;
                        key.Time(Convert.ToInt32(step[counter]));
                        counter++;
                    }
                    if (step[counter] == "leftmouse")
                    {
                        key.LeftMouse();
                        counter++;
                    }
                    if (step[counter] == "RightMouse")
                    {
                        key.RightMouse();
                        counter++;
                    }

                    if (step[counter] == "q") { counter++; SendKeys.Send("q"); }
                    if (step[counter] == "w") { counter++; SendKeys.Send("w"); }
                    if (step[counter] == "e") { counter++; SendKeys.Send("e"); }
                    if (step[counter] == "r") { counter++; SendKeys.Send("r"); }
                    if (step[counter] == "t") { counter++; SendKeys.Send("t"); }
                    if (step[counter] == "y") { counter++; SendKeys.Send("y"); }
                    if (step[counter] == "u") { counter++; SendKeys.Send("u"); }
                    if (step[counter] == "i") { counter++; SendKeys.Send("i"); }
                    if (step[counter] == "o") { counter++; SendKeys.Send("o"); }
                    if (step[counter] == "p") { counter++; SendKeys.Send("p"); }
                    if (step[counter] == "[") { counter++; SendKeys.Send("["); }
                    if (step[counter] == "]") { counter++; SendKeys.Send("]"); }
                    if (step[counter] == "a") { counter++; SendKeys.Send("a"); }
                    if (step[counter] == "s") { counter++; SendKeys.Send("s"); }
                    if (step[counter] == "d") { counter++; SendKeys.Send("d"); }
                    if (step[counter] == "f") { counter++; SendKeys.Send("f"); }
                    if (step[counter] == "g") { counter++; SendKeys.Send("g"); }
                    if (step[counter] == "h") { counter++; SendKeys.Send("h"); }
                    if (step[counter] == "j") { counter++; SendKeys.Send("j"); }
                    if (step[counter] == "k") { counter++; SendKeys.Send("k"); }
                    if (step[counter] == "l") { counter++; SendKeys.Send("l"); }
                    if (step[counter] == ";") { counter++; SendKeys.Send(";"); }
                    if (step[counter] == "'") { counter++; SendKeys.Send("'"); }
                    if (step[counter] == "z") { counter++; SendKeys.Send("z"); }
                    if (step[counter] == "x") { counter++; SendKeys.Send("x"); }
                    if (step[counter] == "c") { counter++; SendKeys.Send("c"); }
                    if (step[counter] == "v") { counter++; SendKeys.Send("v"); }
                    if (step[counter] == "b") { counter++; SendKeys.Send("b"); }
                    if (step[counter] == "n") { counter++; SendKeys.Send("n"); }
                    if (step[counter] == "m") { counter++; SendKeys.Send("m"); }
                    if (step[counter] == ",") { counter++; SendKeys.Send(","); }
                    if (step[counter] == ".") { counter++; SendKeys.Send("."); }
                    if (step[counter] == "/") { counter++; SendKeys.Send("/"); }
                    if (step[counter] == " ") { counter++; SendKeys.Send(" "); }
                    if (step[counter] == "BackSpace") { counter++; SendKeys.Send("{BACKSPACE}"); }

                    if (step[counter] == "1") { counter++; SendKeys.Send("1"); }
                    if (step[counter] == "2") { counter++; SendKeys.Send("2"); }
                    if (step[counter] == "3") { counter++; SendKeys.Send("3"); }
                    if (step[counter] == "4") { counter++; SendKeys.Send("4"); }
                    if (step[counter] == "5") { counter++; SendKeys.Send("5"); }
                    if (step[counter] == "6") { counter++; SendKeys.Send("6"); }
                    if (step[counter] == "7") { counter++; SendKeys.Send("7"); }
                    if (step[counter] == "8") { counter++; SendKeys.Send("8"); }
                    if (step[counter] == "9") { counter++; SendKeys.Send("9"); }
                    if (step[counter] == "0") { counter++; SendKeys.Send("0"); }


                    if (GetAsyncKeyState(27) != 0) { break; }

                    if(step[counter] == "Выход"){ break; }

                    //В конце инструкции перестает выполняться
                        if (step[counter] == null)
                    {
                        break;
                    }
                }
            }

            catch
            {
                MessageBox.Show("Не выбоан файл");
            }
        }

        private void Сlean_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(richTextBox2.Text, string.Empty);
            }
            catch
            {
                MessageBox.Show("Не выбран файл");
            }
            

        }
        private void Button3_Click(object sender, EventArgs e)
        {
            Way_sul(richTextBox3);
        }
        private void Way_sul(System.Windows.Forms.RichTextBox box)
        {
            string x = "";
            string z = "";

            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Multiselect = true;
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in OPF.FileNames)
                {
                    box.Text = file;
                    x = file;
                }
            }

            // добавлеяет второй слеш для ссылки
            foreach (char c in x)
            {
                z += c;
                if (c == '\\')
                {
                    z += c;
                }
            }
            box.Text = z;
        }

        private void RichTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string x = "";
            string z = "";

            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Multiselect = true;
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in OPF.FileNames)
                {
                    richTextBox2.Text = file;
                    x = file;
                }
            }

            // добавлеяет второй слеш для ссылки
            foreach (char c in x)
            {
                z += c;
                if (c == '\\')
                {
                    z += c;
                }
            }
            richTextBox2.Text = z;
        }
    
        private void Button5_Click(object sender, EventArgs e)
        {
            Form4 qwe = new Form4(this);
            qwe.Show();
        }

        
        private void Button6_Click(object sender, EventArgs e)
        {
            
        }
        static void aqweq()
        {
            Playback playBack = new Playback();

            Thread qqq = new Thread(new ThreadStart(playBack.StartPotok));
      
        }

        public void MyCurrentInputLanguage()
        {
            // Gets the current input language  and prints it in a text box.
            
        }

        private void Button10_Click(object sender, EventArgs e)
        {

        }

        // Определяет раскладку в данный момент времени.
        public string Language()
        {
            InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
            string Language = myCurrentLanguage.Culture.EnglishName;       
            return Language;
        }

        // открывает и создает файл
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            bool showdialog = true;

          
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.FileName = richTextBox1.Text;
                SFD.FileName = "MyTXT";
                SFD.Filter = "TXT (*.txt)|*.txt";

                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    filename = SFD.FileName;
                    showdialog = false;

                    StreamWriter SW = new StreamWriter(filename);
                    SW.Write(richTextBox1.Text.ToString());
                    SW.Close();
                }
                
        }

        private void Button9_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("ПРВЕ");
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                Write("Enter");
            }
        }
        private void Button56_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                Write(" ");
            }
        }

        //Й
        private void Button12_Click(object sender, EventArgs e)
        {
            
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                Write("ц");
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {          
            string z = richTextBox2.Text;
            if (checkBox3.Checked == true)
            {
                 // вызов метода в другой поток с дополнительными параметрами в скобке
                 Thread MyThread = new System.Threading.Thread(delegate () { Possition_potok(z); });
                 MyThread.IsBackground = true;
                 MyThread.Start(); // запускаем поток 
                
            } 
 
        }
    
        private void Possition_potok(string z)
        {
            try
            {
                for (; ; )
                {
                    Thread.Sleep(100);
                    if (GetAsyncKeyState(118) != 0)
                    {
                        Possition(z);
                    }
                    if (checkBox3.Checked == false)
                    {
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не выбран файл"); 
                checkBox3.Invoke(new Action(() => checkBox3.Checked = false));

            }


        }
        private void Possition(string text)
        {
            int CursorX = Cursor.Position.X;

            int CursorY = Cursor.Position.Y;

            using (var writer = new StreamWriter(text, true))
            {
                writer.WriteLine("Position");
                Thread.Sleep(50);
                writer.WriteLine(Convert.ToString(CursorX));
                Thread.Sleep(50);
                writer.WriteLine(Convert.ToString(CursorY));
            }


            

        }
       
        private void Button53_Click(object sender, EventArgs e)
        {
            // путь хранится в filename
            string filename = "";
            bool showdialog = true;

            string x = "";

            SaveFileDialog SFD = new SaveFileDialog();
            SFD.FileName = richTextBox2.Text;
            SFD.FileName = "MyTXT";
            SFD.Filter = "TXT (*.txt)|*.txt";
          

            if (SFD.ShowDialog() == DialogResult.OK)
            {
                filename = SFD.FileName;
                showdialog = false;

                StreamWriter SW = new StreamWriter(filename);

                SW.Write(richTextBox2.Text.ToString());

                SW.Close();
    
            }

            // добавляет коенчный путь к файлу для записи в окно.
            string z = ""; 
            foreach (char c in filename)
            {
                z += c;
                if (c == '\\')
                {
                    z += c;
                }
            }
            richTextBox2.Text = z;
        }

        private void Button112_Click(object sender, EventArgs e)
        {
            Star_Read(richTextBox4.Text);
        }

        private void Button111_Click(object sender, EventArgs e)
        {
            Way_sul(richTextBox4);
        }

        private void RichTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button116_Click(object sender, EventArgs e)
        {
            Star_Read(richTextBox6.Text);
        }

        private void Button115_Click(object sender, EventArgs e)
        {
            Way_sul(richTextBox6);
        }

        private void RichTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button114_Click(object sender, EventArgs e)
        {
            Star_Read(richTextBox5.Text);
        }

        private void Button113_Click(object sender, EventArgs e)
        {
            Way_sul(richTextBox5);
        }

        public void RichTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void Izmenit_Click(object sender, EventArgs e)
        {
            Key key = new Key();
            Playback play = new Playback();
            //массив с инструкцией
            string[] step = play.Start(richTextBox3.Text);

            //Если после команды мutability последующие позиции изменяются
            bool мutab = false;
            //Когда после команды первый раз попдает на позицию делает вычисления для последующего
            //изменения других данных
            bool difference = false;
            
            //вычисления разницы между старой позицией и новой
            int positionX = 0;
            int positionY = 0;

            for (int i = 0;i < step.Length;i++)
            {
                if(step[i] == "мutability")
                {
                    мutab = true;
                }
                if(мutab == true && step[i] == "Position")
                {
                    if(difference == false)
                    {
                        positionX = Convert.ToInt32(TextBox.Text) - Convert.ToInt32(step[i+1]);
                        positionY = Convert.ToInt32(textBox1.Text) - Convert.ToInt32(step[i+2]);

                        step[i + 1] = Convert.ToString(Convert.ToInt32(step[i + 1]) + positionX);
                        step[i + 2] = Convert.ToString(Convert.ToInt32(step[i + 2]) + positionY);
                        difference = true;
                    }
                    else
                    {
                        step[i + 1] = Convert.ToString(Convert.ToInt32(step[i + 1]) + positionX);
                        step[i + 2] = Convert.ToString(Convert.ToInt32(step[i + 2]) + positionY);
                    }

                }
                //после этой команды, последующие позиции не изменяются.
                if(step[i] =="end")
                {
                    difference = false;
                    мutab = false;
                    positionX = 0;
                    positionY = 0;
                }


            }
            izm(richTextBox3.Text, step);
        }

        private void izm(string way,string[] data)
        {
            // чтобы первое нажатие на записолось

            File.WriteAllText(richTextBox3.Text, string.Empty);
            bool tim = false;

            try
            {
                using (var writer = new StreamWriter(way, true))
                {
                    //проверяет раскладку
                    int time = 10;
                    string q = File.ReadAllText("Language.txt");


                    for (int i = 0; i<data.Length ; i++)
                    {

                        Thread QQQ = new Thread(new ThreadStart(MyCurrentInputLanguage));
                        QQQ.IsBackground = true;
                        QQQ.Start(); // запускаем поток

                        writer.WriteLine(data[i]);
                        Thread.Sleep(time);

                        if(data[i] == "Выход")
                        {
                            break;
                        }
                        tim = true;
                    }

                    
                }
            }
            catch
            {
                MessageBox.Show("Не выбран файл");
            }
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
