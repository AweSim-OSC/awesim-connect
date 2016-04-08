using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OSCConnect.Controllers
{
    /// <summary>
    /// A class of static methods using the System user32.dll
    /// 
    /// API Reference at: http://www.andreavb.com/API_USER32.html
    /// </summary>
    class User32
    {
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SetForegroundWindow(IntPtr windowHandle);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        // Clipboard monitoring
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int SetClipboardViewer(int hWndNewViewer);

        // Add the app to the chain of apps that windows notifies on clipboard updates.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ChangeClipboardChain(IntPtr handleWindowRemove, IntPtr handleWindowNewNext);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(IntPtr handleWindow, int windowMessage, IntPtr wParam, IntPtr lParam);
        
        // Used for embedding process into the app
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SetParent(IntPtr windowChild, IntPtr windowParent);
    }
}

