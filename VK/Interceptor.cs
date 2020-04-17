using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace KeysHelper
{
    public static class Interceptor
    {
        public static InputSimulator InputSim { get; set; }
        public static bool IsBlocking { get; set; } = true;

        public static event EventHandler<Keys> OnKeyToSimIsDown = delegate { };
        public static event EventHandler<Keys> OnKeyToSimIsUp = delegate { };


        private static IntPtr _hookID = IntPtr.Zero;

        private const int WH_KEYBOARD_LL = 13;
        // IntPtr prevent casting on use:
        private readonly static IntPtr WM_KEYDOWN = new IntPtr(0x0100);
        private readonly static IntPtr WM_KEYUP = new IntPtr(0x0101);
        private readonly static IntPtr minusOne = new IntPtr(-1);


        public static void Start()
        {
            _hookID = SetHook(HookCallback);
        }

        public static void Stop()
        {
            if (_hookID != IntPtr.Zero)
                UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                        GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            bool isMod = false;
            //if (InputSim.InputDeviceState.IsHardwareKeyDown(VirtualKeyCode.APPS))
            if (InputSim.InputDeviceState.IsHardwareKeyDown(VirtualKeyCode.RCONTROL))
            //  inputSim.InputDeviceState.IsHardwareKeyDown(VirtualKeyCode.LCONTROL) ||
            //  inputSim.InputDeviceState.IsHardwareKeyDown(VirtualKeyCode.RCONTROL))
            {
                if (nCode >= 0 && (
                    wParam == WM_KEYDOWN ||
                    wParam == WM_KEYUP))
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    Keys k = (Keys)vkCode;

                    switch (k)
                    {
                        case Keys.X:
                            k = Keys.C;
                            break;
                        case Keys.S:
                            k = Keys.D;
                            break;
                        case Keys.W:
                            k = Keys.E;
                            break;
                    }

                    isMod = (Keys)vkCode != k;

                    if (isMod)
                    {
                        if (wParam == WM_KEYUP)
                            OnKeyToSimIsUp(null, k);
                        else
                            OnKeyToSimIsDown(null, k);
                    }
                }
            }

            return isMod && IsBlocking
                    ? minusOne
                    : CallNextHookEx(_hookID, nCode, wParam, lParam);
        }


        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}