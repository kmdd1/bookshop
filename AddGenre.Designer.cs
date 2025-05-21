namespace bookshop
{
    partial class AddGenre
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
            this.Title = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.genre = new System.Windows.Forms.TextBox();
            this.addbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(57, 157);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(65, 24);
            this.Title.TabIndex = 46;
            this.Title.Text = "Genre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Courier New", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Peru;
            this.label9.Location = new System.Drawing.Point(79, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 38);
            this.label9.TabIndex = 45;
            this.label9.Text = "Add Genre";
            // 
            // genre
            // 
            this.genre.BackColor = System.Drawing.Color.Snow;
            this.genre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.genre.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genre.Location = new System.Drawing.Point(131, 158);
            this.genre.Multiline = true;
            this.genre.Name = "genre";
            this.genre.Size = new System.Drawing.Size(196, 29);
            this.genre.TabIndex = 44;
            this.genre.TextChanged += new System.EventHandler(this.genre_TextChanged);
            // 
            // addbutton
            // 
            this.addbutton.BackColor = System.Drawing.Color.IndianRed;
            this.addbutton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbutton.ForeColor = System.Drawing.Color.White;
            this.addbutton.Location = new System.Drawing.Point(115, 243);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(126, 40);
            this.addbutton.TabIndex = 51;
            this.addbutton.Text = "SAVE";
            this.addbutton.UseVisualStyleBackColor = false;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // AddGenre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 394);
            this.Controls.Add(this.addbutton);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.genre);
            this.Name = "AddGenre";
            this.Text = "AddGenre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox genre;
        private System.Windows.Forms.Button addbutton;
    }
}