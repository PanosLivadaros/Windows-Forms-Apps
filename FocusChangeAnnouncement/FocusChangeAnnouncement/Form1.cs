using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Speech;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FocusChangeAnnouncement
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer engine = new SpeechSynthesizer();
        bool flag1 = true;
        bool flag2 = true;
        bool flag3 = true;
        bool flag4 = true;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            richTextBox1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((button1.Focused) && (flag1))
            {
                richTextBox1.Text = "Focus is currently on Button 1.";
                engine.SpeakAsync(richTextBox1.Text);
                flag1 = false;
                flag2 = true;
                flag3 = true;
                flag4 = true;
            }
            else if ((button2.Focused) && (flag2))
            {
                richTextBox1.Text = "Focus is currently on Button 2.";
                engine.SpeakAsync(richTextBox1.Text);
                flag2 = false;
                flag1 = true;
                flag3 = true;
                flag4 = true;
            }
            else if ((button3.Focused) && (flag3))
            {
                richTextBox1.Text = "Focus is currently on Button 3.";
                engine.SpeakAsync(richTextBox1.Text);
                flag3 = false;
                flag1 = true;
                flag2 = true;
                flag4 = true;
            }
            else if ((button4.Focused) && (flag4))
            {
                richTextBox1.Text = "Focus is currently on Button 4.";
                engine.SpeakAsync(richTextBox1.Text);
                flag4 = false;
                flag1 = true;
                flag1 = true;
                flag3 = true;
            }
        }
    }
}