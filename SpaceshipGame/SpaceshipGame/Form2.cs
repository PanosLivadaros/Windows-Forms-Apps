using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Schema;
using System.Configuration;

namespace SpaceshipGame
{
    public partial class Form2 : Form
    {
        IFormatter form2 = new BinaryFormatter();
        List<PictureBox> bullets = new List<PictureBox>();
        List<PictureBox> projectiles = new List<PictureBox>();
        Random r = new Random();
        int score = 0;
        int sec = 0;
        PictureBox ptemp = new PictureBox();
        int[] scores = new int[10];
        public Form2()
        {
            InitializeComponent();
            if (File.Exists("./a.txt"))
            {
                Stream str = new FileStream("./a.txt", FileMode.Open, FileAccess.Read);
                scores = (int[])form2.Deserialize(str);
                str.Close();
            }
            else
            {
                for (int x = 0; x < 10; x++)
                {
                    scores[x] = 0;
                }
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    pictureBox1.Location = new Point(pictureBox1.Location.X - 15, pictureBox1.Location.Y);
                    break;
                case Keys.Right:
                    pictureBox1.Location = new Point(pictureBox1.Location.X + 15, pictureBox1.Location.Y);
                    break;
                case Keys.Up:
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 15);
                    break;
                case Keys.Down:
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 15);
                    break;
                case Keys.Space:
                    createBullet(pictureBox1.Location.X);
                    break;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool flag;
            if (score > scores.Min())
            {
                flag = true;
                int k = 0;
                while ((k < 10) && (flag))
                {
                    if (scores[k] == scores.Min())
                    {
                        scores[k] = score;
                        flag = false;
                    }
                    k++;
                }
            }
            Array.Sort(scores);
            Array.Reverse(scores);
            Stream str = new FileStream("./a.txt", FileMode.Create, FileAccess.Write);
            form2.Serialize(str, scores);
            str.Close();
            MessageBox.Show("This game has ended.Time ran out! Your score is: " + score);
            Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(r.Next(Width - pictureBox2.Width), pictureBox2.Location.Y);
            createProjectile(pictureBox2.Location.X);
            label1.Text = "Time remaining: "+ (120 - sec).ToString() +" seconds";
            sec++;
        }

        private void createBullet(int startX)
        {
            PictureBox p = new PictureBox();
            p.ImageLocation = "bullet.png";
            p.Location = new Point(startX + 35, pictureBox1.Location.Y - 50);
            p.Size = new Size(60, 50);
            p.BackColor = Color.Transparent;
            p.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(p);
            bullets.Add(p);
        }

        private void createProjectile(int startX)
        {
            PictureBox p = new PictureBox();
            p.ImageLocation = "projectile.png";
            p.Location = new Point(startX + 35, pictureBox2.Location.Y);
            p.Size = new Size(60, 50);
            p.BackColor = Color.Transparent;
            p.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(p);
            projectiles.Add(p);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label2.Text = "Score: " + score;
            for (int i = 0; i < bullets.Count(); i++)
            {
                bullets[i].Location = new Point(bullets[i].Location.X, bullets[i].Location.Y - 30);
                if (bullets[i].Bounds.IntersectsWith(pictureBox2.Bounds))
                {
                    score+=10;
                    ptemp = bullets[i];
                    bullets.Remove(bullets[i]);
                    ptemp.Dispose();
                    ptemp.Hide();
                }
                else if ((bullets[i].Location.Y <= 30) && (bullets[i].Location.Y >= 0))
                {
                    ptemp = bullets[i];
                    bullets.Remove(bullets[i]);
                    ptemp.Dispose();
                    ptemp.Hide();
                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            for (int j = 0; j < projectiles.Count(); j++)
            {
                projectiles[j].Location = new Point(projectiles[j].Location.X, projectiles[j].Location.Y + 30);
                if (projectiles[j].Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    score-=5;
                    ptemp = projectiles[j];
                    projectiles.Remove(projectiles[j]);
                    ptemp.Dispose();
                    ptemp.Hide();
                }
                else if ((projectiles[j].Location.Y <= 1000) && (projectiles[j].Location.Y >= 890))
                {
                    ptemp = projectiles[j];
                    projectiles.Remove(projectiles[j]);
                    ptemp.Dispose();
                    ptemp.Hide();
                }
            }
        }
    }
}
