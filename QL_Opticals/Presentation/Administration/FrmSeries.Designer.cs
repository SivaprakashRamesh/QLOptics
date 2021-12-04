namespace QL_Opticals.Presentation.Administration
{
    partial class FrmSeries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeries));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlLineTop = new DevExpress.XtraEditors.PanelControl();
            this.pnlLineBottom = new DevExpress.XtraEditors.PanelControl();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblemptyAction5 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblemptyAction4 = new System.Windows.Forms.Label();
            this.lblemptyAction3 = new System.Windows.Forms.Label();
            this.lblemptyAction1 = new System.Windows.Forms.Label();
            this.lblemptyAction2 = new System.Windows.Forms.Label();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.dgvSeries = new System.Windows.Forms.DataGridView();
            this.btnDefault = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineBottom)).BeginInit();
            this.pnlAction.SuspendLayout();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlFill);
            this.pnlMain.Controls.Add(this.pnlAction);
            this.pnlMain.Controls.Add(this.pnlLineBottom);
            this.pnlMain.Controls.Add(this.pnlLineTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(784, 361);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlLineTop
            // 
            this.pnlLineTop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlLineTop.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLineTop.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlLineTop.Appearance.Options.UseBackColor = true;
            this.pnlLineTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLineTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLineTop.Location = new System.Drawing.Point(0, 0);
            this.pnlLineTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlLineTop.Name = "pnlLineTop";
            this.pnlLineTop.Size = new System.Drawing.Size(784, 6);
            this.pnlLineTop.TabIndex = 1;
            // 
            // pnlLineBottom
            // 
            this.pnlLineBottom.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlLineBottom.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLineBottom.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlLineBottom.Appearance.Options.UseBackColor = true;
            this.pnlLineBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLineBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLineBottom.Location = new System.Drawing.Point(0, 355);
            this.pnlLineBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlLineBottom.Name = "pnlLineBottom";
            this.pnlLineBottom.Size = new System.Drawing.Size(784, 6);
            this.pnlLineBottom.TabIndex = 16;
            // 
            // pnlAction
            // 
            this.pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.pnlAction.Controls.Add(this.btnDefault);
            this.pnlAction.Controls.Add(this.btnCancel);
            this.pnlAction.Controls.Add(this.lblemptyAction5);
            this.pnlAction.Controls.Add(this.btnSave);
            this.pnlAction.Controls.Add(this.lblemptyAction4);
            this.pnlAction.Controls.Add(this.lblemptyAction3);
            this.pnlAction.Controls.Add(this.lblemptyAction1);
            this.pnlAction.Controls.Add(this.lblemptyAction2);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Location = new System.Drawing.Point(0, 303);
            this.pnlAction.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Padding = new System.Windows.Forms.Padding(9, 5, 7, 8);
            this.pnlAction.Size = new System.Drawing.Size(784, 52);
            this.pnlAction.TabIndex = 201;
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
            // 
            // lblemptyAction5
            // 
            this.lblemptyAction5.AutoSize = true;
            this.lblemptyAction5.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblemptyAction5.Location = new System.Drawing.Point(190, 5);
            this.lblemptyAction5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblemptyAction5.Name = "lblemptyAction5";
            this.lblemptyAction5.Size = new System.Drawing.Size(10, 13);
            this.lblemptyAction5.TabIndex = 56;
            this.lblemptyAction5.Text = " ";
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
            // lblemptyAction4
            // 
            this.lblemptyAction4.AutoSize = true;
            this.lblemptyAction4.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblemptyAction4.Location = new System.Drawing.Point(747, 5);
            this.lblemptyAction4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblemptyAction4.Name = "lblemptyAction4";
            this.lblemptyAction4.Size = new System.Drawing.Size(10, 13);
            this.lblemptyAction4.TabIndex = 22;
            this.lblemptyAction4.Text = " ";
            // 
            // lblemptyAction3
            // 
            this.lblemptyAction3.AutoSize = true;
            this.lblemptyAction3.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblemptyAction3.Location = new System.Drawing.Point(757, 5);
            this.lblemptyAction3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblemptyAction3.Name = "lblemptyAction3";
            this.lblemptyAction3.Size = new System.Drawing.Size(10, 13);
            this.lblemptyAction3.TabIndex = 20;
            this.lblemptyAction3.Text = " ";
            // 
            // lblemptyAction1
            // 
            this.lblemptyAction1.AutoSize = true;
            this.lblemptyAction1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblemptyAction1.Location = new System.Drawing.Point(767, 5);
            this.lblemptyAction1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblemptyAction1.Name = "lblemptyAction1";
            this.lblemptyAction1.Size = new System.Drawing.Size(10, 13);
            this.lblemptyAction1.TabIndex = 18;
            this.lblemptyAction1.Text = " ";
            // 
            // lblemptyAction2
            // 
            this.lblemptyAction2.AutoSize = true;
            this.lblemptyAction2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblemptyAction2.Location = new System.Drawing.Point(9, 5);
            this.lblemptyAction2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblemptyAction2.Name = "lblemptyAction2";
            this.lblemptyAction2.Size = new System.Drawing.Size(10, 13);
            this.lblemptyAction2.TabIndex = 10;
            this.lblemptyAction2.Text = " ";
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.dgvSeries);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 6);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(784, 297);
            this.pnlFill.TabIndex = 203;
            // 
            // dgvSeries
            // 
            this.dgvSeries.BackgroundColor = System.Drawing.Color.White;
            this.dgvSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSeries.Location = new System.Drawing.Point(0, 0);
            this.dgvSeries.Name = "dgvSeries";
            this.dgvSeries.Size = new System.Drawing.Size(784, 297);
            this.dgvSeries.TabIndex = 0;
            // 
            // btnDefault
            // 
            this.btnDefault.Appearance.BackColor = System.Drawing.Color.White;
            this.btnDefault.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDefault.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.btnDefault.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDefault.Appearance.Options.UseBackColor = true;
            this.btnDefault.Appearance.Options.UseFont = true;
            this.btnDefault.Appearance.Options.UseForeColor = true;
            this.btnDefault.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnDefault.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDefault.Image = ((System.Drawing.Image)(resources.GetObject("btnDefault.Image")));
            this.btnDefault.Location = new System.Drawing.Point(576, 5);
            this.btnDefault.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(171, 39);
            this.btnDefault.TabIndex = 58;
            this.btnDefault.Text = "Cancel";
            // 
            // FrmSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.pnlMain);
            this.Name = "FrmSeries";
            this.Text = "FrmSeries";
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineBottom)).EndInit();
            this.pnlAction.ResumeLayout(false);
            this.pnlAction.PerformLayout();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private DevExpress.XtraEditors.PanelControl pnlLineTop;
        private DevExpress.XtraEditors.PanelControl pnlLineBottom;
        private System.Windows.Forms.Panel pnlAction;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label lblemptyAction5;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label lblemptyAction4;
        private System.Windows.Forms.Label lblemptyAction3;
        private System.Windows.Forms.Label lblemptyAction1;
        private System.Windows.Forms.Label lblemptyAction2;
        private System.Windows.Forms.Panel pnlFill;
        private System.Windows.Forms.DataGridView dgvSeries;
        private DevExpress.XtraEditors.SimpleButton btnDefault;
    }
}