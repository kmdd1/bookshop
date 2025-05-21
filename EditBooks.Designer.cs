namespace bookshop
{
    partial class EditBooks
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
            this.cbPublisher = new System.Windows.Forms.ComboBox();
            this.cbGenre = new System.Windows.Forms.ComboBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.QuantityBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.PriceBox = new System.Windows.Forms.TextBox();
            this.AuthorBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbPublisher
            // 
            this.cbPublisher.FormattingEnabled = true;
            this.cbPublisher.Location = new System.Drawing.Point(174, 255);
            this.cbPublisher.Name = "cbPublisher";
            this.cbPublisher.Size = new System.Drawing.Size(196, 24);
            this.cbPublisher.TabIndex = 52;
            // 
            // cbGenre
            // 
            this.cbGenre.FormattingEnabled = true;
            this.cbGenre.Location = new System.Drawing.Point(174, 203);
            this.cbGenre.Name = "cbGenre";
            this.cbGenre.Size = new System.Drawing.Size(196, 24);
            this.cbGenre.TabIndex = 51;
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.IndianRed;
            this.EditButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.ForeColor = System.Drawing.Color.White;
            this.EditButton.Location = new System.Drawing.Point(140, 422);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(126, 40);
            this.EditButton.TabIndex = 50;
            this.EditButton.Text = "SAVE";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 24);
            this.label5.TabIndex = 49;
            this.label5.Text = "Quantity";
            // 
            // QuantityBox
            // 
            this.QuantityBox.BackColor = System.Drawing.Color.Snow;
            this.QuantityBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuantityBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityBox.Location = new System.Drawing.Point(174, 353);
            this.QuantityBox.Multiline = true;
            this.QuantityBox.Name = "QuantityBox";
            this.QuantityBox.Size = new System.Drawing.Size(196, 29);
            this.QuantityBox.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(92, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 24);
            this.label4.TabIndex = 47;
            this.label4.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 24);
            this.label3.TabIndex = 46;
            this.label3.Text = "Publisher";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 45;
            this.label2.Text = "Genre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 44;
            this.label1.Text = "Author";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(100, 98);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(49, 24);
            this.Title.TabIndex = 43;
            this.Title.Text = "Title";
            // 
            // PriceBox
            // 
            this.PriceBox.BackColor = System.Drawing.Color.Snow;
            this.PriceBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PriceBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceBox.Location = new System.Drawing.Point(174, 303);
            this.PriceBox.Multiline = true;
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(196, 29);
            this.PriceBox.TabIndex = 42;
            // 
            // AuthorBox
            // 
            this.AuthorBox.BackColor = System.Drawing.Color.Snow;
            this.AuthorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AuthorBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorBox.Location = new System.Drawing.Point(174, 149);
            this.AuthorBox.Multiline = true;
            this.AuthorBox.Name = "AuthorBox";
            this.AuthorBox.Size = new System.Drawing.Size(196, 29);
            this.AuthorBox.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Courier New", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Peru;
            this.label9.Location = new System.Drawing.Point(109, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(217, 38);
            this.label9.TabIndex = 40;
            this.label9.Text = "Edit Books";
            // 
            // TitleBox
            // 
            this.TitleBox.BackColor = System.Drawing.Color.Snow;
            this.TitleBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleBox.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleBox.Location = new System.Drawing.Point(174, 99);
            this.TitleBox.Multiline = true;
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(196, 29);
            this.TitleBox.TabIndex = 39;
            // 
            // EditBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 492);
            this.Controls.Add(this.cbPublisher);
            this.Controls.Add(this.cbGenre);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.QuantityBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.PriceBox);
            this.Controls.Add(this.AuthorBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TitleBox);
            this.Name = "EditBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditBooks";
            this.Load += new System.EventHandler(this.EditBooks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPublisher;
        private System.Windows.Forms.ComboBox cbGenre;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox QuantityBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox PriceBox;
        private System.Windows.Forms.TextBox AuthorBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TitleBox;
    }
}