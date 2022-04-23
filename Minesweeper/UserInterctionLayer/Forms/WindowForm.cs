using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yt_DesignUI;
using yt_DesignUI.Components;
using yt_DesignUI.Controls;

namespace Minesweeper
{
    public partial class WindowForm : ShadowedForm
    {
        public WindowForm()
        {
            InitializeComponent();

            Animator.Start();
        }

        private void WindowForm_Click(object sender, EventArgs e)
        {
            Focus();
        }
    }
}
