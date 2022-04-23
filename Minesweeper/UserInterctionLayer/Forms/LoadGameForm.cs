using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper.UserInterctionLayer.Forms
{
    public partial class LoadGameForm : Form
    {
        public LoadGameForm()
        {
            InitializeComponent();
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
        private void yt_Button2_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
