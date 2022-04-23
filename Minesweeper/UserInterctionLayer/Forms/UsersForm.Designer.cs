namespace Minesweeper
{
    partial class UsersForm
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
            System.Drawing.StringFormat stringFormat2 = new System.Drawing.StringFormat();
            this.interectiveList1 = new Minesweeper.InterectiveList();
            this.yt_Button1 = new yt_DesignUI.yt_Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // interectiveList1
            // 
            this.interectiveList1.BackColor = System.Drawing.Color.Azure;
            this.interectiveList1.BorderColor = System.Drawing.Color.DarkCyan;
            this.interectiveList1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.interectiveList1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.interectiveList1.ForeColor = System.Drawing.Color.White;
            this.interectiveList1.ItemBorderColor = System.Drawing.Color.RoyalBlue;
            this.interectiveList1.ItemColor = System.Drawing.Color.Azure;
            stringFormat2.Alignment = System.Drawing.StringAlignment.Center;
            stringFormat2.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat2.LineAlignment = System.Drawing.StringAlignment.Center;
            stringFormat2.Trimming = System.Drawing.StringTrimming.Character;
            this.interectiveList1.ItemSF = stringFormat2;
            this.interectiveList1.ItemTextColor = System.Drawing.Color.RoyalBlue;
            this.interectiveList1.ItemTextFont = new System.Drawing.Font("Verdana", 8.25F);
            this.interectiveList1.Location = new System.Drawing.Point(200, 60);
            this.interectiveList1.Name = "interectiveList1";
            this.interectiveList1.Size = new System.Drawing.Size(400, 240);
            this.interectiveList1.TabIndex = 0;
            this.interectiveList1.Text = "interectiveList1";
            this.interectiveList1.Click += new System.EventHandler(this.interectiveList1_Click);
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
            this.yt_Button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yt_Button1.ForeColor = System.Drawing.Color.White;
            this.yt_Button1.HideColor = System.Drawing.Color.White;
            this.yt_Button1.Location = new System.Drawing.Point(245, 325);
            this.yt_Button1.Name = "yt_Button1";
            this.yt_Button1.RippleColor = System.Drawing.Color.Blue;
            this.yt_Button1.RoundingEnable = true;
            this.yt_Button1.Size = new System.Drawing.Size(310, 40);
            this.yt_Button1.TabIndex = 1;
            this.yt_Button1.Text = "Создать нового пользователя";
            this.yt_Button1.TextHover = null;
            this.yt_Button1.UseDownPressEffectOnClick = false;
            this.yt_Button1.UseRippleEffect = true;
            this.yt_Button1.UseZoomEffectOnHover = false;
            this.yt_Button1.Click += new System.EventHandler(this.yt_Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(235, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите имя пользователя:";
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yt_Button1);
            this.Controls.Add(this.interectiveList1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.RoyalBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "UsersForm";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            this.SizeChanged += new System.EventHandler(this.UsersForm_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private InterectiveList interectiveList1;
        private yt_DesignUI.yt_Button yt_Button1;
        private System.Windows.Forms.Label label1;
    }
}