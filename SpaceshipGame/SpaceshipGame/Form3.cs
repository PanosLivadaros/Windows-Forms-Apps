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

namespace SpaceshipGame
{
    public partial class Form3 : Form
    {
        IFormatter form3 = new BinaryFormatter();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                Stream str = new FileStream("./a.txt", FileMode.Open, FileAccess.Read);
                int[] scores = (int[])form3.Deserialize(str);
                for (int i = 0; i < 10; i++)
                {
                    richTextBox1.Text = richTextBox1.Text+ (i + 1) + ". " + scores[i] + "\n";
                }
                str.Close();
            }
            catch (System.IO.IOException d)
            {
                MessageBox.Show("No scores yet; return after at least 1 game has been played.");
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            Stream str = new FileStream("./a.txt", FileMode.Open, FileAccess.Read);
            int[] scores = (int[])form3.Deserialize(str);
            for (int i = 0; i < 10; i++)
            {
                richTextBox1.Text = richTextBox1.Text + (i + 1) + ". " + scores[i] + "\n";
            }
            str.Close();
            MessageBox.Show("The Highscore Board has been updated with the latest Scores!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
