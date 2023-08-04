namespace Cinema
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nowShowingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.popularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allMoviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlUserControls = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nowShowingToolStripMenuItem,
            this.selectDateToolStripMenuItem,
            this.popularToolStripMenuItem,
            this.allMoviesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(861, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nowShowingToolStripMenuItem
            // 
            this.nowShowingToolStripMenuItem.Name = "nowShowingToolStripMenuItem";
            this.nowShowingToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.nowShowingToolStripMenuItem.Text = "Now Showing";
            this.nowShowingToolStripMenuItem.Click += new System.EventHandler(this.nowShowingToolStripMenuItem_Click);
            // 
            // selectDateToolStripMenuItem
            // 
            this.selectDateToolStripMenuItem.Name = "selectDateToolStripMenuItem";
            this.selectDateToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.selectDateToolStripMenuItem.Text = "Select Date";
            this.selectDateToolStripMenuItem.Click += new System.EventHandler(this.selectDateToolStripMenuItem_Click);
            // 
            // popularToolStripMenuItem
            // 
            this.popularToolStripMenuItem.Name = "popularToolStripMenuItem";
            this.popularToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.popularToolStripMenuItem.Text = "Popular";
            this.popularToolStripMenuItem.Click += new System.EventHandler(this.popularToolStripMenuItem_Click);
            // 
            // allMoviesToolStripMenuItem
            // 
            this.allMoviesToolStripMenuItem.Name = "allMoviesToolStripMenuItem";
            this.allMoviesToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.allMoviesToolStripMenuItem.Text = "All Movies";
            this.allMoviesToolStripMenuItem.Click += new System.EventHandler(this.allMoviesToolStripMenuItem_Click);
            // 
            // pnlUserControls
            // 
            this.pnlUserControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUserControls.Location = new System.Drawing.Point(0, 31);
            this.pnlUserControls.Name = "pnlUserControls";
            this.pnlUserControls.Size = new System.Drawing.Size(861, 431);
            this.pnlUserControls.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 461);
            this.Controls.Add(this.pnlUserControls);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nowShowingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem popularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allMoviesToolStripMenuItem;
        private System.Windows.Forms.Panel pnlUserControls;
    }
}

