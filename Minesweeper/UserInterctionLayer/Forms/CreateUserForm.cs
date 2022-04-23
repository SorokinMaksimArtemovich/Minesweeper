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
    public partial class CreateUserForm : WindowForm
    {
        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void borderedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (borderedTextBox1.Text != "")
                {
                    Conector.BufferUserName = borderedTextBox1.Text;
                    SetParametersForm form = new SetParametersForm();
                    form.WindowState = WindowState;
                    form.StartPosition = FormStartPosition.Manual;
                    form.Location = Location;
                    form.Show();
                    this.Close();
                }
            }
        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            UsersForm form = new UsersForm();
            form.WindowState = WindowState;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = Location;
            form.Show();
            this.Close();
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            if (borderedTextBox1.Text != "")
            {
                Conector.BufferUserName = borderedTextBox1.Text;
                SetParametersForm form = new SetParametersForm();
                form.WindowState = WindowState;
                form.StartPosition = FormStartPosition.Manual;
                form.Location = Location;
                form.Show();
                this.Close();
            }
        }
        private void CreateUserForm_SizeChanged(object sender, EventArgs e)
        {
            borderedTextBox1.Font = new Font("Microsoft Sans Serif", (float)(0.027 * Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            label2.Font = new Font("Microsoft Sans Serif", (float)(0.033 * Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            yt_Button1.Font = new Font("Verdana", (float)(0.022 * Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            yt_Button2.Font = new Font("Verdana", (float)(0.027 * Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            yt_Button2.Size = new Size((int)(0.175 * Width), (int)(0.09 * Height));
            yt_Button1.Size = new Size((int)(0.175 * Width), (int)(0.09 * Height));
            label2.Size = new Size((int)(0.37 * Width), (int)(0.056 * Height));
            borderedTextBox1.Size = new Size((int)(0.35 * Width), (int)(0.09 * Height));
            yt_Button1.Location = new Point((int)(0.52 * Width), (int)(0.5 * Height));
            yt_Button2.Location = new Point((int)(0.48 * Width - yt_Button2.Width), (int)(0.5 * Height));
            label2.Location = new Point((int)(0.5 * Width - 0.5 * label2.Width), (int)(0.16 * Height));
            borderedTextBox1.Location = new Point((int)(0.5 * Width - 0.5 * borderedTextBox1.Width), (int)(0.28 * Height));

        }

        private void CreateUserForm_Load(object sender, EventArgs e)
        {
            WindowFormStyle.CloseBottonShouldClose = true;
            borderedTextBox1.Font = new Font("Microsoft Sans Serif", (float)(0.027 * Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            label2.Font = new Font("Microsoft Sans Serif", (float)(0.033 * Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            yt_Button1.Font = new Font("Verdana", (float)(0.022 * Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            yt_Button2.Font = new Font("Verdana", (float)(0.027 * Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            yt_Button2.Size = new Size((int)(0.175 * Width), (int)(0.09 * Height));
            yt_Button1.Size = new Size((int)(0.175 * Width), (int)(0.09 * Height));
            label2.Size = new Size((int)(0.37 * Width), (int)(0.056 * Height));
            borderedTextBox1.Size = new Size((int)(0.35 * Width), (int)(0.09 * Height));
            yt_Button1.Location = new Point((int)(0.52 * Width), (int)(0.5 * Height));
            yt_Button2.Location = new Point((int)(0.48 * Width - yt_Button2.Width), (int)(0.5 * Height));
            label2.Location = new Point((int)(0.5 * Width - 0.5 * label2.Width), (int)(0.16 * Height));
            borderedTextBox1.Location = new Point((int)(0.5 * Width - 0.5 * borderedTextBox1.Width), (int)(0.28 * Height));
            borderedTextBox1.Text = Conector.BufferUserName;
        }
    }
}
