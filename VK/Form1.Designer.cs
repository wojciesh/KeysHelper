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
            this.cbKeyToPress = new System.Windows.Forms.ComboBox();
            this.cbKeyToSim = new System.Windows.Forms.ComboBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cbStartup = new System.Windows.Forms.CheckBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btClear = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.cbModKey = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.iconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miShow = new System.Windows.Forms.ToolStripMenuItem();
            this.miClose = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.iconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbKeyToPress
            // 
            this.cbKeyToPress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKeyToPress.FormattingEnabled = true;
            this.cbKeyToPress.Location = new System.Drawing.Point(13, 15);
            this.cbKeyToPress.Name = "cbKeyToPress";
            this.cbKeyToPress.Size = new System.Drawing.Size(154, 21);
            this.cbKeyToPress.TabIndex = 0;
            // 
            // cbKeyToSim
            // 
            this.cbKeyToSim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKeyToSim.FormattingEnabled = true;
            this.cbKeyToSim.Location = new System.Drawing.Point(198, 15);
            this.cbKeyToSim.Name = "cbKeyToSim";
            this.cbKeyToSim.Size = new System.Drawing.Size(152, 21);
            this.cbKeyToSim.TabIndex = 0;
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
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.iconMenu;
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
            // cbModKey
            // 
            this.cbModKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModKey.FormattingEnabled = true;
            this.cbModKey.Location = new System.Drawing.Point(356, 138);
            this.cbModKey.Name = "cbModKey";
            this.cbModKey.Size = new System.Drawing.Size(102, 21);
            this.cbModKey.TabIndex = 6;
            this.cbModKey.SelectedIndexChanged += new System.EventHandler(this.cbModKey_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Modifier key:";
            // 
            // iconMenu
            // 
            this.iconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShow,
            this.miClose});
            this.iconMenu.Name = "iconMenu";
            this.iconMenu.Size = new System.Drawing.Size(106, 48);
            // 
            // miShow
            // 
            this.miShow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miShow.Name = "miShow";
            this.miShow.Size = new System.Drawing.Size(180, 22);
            this.miShow.Text = "Show";
            this.miShow.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // miClose
            // 
            this.miClose.Name = "miClose";
            this.miClose.Size = new System.Drawing.Size(180, 22);
            this.miClose.Text = "Close";
            this.miClose.Click += new System.EventHandler(this.miClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 232);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbModKey);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.cbStartup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.cbKeyToSim);
            this.Controls.Add(this.cbKeyToPress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeysHelper";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.iconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbKeyToPress;
        private System.Windows.Forms.ComboBox cbKeyToSim;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.CheckBox cbStartup;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.ComboBox cbModKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip iconMenu;
        private System.Windows.Forms.ToolStripMenuItem miShow;
        private System.Windows.Forms.ToolStripMenuItem miClose;
    }
}

