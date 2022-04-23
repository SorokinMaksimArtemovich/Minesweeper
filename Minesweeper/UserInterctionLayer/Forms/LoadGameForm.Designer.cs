namespace Minesweeper.UserInterctionLayer.Forms
{
    partial class LoadGameForm
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
            this.yt_Button1 = new yt_DesignUI.yt_Button();
            this.yt_Button2 = new yt_DesignUI.yt_Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yt_Button1
            // 
            this.yt_Button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.yt_Button1.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button1.BackColorGradientEnabled = false;
            this.yt_Button1.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button1.BorderColor = System.Drawing.Color.Tomato;
            this.yt_Button1.BorderColorEnabled = false;
            this.yt_Button1.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.yt_Button1.BorderColorOnHoverEnabled = false;
            this.yt_Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yt_Button1.ForeColor = System.Drawing.Color.White;
            this.yt_Button1.HideColor = System.Drawing.Color.White;
            this.yt_Button1.Location = new System.Drawing.Point(40, 130);
            this.yt_Button1.Name = "yt_Button1";
            this.yt_Button1.RippleColor = System.Drawing.Color.Blue;
            this.yt_Button1.RoundingEnable = true;
            this.yt_Button1.Size = new System.Drawing.Size(130, 40);
            this.yt_Button1.TabIndex = 1;
            this.yt_Button1.Text = "Новая игра";
            this.yt_Button1.TextHover = null;
            this.yt_Button1.UseDownPressEffectOnClick = false;
            this.yt_Button1.UseRippleEffect = true;
            this.yt_Button1.UseZoomEffectOnHover = false;
            this.yt_Button1.Click += new System.EventHandler(this.yt_Button1_Click);
            // 
            // yt_Button2
            // 
            this.yt_Button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.yt_Button2.BackColorAdditional = System.Drawing.Color.Gray;
            this.yt_Button2.BackColorGradientEnabled = false;
            this.yt_Button2.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.yt_Button2.BorderColor = System.Drawing.Color.Tomato;
            this.yt_Button2.BorderColorEnabled = false;
            this.yt_Button2.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.yt_Button2.BorderColorOnHoverEnabled = false;
            this.yt_Button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yt_Button2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yt_Button2.ForeColor = System.Drawing.Color.White;
            this.yt_Button2.HideColor = System.Drawing.Color.White;
            this.yt_Button2.Location = new System.Drawing.Point(190, 130);
            this.yt_Button2.Name = "yt_Button2";
            this.yt_Button2.RippleColor = System.Drawing.Color.Blue;
            this.yt_Button2.RoundingEnable = true;
            this.yt_Button2.Size = new System.Drawing.Size(130, 40);
            this.yt_Button2.TabIndex = 1;
            this.yt_Button2.Text = "Продолжить";
            this.yt_Button2.TextHover = null;
            this.yt_Button2.UseDownPressEffectOnClick = false;
            this.yt_Button2.UseRippleEffect = true;
            this.yt_Button2.UseZoomEffectOnHover = false;
            this.yt_Button2.Click += new System.EventHandler(this.yt_Button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(25, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Продолжить сохраненную игру?";
            // 
            // LoadGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(360, 210);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yt_Button2);
            this.Controls.Add(this.yt_Button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private yt_DesignUI.yt_Button yt_Button1;
        private yt_DesignUI.yt_Button yt_Button2;
        private System.Windows.Forms.Label label1;
    }
}