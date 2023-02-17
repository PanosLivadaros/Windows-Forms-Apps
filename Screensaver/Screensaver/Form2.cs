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
    public partial class Form2 : Form
    {
        Random r = new Random();
        int angle;
        bool flag = true;
        int x;
        int y;
        public Form2()
        {
            InitializeComponent();
            this.angle = r.Next(0 , 360);
            StartPosition = FormStartPosition.CenterScreen;
            GraphicsPath shape = new GraphicsPath();
            shape.AddEllipse(50, 50, 50, 50);
            this.Region = new Region(shape);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag)
            {
                double radian = (angle * Math.PI) / 180;
                y = (int)(10 * Math.Sin(radian));
                x = (int)(10 * Math.Cos(radian));
            }
            flag = false;
            Top += y;
            Left += x;
            if ((this.Location.X >= Screen.PrimaryScreen.Bounds.Width - 50) || (this.Location.X <= -50))
            {
                x = -x;
                this.BackColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            }
            if ((this.Location.Y >= Screen.PrimaryScreen.Bounds.Height - 50) || (this.Location.Y <= -50))
            {
                y = -y;
                this.BackColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
