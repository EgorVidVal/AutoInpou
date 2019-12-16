using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        bool exitform = false;
        public bool button1WasClicked = false;
        public Form4(Form1 f)
        {
            InitializeComponent();
            Thread MyThread = new System.Threading.Thread(delegate () { qweqweqweqwe(f); });
            MyThread.IsBackground = true;
            MyThread.Start(); // запускаем поток
            Console.WriteLine("asda");
        }

        static int counter = 0;
        public string[] instruction;

        // f отсылка к первой форме.
        public void qweqweqweqwe(Form1 f)
        {
            for (; ; )
            {
                Thread.Sleep(500);
                if (button1WasClicked == true)
                {                
                    f.Replacement_Instructions = instruction;
                }

                if (exitform == true)
                {
                    break;
                }
            }
        }



        List<string> list = new List<string>();
        private void Button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length != 0)
            {
                list.Add(richTextBox1.Text);
                list.Add(richTextBox2.Text);
            }
            if (richTextBox3.Text.Length != 0)
            {
                list.Add(richTextBox3.Text);
                list.Add(richTextBox4.Text);
            }
        }

        // Собирает список в массив.
        private void Button2_Click(object sender, EventArgs e)
        {
            
        }



        private void Form4_Load(object sender, EventArgs e)
        {


        }

        // при закрытии форма выполнить определенные действия
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            exitform = true;
        }


        private void RichTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        // Если все замены выполнены нажимаем ок и данные передаются в первую форму.
        private void Button2_Click_1(object sender, EventArgs e)
        {
            string[] TimeMass = new string[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                TimeMass[i] = list[i];
            }

            instruction = TimeMass;
            button1WasClicked = true;
            Console.WriteLine(string.Join(" ", instruction));
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            list.Clear();
        }

        private void RichTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
