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
    public partial class Form3 : Form
    {
        public Form3()
        {
            TopMost = true;
            InitializeComponent();
           
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string file = Path.Combine(Directory.GetCurrentDirectory(), "file.txt");
            string way = File.ReadAllText(file);

            Playback play = new Playback();

            play.Write("Time", way);
            play.Write(richTextBox1.Text, way);

            Key key = new Key();
            key.DirectStart(way);

            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
