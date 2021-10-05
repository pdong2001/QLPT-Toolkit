
namespace QLPT_Toolkit
{
    partial class FindAddressID
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuBar1 = new DevComponents.DotNetBar.ContextMenuBar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.biTools_FindAddressID = new DevComponents.DotNetBar.ButtonItem();
            this.btnISetting = new DevComponents.DotNetBar.ButtonItem();
            this.pnlMain = new DevComponents.DotNetBar.PanelEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.dgvAddress = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.lblAddressColumnCount = new DevComponents.DotNetBar.LabelX();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.ckbColorErrorsCell = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbxColumsNumberOnly = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbxDetectColumns = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.pnlErrorsNotice = new System.Windows.Forms.Panel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtFileName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnFindAddressIDCheck = new DevComponents.DotNetBar.ButtonX();
            this.btnExportToExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnFileBrowse = new DevComponents.DotNetBar.ButtonX();
            this.timerErrors = new System.Windows.Forms.Timer(this.components);
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.processTimer = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddress)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.pnlErrorsNotice.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuBar1
            // 
            this.contextMenuBar1.AntiAlias = true;
            this.contextMenuBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.contextMenuBar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuBar1.IsMaximized = false;
            this.contextMenuBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.btnISetting});
            this.contextMenuBar1.Location = new System.Drawing.Point(0, 0);
            this.contextMenuBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.contextMenuBar1.Name = "contextMenuBar1";
            this.contextMenuBar1.Size = new System.Drawing.Size(1495, 29);
            this.contextMenuBar1.Stretch = true;
            this.contextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.contextMenuBar1.TabIndex = 0;
            this.contextMenuBar1.TabStop = false;
            this.contextMenuBar1.Text = "contextMenuBar1";
            this.contextMenuBar1.ItemClick += new System.EventHandler(this.contextMenuBar1_ItemClick);
            // 
            // buttonItem1
            // 
            this.buttonItem1.AutoExpandOnClick = true;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biTools_FindAddressID});
            this.buttonItem1.Text = "Chức năng";
            // 
            // biTools_FindAddressID
            // 
            this.biTools_FindAddressID.Name = "biTools_FindAddressID";
            this.biTools_FindAddressID.Text = "Tìm mã địa chỉ";
            // 
            // btnISetting
            // 
            this.btnISetting.AutoExpandOnClick = true;
            this.btnISetting.Name = "btnISetting";
            this.btnISetting.Text = "Cài đặt";
            // 
            // pnlMain
            // 
            this.pnlMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlMain.Controls.Add(this.panelEx2);
            this.pnlMain.Controls.Add(this.panelEx1);
            this.pnlMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 29);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1495, 606);
            this.pnlMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlMain.Style.GradientAngle = 90;
            this.pnlMain.TabIndex = 5;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.dgvAddress);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 116);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1495, 490);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 4;
            this.panelEx2.Text = "panelEx2";
            // 
            // dgvAddress
            // 
            this.dgvAddress.AllowUserToAddRows = false;
            this.dgvAddress.AllowUserToDeleteRows = false;
            this.dgvAddress.AllowUserToResizeRows = false;
            this.dgvAddress.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAddress.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAddress.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvAddress.Location = new System.Drawing.Point(0, 0);
            this.dgvAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvAddress.Name = "dgvAddress";
            this.dgvAddress.RowHeadersWidth = 51;
            this.dgvAddress.Size = new System.Drawing.Size(1495, 490);
            this.dgvAddress.TabIndex = 1;
            this.dgvAddress.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddress_CellEndEdit);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.button1);
            this.panelEx1.Controls.Add(this.lblAddressColumnCount);
            this.panelEx1.Controls.Add(this.progressBarX1);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.ckbColorErrorsCell);
            this.panelEx1.Controls.Add(this.cbxColumsNumberOnly);
            this.panelEx1.Controls.Add(this.comboBoxEx1);
            this.panelEx1.Controls.Add(this.cbxDetectColumns);
            this.panelEx1.Controls.Add(this.pnlErrorsNotice);
            this.panelEx1.Controls.Add(this.txtFileName);
            this.panelEx1.Controls.Add(this.btnFindAddressIDCheck);
            this.panelEx1.Controls.Add(this.btnExportToExcel);
            this.panelEx1.Controls.Add(this.btnFileBrowse);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1495, 116);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // lblAddressColumnCount
            // 
            this.lblAddressColumnCount.AutoSize = true;
            // 
            // 
            // 
            this.lblAddressColumnCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAddressColumnCount.Location = new System.Drawing.Point(869, 79);
            this.lblAddressColumnCount.Name = "lblAddressColumnCount";
            this.lblAddressColumnCount.Size = new System.Drawing.Size(0, 0);
            this.lblAddressColumnCount.TabIndex = 11;
            // 
            // progressBarX1
            // 
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.Location = new System.Drawing.Point(318, 9);
            this.progressBarX1.Maximum = 0;
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(344, 23);
            this.progressBarX1.TabIndex = 8;
            this.progressBarX1.Text = "progressBarX1";
            this.progressBarX1.Visible = false;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(625, 48);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(238, 23);
            this.labelX5.TabIndex = 7;
            this.labelX5.Text = "Địa chỉ";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(381, 48);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(238, 23);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "Năm sinh";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(137, 48);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(238, 23);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "Họ và tên";
            // 
            // ckbColorErrorsCell
            // 
            this.ckbColorErrorsCell.AutoSize = true;
            // 
            // 
            // 
            this.ckbColorErrorsCell.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckbColorErrorsCell.Checked = true;
            this.ckbColorErrorsCell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbColorErrorsCell.CheckValue = "Y";
            this.ckbColorErrorsCell.Location = new System.Drawing.Point(137, 9);
            this.ckbColorErrorsCell.Name = "ckbColorErrorsCell";
            this.ckbColorErrorsCell.Size = new System.Drawing.Size(132, 25);
            this.ckbColorErrorsCell.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckbColorErrorsCell.TabIndex = 6;
            this.ckbColorErrorsCell.Text = "Tô màu ô lỗi";
            // 
            // cbxColumsNumberOnly
            // 
            this.cbxColumsNumberOnly.DisplayMember = "Text";
            this.cbxColumsNumberOnly.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxColumsNumberOnly.FormattingEnabled = true;
            this.cbxColumsNumberOnly.ItemHeight = 25;
            this.cbxColumsNumberOnly.Location = new System.Drawing.Point(381, 77);
            this.cbxColumsNumberOnly.Name = "cbxColumsNumberOnly";
            this.cbxColumsNumberOnly.Size = new System.Drawing.Size(238, 31);
            this.cbxColumsNumberOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxColumsNumberOnly.TabIndex = 5;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 25;
            this.comboBoxEx1.Location = new System.Drawing.Point(137, 77);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(238, 31);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 5;
            // 
            // cbxDetectColumns
            // 
            this.cbxDetectColumns.DisplayMember = "Text";
            this.cbxDetectColumns.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxDetectColumns.FormattingEnabled = true;
            this.cbxDetectColumns.ItemHeight = 25;
            this.cbxDetectColumns.Location = new System.Drawing.Point(625, 78);
            this.cbxDetectColumns.Name = "cbxDetectColumns";
            this.cbxDetectColumns.Size = new System.Drawing.Size(238, 31);
            this.cbxDetectColumns.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxDetectColumns.TabIndex = 5;
            // 
            // pnlErrorsNotice
            // 
            this.pnlErrorsNotice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlErrorsNotice.Controls.Add(this.labelX2);
            this.pnlErrorsNotice.Controls.Add(this.labelX1);
            this.pnlErrorsNotice.Location = new System.Drawing.Point(1206, 78);
            this.pnlErrorsNotice.Name = "pnlErrorsNotice";
            this.pnlErrorsNotice.Size = new System.Drawing.Size(271, 30);
            this.pnlErrorsNotice.TabIndex = 4;
            this.pnlErrorsNotice.Visible = false;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelX2.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(134, 0);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(121, 25);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "Nhấn để sửa.";
            this.labelX2.Click += new System.EventHandler(this.labelX2_Click);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX1.ForeColor = System.Drawing.Color.Red;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(134, 25);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Đã tìm thấy lỗi!";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtFileName.Border.Class = "TextBoxBorder";
            this.txtFileName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFileName.Location = new System.Drawing.Point(1039, 9);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.PreventEnterBeep = true;
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(316, 30);
            this.txtFileName.TabIndex = 1;
            // 
            // btnFindAddressIDCheck
            // 
            this.btnFindAddressIDCheck.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFindAddressIDCheck.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFindAddressIDCheck.Location = new System.Drawing.Point(18, 70);
            this.btnFindAddressIDCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFindAddressIDCheck.Name = "btnFindAddressIDCheck";
            this.btnFindAddressIDCheck.Size = new System.Drawing.Size(112, 41);
            this.btnFindAddressIDCheck.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFindAddressIDCheck.TabIndex = 0;
            this.btnFindAddressIDCheck.Text = "Chỉ định";
            this.btnFindAddressIDCheck.Click += new System.EventHandler(this.btnFindAddressIDCheck_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportToExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExportToExcel.Location = new System.Drawing.Point(18, 9);
            this.btnExportToExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(112, 52);
            this.btnExportToExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExportToExcel.TabIndex = 0;
            this.btnExportToExcel.Text = "Xuất";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnFileBrowse
            // 
            this.btnFileBrowse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileBrowse.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFileBrowse.Location = new System.Drawing.Point(1365, 9);
            this.btnFileBrowse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFileBrowse.Name = "btnFileBrowse";
            this.btnFileBrowse.Size = new System.Drawing.Size(112, 52);
            this.btnFileBrowse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFileBrowse.TabIndex = 0;
            this.btnFileBrowse.Text = "Chọn file";
            this.btnFileBrowse.Click += new System.EventHandler(this.btnFileBrowse_Click);
            // 
            // timerErrors
            // 
            this.timerErrors.Interval = 500;
            this.timerErrors.Tick += new System.EventHandler(this.timerErrors_Tick);
            // 
            // processTimer
            // 
            this.processTimer.Enabled = true;
            this.processTimer.Tick += new System.EventHandler(this.processTimer_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(275, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // FindAddressID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 635);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.contextMenuBar1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FindAddressID";
            this.Text = "Hỗ trợ QLPT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindAddressID_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FindAddressID_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddress)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.pnlErrorsNotice.ResumeLayout(false);
            this.pnlErrorsNotice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ContextMenuBar contextMenuBar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem biTools_FindAddressID;
        private DevComponents.DotNetBar.ButtonItem btnISetting;
        private DevComponents.DotNetBar.PanelEx pnlMain;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvAddress;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFileName;
        private DevComponents.DotNetBar.ButtonX btnFindAddressIDCheck;
        private DevComponents.DotNetBar.ButtonX btnExportToExcel;
        private DevComponents.DotNetBar.ButtonX btnFileBrowse;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxDetectColumns;
        private System.Windows.Forms.Panel pnlErrorsNotice;
        private System.Windows.Forms.Timer timerErrors;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckbColorErrorsCell;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxColumsNumberOnly;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.ComponentModel.BackgroundWorker bw;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private System.Windows.Forms.Timer processTimer;
        private DevComponents.DotNetBar.LabelX lblAddressColumnCount;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
    }
}

