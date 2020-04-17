namespace KeysHelper
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.k1 = new System.Windows.Forms.ComboBox();
            this.k2 = new System.Windows.Forms.ComboBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cbStartup = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // k1
            // 
            this.k1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.k1.FormattingEnabled = true;
            this.k1.Location = new System.Drawing.Point(12, 59);
            this.k1.Name = "k1";
            this.k1.Size = new System.Drawing.Size(97, 21);
            this.k1.TabIndex = 0;
            // 
            // k2
            // 
            this.k2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.k2.FormattingEnabled = true;
            this.k2.Location = new System.Drawing.Point(164, 59);
            this.k2.Name = "k2";
            this.k2.Size = new System.Drawing.Size(105, 21);
            this.k2.TabIndex = 0;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(275, 57);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "= Ctrl + ";
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "KeysHelper";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cbStartup
            // 
            this.cbStartup.AutoSize = true;
            this.cbStartup.Location = new System.Drawing.Point(12, 12);
            this.cbStartup.Name = "cbStartup";
            this.cbStartup.Size = new System.Drawing.Size(117, 17);
            this.cbStartup.TabIndex = 3;
            this.cbStartup.Text = "Start with Windows";
            this.cbStartup.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 231);
            this.Controls.Add(this.cbStartup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.k2);
            this.Controls.Add(this.k1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeysHelper";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox k1;
        private System.Windows.Forms.ComboBox k2;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.CheckBox cbStartup;
    }
}

