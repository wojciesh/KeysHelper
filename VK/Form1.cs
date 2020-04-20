using KeysHelper.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace KeysHelper
{
    public partial class Form1 : Form
    {
        private static InputSimulator sim = new InputSimulator();

        private static SortedDictionary<Keys, Keys> toSim = new SortedDictionary<Keys, Keys>();
        public static readonly object lock_toSim = new object();
        private const string toSim_settingsName = "sims";

        public static VirtualKeyCode ModKey
        {
            get => s_modKey;
            private set
            {
                s_modKey = value;
                Interceptor.ModKey = value;
            }
        }
        private static VirtualKeyCode s_modKey = VirtualKeyCode.RCONTROL;

        private bool IsLoaded { get; set; } = false;


        public Form1()
        {
            InitializeComponent();


            // minimize on auto-startup
            if (Program.StartupController.IsStartedUp)
            {
                WindowState = FormWindowState.Minimized;
            }
            // bind startup checkbox.Checked to this.IsStartupEnabled property
            cbStartup.DataBindings.Add("Checked", this, "IsStartupEnabled");

            SettingsDicHelper.LoadDic(toSim, toSim_settingsName);
            UpdateGrid();


            // populate keys comoboxes with keyboard keys
            var allKeys = ((Keys[])Enum.GetValues(typeof(Keys)))
                .Where(k => (int)k >= 8 && (int)k < 65535)  // only keyboard keys
                .Distinct()                                 // no dups
                .ToList();
            cbKeyToPress.DataSource = new BindingSource(allKeys, null);
            cbKeyToSim.DataSource = new BindingSource(allKeys, null);

            // load & set ModKey
            cbModKey.DataSource = new BindingSource(allKeys, null);
            if (!Enum.TryParse(Settings.Default.modkey, out VirtualKeyCode mk))
                mk = VirtualKeyCode.RCONTROL;
            ModKey = mk;
            cbModKey.SelectedItem = (Keys)ModKey;

            // setup keyboard Interceptor
            // Interceptor.ModKey = ModKey; // <- set in ModKey setter
            Interceptor.ToSim = toSim;
            Interceptor.InputSim = sim;
            Interceptor.IsBlocking = true;
            Interceptor.OnKeyToSimIsDown += SendKeyDown;
            Interceptor.OnKeyToSimIsUp += SendKeyUp;


            Disposed += OnDisposed;

            IsLoaded = true;
        }

        private void OnDisposed(object sender, EventArgs e)
        {
            SettingsDicHelper.SaveSettings();

            Interceptor.OnKeyToSimIsDown -= SendKeyDown;
            Interceptor.OnKeyToSimIsUp -= SendKeyUp;
            this.Disposed -= OnDisposed;
        }

        private void SendKeyUp(object sender, Keys keyToSim)
        {
            // release key to sim
            sim.Keyboard.KeyUp((VirtualKeyCode)keyToSim);

            //this.Text = keyToSim.ToString() + " UP";
        }

        private void SendKeyDown(object sender, Keys keyToSim)
        {
            // ModKey OFF
            VirtualKeyCode mk = ModKey;
            switch (ModKey)     // some non-pressable -> pressable keys
            {
                case VirtualKeyCode.RCONTROL:
                case VirtualKeyCode.LCONTROL:
                    mk = VirtualKeyCode.CONTROL;
                    break;
                case VirtualKeyCode.RMENU:
                case VirtualKeyCode.LMENU:
                    mk = VirtualKeyCode.MENU;
                    break;
                case VirtualKeyCode.RSHIFT:
                case VirtualKeyCode.LSHIFT:
                    mk = VirtualKeyCode.SHIFT;
                    break;
            }
            // mod key up
            sim.Keyboard.KeyUp(mk);


            // preserve alt modifier (needed for Polish language)
            bool isAlt = sim.InputDeviceState.IsHardwareKeyDown(VirtualKeyCode.RMENU);
            if (isAlt)
            {
                sim.Keyboard.KeyUp(VirtualKeyCode.MENU);
                sim.Keyboard.KeyDown(VirtualKeyCode.MENU);
            }

            // press key to sim
            sim.Keyboard.KeyDown((VirtualKeyCode)keyToSim);

            // preserve alt modifier (needed for Polish language)
            if (isAlt)
            {
                sim.Keyboard.KeyUp(VirtualKeyCode.MENU);
                sim.Keyboard.KeyDown(VirtualKeyCode.MENU);
            }


            // ModKey ON 
            sim.Keyboard.KeyDown(mk);

            //this.Text = keyToSim.ToString() + " OWN";
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            miShow.PerformClick();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                //trayIcon.Visible = true;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                //trayIcon.Visible = false;
            }
        }

        public bool IsStartupEnabled
        {
            get => Program.StartupController.IsRegistered;

            set
            {
                if (IsStartupEnabled)
                {
                    if (!value)
                        Program.StartupController.Unregister();
                }
                else
                {
                    if (value)
                        Program.StartupController.Register();
                }
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var id = (Keys)cbKeyToPress.SelectedValue;

            lock (lock_toSim)
            {
                if (toSim.ContainsKey(id))
                    toSim[id] = (Keys)cbKeyToSim.SelectedValue;
                else
                    toSim.Add(id, (Keys)cbKeyToSim.SelectedValue);
            }

            UpdateGrid();

            SettingsDicHelper.SaveDic(toSim, toSim_settingsName, true);
        }

        private void UpdateGrid()
        {
            if (toSim != null && toSim.Count > 0)
            {
                try
                {
                    grid.DataSource = new BindingSource(toSim, null);
                    grid.ReadOnly = true;
                    grid.Columns[0].HeaderText = "Right Ctrl + ";
                    grid.Columns[1].HeaderText = "simulate";
                    grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    grid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                grid.DataSource = null;
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            lock (lock_toSim)
            {
                toSim.Clear();
            }

            UpdateGrid();

            SettingsDicHelper.SaveDic(toSim, toSim_settingsName, true);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            var sr = grid.SelectedRows;
            var n = sr.Count;
            for (int i = 0; i < n; i++)
            {
                toSim.Remove((Keys)sr[i].Cells[0].Value);
            }

            UpdateGrid();

            SettingsDicHelper.SaveDic(toSim, toSim_settingsName, true);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbModKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoaded)
                return;

            Keys mk = (Keys)cbModKey.SelectedItem;
            if (mk != Keys.None)
            {
                ModKey = (VirtualKeyCode)mk;

                // save to Settings
                Settings.Default.modkey = ModKey.ToString();
                Settings.Default.Save();
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //trayIcon.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void miClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

