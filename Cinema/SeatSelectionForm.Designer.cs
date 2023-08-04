namespace Cinema
{
    partial class SeatSelectionForm
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
            this.tblSeats = new System.Windows.Forms.TableLayoutPanel();
            this.btnBuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tblSeats
            // 
            this.tblSeats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSeats.ColumnCount = 1;
            this.tblSeats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSeats.Location = new System.Drawing.Point(0, 0);
            this.tblSeats.Name = "tblSeats";
            this.tblSeats.RowCount = 1;
            this.tblSeats.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSeats.Size = new System.Drawing.Size(1121, 458);
            this.tblSeats.TabIndex = 0;
            // 
            // btnBuy
            // 
            this.btnBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuy.Location = new System.Drawing.Point(1034, 464);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 35);
            this.btnBuy.TabIndex = 1;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // SeatSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 511);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.tblSeats);
            this.Name = "SeatSelectionForm";
            this.Text = "SeatSelectionForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblSeats;
        private System.Windows.Forms.Button btnBuy;
    }
}