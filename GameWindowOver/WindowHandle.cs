using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWindowOver
{
    public class WindowHandleInfo
    {
        // The WM_COMMAND message is sent when the user selects a command item from 
        // a menu, when a control sends a notification message to its parent window, 
        // or when an accelerator keystroke is translated.
        public enum InputType
        {
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WM_COMMAND = 0x111,
            WM_LBUTTONDOWN = 0x201,
            WM_LBUTTONUP = 0x202,
            WM_LBUTTONDBLCLK = 0x203,
            WM_RBUTTONDOWN = 0x204,
            WM_RBUTTONUP = 0x205,
            WM_RBUTTONDBLCLK = 0x206,
            WM_MOUSEMOVE = 0x0200
        }

        public enum MouseButton
        {
            MK_LBUTTON = 0x0001,
            MK_MBUTTON = 0x0010,
            MK_RBUTTON = 0x0002,
            MK_CONTROL = 0x0008,
            MK_SHIFT = 0x0004,
            MK_XBUTTON1 = 0x0020,
            MK_XBUTTON2 = 0x0040
        }

        private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetWindowText(HandleRef hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hwnd, ref Rectangle rectangle);

        // The SendMessage function sends the specified message to a window or windows. 
        // It calls the window procedure for the specified window and does not return
        // until the window procedure has processed the message. 
        [DllImport("User32.dll")]
        static extern Int32 SendMessage(
            IntPtr hWnd,               // handle to destination window
            int Msg,                // message
            int wParam,             // first message parameter
            [MarshalAs(UnmanagedType.LPStr)] string lParam); // second message parameter

        [DllImport("User32.dll")]
        static extern Int32 SendMessage(
            IntPtr hWnd,               // handle to destination window
            int Msg,                // message
            int wParam,             // first message parameter
            int lParam);

        //[DllImport("user32.dll")]
        //static extern 

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        extern static int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        extern static int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr WindowHandle, int Msg, int wParam, int lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        static extern bool SetWindowPos( IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr hWnd);

        private IntPtr _Handle;

        public bool NoInactive
        {
            get
            {
                return (GetWindowLong(_Handle, -20) & 0xFFFFFFFF7FFFFFF) != 0;
            }
            set
            {
                if(value == true)
                {
                    //WS_EX_NOACTIVATE = 0x08000000
                    int CurrentStyle = GetWindowLong(_Handle, -20);
                    SetWindowLong(_Handle, -20, CurrentStyle | 0x08000000);
                }
                else
                {
                    int CurrentStyle = GetWindowLong(_Handle, -20);
                    SetWindowLong(_Handle, -20, CurrentStyle & 0x7FFFFFF);
                }
            }

        }

        public bool Visible
        {
            get
            {
                return IsWindowVisible(_Handle);
            }
        }

        public string WindowsName
        {
            get
            {
                int StringLength = GetWindowTextLength(new HandleRef(this, _Handle)) * 2;
                StringBuilder StringBuilder = new StringBuilder(StringLength);
                GetWindowText(new HandleRef(this, _Handle), StringBuilder, StringBuilder.Capacity);
                return StringBuilder.ToString();
            }
        }

        public IntPtr Handle { get=> _Handle; }

        public WindowHandleInfo(IntPtr handle)
        {
            _Handle = handle;
        }

        public List<IntPtr> GetAllChildHandles()
        {
            List<IntPtr> ChildHandles = new List<IntPtr>();

            GCHandle GCChildhandlesList = GCHandle.Alloc(ChildHandles);
            IntPtr PointerChildHandlesList = GCHandle.ToIntPtr(GCChildhandlesList);

            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(_Handle, childProc, PointerChildHandlesList);
            }
            finally
            {
                GCChildhandlesList.Free();
            }
            return ChildHandles;
        }

        public List<WindowHandleInfo> GetAllChildWindowInfos()
        {
            List<WindowHandleInfo> Return = new List<WindowHandleInfo>();
            foreach (IntPtr Pointer in GetAllChildHandles())
                Return.Add(new WindowHandleInfo(Pointer));
            return Return;
        }

        public Rectangle GetLocation()
        {
            Rectangle NotepadRect = new Rectangle();
            GetWindowRect(_Handle, ref NotepadRect);
            return NotepadRect;
        }


        private bool EnumWindow(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle GCChildhandlesList = GCHandle.FromIntPtr(lParam);

            if (GCChildhandlesList == null || GCChildhandlesList.Target == null)
            {
                return false;
            }

            List<IntPtr> ChildHandles = GCChildhandlesList.Target as List<IntPtr>;
            ChildHandles.Add(hWnd);

            return true;
        }

        public void SetWindowLocation(int X, int Y, int Width, int Height)
        {
            SetWindowPos(_Handle, IntPtr.Zero, X, Y, Width, Height, 0x0004);
        }

        public void SendMouseDown(MouseButton MouseButton, Point LoctionOfPointer, int OffX = 0, int OffY = 0)
        {
            int Location = LoctionOfPointer.X - OffX;
            Location |= (LoctionOfPointer.Y + OffY) << 16;
            //int Location = 0;
            //GetCursorPos(out Location);
            //SendMessage(Handle, (int)InputType.WM_LBUTTONDOWN, 0x00000001, 0x1E5025B);
            switch (MouseButton)
            {
                case MouseButton.MK_LBUTTON:
                    PostMessage(_Handle, (int)InputType.WM_LBUTTONDOWN, 0, Location);
                    break;
                case MouseButton.MK_RBUTTON:
                    PostMessage(_Handle, (int)InputType.WM_RBUTTONDOWN, 0, Location);
                    break;
            }
        }

        public void SendMouseUp(MouseButton MouseButton, Point LoctionOfPointer, int OffX = 0, int OffY = 0)
        {
            int Location = LoctionOfPointer.X + OffX;
            Location |= (LoctionOfPointer.Y + OffY) << 16;
            //SendMessage(Handle, (int)InputType.WM_LBUTTONDOWN, 0x00000001, 0x1E5025B);
            switch (MouseButton)
            {
                case MouseButton.MK_LBUTTON:
                    PostMessage(_Handle, (int)InputType.WM_LBUTTONUP, 0, Location);
                    break;
                case MouseButton.MK_RBUTTON:
                    PostMessage(_Handle, (int)InputType.WM_RBUTTONUP, 0, Location);
                    break;
            }
        }

        public void SendMouseDoubleClick(MouseButton MouseButton, Point LoctionOfPointer, int OffX = 0, int OffY = 0)
        {
            int Location = LoctionOfPointer.X = OffX;
            Location |= (LoctionOfPointer.Y + OffY) << 16;
            //int Location = 0;
            //GetCursorPos(out Location);
            //SendMessage(Handle, (int)InputType.WM_LBUTTONDOWN, 0x00000001, 0x1E5025B);
            switch (MouseButton)
            {
                case MouseButton.MK_LBUTTON:
                    PostMessage(_Handle, (int)InputType.WM_LBUTTONDBLCLK, 0, Location);
                    break;
                case MouseButton.MK_RBUTTON:
                    PostMessage(_Handle, (int)InputType.WM_RBUTTONDBLCLK, 0, Location);
                    break;
            }
        }

        public void SendMouseMove(MouseButton MouseButton, Point LoctionOfPointer, int OffX = 0, int OffY = 0)
        {
            int Location = LoctionOfPointer.X + OffX;
            Location |= (LoctionOfPointer.Y + OffY)  << 16;
            //int Location = 0;
            //GetCursorPos(out Location);
            //SendMessage(Handle, (int)InputType.WM_LBUTTONDOWN, 0x00000001, 0x1E5025B);
            PostMessage(_Handle, (int)InputType.WM_MOUSEMOVE, 0, Location);
        }

        public void SendKeyDown(int KeyValue)
        {
            PostMessage(_Handle, (int)InputType.WM_KEYDOWN, KeyValue, 0);
        }

        public void SendKeyUp(int KeyValue)
        {
            PostMessage(_Handle, (int)InputType.WM_KEYUP, KeyValue, 0);
        }

        public void SetForegroundWindow()
        {
            SetForegroundWindow(_Handle);
        }
    }
}
