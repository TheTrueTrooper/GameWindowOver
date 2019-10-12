using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWindowOver
{
    public partial class WindowCaptureForm : Form
    {
        Dictionary<string, Process> ListOfApps = new Dictionary<string, Process>();
        Dictionary<string, WindowHandleInfo> ListOfWindows = new Dictionary<string, WindowHandleInfo>();

        Process TargetApp;
        WindowHandleInfo TargetWindow;

        Size OldSize;
        Point OldLocation;

        char OnOffKey = ']';

        bool InOnOffKey = false;

        bool DiscordCaptureMode = false;

        bool IgnoreResize = false;

        Color OldBackGroundColor;
        Color OldTransparncyColour;

        int TitleBarHeight = 0;
        int BorderWidth = 0;

        public WindowCaptureForm()
        {
            InitializeComponent();
            TexBox_OnOffKey.Text = OnOffKey.ToString();

            OldSize = this.Size;
            OldLocation = this.Location;

            foreach (Process App in Process.GetProcesses().Where(P => P.MainWindowHandle != IntPtr.Zero && P.ProcessName != "GameWindowOver"))
            {
                ListOfApps.Add($"{App.ProcessName}:{App.Id}", App);
                LisBox_Program.Items.Add(ListOfApps.Last().Key);
            }

            timer1.Enabled = true;
        }

        private void TexBox_OnOffKey_TextChanged(object sender, EventArgs e)
        {
            if (TexBox_OnOffKey.Text.Count() > 1)
                TexBox_OnOffKey.Text = TexBox_OnOffKey.Text.Last().ToString().ToLower();

            if (TexBox_OnOffKey.Text.Count() > 0)
                OnOffKey = TexBox_OnOffKey.Text.Last();
            else
                TexBox_OnOffKey.Text = OnOffKey.ToString();
            TexBox_OnOffKey.SelectionStart = TexBox_OnOffKey.Text.Length;
        }

        private void LisBox_Program_SelectedIndexChanged(object sender, EventArgs e)
        {
            LisBox_Window.Items.Clear();

            if (TargetWindow != null)
                TargetWindow.NoInactive = false;
            TargetWindow = null;

            if (LisBox_Program.SelectedIndex == -1)
            {
                TargetApp = null;
                return;
            }

            TargetApp = ListOfApps[LisBox_Program.Items[LisBox_Program.SelectedIndex].ToString()];
            ListOfWindows = new Dictionary<string, WindowHandleInfo>();
            WindowHandleInfo MainWindow = new WindowHandleInfo(TargetApp.MainWindowHandle);


            ListOfWindows.Add($"{MainWindow.WindowsName}:{MainWindow.Handle}", MainWindow);
            LisBox_Window.Items.Add(ListOfWindows.Last().Key);

            foreach (WindowHandleInfo Window in MainWindow.GetAllChildWindowInfos())
            {
                ListOfWindows.Add($"{Window.WindowsName}:{Window.Handle}", Window);
                LisBox_Window.Items.Add(ListOfWindows.Last().Key);
            }

            timer1.Enabled = true;
        }

        void UpDateApps()
        {
            List<KeyValuePair<string, Process>> AddList;
            List<KeyValuePair<string, Process>> RemoveList;

            Dictionary<string, Process> NewListOfApps = new Dictionary<string, Process>();

            List<Process> TNewListOfApps = Process.GetProcesses().Where(P => P.MainWindowHandle != IntPtr.Zero && P.ProcessName != "GameWindowOver").ToList();
            foreach (Process App in TNewListOfApps)
            {
                NewListOfApps.Add($"{App.ProcessName}:{App.Id}", App);
            }

            Task<List<KeyValuePair<string, Process>>> AddListWorker = new Task<List<KeyValuePair<string, Process>>>(()=>NewListOfApps.Except(ListOfApps, new AppListComparer()).ToList());
            Task<List<KeyValuePair<string, Process>>> RemoveListWorker = new Task<List<KeyValuePair<string, Process>>>(() => ListOfApps.Except(NewListOfApps, new AppListComparer()).ToList());
            AddListWorker.Start();
            RemoveListWorker.Start();

            AddList = AddListWorker.Result;
            RemoveList = RemoveListWorker.Result;


            foreach (KeyValuePair<string, Process> Item in AddList)
            {
                ListOfApps.Add(Item.Key, Item.Value);
                if(!LisBox_Program.Items.Contains(ListOfApps.Last().Key))
                    LisBox_Program.Items.Add(ListOfApps.Last().Key);
            }

            foreach (KeyValuePair<string, Process> Item in RemoveList)
            {
                if (LisBox_Program.SelectedIndex != -1 && Item.Key == LisBox_Program.Items[LisBox_Program.SelectedIndex].ToString())
                    LisBox_Program.SelectedIndex = -1;
                ListOfApps.Remove(Item.Key);
                LisBox_Program.Items.Remove(Item.Key);
            }   
        }

        

        private void LisBox_Window_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LisBox_Window.SelectedIndex == -1)
            {
                if (TargetWindow != null)
                    TargetWindow.NoInactive = false;
                TargetWindow = null;
                return;
            }

            TargetWindow = ListOfWindows[LisBox_Window.Items[LisBox_Window.SelectedIndex].ToString()];
        }

        private void TexBox_OnOffKey_Enter(object sender, EventArgs e)
        {
            InOnOffKey = true;
        }

        private void TexBox_OnOffKey_Leave(object sender, EventArgs e)
        {
            InOnOffKey = false;

        }

        private void SwitchModes(ref bool DiscordCaptureMode)
        {
            if (TargetWindow != null && TargetApp != null)
            {
                DiscordCaptureMode = !DiscordCaptureMode;
                if (DiscordCaptureMode)
                {
                    IgnoreResize = true;
                    //timer1.Enabled = true;
                    OldBackGroundColor = BackColor;
                    BackColor = Color.Wheat;
                    OldTransparncyColour = TransparencyKey;
                    TransparencyKey = Color.Wheat;
                    OldSize = Size;
                    OldLocation = Location;
                    Lab_OnOffKey.Enabled = false;
                    Lab_OnOffKey.Hide();
                    Lab_ProgramName.Enabled = false;
                    Lab_ProgramName.Hide();
                    Lab_WindowName.Enabled = false;
                    Lab_WindowName.Hide();
                    TexBox_OnOffKey.Enabled = false;
                    TexBox_OnOffKey.Hide();
                    CheBox_Control.Enabled = false;
                    CheBox_Control.Hide();
                    CheBox_Shift.Enabled = false;
                    CheBox_Shift.Hide();
                    CheBox_Sound.Enabled = false;
                    CheBox_Sound.Hide();
                    CheBox_Control.Enabled = false;
                    CheBox_Control.Hide();
                    CheBox_Alt.Enabled = false;
                    CheBox_Alt.Hide();
                    LisBox_Program.Enabled = false;
                    LisBox_Program.Hide();
                    LisBox_Window.Enabled = false;
                    LisBox_Window.Hide();
                    TabCon_ModeSelector.Enabled = false;
                    TabCon_ModeSelector.Hide();
                    //FormBorderStyle = FormBorderStyle.None;
                    //SetWindowLong(Handle, -20, DefualtStyle | 0x80000 | 0x20);
                    Rectangle Rec = TargetWindow.GetLocation();
                    Size = new Size(Rec.Right - Rec.Left, Rec.Bottom - Rec.Top);
                    Top = Rec.Top;
                    Left = Rec.Left;
                    TargetWindow.NoInactive = true;
                    TitleBarHeight = RectangleToScreen(ClientRectangle).Top - Top;
                    //BorderWidth = RectangleToScreen(ClientRectangle).Right - Right;
                    IgnoreResize = false;
                }
                else
                {
                    //timer1.Enabled = false;
                    BackColor = OldBackGroundColor;
                    TransparencyKey = OldTransparncyColour;
                    Size = OldSize;
                    Location = OldLocation;
                    Lab_OnOffKey.Enabled = true;
                    Lab_OnOffKey.Show();
                    Lab_ProgramName.Enabled = true;
                    Lab_ProgramName.Show();
                    Lab_WindowName.Enabled = true;
                    Lab_WindowName.Show();
                    TexBox_OnOffKey.Enabled = true;
                    TexBox_OnOffKey.Show();
                    CheBox_Control.Enabled = true;
                    CheBox_Control.Show();
                    CheBox_Shift.Enabled = true;
                    CheBox_Shift.Show();
                    CheBox_Sound.Enabled = true;
                    CheBox_Sound.Show();
                    CheBox_Control.Enabled = true;
                    CheBox_Control.Show();
                    CheBox_Alt.Enabled = true;
                    CheBox_Alt.Show();
                    LisBox_Program.Enabled = true;
                    LisBox_Program.Show();
                    LisBox_Window.Enabled = true;
                    LisBox_Window.Show();
                    TabCon_ModeSelector.Enabled = true;
                    TabCon_ModeSelector.Show();
                    //SetWindowLong(Handle, -20, DefualtStyle);
                    //FormBorderStyle = FormBorderStyle.Sizable;
                    TargetWindow.NoInactive = false;
                }
            }
            else
                MessageBox.Show("Please Select a window");
        }

        private void WindowCaptureForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!InOnOffKey)
            {
                Keys K = (Keys)char.ToUpper(OnOffKey);
                switch(OnOffKey)
                {
                    case ']':
                        K = Keys.Oem6;
                        break;
                    case '[':
                        K = Keys.Oem4;
                        break;
                    case '.':
                        K = Keys.OemPeriod;
                        break;
                    case ',':
                        K = Keys.Oemcomma;
                        break;
                    case '\'':
                        K = Keys.OemQuotes;
                        break;
                    case '?':
                        K = Keys.OemQuestion;
                        break;
                    case ';':
                        K = Keys.OemSemicolon;
                        break;
                    case '\\':
                        K = Keys.OemBackslash;
                        break;
                    case '+':
                        K = Keys.OemMinus;
                        break;
                    case '`':
                        K = Keys.Oemtilde;
                        break;
                }
                if (K == e.KeyCode && e.Control == CheBox_Control.Checked && e.Shift == CheBox_Shift.Checked && e.Alt == CheBox_Alt.Checked)
                {
                    SwitchModes(ref DiscordCaptureMode);
                }
                else if (DiscordCaptureMode)
                {
                    TargetWindow.SendKeyDown(e.KeyValue);
                }

            }
        }

        private void WindowCaptureForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (DiscordCaptureMode && !CheBox_DoubleKeyProtection.Checked)
            {
                Keys K = (Keys)char.ToUpper(OnOffKey);
                if (!(K == e.KeyCode && e.Control == CheBox_Control.Checked && e.Shift == CheBox_Shift.Checked && e.Alt == CheBox_Alt.Checked))
                    TargetWindow.SendKeyUp(e.KeyValue);
            }
        }

        //const int YOff = 33;
        //const int XOff = 3;

        private void WindowCaptureForm_MouseDown(object sender, MouseEventArgs e)
        {
            if(DiscordCaptureMode)
            {
                if (e.Button == MouseButtons.Left)
                    TargetWindow.SendMouseDown(WindowHandleInfo.MouseButton.MK_LBUTTON, e.Location, BorderWidth, TitleBarHeight);
                if (e.Button == MouseButtons.Middle)
                    TargetWindow.SendMouseDown(WindowHandleInfo.MouseButton.MK_MBUTTON, e.Location, BorderWidth, TitleBarHeight);
                if (e.Button == MouseButtons.Right)
                    TargetWindow.SendMouseDown(WindowHandleInfo.MouseButton.MK_RBUTTON, e.Location, BorderWidth, TitleBarHeight);
                if (e.Button == MouseButtons.XButton1)
                    TargetWindow.SendMouseDown(WindowHandleInfo.MouseButton.MK_XBUTTON1, e.Location, BorderWidth, TitleBarHeight);
                if (e.Button == MouseButtons.XButton2)
                    TargetWindow.SendMouseDown(WindowHandleInfo.MouseButton.MK_XBUTTON2, e.Location, BorderWidth, TitleBarHeight);
            }
        }

        private void WindowCaptureForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (DiscordCaptureMode)
            {
                if (e.Button == MouseButtons.Left)
                    TargetWindow.SendMouseUp(WindowHandleInfo.MouseButton.MK_LBUTTON, e.Location, BorderWidth, TitleBarHeight);
                if (e.Button == MouseButtons.Middle)
                    TargetWindow.SendMouseUp(WindowHandleInfo.MouseButton.MK_MBUTTON, e.Location, BorderWidth, TitleBarHeight);
                if (e.Button == MouseButtons.Right)
                    TargetWindow.SendMouseUp(WindowHandleInfo.MouseButton.MK_RBUTTON, e.Location, BorderWidth, TitleBarHeight);
                if (e.Button == MouseButtons.XButton1)
                    TargetWindow.SendMouseUp(WindowHandleInfo.MouseButton.MK_XBUTTON1, e.Location, BorderWidth, TitleBarHeight);
                if (e.Button == MouseButtons.XButton2)
                    TargetWindow.SendMouseUp(WindowHandleInfo.MouseButton.MK_XBUTTON2, e.Location, BorderWidth, TitleBarHeight);
            }
        }

        private void WindowCaptureForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DiscordCaptureMode)
            {
                if (e.Button == MouseButtons.Left)
                    TargetWindow.SendMouseDoubleClick(WindowHandleInfo.MouseButton.MK_LBUTTON, e.Location, BorderWidth, TitleBarHeight);
                if (e.Button == MouseButtons.Middle)
                    TargetWindow.SendMouseDoubleClick(WindowHandleInfo.MouseButton.MK_MBUTTON, e.Location, BorderWidth, TitleBarHeight);
                if (e.Button == MouseButtons.Right)
                    TargetWindow.SendMouseDoubleClick(WindowHandleInfo.MouseButton.MK_RBUTTON, e.Location, BorderWidth, TitleBarHeight);
                if (e.Button == MouseButtons.XButton1)
                    TargetWindow.SendMouseDoubleClick(WindowHandleInfo.MouseButton.MK_XBUTTON1, e.Location, BorderWidth, TitleBarHeight);
                if (e.Button == MouseButtons.XButton2)
                    TargetWindow.SendMouseDoubleClick(WindowHandleInfo.MouseButton.MK_XBUTTON2, e.Location, BorderWidth, TitleBarHeight);
            }
        }

        private void WindowCaptureForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (DiscordCaptureMode)
            {
                TargetWindow.SendMouseMove(WindowHandleInfo.MouseButton.MK_XBUTTON2, e.Location, BorderWidth, TitleBarHeight);
            }
        }

        private void WindowCaptureForm_ResizeEnd(object sender, EventArgs e)
        {
            if (DiscordCaptureMode)
            {
                //BorderWidth = screenRectangle.Top - this.Top;
                TitleBarHeight = RectangleToScreen(ClientRectangle).Top - Top;
                //BorderWidth = RectangleToScreen(ClientRectangle).Right - Right;
                TargetWindow.SetWindowLocation(Location.X, Location.Y, Size.Width, Size.Height);
                TargetWindow.SetForegroundWindow();
            }
        }

        private void WindowCaptureForm_SizeChanged(object sender, EventArgs e)
        {
            if(!IgnoreResize && DiscordCaptureMode && WindowState == FormWindowState.Maximized)
            {
                //BorderWidth = screenRectangle.Top - this.Top;
                TitleBarHeight = RectangleToScreen(ClientRectangle).Top - Top;
                //BorderWidth = RectangleToScreen(ClientRectangle).Right - Right;
                TargetWindow.SetWindowLocation(Location.X, Location.Y, Size.Width, Size.Height);
                TargetWindow.SetForegroundWindow();
            }
        }

        /*
         *foreach (var process in Process.GetProcesses().Where(p => p.MainWindowHandle != IntPtr.Zero))
         *foreach( Window window in Application.Current.Windows ) {
         *Console.WriteLine(window.Title);
         */

        private void WindowCaptureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(TargetWindow != null)
                TargetWindow.NoInactive = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!DiscordCaptureMode)
            {
                UpDateApps();
            }
        }
    }
}
