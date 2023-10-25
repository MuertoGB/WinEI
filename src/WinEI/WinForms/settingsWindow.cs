// WinEI
// https://github.com/MuertoGB/WinEI

// WinForms
// settingsWindow.cs
// Released under the GNU GLP v3.0

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinEI.UI;
using WinEI.UI.Controls;
using WinEI.WIN32;

namespace WinEI
{
    internal partial class settingsWindow : Form
    {

        #region Private Members
        private Timer _timer;
        private bool _showLabel = true;
        private int _accentInteger = 0;
        #endregion

        #region Overrides Properties
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
        internal settingsWindow()
        {
            InitializeComponent();

            WireAccentCheckChangedEventHandlers();

            Load += settingsWindow_Load;
            KeyDown += aboutWindow_KeyDown;
            pbxLogo.MouseDoubleClick += pbxLogo_MouseDoubleClick;
            pbxLogo.MouseMove += settingsWindow_MouseMove;
            lblTitle.MouseMove += settingsWindow_MouseMove;

            cmdClose.Font = Program.FONT_MDL2_REG_12;
            cmdClose.Text = Chars.EXIT_CROSS;
        }

        private void WireAccentCheckChangedEventHandlers()
        {
            rbnAccent0Default.CheckedChanged += Accent_CheckedChanged;
            rbnAccent1Mint.CheckedChanged += Accent_CheckedChanged;
            rbnAccent2Green.CheckedChanged += Accent_CheckedChanged;
            rbnAccent3Purple.CheckedChanged += Accent_CheckedChanged;
            rbnAccent4Gold.CheckedChanged += Accent_CheckedChanged;
            rbnAccent5Red.CheckedChanged += Accent_CheckedChanged;
            rbnAccent6White.CheckedChanged += Accent_CheckedChanged;
        }
        #endregion

        #region Window Events
        private void settingsWindow_Load(object sender, EventArgs e)
        {
            lblSettingsSaved.Hide();

            UpdateUI();
        }
        #endregion

        #region Mouse Events
        private void settingsWindow_MouseMove(object sender, MouseEventArgs e)
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

        private void cmdReset_Click(object sender, EventArgs e)
        {
            DialogResult result =
                WEIMessageBox.Show(
                this,
                Strings.WARNING,
                Strings.QUESTION_RESET_SETTINGS,
                WEIMessageBoxType.Warning,
                WEIMessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            Settings.Reset();

            Program.mWindow.SetAccentColour();

            UpdateUI();

            ShowSettingsAppliedLabel();
        }

        private void cmdOkay_Click(object sender, EventArgs e)
        {
            _showLabel = false;
            cmdApply.PerformClick();
            Close();
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            Settings.WriteBool(
                SettingsBool.DisableVersionCheck,
                swDisableVersionCheck.Checked);

            Settings.WriteBool(
                SettingsBool.ShowHardware,
                swShowHardware.Checked);

            Settings.WriteInteger(
                SettingsInteger.AccentColor,
                _accentInteger);

            Settings.WriteBool(
                SettingsBool.ApiHardwareMode,
                swApiHardwareMode.Checked);

            string apiKey =
                string.IsNullOrEmpty(tbxImgurApiKey?.Text)
                ? string.Empty
                : tbxImgurApiKey.Text;

            Settings.WriteString(
                SettingsString.ImgurApiKey,
                apiKey);

            Settings.WriteBool(
                SettingsBool.DisableFlashing,
                swDisableFlashingUiElements.Checked);

            Settings.WriteBool(
                SettingsBool.DisableSounds,
                swDisableMessageWindowSounds.Checked);

            Settings.WriteBool(
                SettingsBool.LogImgurUrls,
                swLogImgurUrls.Checked);

            Settings.WriteBool(
                SettingsBool.OpenImgurUrls,
                swOpenImgurUrls.Checked);

            Settings.WriteBool(
                SettingsBool.BypassPowerAdapter,
                swBypassPowerAdapter.Checked);

            Program.mWindow.SetAccentColour();

            if (_showLabel)
                ShowSettingsAppliedLabel();
        }
        #endregion

        #region Label Events
        private void ShowSettingsAppliedLabel()
        {
            lblSettingsSaved.Show();

            if (_timer != null && _timer.Enabled)
            {
                _timer.Stop();
                _timer.Dispose();
            }

            _timer = new Timer
            {
                Interval = 2000
            };

            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblSettingsSaved.Hide();
            _timer.Stop();
            _timer.Dispose();
        }
        #endregion

        #region RadioButton Events
        private void rbnAccent0Default_CheckedChanged(object sender, EventArgs e) =>
            _accentInteger = 0;

        private void rbnAccent1Mint_CheckedChanged(object sender, EventArgs e) =>
            _accentInteger = 1;

        private void rbnAccent2Green_CheckedChanged(object sender, EventArgs e) =>
            _accentInteger = 2;

        private void rbnAccent3Pink_CheckedChanged(object sender, EventArgs e) =>
            _accentInteger = 3;

        private void rbnAccent4Gold_CheckedChanged(object sender, EventArgs e) =>
            _accentInteger = 4;

        private void rbnAccent5Red_CheckedChanged(object sender, EventArgs e) =>
            _accentInteger = 5;

        private void rbnAccent6Orange_CheckedChanged(object sender, EventArgs e) =>
            _accentInteger = 6;
        #endregion

        #region Picturebox Events
        private void pbxLogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                CenterToParent();
        }
        #endregion

