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
    public partial class StatisticsGloryHallForm : WindowForm
    {
        public StatisticsGloryHallForm()
        {
            InitializeComponent();
        }
        private void GloryHallForm_SizeChanged(object sender, EventArgs e)
        {
            castomizedTable1.Size = new Size((int)(0.6875 * Width), (int)(0.567 * Height));
            yt_Button1.Size = new Size((int)(0.106 * Width), (int)(0.076 * Height));
            yt_Button2.Size = new Size((int)(0.169 * Width), (int)(0.076 * Height));
            yt_Button3.Size = new Size((int)(0.225 * Width), (int)(0.076 * Height));
            yt_Button4.Size = new Size((int)(0.106 * Width), (int)(0.076 * Height));
            castomizedComboBox1.BaceSize = new Size((int)(0.2 * Width), (int)(0.0444 * Height));
            castomizedComboBox1.Font = new Font("Verdana", (float)(0.019 * Height), FontStyle.Bold);
            yt_Button1.Font = new Font("Verdana", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            yt_Button2.Font = new Font("Verdana", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            yt_Button3.Font = new Font("Verdana", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            yt_Button4.Font = new Font("Verdana", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label1.Font = new Font("Microsoft Sans Serif", (float)(0.035 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label2.Font = new Font("Microsoft Sans Serif", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            castomizedTable1.Location = new Point((Width - castomizedTable1.Width) / 2, (int)(0.1762 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button1.Location = new Point((int)(0.1745 * Width), (int)(0.7827 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button2.Location = new Point((int)(0.296 * Width), (int)(0.7827 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button3.Location = new Point((int)(0.4795 * Width), (int)(0.7827 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button4.Location = new Point((int)(0.7195 * Width), (int)(0.7827 * Height) + WindowFormStyle.HeaderHeight);
            label1.Location = new Point((Width - label1.Width) / 2, (int)(0.02 * Height) + WindowFormStyle.HeaderHeight);
            label2.Location = new Point((int)(0.25125 * Width), (int)(0.1006 * Height) + WindowFormStyle.HeaderHeight);
            castomizedComboBox1.Location = new Point((int)(0.58625 * Width), (int)(0.1028 * Height) + WindowFormStyle.HeaderHeight);
        }
        private void GloryHallForm_Load(object sender, EventArgs e)
        {
            WindowFormStyle.CloseBottonShouldClose = false;
            castomizedTable1.Size = new Size((int)(0.6875 * Width), (int)(0.567 * Height));
            yt_Button1.Size = new Size((int)(0.106 * Width), (int)(0.076 * Height));
            yt_Button2.Size = new Size((int)(0.169 * Width), (int)(0.076 * Height));
            yt_Button3.Size = new Size((int)(0.225 * Width), (int)(0.076 * Height));
            yt_Button4.Size = new Size((int)(0.106 * Width), (int)(0.076 * Height));
            castomizedComboBox1.BaceSize = new Size((int)(0.2 * Width), (int)(0.0444 * Height));
            castomizedComboBox1.Font = new Font("Verdana", (float)(0.019 * Height), FontStyle.Bold);
            yt_Button1.Font = new Font("Verdana", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            yt_Button2.Font = new Font("Verdana", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            yt_Button3.Font = new Font("Verdana", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            yt_Button4.Font = new Font("Verdana", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label1.Font = new Font("Microsoft Sans Serif", (float)(0.035 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label2.Font = new Font("Microsoft Sans Serif", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            castomizedTable1.Location = new Point((Width - castomizedTable1.Width) / 2, (int)(0.1762 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button1.Location = new Point((int)(0.1745 * Width), (int)(0.7827 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button2.Location = new Point((int)(0.2955 * Width), (int)(0.7827 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button3.Location = new Point((int)(0.4795 * Width), (int)(0.7827 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button4.Location = new Point((int)(0.7195 * Width), (int)(0.7827 * Height) + WindowFormStyle.HeaderHeight);
            label1.Location = new Point((Width - label1.Width) / 2, (int)(0.02 * Height) + WindowFormStyle.HeaderHeight);
            label2.Location = new Point((int)(0.25125 * Width), (int)(0.1006 * Height) + WindowFormStyle.HeaderHeight);
            castomizedComboBox1.Location = new Point((int)(0.58625 * Width), (int)(0.1028 * Height) + WindowFormStyle.HeaderHeight);
            foreach (var i in Conector.GetStatistics(castomizedComboBox1.Text))
            {
                castomizedTable1.AddRow(i);
            }
        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            //выход
            if (Conector.IsAlwaysSaveGame())
            {
                Conector.SaveGame();
                Close();
            }
            else
            {
                SaveGameForm dialogForm = new SaveGameForm();
                DialogResult result = dialogForm.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    Conector.SaveGame();
                    Close();
                }
                else if (result == DialogResult.No)
                {
                    Conector.LoseGame();
                    Close();
                }
            }
        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            //новая игра
            FieldForm form = new FieldForm();
            form.WindowState = WindowState;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = Location;
            form.Show();
            Close();
        }

        private void yt_Button3_Click(object sender, EventArgs e)
        {
            //продолжить
            FieldForm form = new FieldForm();
            form.WindowState = WindowState;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = Location;
            form.Show();
            Close();
        }

        private void yt_Button4_Click(object sender, EventArgs e)
        {
            //назад
            StatisticsForm form = new StatisticsForm();
            form.WindowState = WindowState;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = Location;
            form.Show();
            Close();
        }

        private void castomizedComboBox1_TextChanged(object sender, EventArgs e)
        {
            castomizedTable1.RemoveRows();
            foreach (var i in Conector.GetStatistics(castomizedComboBox1.Text))
            {
                castomizedTable1.AddRow(i);
            }
            castomizedTable1.Invalidate();
        }
        private void GloryHallForm_Click(object sender, EventArgs e)
        {
            if (WindowFormStyle.IsClosedBottonClicked)
            {
                if (Conector.IsAlwaysSaveGame())
                {
                    Conector.SaveGame();
                    Close();
                }
                else
                {
                    SaveGameForm dialogForm = new SaveGameForm();
                    DialogResult result = dialogForm.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        Conector.SaveGame();
                        Close();
                    }
                    else if (result == DialogResult.No)
                    {
                        Conector.LoseGame();
                        Close();
                    }
                }
            }
        }
    }
}