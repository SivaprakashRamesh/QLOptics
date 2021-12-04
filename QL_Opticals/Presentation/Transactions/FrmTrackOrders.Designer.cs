namespace QL_Opticals.Presentation.Transactions
{
    partial class FrmTrackOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrackOrders));
            this.pnlTrackOrders = new DevExpress.XtraEditors.PanelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnsearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtCustomerCode = new DevExpress.XtraEditors.TextEdit();
            this.dateOrderDate = new DevExpress.XtraEditors.DateEdit();
            this.dateDeliveryDate = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblemptyAction5 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblemptyAction4 = new System.Windows.Forms.Label();
            this.lblemptyAction3 = new System.Windows.Forms.Label();
            this.lblemptyAction1 = new System.Windows.Forms.Label();
            this.lblemptyAction2 = new System.Windows.Forms.Label();
            this.pnlLineBottom = new DevExpress.XtraEditors.PanelControl();
            this.pnlLineTop = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTrackOrders)).BeginInit();
            this.pnlTrackOrders.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOrderDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDeliveryDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDeliveryDate.Properties)).BeginInit();
            this.pnlAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineTop)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTrackOrders
            // 
            this.pnlTrackOrders.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlTrackOrders.Appearance.Options.UseBackColor = true;
            this.pnlTrackOrders.Controls.Add(this.panel2);
            this.pnlTrackOrders.Controls.Add(this.panel1);
            this.pnlTrackOrders.Controls.Add(this.pnlAction);
            this.pnlTrackOrders.Controls.Add(this.pnlLineBottom);
            this.pnlTrackOrders.Controls.Add(this.pnlLineTop);
            this.pnlTrackOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTrackOrders.Location = new System.Drawing.Point(0, 0);
            this.pnlTrackOrders.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlTrackOrders.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlTrackOrders.Name = "pnlTrackOrders";
            this.pnlTrackOrders.Size = new System.Drawing.Size(841, 414);
            this.pnlTrackOrders.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(835, 244);
            this.panel2.TabIndex = 30;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(835, 231);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listing";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 100);
            this.panel1.TabIndex = 29;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnsearch);
            this.panel3.Controls.Add(this.txtCustomerCode);
            this.panel3.Controls.Add(this.dateOrderDate);
            this.panel3.Controls.Add(this.dateDeliveryDate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(835, 25);
            this.panel3.TabIndex = 1;
            // 
            // btnsearch
            // 
            this.btnsearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnsearch.Location = new System.Drawing.Point(739, 0);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(96, 25);
            this.btnsearch.TabIndex = 37;
            this.btnsearch.Text = "Search";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCustomerCode.Location = new System.Drawing.Point(371, 0);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Properties.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.txtCustomerCode.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.txtCustomerCode.Properties.Appearance.Options.UseBorderColor = true;
            this.txtCustomerCode.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerCode.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtCustomerCode.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtCustomerCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtCustomerCode.Size = new System.Drawing.Size(331, 20);
            this.txtCustomerCode.TabIndex = 36;
            // 
            // dateOrderDate
            // 
            this.dateOrderDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateOrderDate.EditValue = null;
            this.dateOrderDate.Location = new System.Drawing.Point(190, 0);
            this.dateOrderDate.Name = "dateOrderDate";
            this.dateOrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateOrderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateOrderDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.dateOrderDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.dateOrderDate.Size = new System.Drawing.Size(181, 20);
            this.dateOrderDate.TabIndex = 35;
            // 
            // dateDeliveryDate
            // 
            this.dateDeliveryDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateDeliveryDate.EditValue = null;
            this.dateDeliveryDate.Location = new System.Drawing.Point(0, 0);
            this.dateDeliveryDate.Name = "dateDeliveryDate";
            this.dateDeliveryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDeliveryDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDeliveryDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.dateDeliveryDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.dateDeliveryDate.Size = new System.Drawing.Size(190, 20);
            this.dateDeliveryDate.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search";
            // 
            // pnlAction
            // 
            this.pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.pnlAction.Controls.Add(this.btnCancel);
            this.pnlAction.Controls.Add(this.lblemptyAction5);
            this.pnlAction.Controls.Add(this.btnSave);
            this.pnlAction.Controls.Add(this.lblemptyAction4);
            this.pnlAction.Controls.Add(this.lblemptyAction3);
            this.pnlAction.Controls.Add(this.lblemptyAction1);
            this.pnlAction.Controls.Add(this.lblemptyAction2);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Location = new System.Drawing.Point(3, 353);
            this.pnlAction.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Padding = new System.Windows.Forms.Padding(9, 5, 7, 8);
            this.pnlAction.Size = new System.Drawing.Size(835, 52);
            this.pnlAction.TabIndex = 28;
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
            this.lblemptyAction4.Location = new System.Drawing.Point(798, 5);
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
            this.lblemptyAction3.Location = new System.Drawing.Point(808, 5);
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
            this.lblemptyAction1.Location = new System.Drawing.Point(818, 5);
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
            // pnlLineBottom
            // 
            this.pnlLineBottom.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlLineBottom.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLineBottom.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlLineBottom.Appearance.Options.UseBackColor = true;
            this.pnlLineBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLineBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLineBottom.Location = new System.Drawing.Point(3, 405);
            this.pnlLineBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlLineBottom.Name = "pnlLineBottom";
            this.pnlLineBottom.Size = new System.Drawing.Size(835, 6);
            this.pnlLineBottom.TabIndex = 27;
            // 
            // pnlLineTop
            // 
            this.pnlLineTop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlLineTop.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLineTop.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlLineTop.Appearance.Options.UseBackColor = true;
            this.pnlLineTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLineTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLineTop.Location = new System.Drawing.Point(3, 3);
            this.pnlLineTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlLineTop.Name = "pnlLineTop";
            this.pnlLineTop.Size = new System.Drawing.Size(835, 6);
            this.pnlLineTop.TabIndex = 25;
            // 
            // FrmTrackOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 414);
            this.Controls.Add(this.pnlTrackOrders);
            this.Name = "FrmTrackOrders";
            this.Text = "Track Orders";
            ((System.ComponentModel.ISupportInitialize)(this.pnlTrackOrders)).EndInit();
            this.pnlTrackOrders.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOrderDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateOrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDeliveryDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDeliveryDate.Properties)).EndInit();
            this.pnlAction.ResumeLayout(false);
            this.pnlAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLineTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTrackOrders;
        private DevExpress.XtraEditors.PanelControl pnlLineTop;
        private System.Windows.Forms.Panel pnlAction;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label lblemptyAction5;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label lblemptyAction4;
        private System.Windows.Forms.Label lblemptyAction3;
        private System.Windows.Forms.Label lblemptyAction1;
        private System.Windows.Forms.Label lblemptyAction2;
        private DevExpress.XtraEditors.PanelControl pnlLineBottom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit dateDeliveryDate;
        private DevExpress.XtraEditors.DateEdit dateOrderDate;
        private DevExpress.XtraEditors.SimpleButton btnsearch;
        private DevExpress.XtraEditors.TextEdit txtCustomerCode;
    }
}