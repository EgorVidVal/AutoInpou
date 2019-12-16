using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        Key form = new Key();

        string q = "";
        public Form2()
        {
            InitializeComponent();
            Form1 form = new Form1();
            string z = form.richTextBox2.Text + "\\" + form.richTextBox1.Text + ".txt";

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
         
            string file = Path.Combine(Directory.GetCurrentDirectory(), "file.txt");
            string way = File.ReadAllText(file);

            Playback play = new Playback();

            play.Write("Textadd", way);
            play.Write(richTextBox1.Text,way);

            Key key = new Key();
            key.DirectStart(way);

            this.Close();


        }

        private void Button1_Click(object sender, EventArgs e)
        {
         
          
        }
    }
}
