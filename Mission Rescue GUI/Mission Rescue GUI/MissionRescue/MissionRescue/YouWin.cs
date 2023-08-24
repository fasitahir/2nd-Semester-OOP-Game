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
    public partial class YouWin : Form
    {
        public YouWin()
        {
            InitializeComponent();
            score.Text = "Your Total Score: " + ((Form1)Program.currentForm).score;
        }

        private void score_Click(object sender, EventArgs e)
        {
            
        }
    }
}
