namespace Cinema
{
    partial class SelectDateControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpMovie = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlMovies
            // 
            this.pnlMovies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMovies.BackColor = System.Drawing.Color.PaleGreen;
            this.pnlMovies.Location = new System.Drawing.Point(0, 53);
            this.pnlMovies.Name = "pnlMovies";
            this.pnlMovies.Size = new System.Drawing.Size(809, 439);
            this.pnlMovies.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Date:";
            // 
            // dtpMovie
            // 
            this.dtpMovie.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMovie.Location = new System.Drawing.Point(94, 15);
            this.dtpMovie.Name = "dtpMovie";
            this.dtpMovie.Size = new System.Drawing.Size(100, 22);
            this.dtpMovie.TabIndex = 2;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(200, 9);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(81, 38);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // SelectDateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dtpMovie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlMovies);
            this.Name = "SelectDateControl";
            this.Size = new System.Drawing.Size(809, 492);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMovies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpMovie;
        private System.Windows.Forms.Button btnFilter;
    }
}
