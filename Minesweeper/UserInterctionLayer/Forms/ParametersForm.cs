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
    public partial class ParametersForm : WindowForm
    {
        public ParametersForm()
        {
            InitializeComponent();
        }
        private void ChangeActivity(bool activity)
        {
            if (activity)
            {
                borderedTextBox1.IsActive = true;
                borderedTextBox1.Invalidate();
                borderedTextBox2.IsActive = true;
                borderedTextBox2.Invalidate();
                borderedTextBox3.IsActive = true;
                borderedTextBox3.Invalidate();
                acitvatedLabel1.IsActive = true;
                acitvatedLabel1.Invalidate();
                acitvatedLabel2.IsActive = true;
                acitvatedLabel2.Invalidate();
                acitvatedLabel3.IsActive = true;
                acitvatedLabel3.Invalidate();
            }
            else
            {
                borderedTextBox1.IsActive = false;
                borderedTextBox1.Invalidate();
                borderedTextBox2.IsActive = false;
                borderedTextBox2.Invalidate();
                borderedTextBox3.IsActive = false;
                borderedTextBox3.Invalidate();
                acitvatedLabel1.IsActive = false;
                acitvatedLabel1.Invalidate();
                acitvatedLabel2.IsActive = false;
                acitvatedLabel2.Invalidate();
                acitvatedLabel3.IsActive = false;
                acitvatedLabel3.Invalidate();
            }
        }

        private void egoldsRadioButton4_MouseClick(object sender, EventArgs e)
        {
            if (egoldsRadioButton4.IsChecked)
            {
                if (egoldsRadioButton1.IsChecked)
                {
                    egoldsRadioButton1.IsChecked = false;
                    egoldsRadioButton1.Invalidate();
                }
                if (egoldsRadioButton2.IsChecked)
                {
                    egoldsRadioButton2.IsChecked = false;
                    egoldsRadioButton2.Invalidate();
                }
                if (egoldsRadioButton3.IsChecked)
                {
                    egoldsRadioButton3.IsChecked = false;
                    egoldsRadioButton3.Invalidate();
                }
                ChangeActivity(true);
            }
        }

        private void egoldsRadioButton1_MouseClick(object sender, EventArgs e)
        {
            if (egoldsRadioButton1.IsChecked)
            {
                if (egoldsRadioButton2.IsChecked)
                {
                    egoldsRadioButton2.IsChecked = false;
                    egoldsRadioButton2.Invalidate();
                }
                if (egoldsRadioButton3.IsChecked)
                {
                    egoldsRadioButton3.IsChecked = false;
                    egoldsRadioButton3.Invalidate();
                }
                if (egoldsRadioButton4.IsChecked)
                {
                    egoldsRadioButton4.IsChecked = false;
                    egoldsRadioButton4.Invalidate();
                }
                ChangeActivity(false);
            }
        }

        private void egoldsRadioButton2_MouseClick(object sender, EventArgs e)
        {
            if (egoldsRadioButton2.IsChecked)
            {
                if (egoldsRadioButton1.IsChecked)
                {
                    egoldsRadioButton1.IsChecked = false;
                    egoldsRadioButton1.Invalidate();
                }
                if (egoldsRadioButton3.IsChecked)
                {
                    egoldsRadioButton3.IsChecked = false;
                    egoldsRadioButton3.Invalidate();
                }
                if (egoldsRadioButton4.IsChecked)
                {
                    egoldsRadioButton4.IsChecked = false;
                    egoldsRadioButton4.Invalidate();
                }
                ChangeActivity(false);
            }
        }

        private void egoldsRadioButton3_MouseClick(object sender, EventArgs e)
        {
            if (egoldsRadioButton3.IsChecked)
            {
                if (egoldsRadioButton1.IsChecked)
                {
                    egoldsRadioButton1.IsChecked = false;
                    egoldsRadioButton1.Invalidate();
                }
                if (egoldsRadioButton2.IsChecked)
                {
                    egoldsRadioButton2.IsChecked = false;
                    egoldsRadioButton2.Invalidate();
                }
                if (egoldsRadioButton4.IsChecked)
                {
                    egoldsRadioButton4.IsChecked = false;
                    egoldsRadioButton4.Invalidate();
                }
                ChangeActivity(false);
            }
        }

        private void ParametersForm_SizeChanged(object sender, EventArgs e)
        {
            yt_Button1.Size = new Size((int)(0.175 * Width), (int)(0.09 * Height));
            yt_Button2.Size = new Size((int)(0.175 * Width), (int)(0.09 * Height));
            borderedPanel1.Size = new Size((int)(0.5 * Width), (int)(0.46 * Height));
            yt_Button1.Location = new Point((int)(0.5375 * Width), (int)(0.71 * Height));
            yt_Button2.Location = new Point((int)(0.2875 * Width), (int)(0.71 * Height));
            borderedPanel1.Location = new Point((int)(0.25 * Width), (int)(0.22 * Height));
            customizedCheckBox2.Size = new Size((int)(0.8 * borderedPanel1.Width), (int)(0.08 * borderedPanel1.Height));
            customizedCheckBox1.Size = new Size((int)(0.8 * borderedPanel1.Width), (int)(0.08 * borderedPanel1.Height));
            line1.Size = new Size((int)(0.985 * borderedPanel1.Width), 1);
            borderedTextBox3.Size = new Size((int)(0.13 * borderedPanel1.Width), (int)(0.11 * borderedPanel1.Height));
            borderedTextBox2.Size = new Size((int)(0.13 * borderedPanel1.Width), (int)(0.11 * borderedPanel1.Height));
            borderedTextBox1.Size = new Size((int)(0.13 * borderedPanel1.Width), (int)(0.11 * borderedPanel1.Height));
            acitvatedLabel3.Size = new Size((int)(0.35 * borderedPanel1.Width), (int)(0.083 * borderedPanel1.Height));
            acitvatedLabel2.Size = new Size((int)(0.28 * borderedPanel1.Width), (int)(0.083 * borderedPanel1.Height));
            acitvatedLabel1.Size = new Size((int)(0.27 * borderedPanel1.Width), (int)(0.083 * borderedPanel1.Height));
            egoldsRadioButton4.Size = new Size((int)(0.44 * borderedPanel1.Width), (int)(0.1025 * borderedPanel1.Height));
            egoldsRadioButton3.Size = new Size((int)(0.35 * borderedPanel1.Width), (int)(0.1025 * borderedPanel1.Height));
            egoldsRadioButton2.Size = new Size((int)(0.3 * borderedPanel1.Width), (int)(0.1025 * borderedPanel1.Height));
            egoldsRadioButton1.Size = new Size((int)(0.3 * borderedPanel1.Width), (int)(0.1025 * borderedPanel1.Height));
            label1.Size = new Size((int)(0.56 * borderedPanel1.Width), (int)(0.088 * borderedPanel1.Height));
            customizedCheckBox2.Font = new Font("Microsoft Sans Serif", (float)(0.0549 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            customizedCheckBox1.Font = new Font("Microsoft Sans Serif", (float)(0.0549 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            borderedTextBox3.Font = new Font("Microsoft Sans Serif", (float)(0.046 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            borderedTextBox2.Font = new Font("Microsoft Sans Serif", (float)(0.046 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            borderedTextBox1.Font = new Font("Microsoft Sans Serif", (float)(0.046 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            acitvatedLabel3.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            acitvatedLabel2.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            acitvatedLabel1.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            egoldsRadioButton4.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            egoldsRadioButton3.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            egoldsRadioButton2.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            egoldsRadioButton1.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            label1.Font = new Font("Microsoft Sans Serif", (float)(0.0537 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            yt_Button1.Font = new Font("Verdana", (float)(0.0488 * borderedPanel1.Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            yt_Button2.Font = new Font("Verdana", (float)(0.0585 * borderedPanel1.Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            customizedCheckBox2.Location = new Point((int)(0.0375 * borderedPanel1.Width), (int)(0.87 * borderedPanel1.Height));
            customizedCheckBox1.Location = new Point((int)(0.0375 * borderedPanel1.Width), (int)(0.74 * borderedPanel1.Height));
            line1.Location = new Point((int)(0.0075 * borderedPanel1.Width), (int)(0.7 * borderedPanel1.Height));
            borderedTextBox3.Location = new Point((int)(0.83 * borderedPanel1.Width), (int)(0.55 * borderedPanel1.Height));
            borderedTextBox2.Location = new Point((int)(0.83 * borderedPanel1.Width), (int)(0.41 * borderedPanel1.Height));
            borderedTextBox1.Location = new Point((int)(0.83 * borderedPanel1.Width), (int)(0.28 * borderedPanel1.Height));
            acitvatedLabel3.Location = new Point((int)(0.46 * borderedPanel1.Width), (int)(0.56 * borderedPanel1.Height));
            acitvatedLabel2.Location = new Point((int)(0.46 * borderedPanel1.Width), (int)(0.43 * borderedPanel1.Height));
            acitvatedLabel1.Location = new Point((int)(0.46 * borderedPanel1.Width), (int)(0.3 * borderedPanel1.Height));
            egoldsRadioButton4.Location = new Point((int)(0.46 * borderedPanel1.Width), (int)(0.156 * borderedPanel1.Height));
            egoldsRadioButton3.Location = new Point((int)(0.0325 * borderedPanel1.Width), (int)(0.42 * borderedPanel1.Height));
            egoldsRadioButton2.Location = new Point((int)(0.0325 * borderedPanel1.Width), (int)(0.29 * borderedPanel1.Height));
            egoldsRadioButton1.Location = new Point((int)(0.0325 * borderedPanel1.Width), (int)(0.156 * borderedPanel1.Height));
            label1.Location = new Point((int)(0.225 * borderedPanel1.Width), (int)(0.005 * borderedPanel1.Height));
        }

        private void ParametersForm_Load(object sender, EventArgs e)
        {
            WindowFormStyle.CloseBottonShouldClose = false;
            yt_Button1.Size = new Size((int)(0.175 * Width), (int)(0.09 * Height));
            yt_Button2.Size = new Size((int)(0.175 * Width), (int)(0.09 * Height));
            borderedPanel1.Size = new Size((int)(0.5 * Width), (int)(0.46 * Height));
            yt_Button1.Location = new Point((int)(0.5375 * Width), (int)(0.71 * Height));
            yt_Button2.Location = new Point((int)(0.2875 * Width), (int)(0.71 * Height));
            borderedPanel1.Location = new Point((int)(0.25 * Width), (int)(0.22 * Height));
            customizedCheckBox2.Size = new Size((int)(0.8 * borderedPanel1.Width), (int)(0.08 * borderedPanel1.Height));
            customizedCheckBox1.Size = new Size((int)(0.8 * borderedPanel1.Width), (int)(0.08 * borderedPanel1.Height));
            line1.Size = new Size((int)(0.985 * borderedPanel1.Width), 1);
            borderedTextBox3.Size = new Size((int)(0.13 * borderedPanel1.Width), (int)(0.11 * borderedPanel1.Height));
            borderedTextBox2.Size = new Size((int)(0.13 * borderedPanel1.Width), (int)(0.11 * borderedPanel1.Height));
            borderedTextBox1.Size = new Size((int)(0.13 * borderedPanel1.Width), (int)(0.11 * borderedPanel1.Height));
            acitvatedLabel3.Size = new Size((int)(0.35 * borderedPanel1.Width), (int)(0.083 * borderedPanel1.Height));
            acitvatedLabel2.Size = new Size((int)(0.28 * borderedPanel1.Width), (int)(0.083 * borderedPanel1.Height));
            acitvatedLabel1.Size = new Size((int)(0.27 * borderedPanel1.Width), (int)(0.083 * borderedPanel1.Height));
            egoldsRadioButton4.Size = new Size((int)(0.44 * borderedPanel1.Width), (int)(0.1025 * borderedPanel1.Height));
            egoldsRadioButton3.Size = new Size((int)(0.35 * borderedPanel1.Width), (int)(0.1025 * borderedPanel1.Height));
            egoldsRadioButton2.Size = new Size((int)(0.3 * borderedPanel1.Width), (int)(0.1025 * borderedPanel1.Height));
            egoldsRadioButton1.Size = new Size((int)(0.3 * borderedPanel1.Width), (int)(0.1025 * borderedPanel1.Height));
            label1.Size = new Size((int)(0.56 * borderedPanel1.Width), (int)(0.088 * borderedPanel1.Height));
            yt_Button1.Font = new Font("Verdana", (float)(0.0488 * borderedPanel1.Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            yt_Button2.Font = new Font("Verdana", (float)(0.0585 * borderedPanel1.Height), FontStyle.Bold, GraphicsUnit.Point, (byte)(204));
            customizedCheckBox2.Font = new Font("Microsoft Sans Serif", (float)(0.0549 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            customizedCheckBox1.Font = new Font("Microsoft Sans Serif", (float)(0.0549 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            acitvatedLabel3.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            acitvatedLabel2.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            acitvatedLabel1.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            egoldsRadioButton4.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            egoldsRadioButton3.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            egoldsRadioButton2.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            egoldsRadioButton1.Font = new Font("Microsoft Sans Serif", (float)(0.05 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            label1.Font = new Font("Microsoft Sans Serif", (float)(0.0537 * borderedPanel1.Height), FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            customizedCheckBox2.Location = new Point((int)(0.0375 * borderedPanel1.Width), (int)(0.87 * borderedPanel1.Height));
            customizedCheckBox1.Location = new Point((int)(0.0375 * borderedPanel1.Width), (int)(0.74 * borderedPanel1.Height));
            line1.Location = new Point((int)(0.0075 * borderedPanel1.Width), (int)(0.7 * borderedPanel1.Height));
            borderedTextBox3.Location = new Point((int)(0.83 * borderedPanel1.Width), (int)(0.55 * borderedPanel1.Height));
            borderedTextBox2.Location = new Point((int)(0.83 * borderedPanel1.Width), (int)(0.41 * borderedPanel1.Height));
            borderedTextBox1.Location = new Point((int)(0.83 * borderedPanel1.Width), (int)(0.28 * borderedPanel1.Height));
            acitvatedLabel3.Location = new Point((int)(0.46 * borderedPanel1.Width), (int)(0.56 * borderedPanel1.Height));
            acitvatedLabel2.Location = new Point((int)(0.46 * borderedPanel1.Width), (int)(0.43 * borderedPanel1.Height));
            acitvatedLabel1.Location = new Point((int)(0.46 * borderedPanel1.Width), (int)(0.3 * borderedPanel1.Height));
            egoldsRadioButton4.Location = new Point((int)(0.46 * borderedPanel1.Width), (int)(0.156 * borderedPanel1.Height));
            egoldsRadioButton3.Location = new Point((int)(0.0325 * borderedPanel1.Width), (int)(0.42 * borderedPanel1.Height));
            egoldsRadioButton2.Location = new Point((int)(0.0325 * borderedPanel1.Width), (int)(0.29 * borderedPanel1.Height));
            egoldsRadioButton1.Location = new Point((int)(0.0325 * borderedPanel1.Width), (int)(0.156 * borderedPanel1.Height));
            label1.Location = new Point((int)(0.225 * borderedPanel1.Width), (int)(0.005 * borderedPanel1.Height));
            if (Conector.CurentDificultyLevel == "Новичек")
            {
                egoldsRadioButton1.IsChecked = true;
                egoldsRadioButton2.IsChecked = false;
                egoldsRadioButton3.IsChecked = false;
                egoldsRadioButton4.IsChecked = false;
            }
            else if (Conector.CurentDificultyLevel == "Любитель")
            {
                egoldsRadioButton1.IsChecked = false;
                egoldsRadioButton2.IsChecked = true;
                egoldsRadioButton3.IsChecked = false;
                egoldsRadioButton4.IsChecked = false;
            }
            else if (Conector.CurentDificultyLevel == "Профессионал")
            {
                egoldsRadioButton1.IsChecked = false;
                egoldsRadioButton2.IsChecked = false;
                egoldsRadioButton3.IsChecked = true;
                egoldsRadioButton4.IsChecked = false;
            }
            else if (Conector.CurentDificultyLevel == "Пользовательский")
            {
                egoldsRadioButton1.IsChecked = false;
                egoldsRadioButton2.IsChecked = false;
                egoldsRadioButton3.IsChecked = false;
                egoldsRadioButton4.IsChecked = true;
                borderedTextBox1.IsActive = true;
                borderedTextBox2.IsActive = true;
                borderedTextBox3.IsActive = true;
                acitvatedLabel1.IsActive = true;
                acitvatedLabel2.IsActive = true;
                acitvatedLabel3.IsActive = true;
            }
        }
        private void yt_Button1_Click(object sender, EventArgs e)
        {
            bool IsCorrect = true;
            if (egoldsRadioButton1.IsChecked && Conector.CurentDificultyLevel != "Новичек")
            {
                Conector.SetDificultyLevel("Новичек");
            }
            if (egoldsRadioButton2.IsChecked && Conector.CurentDificultyLevel != "Любитель")
            {
                Conector.SetDificultyLevel("Любитель");
            }
            if (egoldsRadioButton3.IsChecked && Conector.CurentDificultyLevel != "Профессионал")
            {
                Conector.SetDificultyLevel("Профессионал");
            }
            if (egoldsRadioButton4.IsChecked)
            {
                int HeightCount, WidthCount, MinesCount;
                int.TryParse(borderedTextBox1.Text, out HeightCount);
                int.TryParse(borderedTextBox2.Text, out WidthCount);
                int.TryParse(borderedTextBox3.Text, out MinesCount);
                if (HeightCount < 9 || HeightCount > 24)
                {
                    IsCorrect = false;
                    borderedTextBox1.ForeColor = Color.Red;
                    borderedTextBox1.BorderColor = Color.Red;
                    borderedTextBox1.Invalidate();
                }
                if (WidthCount < 9 || WidthCount > 30)
                {
                    IsCorrect = false;
                    borderedTextBox2.ForeColor = Color.Red;
                    borderedTextBox2.BorderColor = Color.Red;
                    borderedTextBox2.Invalidate();
                }
                if (MinesCount < 10 || MinesCount > 669)
                {
                    IsCorrect = false;
                    borderedTextBox3.ForeColor = Color.Red;
                    borderedTextBox3.BorderColor = Color.Red;
                    borderedTextBox3.Invalidate();
                }
                IsCorrect &= (Conector.CurentDificultyLevel != "Пользовательский" || Conector.height != HeightCount || Conector.width != WidthCount || Conector.minesCount != MinesCount);
                if (IsCorrect)
                {
                    Conector.SetDificultyLevel("Пользовательский", HeightCount, WidthCount, MinesCount);
                }
            }
            if (IsCorrect)
            {
                if (Conector.IsAlwaysSaveGame())
                {
                    Conector.SaveGame();
                    Conector.SetUserParameters(customizedCheckBox1.IsChecked, customizedCheckBox2.IsChecked);
                    FieldForm form = new FieldForm();
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
                        Conector.SetUserParameters(customizedCheckBox1.IsChecked, customizedCheckBox2.IsChecked);
                        FieldForm form = new FieldForm();
                        form.WindowState = WindowState;
                        form.StartPosition = FormStartPosition.Manual;
                        form.Location = Location;
                        form.Show();
                        Close();
                    }
                    else if (result == DialogResult.No)
                    {
                        Conector.LoseGame();
                        Conector.SetUserParameters(customizedCheckBox1.IsChecked, customizedCheckBox2.IsChecked);
                        FieldForm form = new FieldForm();
                        form.WindowState = WindowState;
                        form.StartPosition = FormStartPosition.Manual;
                        form.Location = Location;
                        form.Show();
                        Close();
                    }
                }
            }
        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            FieldForm form = new FieldForm();
            form.WindowState = WindowState;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = Location;
            form.Show();
            Close();
        }

        private void borderedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void borderedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void borderedTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void borderedTextBox1_Click(object sender, EventArgs e)
        {
            borderedTextBox1.BorderColor = Color.RoyalBlue;
            borderedTextBox1.ForeColor = Color.RoyalBlue;
            borderedTextBox1.Invalidate();
        }

        private void borderedTextBox2_Click(object sender, EventArgs e)
        {
            borderedTextBox2.BorderColor = Color.RoyalBlue;
            borderedTextBox2.ForeColor = Color.RoyalBlue;
            borderedTextBox2.Invalidate();
        }

        private void borderedTextBox3_Click(object sender, EventArgs e)
        {
            borderedTextBox3.BorderColor = Color.RoyalBlue;
            borderedTextBox3.ForeColor = Color.RoyalBlue;
            borderedTextBox3.Invalidate();
        }
        private void ParametersForm_Click(object sender, EventArgs e)
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
