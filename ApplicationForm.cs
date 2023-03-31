using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace CISESPORT
{
    public partial class ApplicationForm : Form
    {
      
        public ApplicationForm()
        {
            InitializeComponent();
            
        }

        private void allPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            this.Hide();
            FormAllPlayer FormP = new FormAllPlayer();
            FormP.ShowDialog();
            FormP = null;
            this.Show();

        }

        private void teamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            FormTeamInfo FormT = new FormTeamInfo();
            FormT.ShowDialog();
            FormT = null;
            this.Show();
        }
    }
}
