namespace Minesweeper.UserInterctionLayer.Forms
{
    partial class WindowWithMenuForm
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
            this.windowWithMenuFormStyle1 = new Minesweeper.UserInterctionLayer.Components.WindowWithMenuFormStyle(this.components);
            this.SuspendLayout();
            // 
            // windowWithMenuFormStyle1
            // 
            this.windowWithMenuFormStyle1.AllowUserResize = false;
            this.windowWithMenuFormStyle1.BackColor = System.Drawing.Color.Azure;
            this.windowWithMenuFormStyle1.ContextMenuForm = null;
            this.windowWithMenuFormStyle1.ControlBoxButtonsWidth = 50;
            this.windowWithMenuFormStyle1.EnableControlBoxIconsLight = false;
            this.windowWithMenuFormStyle1.EnableControlBoxMouseLight = false;
            this.windowWithMenuFormStyle1.Form = this;
            this.windowWithMenuFormStyle1.FormStyle = Components.WindowWithMenuFormStyle.fStyle.UserStyle;
            this.windowWithMenuFormStyle1.HeaderColor = System.Drawing.Color.SkyBlue;
            this.windowWithMenuFormStyle1.HeaderColorAdditional = System.Drawing.Color.CadetBlue;
            this.windowWithMenuFormStyle1.HeaderColorGradientEnable = true;
            this.windowWithMenuFormStyle1.HeaderColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.windowWithMenuFormStyle1.HeaderHeight = 57;
            this.windowWithMenuFormStyle1.HeaderImage = null;
            this.windowWithMenuFormStyle1.HeaderTextColor = System.Drawing.Color.White;
            this.windowWithMenuFormStyle1.HeaderTextFont = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.windowWithMenuFormStyle1.MenuTextFont = new System.Drawing.Font("Georgia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // WindowWithMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WindowWithMenuForm";
            this.Text = "Сапер";
            this.ResumeLayout(false);


        }

        #endregion

        protected Components.WindowWithMenuFormStyle windowWithMenuFormStyle1;
    }
}