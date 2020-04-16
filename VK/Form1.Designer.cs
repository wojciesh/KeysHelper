namespace VK
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
            this.k1 = new System.Windows.Forms.ComboBox();
            this.k2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // k1
            // 
            this.k1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.k1.FormattingEnabled = true;
            this.k1.Location = new System.Drawing.Point(12, 34);
            this.k1.Name = "k1";
            this.k1.Size = new System.Drawing.Size(121, 21);
            this.k1.TabIndex = 0;
            // 
            // k2
            // 
            this.k2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.k2.FormattingEnabled = true;
            this.k2.Location = new System.Drawing.Point(188, 34);
            this.k2.Name = "k2";
            this.k2.Size = new System.Drawing.Size(121, 21);
            this.k2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "A";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "= Ctrl + ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 273);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.k2);
            this.Controls.Add(this.k1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox k1;
        private System.Windows.Forms.ComboBox k2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

