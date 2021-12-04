namespace QL_Opticals.Presentation.QLControls
{
    partial class CFLControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlCFL = new DevExpress.XtraEditors.PanelControl();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvCFL = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResize = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCFL)).BeginInit();
            this.pnlCFL.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCFL)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCFL
            // 
            this.pnlCFL.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlCFL.Appearance.BackColor2 = System.Drawing.Color.DeepSkyBlue;
            this.pnlCFL.Appearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.pnlCFL.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlCFL.Appearance.Options.UseBackColor = true;
            this.pnlCFL.Appearance.Options.UseBorderColor = true;
            this.pnlCFL.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnlCFL.Controls.Add(this.pnlGrid);
            this.pnlCFL.Controls.Add(this.pnlSearch);
            this.pnlCFL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCFL.Location = new System.Drawing.Point(0, 0);
            this.pnlCFL.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlCFL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlCFL.Name = "pnlCFL";
            this.pnlCFL.Size = new System.Drawing.Size(300, 300);
            this.pnlCFL.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvCFL);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(2, 32);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlGrid.Size = new System.Drawing.Size(296, 266);
            this.pnlGrid.TabIndex = 1;
            // 
            // dgvCFL
            // 
            this.dgvCFL.BackgroundColor = System.Drawing.Color.White;
            this.dgvCFL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCFL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCFL.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCFL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCFL.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dgvCFL.Location = new System.Drawing.Point(10, 5);
            this.dgvCFL.Name = "dgvCFL";
            this.dgvCFL.Size = new System.Drawing.Size(276, 256);
            this.dgvCFL.TabIndex = 2;
            this.dgvCFL.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCFL_CellClick);
            this.dgvCFL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCFL_KeyDown);
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.btnResize);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(2, 2);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlSearch.Size = new System.Drawing.Size(296, 30);
            this.pnlSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(64, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(192, 21);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(256, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = " ";
            // 
            // btnResize
            // 
            this.btnResize.BackgroundImage = global::QL_Opticals.Properties.Resources.Resize;
            this.btnResize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnResize.FlatAppearance.BorderSize = 0;
            this.btnResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResize.Location = new System.Drawing.Point(266, 5);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(20, 20);
            this.btnResize.TabIndex = 4;
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.Black;
            this.lblSearch.Location = new System.Drawing.Point(10, 5);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(54, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search";
            // 
            // CFLControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.ForeColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.pnlCFL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "CFLControl";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CFLControl";
            this.Deactivate += new System.EventHandler(this.CFLControl_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CFLControl_FormClosing);
            this.Load += new System.EventHandler(this.CFLControl_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CFLControl_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCFL)).EndInit();
            this.pnlCFL.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCFL)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlCFL;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvCFL;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}