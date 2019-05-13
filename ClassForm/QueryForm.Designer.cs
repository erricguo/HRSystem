namespace ClassForm
{
    partial class QueryForm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cboRowCount = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lb01 = new DevExpress.XtraEditors.LabelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.TP01 = new DevExpress.XtraTab.XtraTabPage();
            this.TP02 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.lbcRight = new DevExpress.XtraEditors.ListBoxControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnOut = new DevExpress.XtraEditors.SimpleButton();
            this.lbcLeft = new DevExpress.XtraEditors.ListBoxControl();
            this.lb02 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.memoSQL = new DevExpress.XtraEditors.MemoEdit();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.rg01 = new DevExpress.XtraEditors.RadioGroup();
            this.cboMix = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboColumn = new DevExpress.XtraEditors.ComboBoxEdit();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRowCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.TP02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbcRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcLeft)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoSQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rg01.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboColumn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cboRowCount);
            this.panelControl1.Controls.Add(this.lb01);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(535, 52);
            this.panelControl1.TabIndex = 0;
            // 
            // cboRowCount
            // 
            this.cboRowCount.EditValue = "500";
            this.cboRowCount.Location = new System.Drawing.Point(108, 12);
            this.cboRowCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboRowCount.Name = "cboRowCount";
            this.cboRowCount.Properties.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRowCount.Properties.Appearance.Options.UseFont = true;
            this.cboRowCount.Properties.AppearanceDropDown.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRowCount.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboRowCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRowCount.Properties.Items.AddRange(new object[] {
            "100",
            "200",
            "500",
            "1000",
            "2000",
            "5000",
            "ALL"});
            this.cboRowCount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboRowCount.Size = new System.Drawing.Size(170, 28);
            this.cboRowCount.TabIndex = 2;
            // 
            // lb01
            // 
            this.lb01.Appearance.BackColor2 = System.Drawing.Color.Blue;
            this.lb01.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb01.Appearance.ForeColor = System.Drawing.Color.White;
            this.lb01.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb01.Location = new System.Drawing.Point(10, 14);
            this.lb01.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lb01.Name = "lb01";
            this.lb01.Size = new System.Drawing.Size(90, 24);
            this.lb01.TabIndex = 1;
            this.lb01.Text = "顯示資料數";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Enabled = false;
            this.splitterControl1.Location = new System.Drawing.Point(0, 52);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(535, 6);
            this.splitterControl1.TabIndex = 3;
            this.splitterControl1.TabStop = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.xtraTabControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 58);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(535, 470);
            this.panelControl2.TabIndex = 4;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.TP01;
            this.xtraTabControl1.Size = new System.Drawing.Size(531, 466);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TP01,
            this.TP02});
            // 
            // TP01
            // 
            this.TP01.Appearance.Header.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TP01.Appearance.Header.Options.UseFont = true;
            this.TP01.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TP01.Name = "TP01";
            this.TP01.Size = new System.Drawing.Size(526, 433);
            this.TP01.Text = "一般設定";
            // 
            // TP02
            // 
            this.TP02.Appearance.Header.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TP02.Appearance.Header.Options.UseFont = true;
            this.TP02.Controls.Add(this.panelControl5);
            this.TP02.Controls.Add(this.panel1);
            this.TP02.Controls.Add(this.panelControl4);
            this.TP02.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TP02.Name = "TP02";
            this.TP02.Size = new System.Drawing.Size(525, 430);
            this.TP02.Text = "進階設定";
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.lbcRight);
            this.panelControl5.Controls.Add(this.btnIn);
            this.panelControl5.Controls.Add(this.btnOut);
            this.panelControl5.Controls.Add(this.lbcLeft);
            this.panelControl5.Controls.Add(this.lb02);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(0, 270);
            this.panelControl5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(525, 160);
            this.panelControl5.TabIndex = 2;
            // 
            // lbcRight
            // 
            this.lbcRight.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcRight.Appearance.Options.UseFont = true;
            this.lbcRight.Location = new System.Drawing.Point(300, 38);
            this.lbcRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbcRight.Name = "lbcRight";
            this.lbcRight.Size = new System.Drawing.Size(224, 116);
            this.lbcRight.TabIndex = 9;
            // 
            // btnIn
            // 
            this.btnIn.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Image = global::ClassForm.Properties.Resources.next;
            this.btnIn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnIn.Location = new System.Drawing.Point(230, 100);
            this.btnIn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(62, 52);
            this.btnIn.TabIndex = 8;
            // 
            // btnOut
            // 
            this.btnOut.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOut.Appearance.Options.UseFont = true;
            this.btnOut.Image = global::ClassForm.Properties.Resources.prior;
            this.btnOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnOut.Location = new System.Drawing.Point(230, 38);
            this.btnOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(62, 52);
            this.btnOut.TabIndex = 7;
            // 
            // lbcLeft
            // 
            this.lbcLeft.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcLeft.Appearance.Options.UseFont = true;
            this.lbcLeft.Location = new System.Drawing.Point(0, 38);
            this.lbcLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbcLeft.Name = "lbcLeft";
            this.lbcLeft.Size = new System.Drawing.Size(224, 116);
            this.lbcLeft.TabIndex = 3;
            // 
            // lb02
            // 
            this.lb02.Appearance.BackColor2 = System.Drawing.Color.Blue;
            this.lb02.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb02.Appearance.ForeColor = System.Drawing.Color.White;
            this.lb02.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb02.Location = new System.Drawing.Point(10, 8);
            this.lb02.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lb02.Name = "lb02";
            this.lb02.Size = new System.Drawing.Size(90, 24);
            this.lb02.TabIndex = 2;
            this.lb02.Text = "排序";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.memoSQL);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 84);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 186);
            this.panel1.TabIndex = 1;
            // 
            // memoSQL
            // 
            this.memoSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoSQL.Location = new System.Drawing.Point(0, 0);
            this.memoSQL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.memoSQL.Name = "memoSQL";
            this.memoSQL.Properties.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoSQL.Properties.Appearance.Options.UseFont = true;
            this.memoSQL.Size = new System.Drawing.Size(525, 186);
            this.memoSQL.TabIndex = 0;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.btnAdd);
            this.panelControl4.Controls.Add(this.btnClear);
            this.panelControl4.Controls.Add(this.rg01);
            this.panelControl4.Controls.Add(this.cboMix);
            this.panelControl4.Controls.Add(this.cboColumn);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(525, 84);
            this.panelControl4.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Location = new System.Drawing.Point(332, 44);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 34);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "加入";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Location = new System.Drawing.Point(230, 44);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 34);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "清除";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rg01
            // 
            this.rg01.Location = new System.Drawing.Point(5, 44);
            this.rg01.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rg01.Name = "rg01";
            this.rg01.Properties.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rg01.Properties.Appearance.Options.UseFont = true;
            this.rg01.Properties.Columns = 2;
            this.rg01.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "AND"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "OR")});
            this.rg01.Size = new System.Drawing.Size(219, 34);
            this.rg01.TabIndex = 5;
            // 
            // cboMix
            // 
            this.cboMix.EditValue = "=";
            this.cboMix.Location = new System.Drawing.Point(230, 6);
            this.cboMix.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboMix.Name = "cboMix";
            this.cboMix.Properties.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMix.Properties.Appearance.Options.UseFont = true;
            this.cboMix.Properties.AppearanceDropDown.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMix.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboMix.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMix.Properties.DropDownRows = 10;
            this.cboMix.Properties.Items.AddRange(new object[] {
            "=",
            ">=",
            "<=",
            ">",
            "<",
            "<>",
            "like%",
            "%like",
            "%like%"});
            this.cboMix.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboMix.Size = new System.Drawing.Size(95, 28);
            this.cboMix.TabIndex = 4;
            // 
            // cboColumn
            // 
            this.cboColumn.EditValue = "";
            this.cboColumn.Location = new System.Drawing.Point(5, 6);
            this.cboColumn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboColumn.Name = "cboColumn";
            this.cboColumn.Properties.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboColumn.Properties.Appearance.Options.UseFont = true;
            this.cboColumn.Properties.AppearanceDropDown.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboColumn.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboColumn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboColumn.Properties.DropDownRows = 10;
            this.cboColumn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboColumn.Size = new System.Drawing.Size(219, 28);
            this.cboColumn.TabIndex = 3;
            this.cboColumn.SelectedIndexChanged += new System.EventHandler(this.cboColumn_SelectedIndexChanged);
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl2.Enabled = false;
            this.splitterControl2.Location = new System.Drawing.Point(0, 528);
            this.splitterControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(535, 6);
            this.splitterControl2.TabIndex = 5;
            this.splitterControl2.TabStop = false;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnCancel);
            this.panelControl3.Controls.Add(this.btnOK);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 534);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(535, 70);
            this.panelControl3.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::ClassForm.Properties.Resources.cnacel;
            this.btnCancel.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancel.Location = new System.Drawing.Point(302, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 54);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Image = global::ClassForm.Properties.Resources.ok;
            this.btnOK.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOK.Location = new System.Drawing.Point(114, 8);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 54);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "確定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // QueryForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 604);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "QueryForm";
            this.Text = "查詢條件";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboRowCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.TP02.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbcRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbcLeft)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoSQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rg01.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboColumn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lb01;
        private DevExpress.XtraEditors.ComboBoxEdit cboRowCount;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage TP01;
        private DevExpress.XtraTab.XtraTabPage TP02;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.ListBoxControl lbcRight;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.SimpleButton btnOut;
        private DevExpress.XtraEditors.ListBoxControl lbcLeft;
        private DevExpress.XtraEditors.LabelControl lb02;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.MemoEdit memoSQL;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.RadioGroup rg01;
        private DevExpress.XtraEditors.ComboBoxEdit cboMix;
        private DevExpress.XtraEditors.ComboBoxEdit cboColumn;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}