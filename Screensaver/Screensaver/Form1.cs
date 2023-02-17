using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Reflection.Metadata;
using System.Threading;

namespace Screensaver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Thread[] t = new Thread[int.Parse(textBox1.Text)];
                    for (int i = 0; i < int.Parse(textBox1.Text); i++)
                    {
                        t[i] = new Thread(showNewScreensaver);
                        t[i].Start();
                    }
                    this.WindowState = FormWindowState.Minimized;
                }
                catch
                {
                    MessageBox.Show("Next time try typing a number!");
                }
            }
        }

        private void showNewScreensaver()
        {
            Form f2 = new Form2();
            f2.ShowDialog();
        }
    }
}