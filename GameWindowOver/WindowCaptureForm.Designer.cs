namespace GameWindowOver
{
    partial class WindowCaptureForm
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
            this.TabCon_ModeSelector = new System.Windows.Forms.TabControl();
            this.TabPag_WindowedMode = new System.Windows.Forms.TabPage();
            this.Lab_WindowName = new System.Windows.Forms.Label();
            this.Lab_ProgramName = new System.Windows.Forms.Label();
            this.LisBox_Window = new System.Windows.Forms.ListBox();
            this.LisBox_Program = new System.Windows.Forms.ListBox();
            this.TabPag_ScreenMode = new System.Windows.Forms.TabPage();
            this.CheBox_Sound = new System.Windows.Forms.CheckBox();
            this.Lab_OnOffKey = new System.Windows.Forms.Label();
            this.TexBox_OnOffKey = new System.Windows.Forms.TextBox();
            this.CheBox_Control = new System.Windows.Forms.CheckBox();
            this.CheBox_Shift = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CheBox_Alt = new System.Windows.Forms.CheckBox();
            this.CheBox_DoubleKeyProtection = new System.Windows.Forms.CheckBox();
            this.TabCon_ModeSelector.SuspendLayout();
            this.TabPag_WindowedMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabCon_ModeSelector
            // 
            this.TabCon_ModeSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabCon_ModeSelector.Controls.Add(this.TabPag_WindowedMode);
            this.TabCon_ModeSelector.Controls.Add(this.TabPag_ScreenMode);
            this.TabCon_ModeSelector.Location = new System.Drawing.Point(9, 35);
            this.TabCon_ModeSelector.Name = "TabCon_ModeSelector";
            this.TabCon_ModeSelector.SelectedIndex = 0;
            this.TabCon_ModeSelector.Size = new System.Drawing.Size(433, 388);
            this.TabCon_ModeSelector.TabIndex = 0;
            // 
            // TabPag_WindowedMode
            // 
            this.TabPag_WindowedMode.Controls.Add(this.Lab_WindowName);
            this.TabPag_WindowedMode.Controls.Add(this.Lab_ProgramName);
            this.TabPag_WindowedMode.Controls.Add(this.LisBox_Window);
            this.TabPag_WindowedMode.Controls.Add(this.LisBox_Program);
            this.TabPag_WindowedMode.Location = new System.Drawing.Point(4, 22);
            this.TabPag_WindowedMode.Name = "TabPag_WindowedMode";
            this.TabPag_WindowedMode.Padding = new System.Windows.Forms.Padding(3);
            this.TabPag_WindowedMode.Size = new System.Drawing.Size(425, 362);
            this.TabPag_WindowedMode.TabIndex = 0;
            this.TabPag_WindowedMode.Text = "Windowed Mode";
            this.TabPag_WindowedMode.UseVisualStyleBackColor = true;
            // 
            // Lab_WindowName
            // 
            this.Lab_WindowName.AutoSize = true;
            this.Lab_WindowName.Location = new System.Drawing.Point(208, 16);
            this.Lab_WindowName.Name = "Lab_WindowName";
            this.Lab_WindowName.Size = new System.Drawing.Size(77, 13);
            this.Lab_WindowName.TabIndex = 7;
            this.Lab_WindowName.Text = "Window Name";
            // 
            // Lab_ProgramName
            // 
            this.Lab_ProgramName.AutoSize = true;
            this.Lab_ProgramName.Location = new System.Drawing.Point(6, 16);
            this.Lab_ProgramName.Name = "Lab_ProgramName";
            this.Lab_ProgramName.Size = new System.Drawing.Size(77, 13);
            this.Lab_ProgramName.TabIndex = 6;
            this.Lab_ProgramName.Text = "Program Name";
            // 
            // LisBox_Window
            // 
            this.LisBox_Window.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LisBox_Window.FormattingEnabled = true;
            this.LisBox_Window.Location = new System.Drawing.Point(211, 32);
            this.LisBox_Window.Name = "LisBox_Window";
            this.LisBox_Window.Size = new System.Drawing.Size(208, 316);
            this.LisBox_Window.TabIndex = 1;
            this.LisBox_Window.SelectedIndexChanged += new System.EventHandler(this.LisBox_Window_SelectedIndexChanged);
            // 
            // LisBox_Program
            // 
            this.LisBox_Program.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LisBox_Program.FormattingEnabled = true;
            this.LisBox_Program.Location = new System.Drawing.Point(6, 32);
            this.LisBox_Program.Name = "LisBox_Program";
            this.LisBox_Program.Size = new System.Drawing.Size(199, 316);
            this.LisBox_Program.TabIndex = 0;
            this.LisBox_Program.SelectedIndexChanged += new System.EventHandler(this.LisBox_Program_SelectedIndexChanged);
            // 
            // TabPag_ScreenMode
            // 
            this.TabPag_ScreenMode.Location = new System.Drawing.Point(4, 22);
            this.TabPag_ScreenMode.Name = "TabPag_ScreenMode";
            this.TabPag_ScreenMode.Padding = new System.Windows.Forms.Padding(3);
            this.TabPag_ScreenMode.Size = new System.Drawing.Size(425, 362);
            this.TabPag_ScreenMode.TabIndex = 1;
            this.TabPag_ScreenMode.Text = "Screen Mode";
            this.TabPag_ScreenMode.UseVisualStyleBackColor = true;
            // 
            // CheBox_Sound
            // 
            this.CheBox_Sound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheBox_Sound.AutoSize = true;
            this.CheBox_Sound.Location = new System.Drawing.Point(354, 5);
            this.CheBox_Sound.Name = "CheBox_Sound";
            this.CheBox_Sound.Size = new System.Drawing.Size(97, 17);
            this.CheBox_Sound.TabIndex = 1;
            this.CheBox_Sound.Text = "Capture Sound";
            this.CheBox_Sound.UseVisualStyleBackColor = true;
            // 
            // Lab_OnOffKey
            // 
            this.Lab_OnOffKey.AutoSize = true;
            this.Lab_OnOffKey.Location = new System.Drawing.Point(13, 9);
            this.Lab_OnOffKey.Name = "Lab_OnOffKey";
            this.Lab_OnOffKey.Size = new System.Drawing.Size(61, 13);
            this.Lab_OnOffKey.TabIndex = 2;
            this.Lab_OnOffKey.Text = "On/Off Key";
            // 
            // TexBox_OnOffKey
            // 
            this.TexBox_OnOffKey.Location = new System.Drawing.Point(80, 6);
            this.TexBox_OnOffKey.Name = "TexBox_OnOffKey";
            this.TexBox_OnOffKey.Size = new System.Drawing.Size(29, 20);
            this.TexBox_OnOffKey.TabIndex = 3;
            this.TexBox_OnOffKey.TextChanged += new System.EventHandler(this.TexBox_OnOffKey_TextChanged);
            this.TexBox_OnOffKey.Enter += new System.EventHandler(this.TexBox_OnOffKey_Enter);
            this.TexBox_OnOffKey.Leave += new System.EventHandler(this.TexBox_OnOffKey_Leave);
            // 
            // CheBox_Control
            // 
            this.CheBox_Control.AutoSize = true;
            this.CheBox_Control.Location = new System.Drawing.Point(115, 5);
            this.CheBox_Control.Name = "CheBox_Control";
            this.CheBox_Control.Size = new System.Drawing.Size(59, 17);
            this.CheBox_Control.TabIndex = 4;
            this.CheBox_Control.Text = "Control";
            this.CheBox_Control.UseVisualStyleBackColor = true;
            // 
            // CheBox_Shift
            // 
            this.CheBox_Shift.AutoSize = true;
            this.CheBox_Shift.Location = new System.Drawing.Point(171, 5);
            this.CheBox_Shift.Name = "CheBox_Shift";
            this.CheBox_Shift.Size = new System.Drawing.Size(47, 17);
            this.CheBox_Shift.TabIndex = 5;
            this.CheBox_Shift.Text = "Shift";
            this.CheBox_Shift.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CheBox_Alt
            // 
            this.CheBox_Alt.AutoSize = true;
            this.CheBox_Alt.Location = new System.Drawing.Point(224, 5);
            this.CheBox_Alt.Name = "CheBox_Alt";
            this.CheBox_Alt.Size = new System.Drawing.Size(38, 17);
            this.CheBox_Alt.TabIndex = 6;
            this.CheBox_Alt.Text = "Alt";
            this.CheBox_Alt.UseVisualStyleBackColor = true;
            // 
            // CheBox_DoubleKeyProtection
            // 
            this.CheBox_DoubleKeyProtection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheBox_DoubleKeyProtection.AutoSize = true;
            this.CheBox_DoubleKeyProtection.Checked = true;
            this.CheBox_DoubleKeyProtection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheBox_DoubleKeyProtection.Location = new System.Drawing.Point(319, 28);
            this.CheBox_DoubleKeyProtection.Name = "CheBox_DoubleKeyProtection";
            this.CheBox_DoubleKeyProtection.Size = new System.Drawing.Size(132, 17);
            this.CheBox_DoubleKeyProtection.TabIndex = 7;
            this.CheBox_DoubleKeyProtection.Text = "Double Key Protection";
            this.CheBox_DoubleKeyProtection.UseVisualStyleBackColor = true;
            // 
            // WindowCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 435);
            this.Controls.Add(this.CheBox_DoubleKeyProtection);
            this.Controls.Add(this.CheBox_Alt);
            this.Controls.Add(this.CheBox_Shift);
            this.Controls.Add(this.CheBox_Control);
            this.Controls.Add(this.TexBox_OnOffKey);
            this.Controls.Add(this.Lab_OnOffKey);
            this.Controls.Add(this.CheBox_Sound);
            this.Controls.Add(this.TabCon_ModeSelector);
            this.KeyPreview = true;
            this.Name = "WindowCaptureForm";
            this.Text = "Discord Capture Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowCaptureForm_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.WindowCaptureForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.WindowCaptureForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WindowCaptureForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WindowCaptureForm_KeyUp);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.WindowCaptureForm_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowCaptureForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowCaptureForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowCaptureForm_MouseUp);
            this.TabCon_ModeSelector.ResumeLayout(false);
            this.TabPag_WindowedMode.ResumeLayout(false);
            this.TabPag_WindowedMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabCon_ModeSelector;
        private System.Windows.Forms.TabPage TabPag_WindowedMode;
        private System.Windows.Forms.TabPage TabPag_ScreenMode;
        private System.Windows.Forms.CheckBox CheBox_Sound;
        private System.Windows.Forms.Label Lab_OnOffKey;
        private System.Windows.Forms.TextBox TexBox_OnOffKey;
        private System.Windows.Forms.CheckBox CheBox_Control;
        private System.Windows.Forms.CheckBox CheBox_Shift;
        private System.Windows.Forms.Label Lab_WindowName;
        private System.Windows.Forms.Label Lab_ProgramName;
        private System.Windows.Forms.ListBox LisBox_Window;
        private System.Windows.Forms.ListBox LisBox_Program;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox CheBox_Alt;
        private System.Windows.Forms.CheckBox CheBox_DoubleKeyProtection;
    }
}

