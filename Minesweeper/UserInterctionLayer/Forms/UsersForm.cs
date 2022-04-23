using Minesweeper.UserInterctionLayer.Forms;
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
using yt_DesignUI;

namespace Minesweeper
{
    public partial class UsersForm : WindowForm
    {
        public UsersForm()
        {
            InitializeComponent();
            
        }

        private void UsersForm_SizeChanged(object sender, EventArgs e)
        {
            interectiveList1.ItemTextFont = new Font("Arial", (float)(0.0195 * Height), FontStyle.Bold);
            yt_Button1.Font = new Font("Verdana", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            label1.Font = new Font("Microsoft Sans Serif", (float)(0.035 * Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            interectiveList1.Size = new Size((int)(0.5 * Width), (int)(0.5 * Height));
            yt_Button1.Size = new Size((int)(0.39 * Width), (int)(0.09 * Height));
            label1.Size = new Size((int)(0.41 * Width), (int)(0.055 * Height));
            interectiveList1.Location = new Point((int)(0.5 * (Width - interectiveList1.Width)), (int)(0.13 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button1.Location = new Point((int)(0.5 * (Width - yt_Button1.Width)), (int)(0.72 * Height) + WindowFormStyle.HeaderHeight);
            label1.Location = new Point((int)(0.5 * (Width - label1.Width)), (int)(0.045 * Height) + WindowFormStyle.HeaderHeight);
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            WindowFormStyle.CloseBottonShouldClose = true;
            interectiveList1.ItemTextFont = new Font("Arial", (float)(0.0195 * Height), FontStyle.Bold);
            yt_Button1.Font = new Font("Verdana", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            label1.Font = new Font("Microsoft Sans Serif", (float)(0.035 * Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            interectiveList1.Size = new Size((int)(0.5 * Width), (int)(0.5 * Height));
            yt_Button1.Size = new Size((int)(0.39 * Width), (int)(0.09 * Height)); 
            label1.Size = new Size((int)(0.41 * Width), (int)(0.055 * Height));
            interectiveList1.Location = new Point((int)(0.5 * (Width - interectiveList1.Width)), (int)(0.13 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button1.Location = new Point((int)(0.5 * (Width - yt_Button1.Width)), (int)(0.72 * Height) + WindowFormStyle.HeaderHeight);
            label1.Location = new Point((int)(0.5 * (Width - label1.Width)), (int)(0.045 * Height) + WindowFormStyle.HeaderHeight);
            foreach (var i in Conector.GetUsers())
            {
                this.interectiveList1.AddItem(i);
            }
        }

        private void interectiveList1_Click(object sender, EventArgs e)
        {
            if (interectiveList1.ClickedItem != null)
            {
                Conector.SetUser(interectiveList1.ClickedItem);
                if (!Conector.IsFinished)
                {
                    if (!Conector.IsAlwaysLoadGame())
                    {
                        LoadGameForm dialogForm = new LoadGameForm();
                        if (dialogForm.ShowDialog() == DialogResult.No)
                        {
                            Conector.LoseGame();
                        }
                    }
                }
                FieldForm form = new FieldForm();
                form.WindowState = WindowState;
                form.StartPosition = FormStartPosition.Manual;
                form.Location = Location;
                form.Show();
                Close();
            }
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            CreateUserForm form = new CreateUserForm();
            form.WindowState = WindowState;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = Location;
            form.Show();
            Close();
        }
    }
}
