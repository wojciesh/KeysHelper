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
            this.grid = new System.Windows.Forms.DataGridView();
            this.btClear = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // k1
            // 
            this.k1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.k1.FormattingEnabled = true;
            this.k1.Location = new System.Drawing.Point(13, 15);
            this.k1.Name = "k1";
            this.k1.Size = new System.Drawing.Size(154, 21);
            this.k1.TabIndex = 0;
            // 
            // k2
            // 
            this.k2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.k2.FormattingEnabled = true;
            this.k2.Location = new System.Drawing.Point(198, 15);
            this.k2.Name = "k2";
            this.k2.Size = new System.Drawing.Size(152, 21);
            this.k2.TabIndex = 0;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(356, 13);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(102, 23);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "=>";
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
            this.cbStartup.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbStartup.Location = new System.Drawing.Point(356, 185);
            this.cbStartup.Name = "cbStartup";
            this.cbStartup.Size = new System.Drawing.Size(102, 31);
            this.cbStartup.TabIndex = 3;
            this.cbStartup.Text = "Start with Windows";
            this.cbStartup.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(13, 42);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(337, 174);
            this.grid.TabIndex = 4;
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(356, 71);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(102, 23);
            this.btClear.TabIndex = 5;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(356, 42);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(102, 23);
            this.btDelete.TabIndex = 5;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 232);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.cbStartup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.k2);
            this.Controls.Add(this.k1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeysHelper";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
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
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btDelete;
    }
}

