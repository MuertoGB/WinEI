namespace WinEI.WinForms
{
    partial class detailsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(detailsWindow));
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.pnlSplit = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblTextBuggedWinsat = new System.Windows.Forms.Label();
            this.lblTextWinsatDll = new System.Windows.Forms.Label();
            this.lblTextWinsatExe = new System.Windows.Forms.Label();
            this.lblOperatingSystem = new System.Windows.Forms.Label();
            this.lblWinsatExe = new System.Windows.Forms.Label();
            this.lblWinsatDll = new System.Windows.Forms.Label();
            this.lblTextOperatingSystem = new System.Windows.Forms.Label();
            this.tlpMainNestedBuggedWinsat = new System.Windows.Forms.TableLayoutPanel();
            this.cmdSeeDetails = new System.Windows.Forms.Button();
            this.lblBuggedWinsat = new System.Windows.Forms.Label();
            this.lblTextInstallDate = new System.Windows.Forms.Label();
            this.lblInstallDate = new System.Windows.Forms.Label();
            this.lblTextUptime = new System.Windows.Forms.Label();
            this.lblUptime = new System.Windows.Forms.Label();
            this.lblTextCulture = new System.Windows.Forms.Label();
            this.lblCulture = new System.Windows.Forms.Label();
            this.lblTextElevated = new System.Windows.Forms.Label();
            this.lblElevated = new System.Windows.Forms.Label();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.tlpMainNestedBuggedWinsat.SuspendLayout();
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
            this.tlpTitle.Controls.Add(this.lblTitle, 1, 0);
            this.tlpTitle.Controls.Add(this.cmdClose, 2, 0);
            this.tlpTitle.Controls.Add(this.pbxLogo, 0, 0);
            this.tlpTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTitle.Location = new System.Drawing.Point(1, 1);
            this.tlpTitle.Margin = new System.Windows.Forms.Padding(2);
            this.tlpTitle.Name = "tlpTitle";
            this.tlpTitle.RowCount = 1;
            this.tlpTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitle.Size = new System.Drawing.Size(508, 40);
            this.tlpTitle.TabIndex = 99;
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
            this.lblTitle.Size = new System.Drawing.Size(428, 40);
            this.lblTitle.TabIndex = 99;
            this.lblTitle.Text = "System Details";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cmdClose.Location = new System.Drawing.Point(468, 0);
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
            this.pbxLogo.TabIndex = 13;
            this.pbxLogo.TabStop = false;
            // 
            // pnlSplit
            // 
            this.pnlSplit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.pnlSplit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSplit.Location = new System.Drawing.Point(1, 41);
            this.pnlSplit.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSplit.Name = "pnlSplit";
            this.pnlSplit.Size = new System.Drawing.Size(508, 2);
            this.pnlSplit.TabIndex = 99;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblTextBuggedWinsat, 0, 14);
            this.tlpMain.Controls.Add(this.lblTextWinsatDll, 0, 12);
            this.tlpMain.Controls.Add(this.lblTextWinsatExe, 0, 10);
            this.tlpMain.Controls.Add(this.lblOperatingSystem, 2, 0);
            this.tlpMain.Controls.Add(this.lblWinsatExe, 2, 10);
            this.tlpMain.Controls.Add(this.lblWinsatDll, 2, 12);
            this.tlpMain.Controls.Add(this.lblTextOperatingSystem, 0, 0);
            this.tlpMain.Controls.Add(this.tlpMainNestedBuggedWinsat, 2, 14);
            this.tlpMain.Controls.Add(this.lblTextInstallDate, 0, 2);
            this.tlpMain.Controls.Add(this.lblInstallDate, 2, 2);
            this.tlpMain.Controls.Add(this.lblTextUptime, 0, 4);
            this.tlpMain.Controls.Add(this.lblUptime, 2, 4);
            this.tlpMain.Controls.Add(this.lblTextCulture, 0, 8);
            this.tlpMain.Controls.Add(this.lblCulture, 2, 8);
            this.tlpMain.Controls.Add(this.lblTextElevated, 0, 6);
            this.tlpMain.Controls.Add(this.lblElevated, 2, 6);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(1, 43);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 15;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMain.Size = new System.Drawing.Size(508, 295);
            this.tlpMain.TabIndex = 0;
            this.tlpMain.TabStop = true;
            // 
            // lblTextBuggedWinsat
            // 
            this.lblTextBuggedWinsat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblTextBuggedWinsat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextBuggedWinsat.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextBuggedWinsat.ForeColor = System.Drawing.Color.White;
            this.lblTextBuggedWinsat.Location = new System.Drawing.Point(0, 259);
            this.lblTextBuggedWinsat.Margin = new System.Windows.Forms.Padding(0);
            this.lblTextBuggedWinsat.Name = "lblTextBuggedWinsat";
            this.lblTextBuggedWinsat.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblTextBuggedWinsat.Size = new System.Drawing.Size(160, 36);
            this.lblTextBuggedWinsat.TabIndex = 3;
            this.lblTextBuggedWinsat.Text = "Bugged WinSAT";
            this.lblTextBuggedWinsat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextWinsatDll
            // 
            this.lblTextWinsatDll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblTextWinsatDll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextWinsatDll.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextWinsatDll.ForeColor = System.Drawing.Color.White;
            this.lblTextWinsatDll.Location = new System.Drawing.Point(0, 222);
            this.lblTextWinsatDll.Margin = new System.Windows.Forms.Padding(0);
            this.lblTextWinsatDll.Name = "lblTextWinsatDll";
            this.lblTextWinsatDll.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblTextWinsatDll.Size = new System.Drawing.Size(160, 36);
            this.lblTextWinsatDll.TabIndex = 2;
            this.lblTextWinsatDll.Text = "WinSAT API DLL";
            this.lblTextWinsatDll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextWinsatExe
            // 
            this.lblTextWinsatExe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblTextWinsatExe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextWinsatExe.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextWinsatExe.ForeColor = System.Drawing.Color.White;
            this.lblTextWinsatExe.Location = new System.Drawing.Point(0, 185);
            this.lblTextWinsatExe.Margin = new System.Windows.Forms.Padding(0);
            this.lblTextWinsatExe.Name = "lblTextWinsatExe";
            this.lblTextWinsatExe.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblTextWinsatExe.Size = new System.Drawing.Size(160, 36);
            this.lblTextWinsatExe.TabIndex = 1;
            this.lblTextWinsatExe.Text = "WinSAT Executable";
            this.lblTextWinsatExe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOperatingSystem
            // 
            this.lblOperatingSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblOperatingSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOperatingSystem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperatingSystem.ForeColor = System.Drawing.Color.White;
            this.lblOperatingSystem.Location = new System.Drawing.Point(161, 0);
            this.lblOperatingSystem.Margin = new System.Windows.Forms.Padding(0);
            this.lblOperatingSystem.Name = "lblOperatingSystem";
            this.lblOperatingSystem.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblOperatingSystem.Size = new System.Drawing.Size(347, 36);
            this.lblOperatingSystem.TabIndex = 6;
            this.lblOperatingSystem.Text = "...";
            this.lblOperatingSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWinsatExe
            // 
            this.lblWinsatExe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblWinsatExe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWinsatExe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinsatExe.ForeColor = System.Drawing.Color.White;
            this.lblWinsatExe.Location = new System.Drawing.Point(161, 185);
            this.lblWinsatExe.Margin = new System.Windows.Forms.Padding(0);
            this.lblWinsatExe.Name = "lblWinsatExe";
            this.lblWinsatExe.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblWinsatExe.Size = new System.Drawing.Size(347, 36);
            this.lblWinsatExe.TabIndex = 9;
            this.lblWinsatExe.Text = "...";
            this.lblWinsatExe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWinsatDll
            // 
            this.lblWinsatDll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblWinsatDll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWinsatDll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinsatDll.ForeColor = System.Drawing.Color.White;
            this.lblWinsatDll.Location = new System.Drawing.Point(161, 222);
            this.lblWinsatDll.Margin = new System.Windows.Forms.Padding(0);
            this.lblWinsatDll.Name = "lblWinsatDll";
            this.lblWinsatDll.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblWinsatDll.Size = new System.Drawing.Size(347, 36);
            this.lblWinsatDll.TabIndex = 10;
            this.lblWinsatDll.Text = "...";
            this.lblWinsatDll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextOperatingSystem
            // 
            this.lblTextOperatingSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblTextOperatingSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextOperatingSystem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextOperatingSystem.ForeColor = System.Drawing.Color.White;
            this.lblTextOperatingSystem.Location = new System.Drawing.Point(0, 0);
            this.lblTextOperatingSystem.Margin = new System.Windows.Forms.Padding(0);
            this.lblTextOperatingSystem.Name = "lblTextOperatingSystem";
            this.lblTextOperatingSystem.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblTextOperatingSystem.Size = new System.Drawing.Size(160, 36);
            this.lblTextOperatingSystem.TabIndex = 0;
            this.lblTextOperatingSystem.Text = "Operating System";
            this.lblTextOperatingSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpMainNestedBuggedWinsat
            // 
            this.tlpMainNestedBuggedWinsat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tlpMainNestedBuggedWinsat.ColumnCount = 2;
            this.tlpMainNestedBuggedWinsat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpMainNestedBuggedWinsat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpMainNestedBuggedWinsat.Controls.Add(this.cmdSeeDetails, 0, 0);
            this.tlpMainNestedBuggedWinsat.Controls.Add(this.lblBuggedWinsat, 0, 0);
            this.tlpMainNestedBuggedWinsat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainNestedBuggedWinsat.Location = new System.Drawing.Point(161, 259);
            this.tlpMainNestedBuggedWinsat.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMainNestedBuggedWinsat.Name = "tlpMainNestedBuggedWinsat";
            this.tlpMainNestedBuggedWinsat.RowCount = 1;
            this.tlpMainNestedBuggedWinsat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainNestedBuggedWinsat.Size = new System.Drawing.Size(347, 36);
            this.tlpMainNestedBuggedWinsat.TabIndex = 0;
            this.tlpMainNestedBuggedWinsat.TabStop = true;
            // 
            // cmdSeeDetails
            // 
            this.cmdSeeDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.cmdSeeDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdSeeDetails.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdSeeDetails.FlatAppearance.BorderSize = 0;
            this.cmdSeeDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdSeeDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.cmdSeeDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSeeDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSeeDetails.ForeColor = System.Drawing.Color.White;
            this.cmdSeeDetails.Location = new System.Drawing.Point(225, 0);
            this.cmdSeeDetails.Margin = new System.Windows.Forms.Padding(0);
            this.cmdSeeDetails.Name = "cmdSeeDetails";
            this.cmdSeeDetails.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdSeeDetails.Size = new System.Drawing.Size(122, 36);
            this.cmdSeeDetails.TabIndex = 0;
            this.cmdSeeDetails.Text = "SEE DETAILS";
            this.cmdSeeDetails.UseVisualStyleBackColor = false;
            this.cmdSeeDetails.Click += new System.EventHandler(this.cmdSeeDetails_Click);
            // 
            // lblBuggedWinsat
            // 
            this.lblBuggedWinsat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBuggedWinsat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuggedWinsat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuggedWinsat.ForeColor = System.Drawing.Color.White;
            this.lblBuggedWinsat.Location = new System.Drawing.Point(0, 0);
            this.lblBuggedWinsat.Margin = new System.Windows.Forms.Padding(0);
            this.lblBuggedWinsat.Name = "lblBuggedWinsat";
            this.lblBuggedWinsat.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblBuggedWinsat.Size = new System.Drawing.Size(225, 36);
            this.lblBuggedWinsat.TabIndex = 12;
            this.lblBuggedWinsat.Text = "...";
            this.lblBuggedWinsat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextInstallDate
            // 
            this.lblTextInstallDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblTextInstallDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextInstallDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextInstallDate.ForeColor = System.Drawing.Color.White;
            this.lblTextInstallDate.Location = new System.Drawing.Point(0, 37);
            this.lblTextInstallDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblTextInstallDate.Name = "lblTextInstallDate";
            this.lblTextInstallDate.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblTextInstallDate.Size = new System.Drawing.Size(160, 36);
            this.lblTextInstallDate.TabIndex = 4;
            this.lblTextInstallDate.Text = "System Install Date";
            this.lblTextInstallDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInstallDate
            // 
            this.lblInstallDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblInstallDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInstallDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallDate.ForeColor = System.Drawing.Color.White;
            this.lblInstallDate.Location = new System.Drawing.Point(161, 37);
            this.lblInstallDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblInstallDate.Name = "lblInstallDate";
            this.lblInstallDate.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblInstallDate.Size = new System.Drawing.Size(347, 36);
            this.lblInstallDate.TabIndex = 7;
            this.lblInstallDate.Text = "...";
            this.lblInstallDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextUptime
            // 
            this.lblTextUptime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblTextUptime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextUptime.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextUptime.ForeColor = System.Drawing.Color.White;
            this.lblTextUptime.Location = new System.Drawing.Point(0, 74);
            this.lblTextUptime.Margin = new System.Windows.Forms.Padding(0);
            this.lblTextUptime.Name = "lblTextUptime";
            this.lblTextUptime.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblTextUptime.Size = new System.Drawing.Size(160, 36);
            this.lblTextUptime.TabIndex = 5;
            this.lblTextUptime.Text = "System Uptime";
            this.lblTextUptime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUptime
            // 
            this.lblUptime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblUptime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUptime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUptime.ForeColor = System.Drawing.Color.White;
            this.lblUptime.Location = new System.Drawing.Point(161, 74);
            this.lblUptime.Margin = new System.Windows.Forms.Padding(0);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblUptime.Size = new System.Drawing.Size(347, 36);
            this.lblUptime.TabIndex = 8;
            this.lblUptime.Text = "...";
            this.lblUptime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextCulture
            // 
            this.lblTextCulture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblTextCulture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextCulture.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextCulture.ForeColor = System.Drawing.Color.White;
            this.lblTextCulture.Location = new System.Drawing.Point(0, 148);
            this.lblTextCulture.Margin = new System.Windows.Forms.Padding(0);
            this.lblTextCulture.Name = "lblTextCulture";
            this.lblTextCulture.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblTextCulture.Size = new System.Drawing.Size(160, 36);
            this.lblTextCulture.TabIndex = 12;
            this.lblTextCulture.Text = "Culture";
            this.lblTextCulture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCulture
            // 
            this.lblCulture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCulture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCulture.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCulture.ForeColor = System.Drawing.Color.White;
            this.lblCulture.Location = new System.Drawing.Point(161, 148);
            this.lblCulture.Margin = new System.Windows.Forms.Padding(0);
            this.lblCulture.Name = "lblCulture";
            this.lblCulture.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblCulture.Size = new System.Drawing.Size(347, 36);
            this.lblCulture.TabIndex = 13;
            this.lblCulture.Text = "...";
            this.lblCulture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextElevated
            // 
            this.lblTextElevated.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblTextElevated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextElevated.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextElevated.ForeColor = System.Drawing.Color.White;
            this.lblTextElevated.Location = new System.Drawing.Point(0, 111);
            this.lblTextElevated.Margin = new System.Windows.Forms.Padding(0);
            this.lblTextElevated.Name = "lblTextElevated";
            this.lblTextElevated.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblTextElevated.Size = new System.Drawing.Size(160, 36);
            this.lblTextElevated.TabIndex = 99;
            this.lblTextElevated.Text = "Elevated";
            this.lblTextElevated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblElevated
            // 
            this.lblElevated.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblElevated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblElevated.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElevated.ForeColor = System.Drawing.Color.White;
            this.lblElevated.Location = new System.Drawing.Point(161, 111);
            this.lblElevated.Margin = new System.Windows.Forms.Padding(0);
            this.lblElevated.Name = "lblElevated";
            this.lblElevated.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblElevated.Size = new System.Drawing.Size(347, 36);
            this.lblElevated.TabIndex = 15;
            this.lblElevated.Text = "...";
            this.lblElevated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // detailsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(510, 339);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlSplit);
            this.Controls.Add(this.tlpTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(510, 339);
            this.Name = "detailsWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "System Details";
            this.tlpTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.tlpMainNestedBuggedWinsat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Panel pnlSplit;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblTextOperatingSystem;
        private System.Windows.Forms.Label lblTextBuggedWinsat;
        private System.Windows.Forms.Label lblTextWinsatDll;
        private System.Windows.Forms.Label lblTextWinsatExe;
        private System.Windows.Forms.Label lblTextInstallDate;
        private System.Windows.Forms.Label lblTextUptime;
        private System.Windows.Forms.Label lblOperatingSystem;
        private System.Windows.Forms.Label lblInstallDate;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.Label lblWinsatExe;
        private System.Windows.Forms.Label lblWinsatDll;
        private System.Windows.Forms.Label lblTextCulture;
        private System.Windows.Forms.Label lblCulture;
        private System.Windows.Forms.TableLayoutPanel tlpMainNestedBuggedWinsat;
        private System.Windows.Forms.Label lblBuggedWinsat;
        private System.Windows.Forms.Button cmdSeeDetails;
        private System.Windows.Forms.Label lblTextElevated;
        private System.Windows.Forms.Label lblElevated;
    }
}