        #region UI Events

        private void UpdateUI()
        {
            swDisableVersionCheck.Checked =
                Settings.ReadBool(
                    SettingsBool.DisableVersionCheck);

            swShowHardware.Checked =
                Settings.ReadBool(
                    SettingsBool.ShowHardware);

            int AccentColour =
                Settings.ReadInteger(
                    SettingsInteger.AccentColor);

            switch (AccentColour)
            {
                case 0:
                    rbnAccent0Default.Checked = true;
                    break;
                case 1:
                    rbnAccent1Mint.Checked = true;
                    break;
                case 2:
                    rbnAccent2Green.Checked = true;
                    break;
                case 3:
                    rbnAccent3Purple.Checked = true;
                    break;
                case 4:
                    rbnAccent4Gold.Checked = true;
                    break;
                case 5:
                    rbnAccent5Red.Checked = true;
                    break;
                case 6:
                    rbnAccent6White.Checked = true;
                    break;
                default:
                    rbnAccent0Default.Checked = true;
                    break;
            }

            swApiHardwareMode.Checked =
                Settings.ReadBool(
                    SettingsBool.ApiHardwareMode);

            string apiKey =
                Settings.ReadString(
                    SettingsString.ImgurApiKey);

            tbxImgurApiKey.Text =
                !string.IsNullOrEmpty(apiKey)
                ? apiKey
                : string.Empty;

            swDisableFlashingUiElements.Checked =
                Settings.ReadBool(
                    SettingsBool.DisableFlashing);

            swDisableMessageWindowSounds.Checked =
                Settings.ReadBool(
                    SettingsBool.DisableSounds);

            swLogImgurUrls.Checked =
                Settings.ReadBool(
                    SettingsBool.LogImgurUrls);

            swOpenImgurUrls.Checked =
                Settings.ReadBool(
                    SettingsBool.OpenImgurUrls);

            swBypassPowerAdapter.Checked =
                Settings.ReadBool(
                    SettingsBool.BypassPowerAdapter);
        }

        private void Accent_CheckedChanged(object sender, EventArgs e)
        {
            WEIRadioButton control =
                sender as WEIRadioButton;

            WEISwitch[] switches =
            {
                swDisableVersionCheck,
                swShowHardware,
                swApiHardwareMode,
                swDisableFlashingUiElements,
                swDisableMessageWindowSounds,
                swLogImgurUrls,
                swOpenImgurUrls,
                swBypassPowerAdapter
            };

            foreach (WEISwitch weiSwitch in switches)
                weiSwitch.CheckedColor = control.CheckedColor;

            pnlSplit.BackColor =
                control.CheckedColor;
        }
        #endregion

    }
}