namespace Cinema
{
    partial class AllMoviesControl
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
            this.pnlMovies.BackColor = System.Drawing.Color.LightSalmon;
            this.pnlMovies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMovies.Location = new System.Drawing.Point(0, 0);
            this.pnlMovies.Name = "pnlMovies";
            this.pnlMovies.Size = new System.Drawing.Size(762, 453);
            this.pnlMovies.TabIndex = 1;
            // 
            // AllMoviesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.Controls.Add(this.pnlMovies);
            this.Name = "AllMoviesControl";
            this.Size = new System.Drawing.Size(762, 453);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMovies;
    }
}
