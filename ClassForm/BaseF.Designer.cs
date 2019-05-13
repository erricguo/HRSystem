namespace ClassForm
{
    partial class BaseF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseF));
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDel = new DevExpress.XtraBars.BarButtonItem();
            this.btnFirst = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrior = new DevExpress.XtraBars.BarButtonItem();
            this.btnNext = new DevExpress.XtraBars.BarButtonItem();
            this.btnLast = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.barPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.TCMain = new DevExpress.XtraTab.XtraTabControl();
            this.TP01 = new DevExpress.XtraTab.XtraTabPage();
            this.TP02 = new DevExpress.XtraTab.XtraTabPage();
            this.GCMain = new DevExpress.XtraGrid.GridControl();
            this.GVMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.GCBody = new DevExpress.XtraGrid.GridControl();
            this.GVBody = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sharedImageCollection1 = new DevExpress.Utils.SharedImageCollection();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TCMain)).BeginInit();
            this.TCMain.SuspendLayout();
            this.TP02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCBody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVBody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1.ImageSource)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNew,
            this.btnQuery,
            this.btnEdit,
            this.btnDel,
            this.btnSaveAndNew,
            this.barButtonItem1,
            this.btnCancel,
            this.btnFirst,
            this.btnPrior,
            this.btnNext,
            this.btnLast,
            this.btnSave,
            this.barPrint});
            this.barManager1.MaxItemId = 13;
            this.barManager1.StatusBar = this.bar2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFirst, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrior),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNext),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLast),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveAndNew, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barPrint, true)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.Text = "Tools";
            // 
            // btnNew
            // 
            this.btnNew.Caption = "新增";
            this.btnNew.Glyph = global::ClassForm.Properties.Resources.newfile;
            this.btnNew.Id = 0;
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnQuery
            // 
            this.btnQuery.Caption = "查詢";
            this.btnQuery.Glyph = global::ClassForm.Properties.Resources.search;
            this.btnQuery.Id = 1;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQuery_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "編輯";
            this.btnEdit.Glyph = global::ClassForm.Properties.Resources.editfile;
            this.btnEdit.Id = 2;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnDel
            // 
            this.btnDel.Caption = "刪除";
            this.btnDel.Glyph = global::ClassForm.Properties.Resources.delfile;
            this.btnDel.Id = 3;
            this.btnDel.Name = "btnDel";
            this.btnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDel_ItemClick);
            // 
            // btnFirst
            // 
            this.btnFirst.Caption = "第一筆";
            this.btnFirst.Glyph = global::ClassForm.Properties.Resources.first;
            this.btnFirst.Id = 7;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Tag = ((short)(0));
            this.btnFirst.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFirst_ItemClick);
            // 
            // btnPrior
            // 
            this.btnPrior.Caption = "上一筆";
            this.btnPrior.Glyph = global::ClassForm.Properties.Resources.prior;
            this.btnPrior.Id = 8;
            this.btnPrior.Name = "btnPrior";
            this.btnPrior.Tag = ((short)(1));
            this.btnPrior.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFirst_ItemClick);
            // 
            // btnNext
            // 
            this.btnNext.Caption = "下一筆";
            this.btnNext.Glyph = global::ClassForm.Properties.Resources.next;
            this.btnNext.Id = 9;
            this.btnNext.Name = "btnNext";
            this.btnNext.Tag = ((short)(2));
            this.btnNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFirst_ItemClick);
            // 
            // btnLast
            // 
            this.btnLast.Caption = "最後一筆";
            this.btnLast.Glyph = global::ClassForm.Properties.Resources.last;
            this.btnLast.Id = 10;
            this.btnLast.Name = "btnLast";
            this.btnLast.Tag = ((short)(3));
            this.btnLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFirst_ItemClick);
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Caption = "儲存並新增";
            this.btnSaveAndNew.Glyph = global::ClassForm.Properties.Resources.ok;
            this.btnSaveAndNew.Id = 4;
            this.btnSaveAndNew.Name = "btnSaveAndNew";
            this.btnSaveAndNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAndNew_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "取消";
            this.btnCancel.Glyph = global::ClassForm.Properties.Resources.cnacel;
            this.btnCancel.Id = 6;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "儲存";
            this.btnSave.Glyph = global::ClassForm.Properties.Resources.save;
            this.btnSave.Id = 11;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // barPrint
            // 
            this.barPrint.Caption = "btnPrint";
            this.barPrint.Glyph = global::ClassForm.Properties.Resources.print;
            this.barPrint.Id = 12;
            this.barPrint.Name = "barPrint";
            this.barPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPrint_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 3";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Custom 3";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlTop.Size = new System.Drawing.Size(974, 42);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 599);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlBottom.Size = new System.Drawing.Size(974, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 42);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 557);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(974, 42);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 557);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 42);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(974, 150);
            this.panelControl1.TabIndex = 14;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 192);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(974, 6);
            this.splitterControl1.TabIndex = 15;
            this.splitterControl1.TabStop = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.TCMain);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 198);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(974, 249);
            this.panelControl2.TabIndex = 16;
            // 
            // TCMain
            // 
            this.TCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCMain.Location = new System.Drawing.Point(2, 2);
            this.TCMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TCMain.Name = "TCMain";
            this.TCMain.SelectedTabPage = this.TP01;
            this.TCMain.Size = new System.Drawing.Size(970, 245);
            this.TCMain.TabIndex = 0;
            this.TCMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TP01,
            this.TP02});
            // 
            // TP01
            // 
            this.TP01.Appearance.Header.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TP01.Appearance.Header.Options.UseFont = true;
            this.TP01.Appearance.PageClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.TP01.Appearance.PageClient.Options.UseBackColor = true;
            this.TP01.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TP01.Name = "TP01";
            this.TP01.Size = new System.Drawing.Size(965, 212);
            this.TP01.Text = "詳細資料";
            // 
            // TP02
            // 
            this.TP02.Appearance.Header.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TP02.Appearance.Header.Options.UseFont = true;
            this.TP02.Controls.Add(this.GCMain);
            this.TP02.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TP02.Name = "TP02";
            this.TP02.Size = new System.Drawing.Size(964, 209);
            this.TP02.Text = "資料瀏覽";
            // 
            // GCMain
            // 
            this.GCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCMain.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GCMain.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GCMain.Location = new System.Drawing.Point(0, 0);
            this.GCMain.MainView = this.GVMain;
            this.GCMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GCMain.MenuManager = this.barManager1;
            this.GCMain.Name = "GCMain";
            this.GCMain.Size = new System.Drawing.Size(964, 209);
            this.GCMain.TabIndex = 0;
            this.GCMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVMain});
            // 
            // GVMain
            // 
            this.GVMain.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(223)))));
            this.GVMain.Appearance.FocusedCell.Options.UseBackColor = true;
            this.GVMain.Appearance.HeaderPanel.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GVMain.Appearance.HeaderPanel.Options.UseFont = true;
            this.GVMain.Appearance.Row.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GVMain.Appearance.Row.Options.UseFont = true;
            this.GVMain.GridControl = this.GCMain;
            this.GVMain.Name = "GVMain";
            this.GVMain.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.GVMain.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.GVMain.OptionsBehavior.ReadOnly = true;
            this.GVMain.OptionsView.ColumnAutoWidth = false;
            this.GVMain.OptionsView.ShowGroupPanel = false;
            this.GVMain.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GVMain_FocusedRowChanged);
            this.GVMain.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.GVMain_CustomColumnDisplayText);
            this.GVMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GVMain_MouseDown);
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl2.Location = new System.Drawing.Point(0, 447);
            this.splitterControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(974, 6);
            this.splitterControl2.TabIndex = 17;
            this.splitterControl2.TabStop = false;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.Controls.Add(this.GCBody);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 453);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(974, 146);
            this.panelControl3.TabIndex = 18;
            // 
            // GCBody
            // 
            this.GCBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCBody.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GCBody.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GCBody.Location = new System.Drawing.Point(2, 2);
            this.GCBody.MainView = this.GVBody;
            this.GCBody.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GCBody.MenuManager = this.barManager1;
            this.GCBody.Name = "GCBody";
            this.GCBody.Size = new System.Drawing.Size(970, 142);
            this.GCBody.TabIndex = 1;
            this.GCBody.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVBody});
            this.GCBody.Click += new System.EventHandler(this.GCBody_Click);
            this.GCBody.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GCBody_KeyUp);
            // 
            // GVBody
            // 
            this.GVBody.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(223)))));
            this.GVBody.Appearance.FocusedCell.Options.UseBackColor = true;
            this.GVBody.Appearance.HeaderPanel.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GVBody.Appearance.HeaderPanel.Options.UseFont = true;
            this.GVBody.Appearance.Row.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GVBody.Appearance.Row.Options.UseFont = true;
            this.GVBody.GridControl = this.GCBody;
            this.GVBody.Name = "GVBody";
            this.GVBody.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.GVBody.OptionsBehavior.ReadOnly = true;
            this.GVBody.OptionsView.ColumnAutoWidth = false;
            this.GVBody.OptionsView.ShowGroupPanel = false;
            this.GVBody.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GVBody_FocusedRowChanged);
            this.GVBody.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GVBody_CellValueChanged);
            this.GVBody.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.GVBody_ValidateRow);
            // 
            // sharedImageCollection1
            // 
            // 
            // 
            // 
            this.sharedImageCollection1.ImageSource.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("sharedImageCollection1.ImageSource.ImageStream")));
            this.sharedImageCollection1.ImageSource.Images.SetKeyName(0, "Checked.png");
            this.sharedImageCollection1.ImageSource.Images.SetKeyName(1, "Grayed.png");
            this.sharedImageCollection1.ImageSource.Images.SetKeyName(2, "Unchecked.png");
            this.sharedImageCollection1.ParentControl = this;
            // 
            // BaseF
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 621);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "BaseF";
            this.Text = "BaseF";
            this.Load += new System.EventHandler(this.BaseF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TCMain)).EndInit();
            this.TCMain.ResumeLayout(false);
            this.TP02.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCBody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVBody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1.ImageSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnQuery;
        private DevExpress.XtraBars.BarButtonItem btnDel;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Bar bar2;
        protected DevExpress.XtraBars.BarManager barManager1;
        protected DevExpress.XtraEditors.PanelControl panelControl1;
        protected DevExpress.XtraEditors.PanelControl panelControl3;
        protected DevExpress.XtraGrid.GridControl GCMain;
        protected DevExpress.XtraTab.XtraTabPage TP01;
        protected DevExpress.XtraTab.XtraTabPage TP02;
        public DevExpress.XtraTab.XtraTabControl TCMain;
        protected DevExpress.XtraGrid.Views.Grid.GridView GVMain;
        protected DevExpress.XtraEditors.SplitterControl splitterControl1;
        protected DevExpress.XtraEditors.SplitterControl splitterControl2;
        protected DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarButtonItem btnFirst;
        private DevExpress.XtraBars.BarButtonItem btnPrior;
        private DevExpress.XtraBars.BarButtonItem btnNext;
        private DevExpress.XtraBars.BarButtonItem btnLast;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        protected DevExpress.XtraGrid.GridControl GCBody;
        protected DevExpress.XtraGrid.Views.Grid.GridView GVBody;
        private DevExpress.Utils.SharedImageCollection sharedImageCollection1;
        protected DevExpress.XtraBars.BarButtonItem btnEdit;
        protected DevExpress.XtraBars.Bar bar1;
        protected DevExpress.XtraBars.BarButtonItem barPrint;
    }
}