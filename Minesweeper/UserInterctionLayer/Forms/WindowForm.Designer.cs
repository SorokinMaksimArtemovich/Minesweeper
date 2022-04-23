namespace Minesweeper
{
    partial class WindowForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowForm));
            this.WindowFormStyle = new yt_DesignUI.Components.EgoldsFormStyle(this.components);
            this.SuspendLayout();
            // 
            // WindowFormStyle
            // 
            this.WindowFormStyle.AllowUserResize = false;
            this.WindowFormStyle.BackColor = System.Drawing.Color.Azure;
            this.WindowFormStyle.ContextMenuForm = null;
            this.WindowFormStyle.ControlBoxButtonsWidth = 50;
            this.WindowFormStyle.EnableControlBoxIconsLight = false;
            this.WindowFormStyle.EnableControlBoxMouseLight = false;
            this.WindowFormStyle.Form = this;
            this.WindowFormStyle.FormStyle = yt_DesignUI.Components.EgoldsFormStyle.fStyle.UserStyle;
            this.WindowFormStyle.HeaderColor = System.Drawing.Color.SkyBlue;
            this.WindowFormStyle.HeaderColorAdditional = System.Drawing.Color.CadetBlue;
            this.WindowFormStyle.HeaderColorGradientEnable = true;
            this.WindowFormStyle.HeaderColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.WindowFormStyle.HeaderHeight = 27;
            this.WindowFormStyle.HeaderImage = null;
            this.WindowFormStyle.HeaderTextColor = System.Drawing.Color.White;
            this.WindowFormStyle.HeaderTextFont = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // WindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WindowForm";
            this.Text = "Сапер";
            this.Click += new System.EventHandler(this.WindowForm_Click);
            this.ResumeLayout(false);

        }

        protected yt_DesignUI.Components.EgoldsFormStyle WindowFormStyle;


        #endregion
    }
}