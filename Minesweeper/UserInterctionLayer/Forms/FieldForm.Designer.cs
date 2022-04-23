
namespace Minesweeper.UserInterctionLayer.Forms
{
    partial class FieldForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameField1 = new Components.GameField();
            this.lableWithIcon1 = new Minesweeper.UserInterctionLayer.Components.LableWithIcon();
            this.lableWithIcon2 = new Minesweeper.UserInterctionLayer.Components.LableWithIcon();
            this.SuspendLayout();
            // 
            // gameField1
            // 
            this.gameField1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(10)))), ((int)(((byte)(101)))));
            this.gameField1.Location = new System.Drawing.Point(30, 20);
            this.gameField1.Name = "gameField1";
            this.gameField1.Size = new System.Drawing.Size(800, 400);
            this.gameField1.TabIndex = 0;
            this.gameField1.Text = "gameField1";
            this.gameField1.Click += new System.EventHandler(this.gameField1_Click);
            // 
            // lableWithIcon1
            // 
            this.lableWithIcon1.Location = new System.Drawing.Point(640, 370);
            this.lableWithIcon1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.lableWithIcon1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lableWithIcon1.Font = new System.Drawing.Font("Times new roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lableWithIcon1.Icon = System.Drawing.Image.FromFile(@"C:\Users\Максим\Documents\Minesweeper\Minesweeper\Images\Mine.png");
            this.lableWithIcon1.Name = "lableWithIcon1";
            this.lableWithIcon1.roundingPercent = 100;
            this.lableWithIcon1.Size = new System.Drawing.Size(100, 30);
            this.lableWithIcon1.TabIndex = 1;
            // 
            // lableWithIcon2
            // 
            this.lableWithIcon2.Location = new System.Drawing.Point(520, 370);
            this.lableWithIcon2.BorderColor = System.Drawing.Color.RoyalBlue;
            this.lableWithIcon2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lableWithIcon2.Font = new System.Drawing.Font("Times new roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lableWithIcon2.Icon = System.Drawing.Image.FromFile(@"C:\Users\Максим\Documents\Minesweeper\Minesweeper\Images\Clock.png");
            this.lableWithIcon2.Name = "lableWithIcon1";
            this.lableWithIcon2.roundingPercent = 100;
            this.lableWithIcon2.Size = new System.Drawing.Size(100, 30);
            this.lableWithIcon2.TabIndex = 1;
            // 
            // FieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lableWithIcon1);
            this.Controls.Add(this.lableWithIcon2);
            this.Controls.Add(this.gameField1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "FieldForm";
            this.Load += new System.EventHandler(this.FieldForm_Load);
            this.Click += new System.EventHandler(this.FieldForm_Click);
            this.SizeChanged += new System.EventHandler(this.FieldForm_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private Components.GameField gameField1;
        private Components.LableWithIcon lableWithIcon1;
        private Components.LableWithIcon lableWithIcon2;
    }
}