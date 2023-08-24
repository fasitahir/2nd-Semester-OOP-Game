using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionRescue
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
            instructionsUC1.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void instructionBtn_Click(object sender, EventArgs e)
        {
            instructionsUC1.Show();
            instructionsUC1.BringToFront();
        }
    }
}
