namespace bookshop
{
    partial class GenrePrice
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
            this.addbutton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPriceIncrease = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGenreId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addbutton
            // 
            this.addbutton.BackColor = System.Drawing.Color.IndianRed;
            this.addbutton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbutton.ForeColor = System.Drawing.Color.White;
            this.addbutton.Location = new System.Drawing.Point(145, 324);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(126, 40);
            this.addbutton.TabIndex = 55;
            this.addbutton.Text = "SAVE";
            this.addbutton.UseVisualStyleBackColor = false;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(52, 168);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(65, 24);
            this.Title.TabIndex = 54;
            this.Title.Text = "Genre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Courier New", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Peru;
            this.label9.Location = new System.Drawing.Point(138, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 38);
            this.label9.TabIndex = 53;
            this.label9.Text = "Add Genre";
            // 
            // txtPriceIncrease
            // 
            this.txtPriceIncrease.BackColor = System.Drawing.Color.Snow;
            this.txtPriceIncrease.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPriceIncrease.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceIncrease.Location = new System.Drawing.Point(202, 169);
            this.txtPriceIncrease.Multiline = true;
            this.txtPriceIncrease.Name = "txtPriceIncrease";
            this.txtPriceIncrease.Size = new System.Drawing.Size(196, 29);
            this.txtPriceIncrease.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 24);
            this.label1.TabIndex = 54;
            this.label1.Text = "Price Increase";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 24);
            this.label2.TabIndex = 57;
            this.label2.Text = "Genre ID";
            // 
            // txtGenreId
            // 
            this.txtGenreId.BackColor = System.Drawing.Color.Snow;
            this.txtGenreId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGenreId.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenreId.Location = new System.Drawing.Point(202, 229);
            this.txtGenreId.Multiline = true;
            this.txtGenreId.Name = "txtGenreId";
            this.txtGenreId.Size = new System.Drawing.Size(196, 29);
            this.txtGenreId.TabIndex = 56;
            // 
            // GenrePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGenreId);
            this.Controls.Add(this.addbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPriceIncrease);
            this.Name = "GenrePrice";
            this.Text = "GenrePrice";
            this.Load += new System.EventHandler(this.GenrePrice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPriceIncrease;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGenreId;
    }
}