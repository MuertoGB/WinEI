﻿// WinEI
// https://github.com/MuertoGB/WinEI

// WinForms
// aboutWindow.cs
// Released under the GNU GLP v3.0

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinEI.WIN32;

namespace WinEI
{
    public partial class aboutWindow : Form
    {

        #region Overriden Properties
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;

                Params.ClassStyle = Params.ClassStyle
                    | Program.CS_DBLCLKS
                    | Program.CS_DROP;

                return Params;
            }
        }
        #endregion

        #region Constructor
        public aboutWindow()
        {
            InitializeComponent();

            Load += aboutWindow_Load;
            KeyDown += aboutWindow_KeyDown;

            pbxLogo.MouseMove += aboutWindow_MouseMove;
            pbxLogo.MouseDoubleClick += pbxLogo_MouseDoubleClick;
            lblTitle.MouseMove += aboutWindow_MouseMove;

            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Chars.EXIT_CROSS;
        }
        #endregion

        #region Window Events
        private void aboutWindow_Load(object sender, EventArgs e)
        {
            lblBuild.Text =
                $"{Application.ProductVersion}.{WEIVersion.Build}";

            lblChannel.Text =
                WEIVersion.Channel.ToUpper();
        }
        #endregion

        #region Mouse Events
        private void aboutWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture(
                    new HandleRef(this, Handle));

                NativeMethods.SendMessage(
                    new HandleRef(this, Handle),
                    Program.WM_NCLBUTTONDOWN,
                    (IntPtr)Program.HT_CAPTION,
                    (IntPtr)0);
            }
        }
        #endregion

        #region KeyDown Events
        private void aboutWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        #endregion

        #region Button Events
        private void cmdClose_Click(object sender, EventArgs e) =>
            Close();

        private void cmdEmail_Click(object sender, EventArgs e) =>
            Process.Start(
                "mailto:muertogb@proton.me");

        private void cmdSource_Click(object sender, EventArgs e) =>
            Process.Start(
                "https://github.com/MuertoGB/WinEI");

        private void cmdIssues_Click(object sender, EventArgs e) =>
            Process.Start(
                "https://github.com/MuertoGB/WinEI/issues");

        private void cmdDonate_Click(object sender, EventArgs e) =>
            Process.Start(
                "https://www.paypal.com/donate/?hosted_button_id=Z88F3UEZB47SQ");
        #endregion

        #region Picturebox Events
        private void pbxLogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                CenterToParent();
        }
        #endregion

    }
}