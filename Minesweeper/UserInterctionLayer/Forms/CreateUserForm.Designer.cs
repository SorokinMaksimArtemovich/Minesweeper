namespace Minesweeper.UserInterctionLayer.Forms
{
    partial class CreateUserForm
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
            this.borderedTextBox1 = new Minesweeper.UserInterctionLayer.Components.BorderedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.yt_Button1 = new yt_DesignUI.yt_Button();
            this.yt_Button2 = new yt_DesignUI.yt_Button();
            this.SuspendLayout();
            // 
            // borderedTextBox1
            // 
            this.borderedTextBox1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.borderedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.borderedTextBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.borderedTextBox1.Location = new System.Drawing.Point(260, 125);
            this.borderedTextBox1.Name = "borderedTextBox1";
            this.borderedTextBox1.Size = new System.Drawing.Size(280, 40);
            this.borderedTextBox1.TabIndex = 10;
            this.borderedTextBox1.UseSystemPasswordChar = false;
            this.borderedTextBox1.IsActive = true;
            this.borderedTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.borderedTextBox1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(252, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Введите имя пользователя";
            // 
            // yt_Button1
            // 
            this.yt_Button1.BackColor = System.Drawing.Color.FromArgb(255, 168, 216, 255);
            this.yt_Button1.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button1.BackColorGradientEnabled = false;
            this.yt_Button1.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button1.BorderColor = System.Drawing.Color.Tomato;
            this.yt_Button1.BorderColorEnabled = false;
            this.yt_Button1.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.yt_Button1.BorderColorOnHoverEnabled = false;
            this.yt_Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yt_Button1.ForeColor = System.Drawing.Color.White;
            this.yt_Button1.HideColor = System.Drawing.Color.White;
            this.yt_Button1.Location = new System.Drawing.Point(415, 224);
            this.yt_Button1.Name = "yt_Button1";
            this.yt_Button1.RippleColor = System.Drawing.Color.Blue;
            this.yt_Button1.RoundingEnable = true;
            this.yt_Button1.Size = new System.Drawing.Size(140, 40);
            this.yt_Button1.TabIndex = 13;
            this.yt_Button1.Text = "Создать пользователя";
            this.yt_Button1.TextHover = null;
            this.yt_Button1.UseDownPressEffectOnClick = false;
            this.yt_Button1.UseRippleEffect = true;
            this.yt_Button1.UseZoomEffectOnHover = false;
            this.yt_Button1.Click += new System.EventHandler(this.yt_Button1_Click);
            // 
            // yt_Button2
            // 
            this.yt_Button2.BackColor = System.Drawing.Color.FromArgb(255, 168, 216, 255);
            this.yt_Button2.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button2.BackColorGradientEnabled = false;
            this.yt_Button2.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button2.BorderColor = System.Drawing.Color.Tomato;
            this.yt_Button2.BorderColorEnabled = false;
            this.yt_Button2.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.yt_Button2.BorderColorOnHoverEnabled = false;
            this.yt_Button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yt_Button2.ForeColor = System.Drawing.Color.White;
            this.yt_Button2.HideColor = System.Drawing.Color.White;
            this.yt_Button2.Location = new System.Drawing.Point(245, 224);
            this.yt_Button2.Name = "yt_Button2";
            this.yt_Button2.RippleColor = System.Drawing.Color.Blue;
            this.yt_Button2.RoundingEnable = true;
            this.yt_Button2.Size = new System.Drawing.Size(140, 40);
            this.yt_Button2.TabIndex = 14;
            this.yt_Button2.Text = "Отмена";
            this.yt_Button2.TextHover = null;
            this.yt_Button2.UseDownPressEffectOnClick = false;
            this.yt_Button2.UseRippleEffect = true;
            this.yt_Button2.UseZoomEffectOnHover = false;
            this.yt_Button2.Click += new System.EventHandler(this.yt_Button2_Click);
            // 
            // CreateUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.yt_Button2);
            this.Controls.Add(this.yt_Button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.borderedTextBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "CreateUserForm";
            this.Load += new System.EventHandler(this.CreateUserForm_Load);
            this.SizeChanged += new System.EventHandler(this.CreateUserForm_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.BorderedTextBox borderedTextBox1;
        private System.Windows.Forms.Label label2;
        private yt_DesignUI.yt_Button yt_Button1;
        private yt_DesignUI.yt_Button yt_Button2;
    }
}