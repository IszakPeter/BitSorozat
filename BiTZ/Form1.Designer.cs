namespace BiTZ
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
            this.test = new System.Windows.Forms.Button();
            this.tabel = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabel)).BeginInit();
            this.SuspendLayout();
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(735, 12);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(75, 23);
            this.test.TabIndex = 4;
            this.test.Text = "test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // tabel
            // 
            this.tabel.AllowUserToAddRows = false;
            this.tabel.AllowUserToDeleteRows = false;
            this.tabel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabel.Location = new System.Drawing.Point(28, 59);
            this.tabel.Name = "tabel";
            this.tabel.ReadOnly = true;
            this.tabel.Size = new System.Drawing.Size(782, 420);
            this.tabel.TabIndex = 5;
            this.tabel.SelectionChanged += new System.EventHandler(this.Kiemel);
            this.tabel.Click += new System.EventHandler(this.tabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 491);
            this.Controls.Add(this.tabel);
            this.Controls.Add(this.test);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button test;
        private System.Windows.Forms.DataGridView tabel;
    }
}

