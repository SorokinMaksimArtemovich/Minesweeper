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
    public partial class StatisticsForm : WindowForm
    {
        public StatisticsForm()
        {
            InitializeComponent();
        }
        private void StatisticsForm_SizeChanged(object sender, EventArgs e)
        {
            borderedPanel1.Size = new Size((int)(0.675 * Width), (int)(0.556 * Height));
            yt_Button1.Size = new Size((int)(0.135 * Width), (int)(0.107 * Height));
            yt_Button2.Size = new Size((int)(0.185 * Width), (int)(0.107 * Height));
            yt_Button3.Size = new Size((int)(0.179 * Width), (int)(0.107 * Height));
            yt_Button4.Size = new Size((int)(0.179 * Width), (int)(0.107 * Height));
            yt_Button1.Font = new Font("Verdana", (float)(0.0244 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            yt_Button2.Font = new Font("Verdana", (float)(0.0244 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            yt_Button3.Font = new Font("Verdana", (float)(0.0244 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            yt_Button4.Font = new Font("Verdana", (float)(0.0244 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            borderedPanel1.Location = new Point((int)(0.1625 * Width), (int)(0.067 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button1.Location = new Point((int)(0.159 * Width), (int)(0.711 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button2.Location = new Point((int)(0.674 * Width), (int)(0.711 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button3.Location = new Point((int)(0.301 * Width), (int)(0.711 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button4.Location = new Point((int)(0.4875 * Width), (int)(0.711 * Height) + WindowFormStyle.HeaderHeight);
            label1.Size = new Size(0, 20);
            label2.Size = new Size(196, 20);
            label3.Size = new Size(159, 17);
            label4.Size = new Size(140, 16);
            label5.Size = new Size(100, 16);
            label6.Size = new Size(200, 16);
            label7.Size = new Size(191, 16);
            label8.Size = new Size(107, 16);
            label9.Size = new Size(140, 16);
            label10.Size = new Size(140, 16);
            label11.Size = new Size(140, 16);
            label12.Size = new Size(140, 16);
            label13.Size = new Size(140, 16);
            label1.Font = new Font("Microsoft Sans Serif", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label2.Font = new Font("Microsoft Sans Serif", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label3.Font = new Font("Microsoft Sans Serif", (float)(0.0222 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label4.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label5.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label6.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label7.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label8.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label9.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label10.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label11.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label12.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label13.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label1.Location = new Point((borderedPanel1.Width - label1.Width) / 2, (int)(0.008 * borderedPanel1.Height));
            label2.Location = new Point((borderedPanel1.Width - label2.Width) / 2, (int)(0.088 * borderedPanel1.Height));
            label3.Location = new Point((borderedPanel1.Width - label3.Width) / 2, (int)(0.088 * borderedPanel1.Height));
            label4.Location = new Point((int)(0.0926 * borderedPanel1.Width), (int)(0.32 * borderedPanel1.Height));
            label5.Location = new Point((int)(0.0926 * borderedPanel1.Width), (int)(0.432 * borderedPanel1.Height));
            label6.Location = new Point((int)(0.0926 * borderedPanel1.Width), (int)(0.544 * borderedPanel1.Height));
            label7.Location = new Point((int)(0.0926 * borderedPanel1.Width), (int)(0.648 * borderedPanel1.Height));
            label8.Location = new Point((int)(0.0926 * borderedPanel1.Width), (int)(0.752 * borderedPanel1.Height));
            label9.Location = new Point((int)(0.861 * borderedPanel1.Width), (int)(0.32 * borderedPanel1.Height));
            label10.Location = new Point((int)(0.861 * borderedPanel1.Width), (int)(0.432 * borderedPanel1.Height));
            label11.Location = new Point((int)(0.861 * borderedPanel1.Width), (int)(0.544 * borderedPanel1.Height));
            label12.Location = new Point((int)(0.861 * borderedPanel1.Width), (int)(0.648 * borderedPanel1.Height));
            label13.Location = new Point((int)(0.861 * borderedPanel1.Width), (int)(0.32 * borderedPanel1.Height));
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            WindowFormStyle.CloseBottonShouldClose = false;
            label1.Text = "Статистика пользователя \"" + Conector.GetUserName(Conector.CurentUserID) + "\"";
            label2.Text = "для уровня \"" + Conector.CurentDificultyLevel + "\"";
            label3.Text = DateTime.Now.ToString();
            label9.Text = Conector.GetCurentUserStatistics()[0];
            label10.Text = Conector.GetCurentUserStatistics()[1];
            label11.Text = Conector.GetCurentUserStatistics()[2];
            label12.Text = Conector.GetCurentUserStatistics()[3];
            label13.Text = Conector.GetCurentUserStatistics()[4] + '%';
            borderedPanel1.Size = new Size((int)(0.675 * Width), (int)(0.556 * Height));
            yt_Button1.Size = new Size((int)(0.135 * Width), (int)(0.107 * Height));
            yt_Button2.Size = new Size((int)(0.185 * Width), (int)(0.107 * Height));
            yt_Button3.Size = new Size((int)(0.179 * Width), (int)(0.107 * Height));
            yt_Button4.Size = new Size((int)(0.179 * Width), (int)(0.107 * Height));
            yt_Button1.Font = new Font("Verdana", (float)(0.0244 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            yt_Button2.Font = new Font("Verdana", (float)(0.0244 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            yt_Button3.Font = new Font("Verdana", (float)(0.0244 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            yt_Button4.Font = new Font("Verdana", (float)(0.0244 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            borderedPanel1.Location = new Point((int)(0.1625 * Width), (int)(0.067 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button1.Location = new Point((int)(0.159 * Width), (int)(0.711 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button2.Location = new Point((int)(0.674 * Width), (int)(0.711 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button3.Location = new Point((int)(0.301 * Width), (int)(0.711 * Height) + WindowFormStyle.HeaderHeight);
            yt_Button4.Location = new Point((int)(0.4875 * Width), (int)(0.711 * Height) + WindowFormStyle.HeaderHeight);
            label1.Size = new Size(0, 20);
            label2.Size = new Size(196, 20);
            label3.Size = new Size(159, 17);
            label4.Size = new Size(140, 16);
            label5.Size = new Size(100, 16);
            label6.Size = new Size(200, 16);
            label7.Size = new Size(191, 16);
            label8.Size = new Size(107, 16);
            label9.Size = new Size(140, 16);
            label10.Size = new Size(140, 16);
            label11.Size = new Size(140, 16);
            label12.Size = new Size(140, 16);
            label13.Size = new Size(140, 16);
            label1.Font = new Font("Microsoft Sans Serif", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label2.Font = new Font("Microsoft Sans Serif", (float)(0.0267 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label3.Font = new Font("Microsoft Sans Serif", (float)(0.0222 * Height), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label4.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label5.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label6.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label7.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label8.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label9.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label10.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label11.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label12.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label13.Font = new Font("Microsoft Sans Serif", (float)(0.0212 * Height), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            label1.Location = new Point((borderedPanel1.Width - label1.Width) / 2, (int)(0.008 * borderedPanel1.Height));
            label2.Location = new Point((borderedPanel1.Width - label2.Width) / 2, (int)(0.088 * borderedPanel1.Height));
            label3.Location = new Point((borderedPanel1.Width - label3.Width) / 2, (int)(0.088 * borderedPanel1.Height));
            label4.Location = new Point((int)(0.0926 * borderedPanel1.Width), (int)(0.32 * borderedPanel1.Height));
            label5.Location = new Point((int)(0.0926 * borderedPanel1.Width), (int)(0.432 * borderedPanel1.Height));
            label6.Location = new Point((int)(0.0926 * borderedPanel1.Width), (int)(0.544 * borderedPanel1.Height));
            label7.Location = new Point((int)(0.0926 * borderedPanel1.Width), (int)(0.648 * borderedPanel1.Height));
            label8.Location = new Point((int)(0.0926 * borderedPanel1.Width), (int)(0.752 * borderedPanel1.Height));
            label9.Location = new Point((int)(0.861 * borderedPanel1.Width), (int)(0.32 * borderedPanel1.Height));
            label10.Location = new Point((int)(0.861 * borderedPanel1.Width), (int)(0.432 * borderedPanel1.Height));
            label11.Location = new Point((int)(0.861 * borderedPanel1.Width), (int)(0.544 * borderedPanel1.Height));
            label12.Location = new Point((int)(0.861 * borderedPanel1.Width), (int)(0.648 * borderedPanel1.Height));
            label13.Location = new Point((int)(0.861 * borderedPanel1.Width), (int)(0.752 * borderedPanel1.Height));
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
            //продолжить игру
            FieldForm form = new FieldForm();
            form.WindowState = WindowState;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = Location;
            form.Show();
            Close();
        }
        private void yt_Button3_Click(object sender, EventArgs e)
        {
            //новая игра
            Conector.LoseGame();
            FieldForm form = new FieldForm();
            form.WindowState = WindowState;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = Location;
            form.Show();
            Close();
        }
        private void yt_Button4_Click(object sender, EventArgs e)
        {
            //зал славы
            StatisticsGloryHallForm form = new StatisticsGloryHallForm();
            form.WindowState = WindowState;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = Location;
            form.Show();
            Close();
        }
        private void StatisticsForm_Click(object sender, EventArgs e)
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
