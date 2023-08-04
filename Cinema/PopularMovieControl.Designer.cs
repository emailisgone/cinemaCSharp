namespace Cinema
{
    partial class PopularMovieControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.numMovies = new System.Windows.Forms.NumericUpDown();
            this.btnFilter = new System.Windows.Forms.Button();
            this.pnlMovies = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numMovies)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movies to show:";
            // 
            // numMovies
            // 
            this.numMovies.Location = new System.Drawing.Point(117, 13);
            this.numMovies.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numMovies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMovies.Name = "numMovies";
            this.numMovies.Size = new System.Drawing.Size(52, 22);
            this.numMovies.TabIndex = 1;
            this.numMovies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(175, 7);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 32);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // pnlMovies
            // 
            this.pnlMovies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMovies.Location = new System.Drawing.Point(0, 41);
            this.pnlMovies.Name = "pnlMovies";
            this.pnlMovies.Size = new System.Drawing.Size(786, 413);
            this.pnlMovies.TabIndex = 3;
            // 
            // PopularMovieControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.Controls.Add(this.pnlMovies);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.numMovies);
            this.Controls.Add(this.label1);
            this.Name = "PopularMovieControl";
            this.Size = new System.Drawing.Size(786, 454);
            ((System.ComponentModel.ISupportInitialize)(this.numMovies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMovies;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Panel pnlMovies;
    }
}
