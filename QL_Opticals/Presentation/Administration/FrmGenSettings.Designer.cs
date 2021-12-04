namespace QL_Opticals.Presentation
{
    partial class FrmGenSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenSettings));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tabcontrolGenSettings = new DevExpress.XtraTab.XtraTabControl();
            this.tabAuthorization = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAuth = new System.Windows.Forms.DataGridView();
            this.colAuthorization = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFormList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpnlAuth = new System.Windows.Forms.TableLayoutPanel();
            this.txtBranch = new DevExpress.XtraEditors.TextEdit();
            this.txtEmpName = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlLineBottom = new DevExpress.XtraEditors.PanelControl();
            this.pnlLineTop = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabcontrolGenSettings)).BeginInit();
            this.tabcontrolGenSettings.SuspendLayout();
            this.tabAuthorization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuth)).BeginInit();
            this.tpnlAuth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            this.pnlAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineTop)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.tabcontrolGenSettings);
            this.panelControl1.Controls.Add(this.pnlAction);
            this.panelControl1.Controls.Add(this.pnlLineBottom);
            this.panelControl1.Controls.Add(this.pnlLineTop);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(422, 460);
            this.panelControl1.TabIndex = 0;
            // 
            // tabcontrolGenSettings
            // 
            this.tabcontrolGenSettings.Appearance.BackColor = System.Drawing.Color.White;
            this.tabcontrolGenSettings.Appearance.Options.UseBackColor = true;
            this.tabcontrolGenSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcontrolGenSettings.Location = new System.Drawing.Point(2, 8);
            this.tabcontrolGenSettings.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.tabcontrolGenSettings.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabcontrolGenSettings.Name = "tabcontrolGenSettings";
            this.tabcontrolGenSettings.SelectedTabPage = this.tabAuthorization;
            this.tabcontrolGenSettings.Size = new System.Drawing.Size(418, 392);
            this.tabcontrolGenSettings.TabIndex = 18;
            this.tabcontrolGenSettings.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabAuthorization});
            // 
            // tabAuthorization
            // 
            this.tabAuthorization.Controls.Add(this.panelControl2);
            this.tabAuthorization.Name = "tabAuthorization";
            this.tabAuthorization.Size = new System.Drawing.Size(414, 366);
            this.tabAuthorization.Text = "Authorization";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(414, 366);
            this.panelControl2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvAuth, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tpnlAuth, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(410, 362);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvAuth
            // 
            this.dgvAuth.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuth.BackgroundColor = System.Drawing.Color.White;
            this.dgvAuth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuth.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAuthorization,
            this.colFormList});
            this.dgvAuth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuth.Location = new System.Drawing.Point(3, 123);
            this.dgvAuth.Name = "dgvAuth";
            this.dgvAuth.Size = new System.Drawing.Size(404, 236);
            this.dgvAuth.TabIndex = 0;
            // 
            // colAuthorization
            // 
            this.colAuthorization.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAuthorization.Frozen = true;
            this.colAuthorization.HeaderText = "Authorization";
            this.colAuthorization.Name = "colAuthorization";
            this.colAuthorization.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAuthorization.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colFormList
            // 
            this.colFormList.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFormList.FillWeight = 150F;
            this.colFormList.HeaderText = "List of Forms";
            this.colFormList.Name = "colFormList";
            // 
            // tpnlAuth
            // 
            this.tpnlAuth.BackColor = System.Drawing.Color.White;
            this.tpnlAuth.ColumnCount = 2;
            this.tpnlAuth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnlAuth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnlAuth.Controls.Add(this.txtBranch, 1, 2);
            this.tpnlAuth.Controls.Add(this.txtEmpName, 1, 1);
            this.tpnlAuth.Controls.Add(this.txtUserName, 1, 0);
            this.tpnlAuth.Controls.Add(this.lblUserName, 0, 0);
            this.tpnlAuth.Controls.Add(this.lblEmpName, 0, 1);
            this.tpnlAuth.Controls.Add(this.lblBranch, 0, 2);
            this.tpnlAuth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnlAuth.Location = new System.Drawing.Point(3, 3);
            this.tpnlAuth.Name = "tpnlAuth";
            this.tpnlAuth.RowCount = 3;
            this.tpnlAuth.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnlAuth.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpnlAuth.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tpnlAuth.Size = new System.Drawing.Size(404, 114);
            this.tpnlAuth.TabIndex = 1;
            // 
            // txtBranch
            // 
            this.txtBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBranch.Location = new System.Drawing.Point(206, 81);
            this.txtBranch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Properties.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.txtBranch.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.txtBranch.Properties.Appearance.Options.UseBorderColor = true;
            this.txtBranch.Properties.Appearance.Options.UseFont = true;
            this.txtBranch.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtBranch.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtBranch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtBranch.Size = new System.Drawing.Size(194, 20);
            this.txtBranch.TabIndex = 27;
            // 
            // txtEmpName
            // 
            this.txtEmpName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmpName.Location = new System.Drawing.Point(206, 42);
            this.txtEmpName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Properties.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.txtEmpName.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.txtEmpName.Properties.Appearance.Options.UseBorderColor = true;
            this.txtEmpName.Properties.Appearance.Options.UseFont = true;
            this.txtEmpName.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtEmpName.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtEmpName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtEmpName.Size = new System.Drawing.Size(194, 20);
            this.txtEmpName.TabIndex = 26;
            // 
            // txtUserName
            // 
            this.txtUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserName.Location = new System.Drawing.Point(206, 3);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.txtUserName.Properties.Appearance.Options.UseBorderColor = true;
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtUserName.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtUserName.Size = new System.Drawing.Size(194, 20);
            this.txtUserName.TabIndex = 25;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUserName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.lblUserName.Location = new System.Drawing.Point(4, 0);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(194, 14);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "User Name";
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmpName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.lblEmpName.Location = new System.Drawing.Point(4, 39);
            this.lblEmpName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(194, 14);
            this.lblEmpName.TabIndex = 4;
            this.lblEmpName.Text = "Employee Name";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.BackColor = System.Drawing.Color.Transparent;
            this.lblBranch.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBranch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.lblBranch.Location = new System.Drawing.Point(4, 78);
            this.lblBranch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(194, 14);
            this.lblBranch.TabIndex = 5;
            this.lblBranch.Text = "Branch";
            // 
            // pnlAction
            // 
            this.pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.pnlAction.Controls.Add(this.btnCancel);
            this.pnlAction.Controls.Add(this.label12);
            this.pnlAction.Controls.Add(this.btnSave);
            this.pnlAction.Controls.Add(this.label13);
            this.pnlAction.Controls.Add(this.label14);
            this.pnlAction.Controls.Add(this.label15);
            this.pnlAction.Controls.Add(this.label11);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Location = new System.Drawing.Point(2, 400);
            this.pnlAction.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Padding = new System.Windows.Forms.Padding(9, 5, 7, 8);
            this.pnlAction.Size = new System.Drawing.Size(418, 52);
            this.pnlAction.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.White;
            this.btnCancel.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(200, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(171, 39);
            this.btnCancel.TabIndex = 57;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Location = new System.Drawing.Point(190, 5);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 13);
            this.label12.TabIndex = 56;
            this.label12.Text = " ";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.White;
            this.btnSave.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(19, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(171, 39);
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Save";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Right;
            this.label13.Location = new System.Drawing.Point(381, 5);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = " ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Right;
            this.label14.Location = new System.Drawing.Point(391, 5);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(10, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = " ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Right;
            this.label15.Location = new System.Drawing.Point(401, 5);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = " ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Location = new System.Drawing.Point(9, 5);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = " ";
            // 
            // pnlLineBottom
            // 
            this.pnlLineBottom.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlLineBottom.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLineBottom.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlLineBottom.Appearance.Options.UseBackColor = true;
            this.pnlLineBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLineBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLineBottom.Location = new System.Drawing.Point(2, 452);
            this.pnlLineBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlLineBottom.Name = "pnlLineBottom";
            this.pnlLineBottom.Size = new System.Drawing.Size(418, 6);
            this.pnlLineBottom.TabIndex = 16;
            // 
            // pnlLineTop
            // 
            this.pnlLineTop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlLineTop.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLineTop.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlLineTop.Appearance.Options.UseBackColor = true;
            this.pnlLineTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLineTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLineTop.Location = new System.Drawing.Point(2, 2);
            this.pnlLineTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlLineTop.Name = "pnlLineTop";
            this.pnlLineTop.Size = new System.Drawing.Size(418, 6);
            this.pnlLineTop.TabIndex = 1;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(759, 364);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // FrmGenSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(422, 460);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.Name = "FrmGenSettings";
            this.Text = "General Settings";
            this.Load += new System.EventHandler(this.FrmGenSettings_Load);
            this.Enter += new System.EventHandler(this.FrmGenSettings_Enter);
            this.Resize += new System.EventHandler(this.FrmGenSettings_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabcontrolGenSettings)).EndInit();
            this.tabcontrolGenSettings.ResumeLayout(false);
            this.tabAuthorization.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuth)).EndInit();
            this.tpnlAuth.ResumeLayout(false);
            this.tpnlAuth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            this.pnlAction.ResumeLayout(false);
            this.pnlAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl pnlLineTop;
        private DevExpress.XtraEditors.PanelControl pnlLineBottom;
        private System.Windows.Forms.Panel pnlAction;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraTab.XtraTabControl tabcontrolGenSettings;
        private DevExpress.XtraTab.XtraTabPage tabAuthorization;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tpnlAuth;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Label lblBranch;
        private DevExpress.XtraEditors.TextEdit txtBranch;
        private DevExpress.XtraEditors.TextEdit txtEmpName;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private System.Windows.Forms.DataGridView dgvAuth;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAuthorization;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormList;
    }
}