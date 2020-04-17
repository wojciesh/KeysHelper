using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace VK
{
    public partial class Form1 : Form
    {
        private InputSimulator sim = new InputSimulator();


        public Form1()
        {
            InitializeComponent();

            k1.DataSource = Enum.GetValues(typeof(Keys));
            k2.DataSource = Enum.GetValues(typeof(Keys));

            Interceptor.IsBlocking = true;
            Interceptor.InputSim = sim;
            Interceptor.OnKeyToSimIsDown += SendKeyDown;
            Interceptor.OnKeyToSimIsUp += SendKeyUp;

            this.Disposed += OnDisposed;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OnDisposed(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {

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
    }
}
