namespace Battleships
{
    partial class Form1
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
            this.SunkOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SunkOutput
            // 
            this.SunkOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.SunkOutput.Location = new System.Drawing.Point(526, 151);
            this.SunkOutput.Name = "SunkOutput";
            this.SunkOutput.ReadOnly = true;
            this.SunkOutput.Size = new System.Drawing.Size(206, 38);
            this.SunkOutput.TabIndex = 0;
            this.SunkOutput.Text = "Boats Sunk : 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SunkOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SunkOutput;
    }
}

