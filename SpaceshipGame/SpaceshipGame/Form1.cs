using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace SpaceshipGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void openHighscoreBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void quitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In-Game Controls\n\nShoot: Space\nGo up: Up arrow key\nGo down: Down arrow key\nGo left: Left arrow key\nGo right: Right arrow key");
        }
    }
}