namespace Cinema
{
    partial class NowShowingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMovies = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlMovies
            // 
            this.pnlMovies.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMovies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMovies.Location = new System.Drawing.Point(0, 0);
            this.pnlMovies.Name = "pnlMovies";
            this.pnlMovies.Size = new System.Drawing.Size(765, 454);
            this.pnlMovies.TabIndex = 0;
            // 
            // NowShowingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMovies);
            this.Name = "NowShowingControl";
            this.Size = new System.Drawing.Size(765, 454);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMovies;
    }
}
