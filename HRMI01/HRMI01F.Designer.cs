namespace HRMI01
{
    partial class HRMI01F
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HRMI01F));
            this.tbPW = new DevExpress.XtraEditors.TextEdit();
            this.lbPW = new DevExpress.XtraEditors.LabelControl();
            this.tbID = new DevExpress.XtraEditors.TextEdit();
            this.lbID = new DevExpress.XtraEditors.LabelControl();
            this.tbIP = new DevExpress.XtraEditors.TextEdit();
            this.lbIP = new DevExpress.XtraEditors.LabelControl();
            this.tbDB = new DevExpress.XtraEditors.TextEdit();
            this.lbDB = new DevExpress.XtraEditors.LabelControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.btnConn = new DevExpress.XtraEditors.SimpleButton();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::HRMI01.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.tbPW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPW
            // 
            this.tbPW.Location = new System.Drawing.Point(115, 96);
            this.tbPW.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbPW.Name = "tbPW";
            this.tbPW.Properties.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPW.Properties.Appearance.Options.UseFont = true;
            this.tbPW.Properties.PasswordChar = '●';
            this.tbPW.Size = new System.Drawing.Size(274, 28);
            this.tbPW.TabIndex = 9;
            // 
            // lbPW
            // 
            this.lbPW.Appearance.BackColor2 = System.Drawing.Color.Teal;
            this.lbPW.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPW.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbPW.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbPW.Location = new System.Drawing.Point(22, 97);
            this.lbPW.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbPW.Name = "lbPW";
            this.lbPW.Size = new System.Drawing.Size(85, 26);
            this.lbPW.TabIndex = 8;
            this.lbPW.Tag = "PW";
            this.lbPW.Text = "密碼";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(115, 62);
            this.tbID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbID.Name = "tbID";
            this.tbID.Properties.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbID.Properties.Appearance.Options.UseFont = true;
            this.tbID.Size = new System.Drawing.Size(274, 28);
            this.tbID.TabIndex = 7;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule3.ErrorText = "不可空白";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning;
            conditionValidationRule3.Value1 = "";
            this.dxValidationProvider1.SetValidationRule(this.tbID, conditionValidationRule3);
            // 
            // lbID
            // 
            this.lbID.Appearance.BackColor2 = System.Drawing.Color.Teal;
            this.lbID.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbID.Location = new System.Drawing.Point(22, 63);
            this.lbID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(85, 26);
            this.lbID.TabIndex = 10;
            this.lbID.Tag = "ID";
            this.lbID.Text = "帳號";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(115, 130);
            this.tbIP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbIP.Name = "tbIP";
            this.tbIP.Properties.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIP.Properties.Appearance.Options.UseFont = true;
            this.tbIP.Size = new System.Drawing.Size(274, 28);
            this.tbIP.TabIndex = 12;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule4.ErrorText = "不可空白";
            conditionValidationRule4.Value1 = "";
            this.dxValidationProvider1.SetValidationRule(this.tbIP, conditionValidationRule4);
            // 
            // lbIP
            // 
            this.lbIP.Appearance.BackColor2 = System.Drawing.Color.Teal;
            this.lbIP.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIP.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbIP.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbIP.Location = new System.Drawing.Point(22, 131);
            this.lbIP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(85, 26);
            this.lbIP.TabIndex = 11;
            this.lbIP.Tag = "IP";
            this.lbIP.Text = "主機/IP";
            // 
            // tbDB
            // 
            this.tbDB.Location = new System.Drawing.Point(115, 164);
            this.tbDB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDB.Name = "tbDB";
            this.tbDB.Properties.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDB.Properties.Appearance.Options.UseFont = true;
            this.tbDB.Size = new System.Drawing.Size(274, 28);
            this.tbDB.TabIndex = 14;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule1.ErrorText = "不可空白";
            conditionValidationRule1.Value1 = "";
            this.dxValidationProvider1.SetValidationRule(this.tbDB, conditionValidationRule1);
            // 
            // lbDB
            // 
            this.lbDB.Appearance.BackColor2 = System.Drawing.Color.Teal;
            this.lbDB.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDB.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbDB.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbDB.Location = new System.Drawing.Point(22, 165);
            this.lbDB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbDB.Name = "lbDB";
            this.lbDB.Size = new System.Drawing.Size(85, 26);
            this.lbDB.TabIndex = 13;
            this.lbDB.Tag = "DB";
            this.lbDB.Text = "資料庫";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSave,
            this.btnClose});
            this.barManager1.MaxItemId = 2;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.Text = "Tools";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "儲存";
            this.btnSave.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSave.Glyph")));
            this.btnSave.Id = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "關閉";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 1;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlTop.Size = new System.Drawing.Size(900, 42);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 604);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlBottom.Size = new System.Drawing.Size(900, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 42);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 562);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(900, 42);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 562);
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // btnConn
            // 
            this.btnConn.Appearance.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConn.Appearance.Options.UseFont = true;
            this.btnConn.Location = new System.Drawing.Point(278, 198);
            this.btnConn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(111, 39);
            this.btnConn.TabIndex = 19;
            this.btnConn.Text = "連線測試";
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // HRMI01F
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 626);
            this.Controls.Add(this.btnConn);
            this.Controls.Add(this.tbDB);
            this.Controls.Add(this.lbDB);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.lbIP);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.tbPW);
            this.Controls.Add(this.lbPW);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "HRMI01F";
            this.ShowIcon = false;
            this.Tag = "";
            this.Text = "基本條件設定作業";
            this.Load += new System.EventHandler(this.HRMI01F_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbPW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tbPW;
        private DevExpress.XtraEditors.LabelControl lbPW;
        private DevExpress.XtraEditors.TextEdit tbID;
        private DevExpress.XtraEditors.LabelControl lbID;
        private DevExpress.XtraEditors.TextEdit tbIP;
        private DevExpress.XtraEditors.LabelControl lbIP;
        private DevExpress.XtraEditors.TextEdit tbDB;
        private DevExpress.XtraEditors.LabelControl lbDB;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.SimpleButton btnConn;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}