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
    public partial class FieldForm : WindowWithMenuForm
    {
        Timer timer;

        public FieldForm()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            InitializeComponent();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            Conector.Time++; 
            if (Conector.Time < 999)
            {
                lableWithIcon2.Text = Conector.Time.ToString();
            }
            else
            {
                lableWithIcon2.Text = "999";
            }
            lableWithIcon2.Invalidate();
            if (gameField1.IsGameLost)
            {
                timer.Stop();
                Conector.LoseGame();
                EndGameStatisticsForm form = new EndGameStatisticsForm();
                form.WindowState = WindowState;
                form.StartPosition = FormStartPosition.Manual;
                form.Location = Location;
                form.Show();
                Close();
            }
            if (Conector.minesCount == gameField1.closedCells)
            {
                timer.Stop();
                Conector.WinGame();
                EndGameStatisticsForm form = new EndGameStatisticsForm();
                form.WindowState = WindowState;
                form.StartPosition = FormStartPosition.Manual;
                form.Location = Location;
                form.Show();
                Close();
            }
        }

        private void FieldForm_SizeChanged(object sender, EventArgs e)
        {
            int MaxSize = Math.Min((int)((Height * 0.86 - windowWithMenuFormStyle1.HeaderHeight) / (Conector.height)), (Width - 40) / Conector.width);
            gameField1.Size = new Size(Conector.width * (MaxSize) + 3, Conector.height * (MaxSize) + 3);
            gameField1.Location = new Point((Width - gameField1.Width) / 2, (int)((Height * 0.91) + windowWithMenuFormStyle1.HeaderHeight - gameField1.Height) / 2);
            lableWithIcon1.Size = new Size((int)(Width * 0.125), (int)(Height * 0.067));
            lableWithIcon1.Location = new Point((int)(Width * 0.775), (int)(Height * 0.91));
            lableWithIcon2.Size = new Size((int)(Width * 0.125), (int)(Height * 0.067));
            lableWithIcon2.Location = new Point((int)(Width * 0.625), (int)(Height * 0.91));
            lableWithIcon1.Font = new Font("Times new roman", (float)(Height * 0.038), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            lableWithIcon2.Font = new Font("Times new roman", (float)(Height * 0.038), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
        }

        private void FieldForm_Load(object sender, EventArgs e)
        {
            List<List<Tuple<short, short, bool, bool, bool>>> field = Conector.GetField();
            gameField1.SetData(Conector.height, Conector.width, Conector.minesCount, Conector.closedSquaresCount, Conector.markedMinesCount);
            for (int i = 0; i < Conector.height; i++)
            {
                for (int j = 0; j < Conector.width; j++)
                {
                    gameField1.Add(i, j, field[i][j].Item1, field[i][j].Item2, field[i][j].Item3, field[i][j].Item4, field[i][j].Item5);
                }
            }
            windowWithMenuFormStyle1.CloseBottonShouldClose = false;
            int MaxSize = Math.Min((int)((Height * 0.86 - windowWithMenuFormStyle1.HeaderHeight) / (Conector.height)), (Width - 40) / Conector.width);
            gameField1.Size = new Size(Conector.width * (MaxSize) + 3, Conector.height * (MaxSize) + 3);
            gameField1.Location = new Point((Width - gameField1.Width) / 2, (int)((Height * 0.91) + windowWithMenuFormStyle1.HeaderHeight - gameField1.Height) / 2);
            lableWithIcon1.Size = new Size((int)(Width * 0.125), (int)(Height * 0.067));
            lableWithIcon1.Location = new Point((int)(Width * 0.775), (int)(Height * 0.91));
            lableWithIcon2.Size = new Size((int)(Width * 0.125), (int)(Height * 0.067));
            lableWithIcon2.Location = new Point((int)(Width * 0.625), (int)(Height * 0.91));
            lableWithIcon1.Font = new Font("Times new roman", (float)(Height * 0.038), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            lableWithIcon2.Font = new Font("Times new roman", (float)(Height * 0.038), FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            lableWithIcon1.Text = (Conector.minesCount - Conector.markedMinesCount).ToString();
            if (Conector.Time < 999)
            {
                lableWithIcon2.Text = Conector.Time.ToString();
            }
            else
            {
                lableWithIcon2.Text = "999";
            }
        }

        private void FieldForm_Click(object sender, EventArgs e)
        {
            if (windowWithMenuFormStyle1.ClickedButton == "ChangeUser")
            {
                Conector.SetField(gameField1.GetField());
                if (Conector.IsAlwaysSaveGame())
                {Conector.SaveGame();
                    UsersForm form = new UsersForm();
                    form.WindowState = WindowState;
                    form.StartPosition = FormStartPosition.Manual;
                    form.Location = Location;
                    form.Show();
                    Close();
                }
                else
                {
                    SaveGameForm dialogForm = new SaveGameForm();
                    DialogResult result = dialogForm.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        Conector.SaveGame();
                        UsersForm form = new UsersForm();
                        form.WindowState = WindowState;
                        form.StartPosition = FormStartPosition.Manual;
                        form.Location = Location;
                        form.Show();
                        Close();
                    }
                    else if (result == DialogResult.No)
                    {
                        Conector.LoseGame();
                        UsersForm form = new UsersForm();
                        form.WindowState = WindowState;
                        form.StartPosition = FormStartPosition.Manual;
                        form.Location = Location;
                        form.Show();
                        Close();
                    }
                }
            }

            if (windowWithMenuFormStyle1.ClickedButton == "GloryHall")
            {
                Conector.SetField(gameField1.GetField());
                GloryHallForm form = new GloryHallForm();
                form.WindowState = WindowState;
                form.StartPosition = FormStartPosition.Manual;
                form.Location = Location;
                form.Show();
                Close();
            }

            if (windowWithMenuFormStyle1.ClickedButton == "NewGame")
            {
                Conector.LoseGame();
                FieldForm form = new FieldForm();
                form.WindowState = WindowState;
                form.StartPosition = FormStartPosition.Manual;
                form.Location = Location;
                form.Show();
                Close();
            }

            if (windowWithMenuFormStyle1.ClickedButton == "Parameters")
            {
                Conector.SetField(gameField1.GetField());
                ParametersForm form = new ParametersForm();
                form.WindowState = WindowState;
                form.StartPosition = FormStartPosition.Manual;
                form.Location = Location;
                form.Show();
                Close();
            }

            if (windowWithMenuFormStyle1.ClickedButton == "Statistics")
            {
                Conector.SetField(gameField1.GetField());
                StatisticsForm form = new StatisticsForm();
                form.WindowState = WindowState;
                form.StartPosition = FormStartPosition.Manual;
                form.Location = Location;
                form.Show();
                Close();
            }

            if (windowWithMenuFormStyle1.IsClosedBottonClicked)
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

        private void gameField1_Click(object sender, EventArgs e)
        {
            Conector.markedMinesCount = gameField1.markedMines;
            Conector.closedSquaresCount = gameField1.closedCells;
            lableWithIcon1.Text = Math.Max(Conector.minesCount - Conector.markedMinesCount, 0).ToString();
            lableWithIcon1.Invalidate();
            if (!timer.Enabled)
            {
                timer.Start();
            }
        }
    }
}
