namespace WinEI
{
    partial class exportWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(exportWindow));
            this.tlpTitle = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSplit = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.cmdExportImage = new System.Windows.Forms.Button();
            this.lblTextExportAsImage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdExportText = new System.Windows.Forms.Button();
            this.tlpTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tlpMain.SuspendLayout();
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
            this.tlpTitle.Size = new System.Drawing.Size(368, 40);
            this.tlpTitle.TabIndex = 101;
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
            this.cmdClose.Location = new System.Drawing.Point(328, 0);
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
            this.lblTitle.Size = new System.Drawing.Size(288, 40);
            this.lblTitle.TabIndex = 99;
            this.lblTitle.Text = "Export";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSplit
            // 
            this.pnlSplit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.pnlSplit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSplit.Location = new System.Drawing.Point(1, 41);
            this.pnlSplit.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSplit.Name = "pnlSplit";
            this.pnlSplit.Size = new System.Drawing.Size(368, 2);
            this.pnlSplit.TabIndex = 102;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMain.Controls.Add(this.cmdExportImage, 2, 0);
            this.tlpMain.Controls.Add(this.lblTextExportAsImage, 0, 0);
            this.tlpMain.Controls.Add(this.label4, 0, 2);
            this.tlpMain.Controls.Add(this.cmdExportText, 2, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(1, 43);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(368, 105);
            this.tlpMain.TabIndex = 0;
            this.tlpMain.TabStop = true;
            // 
            // cmdExportImage
            // 
            this.cmdExportImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.cmdExportImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdExportImage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.cmdExportImage.FlatAppearance.BorderSize = 0;
            this.cmdExportImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExportImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdExportImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExportImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExportImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdExportImage.Location = new System.Drawing.Point(294, 0);
            this.cmdExportImage.Margin = new System.Windows.Forms.Padding(0);
            this.cmdExportImage.Name = "cmdExportImage";
            this.cmdExportImage.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdExportImage.Size = new System.Drawing.Size(74, 52);
            this.cmdExportImage.TabIndex = 0;
            this.cmdExportImage.Text = "...";
            this.cmdExportImage.UseVisualStyleBackColor = false;
            this.cmdExportImage.Click += new System.EventHandler(this.cmdExportImage_Click);
            // 
            // lblTextExportAsImage
            // 
            this.lblTextExportAsImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.lblTextExportAsImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextExportAsImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextExportAsImage.ForeColor = System.Drawing.Color.White;
            this.lblTextExportAsImage.Location = new System.Drawing.Point(0, 0);
            this.lblTextExportAsImage.Margin = new System.Windows.Forms.Padding(0);
            this.lblTextExportAsImage.Name = "lblTextExportAsImage";
            this.lblTextExportAsImage.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.lblTextExportAsImage.Size = new System.Drawing.Size(293, 52);
            this.lblTextExportAsImage.TabIndex = 99;
            this.lblTextExportAsImage.Text = "Export WinEI Printscreen";
            this.lblTextExportAsImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(293, 52);
            this.label4.TabIndex = 99;
            this.label4.Text = "Export WinSAT Information to a Text File";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdExportText
            // 
            this.cmdExportText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.cmdExportText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdExportText.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.cmdExportText.FlatAppearance.BorderSize = 0;
            this.cmdExportText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.cmdExportText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.cmdExportText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExportText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExportText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.cmdExportText.Location = new System.Drawing.Point(294, 53);
            this.cmdExportText.Margin = new System.Windows.Forms.Padding(0);
            this.cmdExportText.Name = "cmdExportText";
            this.cmdExportText.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.cmdExportText.Size = new System.Drawing.Size(74, 52);
            this.cmdExportText.TabIndex = 3;
            this.cmdExportText.Text = "...";
            this.cmdExportText.UseVisualStyleBackColor = false;
            this.cmdExportText.Click += new System.EventHandler(this.cmdExportText_Click);
            // 
            // exportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(370, 149);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlSplit);
            this.Controls.Add(this.tlpTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(370, 149);
            this.Name = "exportWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export";
            this.tlpTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tlpTitle;
        private System.Windows.Forms.PictureBox pbxLogo;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Panel pnlSplit;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblTextExportAsImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdExportImage;
        private System.Windows.Forms.Button cmdExportText;
    }
}