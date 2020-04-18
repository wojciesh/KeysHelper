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
            k1.DataSource = new BindingSource(allKeys, null);
            k2.DataSource = new BindingSource(allKeys, null);


            Interceptor.ToSim = toSim;
            Interceptor.InputSim = sim;
            Interceptor.IsBlocking = true;
            Interceptor.OnKeyToSimIsDown += SendKeyDown;
            Interceptor.OnKeyToSimIsUp += SendKeyUp;


            Disposed += OnDisposed;
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
            sim.Keyboard.KeyUp((VirtualKeyCode)keyToSim);

            //this.Text = keyToSim.ToString() + " UP";
        }

        private void SendKeyDown(object sender, Keys keyToSim)
        {
            // CONTROL OFF
            sim.Keyboard.KeyUp(VirtualKeyCode.CONTROL);

            bool isAlt = sim.InputDeviceState.IsHardwareKeyDown(VirtualKeyCode.RMENU);
            if (isAlt)
            {
                sim.Keyboard.KeyUp(VirtualKeyCode.MENU);
                sim.Keyboard.KeyDown(VirtualKeyCode.MENU);
            }

            sim.Keyboard.KeyDown((VirtualKeyCode)keyToSim);

            if (isAlt)
            {
                sim.Keyboard.KeyUp(VirtualKeyCode.MENU);
                sim.Keyboard.KeyDown(VirtualKeyCode.MENU);
            }


            // CONTROL ON 
            sim.Keyboard.KeyDown(VirtualKeyCode.CONTROL);

            //this.Text = keyToSim.ToString() + " OWN";
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //trayIcon.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
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
            var id = (Keys)k1.SelectedValue;

            lock (lock_toSim)
            {
                if (toSim.ContainsKey(id))
                    toSim[id] = (Keys)k2.SelectedValue;
                else
                    toSim.Add(id, (Keys)k2.SelectedValue);
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
    }
}

