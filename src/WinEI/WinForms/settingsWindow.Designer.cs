namespace WinEI
{
    partial class settingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsWindow));
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSplit = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDisableVersionCheck = new System.Windows.Forms.TableLayoutPanel();
            this.lblDisableVersionCheck = new System.Windows.Forms.Label();
            this.lblStartup = new System.Windows.Forms.Label();
            this.tlpShowHardware = new System.Windows.Forms.TableLayoutPanel();
            this.lblShowHardware = new System.Windows.Forms.Label();
            this.lblApplication = new System.Windows.Forms.Label();
            this.tlpAccentColour = new System.Windows.Forms.TableLayoutPanel();
            this.lblAccentColour = new System.Windows.Forms.Label();
            this.tlpApiHardwareMode = new System.Windows.Forms.TableLayoutPanel();
            this.lblApiHardwareMode = new System.Windows.Forms.Label();
            this.tlpImgurApiKey = new System.Windows.Forms.TableLayoutPanel();
            this.lblImgurApiKey = new System.Windows.Forms.Label();
            this.tbxImgurApiKey = new System.Windows.Forms.TextBox();
            this.tlpDisableFlashingUiElements = new System.Windows.Forms.TableLayoutPanel();
            this.lblDisableFlashingUiElements = new System.Windows.Forms.Label();
            this.tlpDisableMessageWindowSounds = new System.Windows.Forms.TableLayoutPanel();
            this.lblDisableMessageWindowSounds = new System.Windows.Forms.Label();
            this.tlpLogImgurUploads = new System.Windows.Forms.TableLayoutPanel();
            this.lblLogImgurUploads = new System.Windows.Forms.Label();
            this.tlpOpenImgurUrls = new System.Windows.Forms.TableLayoutPanel();
            this.lblOpenImgurUrls = new System.Windows.Forms.Label();
            this.lblOverrides = new System.Windows.Forms.Label();
            this.tlpDisablePowerAdapter = new System.Windows.Forms.TableLayoutPanel();
            this.lblBypassPowerAdapter = new System.Windows.Forms.Label();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdReset = new System.Windows.Forms.Button();
            this.cmdApply = new System.Windows.Forms.Button();
            this.lblSettingsSaved = new System.Windows.Forms.Label();
            this.cmdOkay = new System.Windows.Forms.Button();
            this.swDisableVersionCheck = new WinEI.UI.WEISwitch();
            this.swShowHardware = new WinEI.UI.WEISwitch();
            this.rbnAccent5Red = new WinEI.UI.Controls.WEIRadioButton();
            this.rbnAccent4Gold = new WinEI.UI.Controls.WEIRadioButton();
            this.rbnAccent3Purple = new WinEI.UI.Controls.WEIRadioButton();
            this.rbnAccent2Green = new WinEI.UI.Controls.WEIRadioButton();
            this.rbnAccent0Default = new WinEI.UI.Controls.WEIRadioButton();
            this.rbnAccent1Mint = new WinEI.UI.Controls.WEIRadioButton();
            this.rbnAccent6White = new WinEI.UI.Controls.WEIRadioButton();
            this.swApiHardwareMode = new WinEI.UI.WEISwitch();
            this.swDisableFlashingUiElements = new WinEI.UI.WEISwitch();
            this.swDisableMessageWindowSounds = new WinEI.UI.WEISwitch();
            this.swLogImgurUrls = new WinEI.UI.WEISwitch();
            this.swOpenImgurUrls = new WinEI.UI.WEISwitch();
            this.swBypassPowerAdapter = new WinEI.UI.WEISwitch();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpDisableVersionCheck.SuspendLayout();
            this.tlpShowHardware.SuspendLayout();
            this.tlpAccentColour.SuspendLayout();
            this.tlpApiHardwareMode.SuspendLayout();
            this.tlpImgurApiKey.SuspendLayout();
            this.tlpDisableFlashingUiElements.SuspendLayout();
            this.tlpDisableMessageWindowSounds.SuspendLayout();
            this.tlpLogImgurUploads.SuspendLayout();
            this.tlpOpenImgurUrls.SuspendLayout();
            this.tlpDisablePowerAdapter.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTitle
            // 
            this.tlpTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlpTitle.BackgroundImage = global::WinEI.Properties.Resources.imgSprite;
            this.tlpTitle.ColumnCount = 3;
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTitle.Controls.Add(this.pbxLogo, 0, 0);
            this.tlpTitle.Controls.Add(this.cmdClose, 2, 0);
            this.tlpTitle.Controls.Add(this.lblTitle, 1, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(398, 40);
            this.tlpTitle.TabIndex = 100;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImage = global::WinEI.Properties.Resources.icon24px;
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxLogo.Location = new System.Drawing.Point(8, 8);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(24, 24);
            this.pbxLogo.TabIndex = 100;
            this.pbxLogo.TabStop = false;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmdClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.ForeColor = System.Drawing.Color.White;
            this.cmdClose.Location = new System.Drawing.Point(358, 0);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(0);
            this.cmdClose.MaximumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.MinimumSize = new System.Drawing.Size(40, 40);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Padding = new System.Windows.Forms.Padding(2, 2, 0, 1);
            this.cmdClose.Size = new System.Drawing.Size(40, 40);
            this.cmdClose.TabIndex = 99;
            this.cmdClose.TabStop = false;
            this.cmdClose.Text = "X";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(40, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(318, 40);
            this.lblTitle.TabIndex = 99;
            this.lblTitle.Text = "Settings";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSplit
            // 
            this.pnlSplit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.pnlSplit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSplit.Location = new System.Drawing.Point(1, 41);
            this.pnlSplit.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSplit.Name = "pnlSplit";
            this.pnlSplit.Size = new System.Drawing.Size(398, 2);
            this.pnlSplit.TabIndex = 99;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tlpDisableVersionCheck, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblStartup, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tlpShowHardware, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblApplication, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tlpAccentColour, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.tlpApiHardwareMode, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.tlpImgurApiKey, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.tlpDisableFlashingUiElements, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.tlpDisableMessageWindowSounds, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.tlpLogImgurUploads, 0, 18);
            this.tableLayoutPanel1.Controls.Add(this.tlpOpenImgurUrls, 0, 20);
            this.tableLayoutPanel1.Controls.Add(this.lblOverrides, 0, 22);
            this.tableLayoutPanel1.Controls.Add(this.tlpDisablePowerAdapter, 0, 24);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 26;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(398, 465);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.TabStop = true;
            // 
            // tlpDisableVersionCheck
            // 
            this.tlpDisableVersionCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDisableVersionCheck.ColumnCount = 2;
            this.tlpDisableVersionCheck.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableVersionCheck.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableVersionCheck.Controls.Add(this.lblDisableVersionCheck, 0, 0);
            this.tlpDisableVersionCheck.Controls.Add(this.swDisableVersionCheck, 1, 0);
            this.tlpDisableVersionCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableVersionCheck.Location = new System.Drawing.Point(0, 35);
            this.tlpDisableVersionCheck.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableVersionCheck.Name = "tlpDisableVersionCheck";
            this.tlpDisableVersionCheck.RowCount = 1;
            this.tlpDisableVersionCheck.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableVersionCheck.Size = new System.Drawing.Size(398, 34);
            this.tlpDisableVersionCheck.TabIndex = 0;
            // 
            // lblDisableVersionCheck
            // 
            this.lblDisableVersionCheck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableVersionCheck.AutoSize = true;
            this.lblDisableVersionCheck.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableVersionCheck.ForeColor = System.Drawing.Color.White;
            this.lblDisableVersionCheck.Location = new System.Drawing.Point(2, 7);
            this.lblDisableVersionCheck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableVersionCheck.Name = "lblDisableVersionCheck";
            this.lblDisableVersionCheck.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableVersionCheck.Size = new System.Drawing.Size(162, 20);
            this.lblDisableVersionCheck.TabIndex = 99;
            this.lblDisableVersionCheck.Text = "Disable Version Check";
            // 
            // lblStartup
            // 
            this.lblStartup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblStartup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartup.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblStartup.Location = new System.Drawing.Point(0, 0);
            this.lblStartup.Margin = new System.Windows.Forms.Padding(0);
            this.lblStartup.Name = "lblStartup";
            this.lblStartup.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblStartup.Size = new System.Drawing.Size(398, 34);
            this.lblStartup.TabIndex = 99;
            this.lblStartup.Text = "Startup";
            this.lblStartup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpShowHardware
            // 
            this.tlpShowHardware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpShowHardware.ColumnCount = 2;
            this.tlpShowHardware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShowHardware.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpShowHardware.Controls.Add(this.lblShowHardware, 0, 0);
            this.tlpShowHardware.Controls.Add(this.swShowHardware, 1, 0);
            this.tlpShowHardware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShowHardware.Location = new System.Drawing.Point(0, 70);
            this.tlpShowHardware.Margin = new System.Windows.Forms.Padding(0);
            this.tlpShowHardware.Name = "tlpShowHardware";
            this.tlpShowHardware.RowCount = 1;
            this.tlpShowHardware.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShowHardware.Size = new System.Drawing.Size(398, 34);
            this.tlpShowHardware.TabIndex = 1;
            // 
            // lblShowHardware
            // 
            this.lblShowHardware.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblShowHardware.AutoSize = true;
            this.lblShowHardware.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowHardware.ForeColor = System.Drawing.Color.White;
            this.lblShowHardware.Location = new System.Drawing.Point(2, 7);
            this.lblShowHardware.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShowHardware.Name = "lblShowHardware";
            this.lblShowHardware.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblShowHardware.Size = new System.Drawing.Size(122, 20);
            this.lblShowHardware.TabIndex = 99;
            this.lblShowHardware.Text = "Show Hardware";
            // 
            // lblApplication
            // 
            this.lblApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApplication.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplication.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblApplication.Location = new System.Drawing.Point(0, 105);
            this.lblApplication.Margin = new System.Windows.Forms.Padding(0);
            this.lblApplication.Name = "lblApplication";
            this.lblApplication.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblApplication.Size = new System.Drawing.Size(398, 34);
            this.lblApplication.TabIndex = 99;
            this.lblApplication.Text = "Application";
            this.lblApplication.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpAccentColour
            // 
            this.tlpAccentColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpAccentColour.ColumnCount = 9;
            this.tlpAccentColour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAccentColour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpAccentColour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpAccentColour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpAccentColour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpAccentColour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpAccentColour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpAccentColour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpAccentColour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tlpAccentColour.Controls.Add(this.rbnAccent5Red, 6, 0);
            this.tlpAccentColour.Controls.Add(this.rbnAccent4Gold, 5, 0);
            this.tlpAccentColour.Controls.Add(this.rbnAccent3Purple, 4, 0);
            this.tlpAccentColour.Controls.Add(this.rbnAccent2Green, 3, 0);
            this.tlpAccentColour.Controls.Add(this.lblAccentColour, 0, 0);
            this.tlpAccentColour.Controls.Add(this.rbnAccent0Default, 1, 0);
            this.tlpAccentColour.Controls.Add(this.rbnAccent1Mint, 2, 0);
            this.tlpAccentColour.Controls.Add(this.rbnAccent6White, 7, 0);
            this.tlpAccentColour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAccentColour.Location = new System.Drawing.Point(0, 140);
            this.tlpAccentColour.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAccentColour.Name = "tlpAccentColour";
            this.tlpAccentColour.RowCount = 1;
            this.tlpAccentColour.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAccentColour.Size = new System.Drawing.Size(398, 34);
            this.tlpAccentColour.TabIndex = 2;
            // 
            // lblAccentColour
            // 
            this.lblAccentColour.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAccentColour.AutoSize = true;
            this.lblAccentColour.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccentColour.ForeColor = System.Drawing.Color.White;
            this.lblAccentColour.Location = new System.Drawing.Point(2, 7);
            this.lblAccentColour.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccentColour.Name = "lblAccentColour";
            this.lblAccentColour.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblAccentColour.Size = new System.Drawing.Size(110, 20);
            this.lblAccentColour.TabIndex = 99;
            this.lblAccentColour.Text = "Accent Colour";
            // 
            // tlpApiHardwareMode
            // 
            this.tlpApiHardwareMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpApiHardwareMode.ColumnCount = 2;
            this.tlpApiHardwareMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpApiHardwareMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpApiHardwareMode.Controls.Add(this.lblApiHardwareMode, 0, 0);
            this.tlpApiHardwareMode.Controls.Add(this.swApiHardwareMode, 1, 0);
            this.tlpApiHardwareMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpApiHardwareMode.Location = new System.Drawing.Point(0, 175);
            this.tlpApiHardwareMode.Margin = new System.Windows.Forms.Padding(0);
            this.tlpApiHardwareMode.Name = "tlpApiHardwareMode";
            this.tlpApiHardwareMode.RowCount = 1;
            this.tlpApiHardwareMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpApiHardwareMode.Size = new System.Drawing.Size(398, 34);
            this.tlpApiHardwareMode.TabIndex = 3;
            // 
            // lblApiHardwareMode
            // 
            this.lblApiHardwareMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblApiHardwareMode.AutoSize = true;
            this.lblApiHardwareMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApiHardwareMode.ForeColor = System.Drawing.Color.White;
            this.lblApiHardwareMode.Location = new System.Drawing.Point(2, 7);
            this.lblApiHardwareMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApiHardwareMode.Name = "lblApiHardwareMode";
            this.lblApiHardwareMode.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblApiHardwareMode.Size = new System.Drawing.Size(151, 20);
            this.lblApiHardwareMode.TabIndex = 99;
            this.lblApiHardwareMode.Text = "API Hardware Mode";
            // 
            // tlpImgurApiKey
            // 
            this.tlpImgurApiKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpImgurApiKey.ColumnCount = 2;
            this.tlpImgurApiKey.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImgurApiKey.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tlpImgurApiKey.Controls.Add(this.lblImgurApiKey, 0, 0);
            this.tlpImgurApiKey.Controls.Add(this.tbxImgurApiKey, 1, 0);
            this.tlpImgurApiKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImgurApiKey.Location = new System.Drawing.Point(0, 210);
            this.tlpImgurApiKey.Margin = new System.Windows.Forms.Padding(0);
            this.tlpImgurApiKey.Name = "tlpImgurApiKey";
            this.tlpImgurApiKey.RowCount = 1;
            this.tlpImgurApiKey.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImgurApiKey.Size = new System.Drawing.Size(398, 34);
            this.tlpImgurApiKey.TabIndex = 4;
            // 
            // lblImgurApiKey
            // 
            this.lblImgurApiKey.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImgurApiKey.AutoSize = true;
            this.lblImgurApiKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImgurApiKey.ForeColor = System.Drawing.Color.White;
            this.lblImgurApiKey.Location = new System.Drawing.Point(2, 7);
            this.lblImgurApiKey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImgurApiKey.Name = "lblImgurApiKey";
            this.lblImgurApiKey.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblImgurApiKey.Size = new System.Drawing.Size(164, 20);
            this.lblImgurApiKey.TabIndex = 99;
            this.lblImgurApiKey.Text = "Custom Imgur API Key";
            // 
            // tbxImgurApiKey
            // 
            this.tbxImgurApiKey.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbxImgurApiKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.tbxImgurApiKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxImgurApiKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxImgurApiKey.ForeColor = System.Drawing.Color.White;
            this.tbxImgurApiKey.Location = new System.Drawing.Point(217, 3);
            this.tbxImgurApiKey.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.tbxImgurApiKey.MaxLength = 15;
            this.tbxImgurApiKey.Name = "tbxImgurApiKey";
            this.tbxImgurApiKey.Size = new System.Drawing.Size(171, 27);
            this.tbxImgurApiKey.TabIndex = 0;
            this.tbxImgurApiKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tlpDisableFlashingUiElements
            // 
            this.tlpDisableFlashingUiElements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDisableFlashingUiElements.ColumnCount = 2;
            this.tlpDisableFlashingUiElements.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableFlashingUiElements.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableFlashingUiElements.Controls.Add(this.lblDisableFlashingUiElements, 0, 0);
            this.tlpDisableFlashingUiElements.Controls.Add(this.swDisableFlashingUiElements, 1, 0);
            this.tlpDisableFlashingUiElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableFlashingUiElements.Location = new System.Drawing.Point(0, 245);
            this.tlpDisableFlashingUiElements.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableFlashingUiElements.Name = "tlpDisableFlashingUiElements";
            this.tlpDisableFlashingUiElements.RowCount = 1;
            this.tlpDisableFlashingUiElements.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableFlashingUiElements.Size = new System.Drawing.Size(398, 34);
            this.tlpDisableFlashingUiElements.TabIndex = 5;
            // 
            // lblDisableFlashingUiElements
            // 
            this.lblDisableFlashingUiElements.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableFlashingUiElements.AutoSize = true;
            this.lblDisableFlashingUiElements.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableFlashingUiElements.ForeColor = System.Drawing.Color.White;
            this.lblDisableFlashingUiElements.Location = new System.Drawing.Point(2, 7);
            this.lblDisableFlashingUiElements.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableFlashingUiElements.Name = "lblDisableFlashingUiElements";
            this.lblDisableFlashingUiElements.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableFlashingUiElements.Size = new System.Drawing.Size(207, 20);
            this.lblDisableFlashingUiElements.TabIndex = 99;
            this.lblDisableFlashingUiElements.Text = "Disable Flashing UI Elements";
            // 
            // tlpDisableMessageWindowSounds
            // 
            this.tlpDisableMessageWindowSounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDisableMessageWindowSounds.ColumnCount = 2;
            this.tlpDisableMessageWindowSounds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableMessageWindowSounds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisableMessageWindowSounds.Controls.Add(this.lblDisableMessageWindowSounds, 0, 0);
            this.tlpDisableMessageWindowSounds.Controls.Add(this.swDisableMessageWindowSounds, 1, 0);
            this.tlpDisableMessageWindowSounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisableMessageWindowSounds.Location = new System.Drawing.Point(0, 280);
            this.tlpDisableMessageWindowSounds.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisableMessageWindowSounds.Name = "tlpDisableMessageWindowSounds";
            this.tlpDisableMessageWindowSounds.RowCount = 1;
            this.tlpDisableMessageWindowSounds.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisableMessageWindowSounds.Size = new System.Drawing.Size(398, 34);
            this.tlpDisableMessageWindowSounds.TabIndex = 6;
            // 
            // lblDisableMessageWindowSounds
            // 
            this.lblDisableMessageWindowSounds.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDisableMessageWindowSounds.AutoSize = true;
            this.lblDisableMessageWindowSounds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisableMessageWindowSounds.ForeColor = System.Drawing.Color.White;
            this.lblDisableMessageWindowSounds.Location = new System.Drawing.Point(2, 7);
            this.lblDisableMessageWindowSounds.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisableMessageWindowSounds.Name = "lblDisableMessageWindowSounds";
            this.lblDisableMessageWindowSounds.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblDisableMessageWindowSounds.Size = new System.Drawing.Size(240, 20);
            this.lblDisableMessageWindowSounds.TabIndex = 99;
            this.lblDisableMessageWindowSounds.Text = "Disable Message Window Sounds";
            // 
            // tlpLogImgurUploads
            // 
            this.tlpLogImgurUploads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpLogImgurUploads.ColumnCount = 2;
            this.tlpLogImgurUploads.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLogImgurUploads.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpLogImgurUploads.Controls.Add(this.lblLogImgurUploads, 0, 0);
            this.tlpLogImgurUploads.Controls.Add(this.swLogImgurUrls, 1, 0);
            this.tlpLogImgurUploads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLogImgurUploads.Location = new System.Drawing.Point(0, 315);
            this.tlpLogImgurUploads.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLogImgurUploads.Name = "tlpLogImgurUploads";
            this.tlpLogImgurUploads.RowCount = 1;
            this.tlpLogImgurUploads.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLogImgurUploads.Size = new System.Drawing.Size(398, 34);
            this.tlpLogImgurUploads.TabIndex = 7;
            // 
            // lblLogImgurUploads
            // 
            this.lblLogImgurUploads.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLogImgurUploads.AutoSize = true;
            this.lblLogImgurUploads.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogImgurUploads.ForeColor = System.Drawing.Color.White;
            this.lblLogImgurUploads.Location = new System.Drawing.Point(2, 7);
            this.lblLogImgurUploads.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogImgurUploads.Name = "lblLogImgurUploads";
            this.lblLogImgurUploads.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblLogImgurUploads.Size = new System.Drawing.Size(121, 20);
            this.lblLogImgurUploads.TabIndex = 99;
            this.lblLogImgurUploads.Text = "Log Imgur URLs";
            // 
            // tlpOpenImgurUrls
            // 
            this.tlpOpenImgurUrls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpOpenImgurUrls.ColumnCount = 2;
            this.tlpOpenImgurUrls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOpenImgurUrls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpOpenImgurUrls.Controls.Add(this.lblOpenImgurUrls, 0, 0);
            this.tlpOpenImgurUrls.Controls.Add(this.swOpenImgurUrls, 1, 0);
            this.tlpOpenImgurUrls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOpenImgurUrls.Location = new System.Drawing.Point(0, 350);
            this.tlpOpenImgurUrls.Margin = new System.Windows.Forms.Padding(0);
            this.tlpOpenImgurUrls.Name = "tlpOpenImgurUrls";
            this.tlpOpenImgurUrls.RowCount = 1;
            this.tlpOpenImgurUrls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOpenImgurUrls.Size = new System.Drawing.Size(398, 34);
            this.tlpOpenImgurUrls.TabIndex = 8;
            // 
            // lblOpenImgurUrls
            // 
            this.lblOpenImgurUrls.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOpenImgurUrls.AutoSize = true;
            this.lblOpenImgurUrls.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenImgurUrls.ForeColor = System.Drawing.Color.White;
            this.lblOpenImgurUrls.Location = new System.Drawing.Point(2, 7);
            this.lblOpenImgurUrls.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOpenImgurUrls.Name = "lblOpenImgurUrls";
            this.lblOpenImgurUrls.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblOpenImgurUrls.Size = new System.Drawing.Size(264, 20);
            this.lblOpenImgurUrls.TabIndex = 99;
            this.lblOpenImgurUrls.Text = "Open Imgur URLs in Browser Window";
            // 
            // lblOverrides
            // 
            this.lblOverrides.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblOverrides.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOverrides.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverrides.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(240)))));
            this.lblOverrides.Location = new System.Drawing.Point(0, 385);
            this.lblOverrides.Margin = new System.Windows.Forms.Padding(0);
            this.lblOverrides.Name = "lblOverrides";
            this.lblOverrides.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblOverrides.Size = new System.Drawing.Size(398, 34);
            this.lblOverrides.TabIndex = 99;
            this.lblOverrides.Text = "Overrides";
            this.lblOverrides.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpDisablePowerAdapter
            // 
            this.tlpDisablePowerAdapter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tlpDisablePowerAdapter.ColumnCount = 2;
            this.tlpDisablePowerAdapter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisablePowerAdapter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpDisablePowerAdapter.Controls.Add(this.lblBypassPowerAdapter, 0, 0);
            this.tlpDisablePowerAdapter.Controls.Add(this.swBypassPowerAdapter, 1, 0);
            this.tlpDisablePowerAdapter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisablePowerAdapter.Location = new System.Drawing.Point(0, 420);
            this.tlpDisablePowerAdapter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisablePowerAdapter.Name = "tlpDisablePowerAdapter";
            this.tlpDisablePowerAdapter.RowCount = 1;
            this.tlpDisablePowerAdapter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisablePowerAdapter.Size = new System.Drawing.Size(398, 34);
            this.tlpDisablePowerAdapter.TabIndex = 9;
            // 
            // lblBypassPowerAdapter
            // 
            this.lblBypassPowerAdapter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBypassPowerAdapter.AutoSize = true;
            this.lblBypassPowerAdapter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBypassPowerAdapter.ForeColor = System.Drawing.Color.White;
            this.lblBypassPowerAdapter.Location = new System.Drawing.Point(2, 7);
            this.lblBypassPowerAdapter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBypassPowerAdapter.Name = "lblBypassPowerAdapter";
            this.lblBypassPowerAdapter.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblBypassPowerAdapter.Size = new System.Drawing.Size(252, 20);
            this.lblBypassPowerAdapter.TabIndex = 99;
            this.lblBypassPowerAdapter.Text = "Bypass Power Adapter Enforcement";
            // 
            // tlpButtons
            // 
            this.tlpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tlpButtons.ColumnCount = 4;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpButtons.Controls.Add(this.cmdReset, 0, 0);
            this.tlpButtons.Controls.Add(this.cmdApply, 3, 0);
            this.tlpButtons.Controls.Add(this.lblSettingsSaved, 1, 0);
            this.tlpButtons.Controls.Add(this.cmdOkay, 2, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpButtons.Location = new System.Drawing.Point(1, 508);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(398, 46);
            this.tlpButtons.TabIndex = 1;
            this.tlpButtons.TabStop = true;
            // 
            // cmdReset
            // 
            this.cmdReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.cmdReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdReset.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReset.ForeColor = System.Drawing.Color.White;
            this.cmdReset.Location = new System.Drawing.Point(5, 5);
            this.cmdReset.Margin = new System.Windows.Forms.Padding(1);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(88, 36);
            this.cmdReset.TabIndex = 0;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = false;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // cmdApply
            // 
            this.cmdApply.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.cmdApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdApply.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdApply.ForeColor = System.Drawing.Color.White;
            this.cmdApply.Location = new System.Drawing.Point(305, 5);
            this.cmdApply.Margin = new System.Windows.Forms.Padding(1);
            this.cmdApply.Name = "cmdApply";
            this.cmdApply.Size = new System.Drawing.Size(88, 36);
            this.cmdApply.TabIndex = 2;
            this.cmdApply.Text = "Apply";
            this.cmdApply.UseVisualStyleBackColor = false;
            this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
            // 
            // lblSettingsSaved
            // 
            this.lblSettingsSaved.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSettingsSaved.AutoSize = true;
            this.lblSettingsSaved.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingsSaved.ForeColor = System.Drawing.Color.White;
            this.lblSettingsSaved.Location = new System.Drawing.Point(124, 11);
            this.lblSettingsSaved.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSettingsSaved.Name = "lblSettingsSaved";
            this.lblSettingsSaved.Size = new System.Drawing.Size(61, 23);
            this.lblSettingsSaved.TabIndex = 12;
            this.lblSettingsSaved.Text = "Saved!";
            // 
            // cmdOkay
            // 
            this.cmdOkay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdOkay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdOkay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.cmdOkay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.cmdOkay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdOkay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOkay.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOkay.ForeColor = System.Drawing.Color.White;
            this.cmdOkay.Location = new System.Drawing.Point(214, 5);
            this.cmdOkay.Margin = new System.Windows.Forms.Padding(1);
            this.cmdOkay.Name = "cmdOkay";
            this.cmdOkay.Size = new System.Drawing.Size(85, 36);
            this.cmdOkay.TabIndex = 1;
            this.cmdOkay.Text = "Okay";
            this.cmdOkay.UseVisualStyleBackColor = false;
            this.cmdOkay.Click += new System.EventHandler(this.cmdOkay_Click);
            // 
            // swDisableVersionCheck
            // 
            this.swDisableVersionCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableVersionCheck.BackColor = System.Drawing.Color.Black;
            this.swDisableVersionCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swDisableVersionCheck.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableVersionCheck.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableVersionCheck.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swDisableVersionCheck.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.swDisableVersionCheck.Location = new System.Drawing.Point(355, 8);
            this.swDisableVersionCheck.Name = "swDisableVersionCheck";
            this.swDisableVersionCheck.Size = new System.Drawing.Size(32, 18);
            this.swDisableVersionCheck.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swDisableVersionCheck.TabIndex = 0;
            // 
            // swShowHardware
            // 
            this.swShowHardware.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swShowHardware.BackColor = System.Drawing.Color.Black;
            this.swShowHardware.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swShowHardware.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swShowHardware.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swShowHardware.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swShowHardware.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.swShowHardware.Location = new System.Drawing.Point(355, 8);
            this.swShowHardware.Name = "swShowHardware";
            this.swShowHardware.Size = new System.Drawing.Size(32, 18);
            this.swShowHardware.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swShowHardware.TabIndex = 0;
            // 
            // rbnAccent5Red
            // 
            this.rbnAccent5Red.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbnAccent5Red.BackColor = System.Drawing.Color.Transparent;
            this.rbnAccent5Red.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.rbnAccent5Red.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.rbnAccent5Red.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.rbnAccent5Red.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.rbnAccent5Red.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rbnAccent5Red.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbnAccent5Red.Location = new System.Drawing.Point(337, 7);
            this.rbnAccent5Red.Name = "rbnAccent5Red";
            this.rbnAccent5Red.Size = new System.Drawing.Size(20, 20);
            this.rbnAccent5Red.TabIndex = 5;
            this.rbnAccent5Red.CheckedChanged += new System.EventHandler(this.rbnAccent5Red_CheckedChanged);
            // 
            // rbnAccent4Gold
            // 
            this.rbnAccent4Gold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbnAccent4Gold.BackColor = System.Drawing.Color.Transparent;
            this.rbnAccent4Gold.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.rbnAccent4Gold.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.rbnAccent4Gold.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(75)))));
            this.rbnAccent4Gold.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.rbnAccent4Gold.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rbnAccent4Gold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbnAccent4Gold.Location = new System.Drawing.Point(307, 7);
            this.rbnAccent4Gold.Name = "rbnAccent4Gold";
            this.rbnAccent4Gold.Size = new System.Drawing.Size(20, 20);
            this.rbnAccent4Gold.TabIndex = 4;
            this.rbnAccent4Gold.CheckedChanged += new System.EventHandler(this.rbnAccent4Gold_CheckedChanged);
            // 
            // rbnAccent3Purple
            // 
            this.rbnAccent3Purple.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbnAccent3Purple.BackColor = System.Drawing.Color.Transparent;
            this.rbnAccent3Purple.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.rbnAccent3Purple.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.rbnAccent3Purple.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(40)))), ((int)(((byte)(122)))));
            this.rbnAccent3Purple.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.rbnAccent3Purple.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rbnAccent3Purple.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbnAccent3Purple.Location = new System.Drawing.Point(277, 7);
            this.rbnAccent3Purple.Name = "rbnAccent3Purple";
            this.rbnAccent3Purple.Size = new System.Drawing.Size(20, 20);
            this.rbnAccent3Purple.TabIndex = 3;
            this.rbnAccent3Purple.CheckedChanged += new System.EventHandler(this.rbnAccent3Pink_CheckedChanged);
            // 
            // rbnAccent2Green
            // 
            this.rbnAccent2Green.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbnAccent2Green.BackColor = System.Drawing.Color.Transparent;
            this.rbnAccent2Green.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.rbnAccent2Green.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.rbnAccent2Green.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(220)))), ((int)(((byte)(110)))));
            this.rbnAccent2Green.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.rbnAccent2Green.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rbnAccent2Green.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbnAccent2Green.Location = new System.Drawing.Point(247, 7);
            this.rbnAccent2Green.Name = "rbnAccent2Green";
            this.rbnAccent2Green.Size = new System.Drawing.Size(20, 20);
            this.rbnAccent2Green.TabIndex = 2;
            this.rbnAccent2Green.CheckedChanged += new System.EventHandler(this.rbnAccent2Green_CheckedChanged);
            // 
            // rbnAccent0Default
            // 
            this.rbnAccent0Default.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbnAccent0Default.BackColor = System.Drawing.Color.Transparent;
            this.rbnAccent0Default.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.rbnAccent0Default.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.rbnAccent0Default.Checked = true;
            this.rbnAccent0Default.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.rbnAccent0Default.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.rbnAccent0Default.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rbnAccent0Default.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbnAccent0Default.Location = new System.Drawing.Point(187, 7);
            this.rbnAccent0Default.Name = "rbnAccent0Default";
            this.rbnAccent0Default.Size = new System.Drawing.Size(20, 20);
            this.rbnAccent0Default.TabIndex = 0;
            this.rbnAccent0Default.TabStop = true;
            this.rbnAccent0Default.CheckedChanged += new System.EventHandler(this.rbnAccent0Default_CheckedChanged);
            // 
            // rbnAccent1Mint
            // 
            this.rbnAccent1Mint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbnAccent1Mint.BackColor = System.Drawing.Color.Transparent;
            this.rbnAccent1Mint.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.rbnAccent1Mint.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.rbnAccent1Mint.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(181)))));
            this.rbnAccent1Mint.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.rbnAccent1Mint.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rbnAccent1Mint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbnAccent1Mint.Location = new System.Drawing.Point(217, 7);
            this.rbnAccent1Mint.Name = "rbnAccent1Mint";
            this.rbnAccent1Mint.Size = new System.Drawing.Size(20, 20);
            this.rbnAccent1Mint.TabIndex = 1;
            this.rbnAccent1Mint.CheckedChanged += new System.EventHandler(this.rbnAccent1Mint_CheckedChanged);
            // 
            // rbnAccent6White
            // 
            this.rbnAccent6White.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbnAccent6White.BackColor = System.Drawing.Color.Transparent;
            this.rbnAccent6White.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.rbnAccent6White.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.rbnAccent6White.CheckedColor = System.Drawing.Color.White;
            this.rbnAccent6White.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.rbnAccent6White.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rbnAccent6White.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbnAccent6White.Location = new System.Drawing.Point(367, 7);
            this.rbnAccent6White.Name = "rbnAccent6White";
            this.rbnAccent6White.Size = new System.Drawing.Size(20, 20);
            this.rbnAccent6White.TabIndex = 6;
            this.rbnAccent6White.CheckedChanged += new System.EventHandler(this.rbnAccent6Orange_CheckedChanged);
            // 
            // swApiHardwareMode
            // 
            this.swApiHardwareMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swApiHardwareMode.BackColor = System.Drawing.Color.Black;
            this.swApiHardwareMode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swApiHardwareMode.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swApiHardwareMode.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swApiHardwareMode.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swApiHardwareMode.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.swApiHardwareMode.Location = new System.Drawing.Point(355, 8);
            this.swApiHardwareMode.Name = "swApiHardwareMode";
            this.swApiHardwareMode.Size = new System.Drawing.Size(32, 18);
            this.swApiHardwareMode.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swApiHardwareMode.TabIndex = 0;
            // 
            // swDisableFlashingUiElements
            // 
            this.swDisableFlashingUiElements.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableFlashingUiElements.BackColor = System.Drawing.Color.Black;
            this.swDisableFlashingUiElements.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swDisableFlashingUiElements.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableFlashingUiElements.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableFlashingUiElements.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swDisableFlashingUiElements.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.swDisableFlashingUiElements.Location = new System.Drawing.Point(355, 8);
            this.swDisableFlashingUiElements.Name = "swDisableFlashingUiElements";
            this.swDisableFlashingUiElements.Size = new System.Drawing.Size(32, 18);
            this.swDisableFlashingUiElements.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swDisableFlashingUiElements.TabIndex = 0;
            // 
            // swDisableMessageWindowSounds
            // 
            this.swDisableMessageWindowSounds.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swDisableMessageWindowSounds.BackColor = System.Drawing.Color.Black;
            this.swDisableMessageWindowSounds.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swDisableMessageWindowSounds.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swDisableMessageWindowSounds.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swDisableMessageWindowSounds.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swDisableMessageWindowSounds.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.swDisableMessageWindowSounds.Location = new System.Drawing.Point(355, 8);
            this.swDisableMessageWindowSounds.Name = "swDisableMessageWindowSounds";
            this.swDisableMessageWindowSounds.Size = new System.Drawing.Size(32, 18);
            this.swDisableMessageWindowSounds.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swDisableMessageWindowSounds.TabIndex = 0;
            // 
            // swLogImgurUrls
            // 
            this.swLogImgurUrls.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swLogImgurUrls.BackColor = System.Drawing.Color.Black;
            this.swLogImgurUrls.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swLogImgurUrls.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swLogImgurUrls.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swLogImgurUrls.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swLogImgurUrls.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.swLogImgurUrls.Location = new System.Drawing.Point(355, 8);
            this.swLogImgurUrls.Name = "swLogImgurUrls";
            this.swLogImgurUrls.Size = new System.Drawing.Size(32, 18);
            this.swLogImgurUrls.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swLogImgurUrls.TabIndex = 0;
            // 
            // swOpenImgurUrls
            // 
            this.swOpenImgurUrls.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swOpenImgurUrls.BackColor = System.Drawing.Color.Black;
            this.swOpenImgurUrls.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swOpenImgurUrls.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swOpenImgurUrls.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swOpenImgurUrls.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swOpenImgurUrls.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.swOpenImgurUrls.Location = new System.Drawing.Point(355, 8);
            this.swOpenImgurUrls.Name = "swOpenImgurUrls";
            this.swOpenImgurUrls.Size = new System.Drawing.Size(32, 18);
            this.swOpenImgurUrls.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swOpenImgurUrls.TabIndex = 0;
            // 
            // swBypassPowerAdapter
            // 
            this.swBypassPowerAdapter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swBypassPowerAdapter.BackColor = System.Drawing.Color.Black;
            this.swBypassPowerAdapter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.swBypassPowerAdapter.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.swBypassPowerAdapter.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.swBypassPowerAdapter.ClientColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.swBypassPowerAdapter.ClientColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.swBypassPowerAdapter.Location = new System.Drawing.Point(355, 8);
            this.swBypassPowerAdapter.Name = "swBypassPowerAdapter";
            this.swBypassPowerAdapter.Size = new System.Drawing.Size(32, 18);
            this.swBypassPowerAdapter.SwitchHeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.swBypassPowerAdapter.TabIndex = 0;
            // 
            // settingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(400, 555);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnlSplit);
            this.Controls.Add(this.tlpTitle);
            this.Controls.Add(this.tlpButtons);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 555);
            this.Name = "settingsWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tlpTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpDisableVersionCheck.ResumeLayout(false);
            this.tlpDisableVersionCheck.PerformLayout();
            this.tlpShowHardware.ResumeLayout(false);
            this.tlpShowHardware.PerformLayout();
            this.tlpAccentColour.ResumeLayout(false);
            this.tlpAccentColour.PerformLayout();
            this.tlpApiHardwareMode.ResumeLayout(false);
            this.tlpApiHardwareMode.PerformLayout();
            this.tlpImgurApiKey.ResumeLayout(false);
            this.tlpImgurApiKey.PerformLayout();
            this.tlpDisableFlashingUiElements.ResumeLayout(false);
            this.tlpDisableFlashingUiElements.PerformLayout();
            this.tlpDisableMessageWindowSounds.ResumeLayout(false);
            this.tlpDisableMessageWindowSounds.PerformLayout();
            this.tlpLogImgurUploads.ResumeLayout(false);
            this.tlpLogImgurUploads.PerformLayout();
            this.tlpOpenImgurUrls.ResumeLayout(false);
            this.tlpOpenImgurUrls.PerformLayout();
            this.tlpDisablePowerAdapter.ResumeLayout(false);
            this.tlpDisablePowerAdapter.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.tlpButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        private System.Windows.Forms.PictureBox pbxLogo;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Panel pnlSplit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpDisableVersionCheck;
        private System.Windows.Forms.Label lblDisableVersionCheck;
        private UI.WEISwitch swDisableVersionCheck;
        private System.Windows.Forms.Label lblStartup;
        private System.Windows.Forms.TableLayoutPanel tlpShowHardware;
        private System.Windows.Forms.Label lblShowHardware;
        private UI.WEISwitch swShowHardware;
        private System.Windows.Forms.Label lblApplication;
        private System.Windows.Forms.TableLayoutPanel tlpAccentColour;
        private System.Windows.Forms.Label lblAccentColour;
        private System.Windows.Forms.TableLayoutPanel tlpApiHardwareMode;
        private System.Windows.Forms.Label lblApiHardwareMode;
        private UI.WEISwitch swApiHardwareMode;
        private System.Windows.Forms.TableLayoutPanel tlpImgurApiKey;
        private System.Windows.Forms.Label lblImgurApiKey;
        private System.Windows.Forms.TableLayoutPanel tlpDisableFlashingUiElements;
        private System.Windows.Forms.Label lblDisableFlashingUiElements;
        private UI.WEISwitch swDisableFlashingUiElements;
        private System.Windows.Forms.TableLayoutPanel tlpDisableMessageWindowSounds;
        private System.Windows.Forms.Label lblDisableMessageWindowSounds;
        private UI.WEISwitch swDisableMessageWindowSounds;
        private System.Windows.Forms.TableLayoutPanel tlpLogImgurUploads;
        private System.Windows.Forms.Label lblLogImgurUploads;
        private UI.WEISwitch swLogImgurUrls;
        private System.Windows.Forms.TableLayoutPanel tlpOpenImgurUrls;
        private System.Windows.Forms.Label lblOpenImgurUrls;
        private UI.WEISwitch swOpenImgurUrls;
        private System.Windows.Forms.Label lblOverrides;
        private System.Windows.Forms.TableLayoutPanel tlpDisablePowerAdapter;
        private System.Windows.Forms.Label lblBypassPowerAdapter;
        private UI.WEISwitch swBypassPowerAdapter;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button cmdApply;
        private System.Windows.Forms.Label lblSettingsSaved;
        private System.Windows.Forms.Button cmdOkay;
        private UI.Controls.WEIRadioButton rbnAccent5Red;
        private UI.Controls.WEIRadioButton rbnAccent4Gold;
        private UI.Controls.WEIRadioButton rbnAccent3Purple;
        private UI.Controls.WEIRadioButton rbnAccent2Green;
        private UI.Controls.WEIRadioButton rbnAccent0Default;
        private UI.Controls.WEIRadioButton rbnAccent1Mint;
        private System.Windows.Forms.TextBox tbxImgurApiKey;
        private UI.Controls.WEIRadioButton rbnAccent6White;
    }
}