using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using static ClassForm.fc;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Repository;
using System.Linq;

namespace ClassForm
{
    /// <summary>
    /// 基礎底層
    /// </summary>
    public partial class BaseF : RootForm
    {

        protected DTableGridCreator gridCreator = null;
        protected DTableGridCreator gridCreatorBody = null;
        const string NodeSoftWare = "Software";
        const string NodeHR = "HRMSystem";
        const string NodePath = @"HKEY_CURRENT_USER\Software\" + NodeHR;
        private ProductProxy pproxy = new ProductProxy();
        private ProductProxy pproxyBody = new ProductProxy();
        protected CommandBuilderEx cmdBuilder = new CommandBuilderEx();
        protected CommandBuilderEx cmdBuilderBody = new CommandBuilderEx();

        //public List<FieldControlEx> FCExList = new List<FieldControlEx>();
        public List<FieldGridEx> FGExListMain { get; set; } = new List<FieldGridEx>();
        public List<FieldGridEx> FGExListBody { get; set; } = new List<FieldGridEx>();
        public Dictionary<string, string> DicDisplsy { get; set; } = new Dictionary<string, string>();
        public List<GridView> GVList { get; set; } = new List<GridView>();
        public List<SchemaList> shList { get; set; } = new List<SchemaList>();
        public Dictionary<BaseEdit, string> FMListMain { get; set; } = new Dictionary<BaseEdit, string>();
        public Dictionary<BaseEdit, string> FMListBody { get; set; } = new Dictionary<BaseEdit, string>();
        /*public BindingSource bindingSource = new BindingSource();*/
        QueryForm qf = new QueryForm();

        public LMCList LMCListExMain { get; set; } = new LMCList();
        public LMCList LMCListExBody { get; set; } = new LMCList();

        public class LMCList: List<LMC>
        {
            
            public bool Contains(string Name)
            {
                foreach (LMC a in this)
                {
                    if (a.Name == Name)
                        return true;
                }
                return false;
            }

            public LMC this[string Name]
            {
                //[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries"), __DynamicallyInvokable]
                get
                {
                    foreach (LMC a in this)
                    {
                        if (a.Name == Name)
                            return a;
                    }
                    return null;
                }
                //[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries"), __DynamicallyInvokable]
                /*set
                {
                    if (index >= this._size)
                    {
                        ThrowHelper.ThrowArgumentOutOfRangeException();
                    }
                    this._items[index] = value;
                    this._version++;
                }*/
            }

        }
        public class LMC {
            public string Name { get; set; }
            public BaseEdit LMC_Request { get; set; }
            public string[] LMC_ADMMJ { get; set; }
            //public string[] LMC_Param { get; set; }
            public List<BaseControl> LMC_Param { get; set; }
            public BaseControl LMC_Return { get; set; }
            public int LMC_ReturnIndex { get; set; }
            public LMC(BaseEdit xLMC_Request, string[] xLMC_ADMMJ, List<BaseControl> xLMC_Param, BaseControl xLMC_Return, int xLMC_ReturnIndex)
            {
                Name = xLMC_Request.Name;
                LMC_Request = xLMC_Request;
                LMC_ADMMJ = xLMC_ADMMJ;
                LMC_Param = xLMC_Param;
                LMC_Return = xLMC_Return;
                LMC_ReturnIndex = xLMC_ReturnIndex;
            }

            public string[] GetParamText()
            {
                string[] xParam = new string[LMC_Param.Count];
                for (int i = 0; i < LMC_Param.Count; i++)
                    xParam[i] = LMC_Param[i].Text;

                return xParam;
            }

        }
        /*public class DisPlayControlEx
        {
            public string BindControlName { get; set; } = "";
            public DisPlayControlEx(string xBindControlName)
            {
                BindControlName = xBindControlName;
            }
        }*/
        public class FieldGridEx
        {
            public string FieldName { get; set; } = "";
            public int FieldWidth { get; set; } = 30;
            public string FieldCaption { get; set; } = "";
            public int FieldIndex { get; set; } = 0;
            public GCNum GCType { get; set; } = GCNum.GCN_Main;
            public bool FieldKey { get; set; } = false;
            public bool ReadOnly { get; set; } = false;
            public bool Visibled { get; set; } = true;
            public GCEdit GCEditType { get; set; } = GCEdit.GCE_None;       
            public GCData GCDataType { get; set; } = GCData.GCD_String;
            public bool FieldRequired { get; set; } = false;

            public BaseEdit BEdit { get; set; } = null;
            public FieldGridEx()
            {

            }

            private void InitData(BaseEdit xBEdit,GCEdit xGCEditType, GCNum xGCType, GCData xGCDataType, string xFieldName, string xFieldCaption, int xFieldIndex, int xFieldWidth, bool xFieldKey, bool xFieldRequired)
            {
                FieldName = xFieldName;
                FieldWidth = xFieldWidth;
                FieldCaption = xFieldCaption;
                FieldIndex = xFieldIndex;
                FieldKey = xFieldKey;
                FieldRequired = xFieldRequired;
                GCEditType = xGCEditType; //控件類別
                GCType = xGCType; //屬於單頭或單身
                GCDataType = xGCDataType; //qf SCHEMA 用來判斷顯示哪一種EDIT
                
                if (xBEdit != null)
                {
                    BEdit = xBEdit;
                    //BEdit.ReadOnly = true;
                    BEdit.Properties.AppearanceReadOnly.BackColor = Color.FromArgb(180, 180, 180);
                    BEdit.EnterMoveNextControl = true;
                    BEdit.TabIndex = xFieldIndex;

                    if (BEdit is ButtonEdit)
                    {
                        if (BEdit.Name == "")
                        {
                            BEdit.Name = xFieldName;
                        }
                        ((ButtonEdit)BEdit).Properties.Buttons[0].Width = 15;
                    }
                    if (BEdit is DateEdit)
                    {
                        ((DateEdit)BEdit).EditValueChanged += new EventHandler(Date_EditValueChanged);
                        ((DateEdit)BEdit).Properties.Buttons[0].Width = 15;
                    }
                    if(BEdit is CheckEdit)
                    {
                        ((CheckEdit)BEdit).Properties.ValueChecked = "Y";
                        ((CheckEdit)BEdit).Properties.ValueUnchecked = "N";                       
                    }
                    if(BEdit is RadioGroup)
                    {

                    }
                    if(BEdit is LookUpEdit)
                    {
                       
                    }
                    
                    if(xGCDataType == GCData.GCD_Double)
                    {
                         BEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far; 
                    }
                }

                
                switch (GCEditType)
                {
                    case GCEdit.GCE_Button:
                        break;
                    case GCEdit.GCE_Date:
                        break;
                    case GCEdit.GCE_Time:
                        break;
                    case GCEdit.GCE_Check:
                        break;
                    case GCEdit.GCE_Num:
                        break;
                    case GCEdit.GCE_PW:
                        break;
                    case GCEdit.GCE_RadioGroup:
                        break;

                }
            }


            private void Date_EditValueChanged(object sender, EventArgs e)
            {
                try
                {
                    DateEdit de = (DateEdit)sender;
                    DateTime dt = DateTime.Now;
                    if (!DateTime.TryParse(de.EditValue.ToString(), out dt))
                    {
                        dt = DateTime.ParseExact(de.EditValue.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    de.EditValue = dt.ToString("yyyy/MM/dd");
                }
                catch (System.Exception ex)
                {

                }
            }

            public FieldGridEx(BaseEdit xBEdit, GCEdit xGCEditType, GCNum xGCType, GCData xGCDataType, string xFieldName, string xFieldCaption, int xFieldIndex)
            {
                InitData(xBEdit,xGCEditType, xGCType, xGCDataType, xFieldName, xFieldCaption, xFieldIndex, FieldWidth, FieldKey, FieldRequired);
            }

            public FieldGridEx(BaseEdit xBEdit, GCEdit xGCEditType, GCNum xGCType, GCData xGCDataType, string xFieldName, string xFieldCaption,  int xFieldIndex, int xFieldWidth)
            {
                InitData(xBEdit, xGCEditType, xGCType, xGCDataType, xFieldName, xFieldCaption, xFieldIndex, xFieldWidth, FieldKey, FieldRequired);
            }
            public FieldGridEx(BaseEdit xBEdit, GCEdit xGCEditType, GCNum xGCType, GCData xGCDataType, string xFieldName, string xFieldCaption, int xFieldIndex, bool xFieldKey, bool xFieldRequired)
            {
                InitData(xBEdit, xGCEditType, xGCType, xGCDataType, xFieldName, xFieldCaption, xFieldIndex, FieldWidth, xFieldKey, xFieldRequired);
            }
            public FieldGridEx(BaseEdit xBEdit, GCEdit xGCEditType, GCNum xGCType, GCData xGCDataType, string xFieldName, string xFieldCaption, int xFieldIndex, int xFieldWidth, bool xFieldKey, bool xFieldRequired)
            {
                InitData(xBEdit, xGCEditType, xGCType, xGCDataType, xFieldName, xFieldCaption, xFieldIndex, xFieldWidth, xFieldKey, xFieldRequired);
            }
        }


        public BaseF()
        {
            InitializeComponent();

            GVList.Add(GVMain);
            GVList.Add(GVBody);

            CheckGridStatu(GridStatu.GS_Browse);
            qf.StartPosition = FormStartPosition.CenterParent;


        }

        private void BaseF_Load(object sender, EventArgs e)
        {

        }

        public override GridView GetGV(GCNum xGCNum)
        {
            switch (xGCNum)
            {
                case GCNum.GCN_Main:
                    return GVMain;
                case GCNum.GCN_Body:
                    return GVBody;
            }
            return null;
        }
        public override GridControl GetGC(GCNum xGCNum)
        {
            switch (xGCNum)
            {
                case GCNum.GCN_Main:
                    return GCMain;
                case GCNum.GCN_Body:
                    return GCBody;
            }
            return null;
        }

        protected override void CheckGridStatu(GridStatu gs, bool SetValue = true)
        {
            if(SetValue)
            {
                FGridStatu = gs;
            }

            switch (FGridStatu)
            {
                case GridStatu.GS_Browse:
                    btnNew.Enabled = true;
                    btnQuery.Enabled = true;
                    btnEdit.Enabled = GVMain.RowCount > 0 ? true : false;
                    btnDel.Enabled = GVMain.RowCount > 0 ? true : false;
                    btnFirst.Enabled = GVMain.RowCount > 0 ? true : false;
                    btnPrior.Enabled = GVMain.RowCount > 0 ? true : false;
                    btnNext.Enabled = GVMain.RowCount > 0 ? true : false;
                    btnLast.Enabled = GVMain.RowCount > 0 ? true : false;
                    btnSaveAndNew.Enabled = false;
                    btnCancel.Enabled = false;
                    btnSave.Enabled = false;
                    GVBody.OptionsBehavior.ReadOnly = true;
                    for (int i = 0; i < FGExListMain.Count; i++)
                    {
                        if(FGExListMain[i].BEdit != null)
                        {
                            FGExListMain[i].BEdit.ReadOnly = true;
                        }
                    }
                    break;
                case GridStatu.GS_Add:
                    btnNew.Enabled = false;
                    btnQuery.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDel.Enabled = false;
                    btnFirst.Enabled = false;
                    btnPrior.Enabled = false;
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                    btnSaveAndNew.Enabled = true;
                    btnCancel.Enabled = true;
                    btnSave.Enabled = true;
                    GVBody.OptionsBehavior.ReadOnly = false;
                    for (int i = 0; i < FGExListMain.Count; i++)
                    {
                        if (FGExListMain[i].BEdit != null)
                        {
                            FGExListMain[i].BEdit.ReadOnly = false;
                        }
                    }
                    break;
                case GridStatu.GS_Edit:
                    btnNew.Enabled = false;
                    btnQuery.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDel.Enabled = false;
                    btnFirst.Enabled = false;
                    btnPrior.Enabled = false;
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                    btnSaveAndNew.Enabled = true;
                    btnCancel.Enabled = true;
                    btnSave.Enabled = false;
                    GVBody.OptionsBehavior.ReadOnly = false;
                    for (int i = 0; i < FGExListMain.Count; i++)
                    {
                        if (FGExListMain[i].BEdit != null && !FGExListMain[i].FieldKey)
                        {
                            FGExListMain[i].BEdit.ReadOnly = false;
                        }
                    }
                    break;
            }
        }

        virtual protected void InitDataMain(string SQLStr, string Filter, string OrderBy, string tableName)
        {
            
            SetSchemaInfo(FGExListMain);
            gridCreator = new DTableGridCreator(GCMain);
            gridCreator.SQLStr = SQLStr;            
            gridCreator.Filter = Filter;
            gridCreator.OrderBy = OrderBy;
            gridCreator.tableName = tableName;
            gridCreator.NewQuery = true;

            pproxy.InserCmd = cmdBuilder.InserCmd;
            pproxy.UpdateCmd = cmdBuilder.UpdateCmd;
            pproxy.DeleteCmd = cmdBuilder.DeleteCmd;
            pproxy.SetSqlCmd();

            gridCreator.GetDataEvent = pproxy.GetDataList;
            gridCreator.UpdateDataEvent = pproxy.UpdateValue;
            gridCreator.DeleteDataEvent = pproxy.DeleteValue;
            gridCreator.PrepareData();

            BindData(GCMain,FGExListMain);
            SetFieldInfo(FGExListMain);
            CheckGridStatu(GridStatu.GS_Browse);
            gridCreator.NewQuery = false;

            RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
            edit.Name = "CheckEdit";                
            edit.ValueChecked = "Y";
            edit.ValueUnchecked = "N";
            edit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            edit.PictureChecked = sharedImageCollection1.ImageSource.Images["Checked.png"];
            edit.PictureGrayed = sharedImageCollection1.ImageSource.Images["Grayed.png"];
            edit.PictureUnchecked = sharedImageCollection1.ImageSource.Images["Unchecked.png"];
            GCMain.RepositoryItems.Add(edit);
            RepositoryItemTextEdit tbedit = new RepositoryItemTextEdit();
            tbedit.Name = "TextEdit_P";
            tbedit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tbedit.Mask.EditMask = "p";
            tbedit.Mask.UseMaskAsDisplayFormat = true;
            GCMain.RepositoryItems.Add(tbedit);

            for (int j = 0; j < FGExListMain.Count; j++)
            {
                if (FGExListMain[j].BEdit != null)
                {
                    if (FGExListMain[j].BEdit is CheckEdit)
                    {
                        ((CheckEdit)FGExListMain[j].BEdit).Properties.PictureChecked = sharedImageCollection1.ImageSource.Images["Checked.png"];
                        ((CheckEdit)FGExListMain[j].BEdit).Properties.PictureGrayed = sharedImageCollection1.ImageSource.Images["Grayed.png"];
                        ((CheckEdit)FGExListMain[j].BEdit).Properties.PictureUnchecked = sharedImageCollection1.ImageSource.Images["Unchecked.png"];
                        if (GetGV(FGExListMain[j].GCType).IsVisible)
                            GetGV(FGExListMain[j].GCType).Columns[FGExListMain[j].FieldName].ColumnEdit = GetGC(FGExListMain[j].GCType).RepositoryItems["CheckEdit"];
                    }
                    else if (FGExListMain[j].BEdit is TextEdit)
                    {
                        if(FMListMain.ContainsKey(((TextEdit)FGExListMain[j].BEdit)))
                        {
                            if(GetGV(FGExListMain[j].GCType).IsVisible)
                                GetGV(FGExListMain[j].GCType).Columns[FGExListMain[j].FieldName].ColumnEdit = GetGC(FGExListMain[j].GCType).RepositoryItems["TextEdit_P"];                            
                                                     
                        }
                    }
                    else if(FGExListMain[j].BEdit is LookUpEdit)
                    {

                    }
                }
            }

            foreach(var c in FMListMain)
            {     
                           
                //c.Key.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                //c.Key.Properties.Mask.EditMask = c.Value; // EditValue from 0 to 100 as percent
                //c.Key.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            

            //Leave
            foreach(var c in LMCListExMain)
            {
                c.LMC_Request.Leave += MainControl_Leave;
            }
        }

        virtual protected void InitDataBody(string SQLStr, string Filter, string OrderBy, string tableName)
        {
            gridCreatorBody = new DTableGridCreator(GCBody);
            gridCreatorBody.SQLStr = SQLStr;
            gridCreatorBody.Filter = Filter;
            gridCreatorBody.OrderBy = OrderBy;
            gridCreatorBody.tableName = tableName;
            gridCreatorBody.NewQuery = true;

            pproxyBody.InserCmd = cmdBuilderBody.InserCmd;
            pproxyBody.UpdateCmd = cmdBuilderBody.UpdateCmd;
            pproxyBody.DeleteCmd = cmdBuilderBody.DeleteCmd;
            pproxyBody.SetSqlCmd();

            gridCreatorBody.GetDataEvent = pproxyBody.GetDataList;
            gridCreatorBody.UpdateDataEvent = pproxyBody.UpdateValue;
            gridCreatorBody.DeleteDataEvent = pproxyBody.DeleteValue;
            gridCreatorBody.PrepareData();

            BindData(GCBody, FGExListBody);
            SetFieldInfo(FGExListBody);
            gridCreatorBody.NewQuery = false;

            RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
            edit.Name = "CheckEdit";
            edit.ValueChecked = "Y";
            edit.ValueUnchecked = "N";
            edit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            edit.PictureChecked = sharedImageCollection1.ImageSource.Images["Checked.png"];
            edit.PictureGrayed = sharedImageCollection1.ImageSource.Images["Grayed.png"];
            edit.PictureUnchecked = sharedImageCollection1.ImageSource.Images["Unchecked.png"];
            GCBody.RepositoryItems.Add(edit);
            RepositoryItemTextEdit tbedit = new RepositoryItemTextEdit();
            tbedit.Name = "TextEdit_P";
            tbedit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            tbedit.Mask.EditMask = "p";
            tbedit.Mask.UseMaskAsDisplayFormat = true;
            GCBody.RepositoryItems.Add(tbedit);
            RepositoryItemButtonEdit btnedit = new RepositoryItemButtonEdit();
            btnedit.Name = "ButtonEdit";
            GCBody.RepositoryItems.Add(btnedit);

            for (int j = 0; j < FGExListBody.Count; j++)
            {
                if (FGExListBody[j].BEdit != null)
                {
                    if (FGExListBody[j].BEdit is CheckEdit)
                    {
                        ((CheckEdit)FGExListBody[j].BEdit).Properties.PictureChecked = sharedImageCollection1.ImageSource.Images["Checked.png"];
                        ((CheckEdit)FGExListBody[j].BEdit).Properties.PictureGrayed = sharedImageCollection1.ImageSource.Images["Grayed.png"];
                        ((CheckEdit)FGExListBody[j].BEdit).Properties.PictureUnchecked = sharedImageCollection1.ImageSource.Images["Unchecked.png"];
                        if (GetGV(FGExListBody[j].GCType).IsVisible)
                            GetGV(FGExListBody[j].GCType).Columns[FGExListBody[j].FieldName].ColumnEdit = GetGC(FGExListBody[j].GCType).RepositoryItems["CheckEdit"];
                    }
                    else if (FGExListBody[j].BEdit is ButtonEdit)
                    {
                        if (FMListBody.ContainsKey(((ButtonEdit)FGExListBody[j].BEdit)))
                        {
                            /*
                            if (GetGV(FGExListBody[j].GCType).Columns[FGExListBody[j].FieldName].ColumnEdit.Name == "")
                                GetGV(FGExListBody[j].GCType).Columns[FGExListBody[j].FieldName].ColumnEdit.Name = FGExListBody[j].FieldName;
                                */
                            if (GetGV(FGExListBody[j].GCType).IsVisible)
                            {
                                GetGV(FGExListBody[j].GCType).Columns[FGExListBody[j].FieldName].ColumnEdit = GetGC(FGExListBody[j].GCType).RepositoryItems["ButtonEdit"];
                                GetGV(FGExListBody[j].GCType).Columns[FGExListBody[j].FieldName].ColumnEdit.Name = FGExListBody[j].FieldName;
                            }

                        }
                    }
                    else if (FGExListBody[j].BEdit is TextEdit)
                    {
                        if (FMListBody.ContainsKey(((TextEdit)FGExListBody[j].BEdit)))
                        {
                            if (GetGV(FGExListBody[j].GCType).IsVisible)
                                GetGV(FGExListBody[j].GCType).Columns[FGExListBody[j].FieldName].ColumnEdit = GetGC(FGExListBody[j].GCType).RepositoryItems["TextEdit_P"];

                        }
                    }
                    else if (FGExListBody[j].BEdit is LookUpEdit)
                    {

                    }
                }
            }

            foreach (var c in FMListMain)
            {

               // c.Key.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
               // c.Key.Properties.Mask.EditMask = c.Value; // EditValue from 0 to 100 as percent
               // c.Key.Properties.Mask.UseMaskAsDisplayFormat = true;
            }


            //Leave
            /*foreach (var c in LMCListExMain)
            {
                c.LMC_Request.Leave += MainControl_Leave;
            }*/
        }

        virtual protected void InitUI()
        {

        }

        protected void Init(string SQLStr)
        {

        }

        protected virtual void SetSchemaInfo(List<FieldGridEx> xFGExList)
        {
            for (int j = 0; j < xFGExList.Count; j++)
            {
                switch (xFGExList[j].GCDataType)
                {
                    case GCData.GCD_String:
                    case GCData.GCD_Int:
                    case GCData.GCD_Double:
                    case GCData.GCD_Check:
                        shList.Add(new SchemaList(xFGExList[j].GCDataType, xFGExList[j].FieldName, xFGExList[j].FieldCaption));
                        break;
                    case GCData.GCD_Combo:
                        var items = ((ComboBoxEdit)xFGExList[j].BEdit).Properties.Items;
                        shList.Add(new SchemaList(xFGExList[j].GCDataType, xFGExList[j].FieldName, xFGExList[j].FieldCaption, items));
                        break;


                }
            }
        }
        protected virtual void SetFieldInfo(List<FieldGridEx> xFGExList)
        {           
            for(int i = 0;i<GVList.Count;i++)
            {
                if (GVList[i] != null)
                {
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in GVList[i].Columns)
                    {
                        for (int j = 0; j < xFGExList.Count; j++)
                        {
                            if (col.FieldName != "Rowss")
                            {
                                if (xFGExList[j].FieldName == col.FieldName)
                                {
                                    col.Caption = xFGExList[j].FieldCaption;                                 
                                }
                            }
                            else
                            {
                                col.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        protected virtual void BindData(GridControl mGC, List<FieldGridEx> xFCEx)
        {
            for (int i = 0; i < xFCEx.Count; i++)
            {
                string mFieldName = xFCEx[i].FieldName;
                if(xFCEx[i].BEdit != null && xFCEx[i].BEdit.DataBindings.Count == 0 )
                    xFCEx[i].BEdit.DataBindings.Add("EditValue", mGC.DataSource, mFieldName,false,DataSourceUpdateMode.OnPropertyChanged);
            }
        }


        public class CustomFormatter : IFormatProvider, ICustomFormatter
        {
            // The GetFormat method of the IFormatProvider interface.
            // This must return an object that provides formatting services for the specified type.
            public object GetFormat(System.Type type)
            {
                return this;
            }
            // The Format method of the ICustomFormatter interface.
            // This must format the specified value according to the specified format settings.
            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                string formatValue = arg.ToString();

                if (format == "Date" && formatValue != "")
                {
                    try
                    {
                        DateTime dt = DateTime.Now;
                        if (!DateTime.TryParse(formatValue, out dt))
                        {
                            dt = DateTime.ParseExact(formatValue, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        return formatValue = dt.ToString("yyyy/MM/dd");
                    }
                    catch (System.Exception ex)
                    {
                        return "";
                    }

                }
                else if (format == "Time" && formatValue != "")
                {
                    try
                    {
                        DateTime dt = DateTime.Now;
                        if (!DateTime.TryParse(formatValue, out dt))
                        {
                            dt = DateTime.ParseExact(formatValue, "HHmm", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        return formatValue = dt.ToString("HH:mm");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                        //fc.ErrorLog(ex.Message);
                        return "";
                    }
                }
                else return formatValue;
            }
           
        }

        DateTime mouseDownTime = DateTime.MinValue;
        GridCell mouseDownCell = new GridCell(GridControl.InvalidRowHandle, null);
        TimeSpan DoubleClickInterval = new TimeSpan(0, 0, 0, 0, 400);
        private void GVMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                GridHitInfo hi = GVMain.CalcHitInfo(e.Location);
                if (hi == null || hi.Column == null)
                {
                    return;
                }
                if (hi.InRowCell)
                {
                    if (hi.RowHandle == mouseDownCell.RowHandle && hi.Column == mouseDownCell.Column && DateTime.Now - mouseDownTime < DoubleClickInterval)
                        DoRowDoubleClick(sender as GridView, e.Location);
                }
                mouseDownCell = new GridCell(hi.RowHandle, hi.Column);
                mouseDownTime = DateTime.Now;
            }
        }
        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                TCMain.SelectedTabPageIndex = 0;
            }
        }

        protected void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            if (FGridStatu == GridStatu.GS_Browse)
            {
                TCMain.SelectedTabPageIndex = 0;
                //FGridStatu = GridStatu.GS_Add;
                CheckGridStatu(GridStatu.GS_Add);
                GVBody.OptionsBehavior.ReadOnly = false;
                gridCreator.PrepareNew();
               /* for (int i = 0; i < FGExList.Count; i++)
                {
                    //if (KeyListMain.Contains(MainControls[i].Name) || ReadOnlyListMain.Contains(MainControls[i].Name))
                    if (ReadOnlyListMain.Contains(MainControls[i].Name))
                    {
                        continue;
                    }
                    MainControls[i].Properties.ReadOnly = false;
                }

                for (int i = 0; i < GV_Body.Columns.Count; i++)
                {
                    if (ReadOnlyListBody.Contains(GV_Body.Columns[i].FieldName))
                    {
                        GV_Body.Columns[i].OptionsColumn.ReadOnly = true;
                    }
                    else
                    {
                        GV_Body.Columns[i].OptionsColumn.ReadOnly = false;
                    }
                }*/

                GVMain.AddNewRow();
            }
        }
        protected void btnQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            qf.SetSchemas(shList);
            if(qf.ShowDialog() == DialogResult.OK)
            {
                TCMain.SelectedTabPage = TP02;
                //GetData(qf.Filter);
                gridCreator.NewQuery = true;
                gridCreator.Filter = qf.Filter;
                gridCreator.PrepareData();
                //BindData(FGExList);
                //SetFieldInfo(FGExList);
                gridCreator.NewQuery = false;
                CheckGridStatu(GridStatu.GS_Browse);
            }        
        }
        protected virtual void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FGridStatu == GridStatu.GS_Browse)
            {                
                TCMain.SelectedTabPageIndex = 0;
                CheckGridStatu(GridStatu.GS_Edit);  
            }
        }
        protected void btnDel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FGridStatu == GridStatu.GS_Browse)
            {
                if (GVMain.RowCount > 0)
                {
                    if(new ConfirmForm("確定要刪除此筆資料?", "詢問",-1).ShowDialog() == DialogResult.OK)
                    //if (MessageBox.Show("確定要刪除此筆資料?", "詢問", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {                      
                        if (gridCreatorBody != null)
                        {
                            GVBody.SelectAll();
                            GVBody.DeleteSelectedRows();
                            gridCreatorBody.DeleteValue(((BindingSource)GCBody.DataSource));
                            GVBody.RefreshData();
                            GCBody.Refresh();
                        }
                          
                        GVMain.DeleteSelectedRows();
                        gridCreator.DeleteValue(((BindingSource)GCMain.DataSource));
                        GVMain.RefreshData();
                        GCMain.Refresh();

                        CheckGridStatu(GridStatu.GS_Browse);
                    }
                }
            }
        }
        private void btnFirst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FGridStatu == GridStatu.GS_Browse)
            {
                switch (e.Item.Tag.ToString())
                {
                    case "0":
                        GVMain.MoveFirst();
                        break;
                    case "1":
                        GVMain.MovePrev();
                        break;
                    case "2":
                        GVMain.MoveNext();
                        break;
                    case "3":
                        GVMain.MoveLast();
                        break;
                }

            }
        }
        protected virtual void btnSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FGridStatu == GridStatu.GS_Add)
            {
                FGridStatu = GridStatu.GS_Save;
                if (gridCreatorBody != null)
                {
                    GVBody.PostEditor();
                    GVBody.UpdateCurrentRow();
                }

                GVMain.UpdateCurrentRow();
                if (gridCreatorBody != null)
                {
                    gridCreatorBody.UpdateValue((BindingSource)GCBody.DataSource);
                }
                gridCreator.UpdateValue((BindingSource)GCMain.DataSource);
                //gridCreator.GetData();
                CheckGridStatu(GridStatu.GS_Browse);
                btnNew.PerformClick();
            }
            else if (FGridStatu == GridStatu.GS_Edit)
            {
                FGridStatu = GridStatu.GS_Save;
                if (gridCreatorBody != null)
                {
                    GVBody.PostEditor();
                    GVBody.UpdateCurrentRow();
                   
                }
                //GVMain.PostEditor();
                GVMain.UpdateCurrentRow();
                //gridCreator.UpdateValue(((DataTable)GCMain.DataSource));
                if (gridCreatorBody != null)
                {
                    gridCreatorBody.UpdateValue((BindingSource)GCBody.DataSource);
                }
                gridCreator.UpdateValue((BindingSource)GCMain.DataSource);
                //gridCreator.GetData();
                /*if (gridCreatorBody != null)
                {
                    gridCreatorBody.GetData();
                }*/
                CheckGridStatu(GridStatu.GS_Browse);
            }
            
            
        }

        protected virtual void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            GVMain.CancelUpdateCurrentRow();
            GVMain.RefreshData();
            //gridCreatorBody.GetData();
            GVBody.CancelUpdateCurrentRow();
            GVBody.RefreshData();
            //GCBody.Refresh();
            CheckGridStatu(GridStatu.GS_Browse);
        }

        protected void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            FGridStatu = GridStatu.GS_Save;
            if (gridCreatorBody!=null)
            {
                GVBody.PostEditor();
                GVBody.UpdateCurrentRow();
            }
            GVMain.UpdateCurrentRow();
            if (gridCreatorBody != null)
            {
                gridCreatorBody.UpdateValue((BindingSource)GCBody.DataSource);
            }
            gridCreator.UpdateValue((BindingSource)GCMain.DataSource);
            CheckGridStatu(GridStatu.GS_Browse);           
        }

        protected void GetData(List<FieldGridEx> mList,string xFilter)
        {
           /* gridCreator.Filter = xFilter;
            gridCreator.GetData();
            BindData(mList);
            SetFieldInfo(mList);*/
        }

        private void GVMain_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

        }

        protected virtual void GVMain_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {

        }

        public virtual void MainControl_Leave(object sender, EventArgs e)
        {
            BaseEdit edit = (sender as BaseEdit);
            if (edit.Text.Trim() == "")
            {
                return;
            }
            if(LMCListExMain.Contains(edit.Name))
              LeaveCheckMainFunc(LMCListExMain[edit.Name]);
            else
            {
                LMCListExMain[edit.Name].LMC_Return.Text = "";
            }
        }

        public GridStatu GetGridStatu()
        {
            return FGridStatu;
        }
        /*protected virtual bool MainKeyFieldCheck()
        {
            for (int i = 0; i< FGExList.Count;i++)
            {
                if(FGExList[i].FieldKey)
                {

                }
            }
        }*/

        //public void LeaveCheckMainFunc(BaseEdit xControl, string[] xADMMJ, string[] xParam, Dictionary<BaseControl, int> xReturnFileds)
        public void LeaveCheckMainFunc(LMC xLmc)
        {
            try
            {
                f2.SetMJ = xLmc.LMC_ADMMJ;
                f2.SetMJParam = xLmc.GetParamText();
                if (f2.GetMJ)
                {
                    xLmc.LMC_Return.Text = f2.GetReturn[xLmc.LMC_ReturnIndex];
                    /*for (int i = 0; i < xReturnFileds.Count; i++)
                    {
                        KeyValuePair<BaseControl, int> kv = xReturnFileds.ElementAt(i);
                        kv.Key.Text = f2.GetReturn[kv.Value];
                    }*/
                }
                else
                {
                    if (GetGridStatu() != GridStatu.GS_Browse)
                    {
                        xLmc.LMC_Request.Focus();
                        MessageBox.Show("找不到符合的資料", "錯誤");
                    }
                }
            }
            catch (System.Exception ex)
            {
                if (GetGridStatu() != GridStatu.GS_Browse)
                {
                    MessageBox.Show(ex.Message.ToString());
                    ErrorLog(ex.Message);
                }
            }
        }

        private void GCBody_Click(object sender, EventArgs e)
        {
            if ((FGridStatu == GridStatu.GS_Add) || (FGridStatu == GridStatu.GS_Edit))
            {
                if (GVBody.RowCount == 0)
                {
                    gridCreatorBody.PrepareNew();
                    GVBody.AddNewRow();
                }
            }
        }

        private void GCBody_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
            {
                if (BodyCanNewRow())
                {
                    if (GVBody.PostEditor())
                    {
                        GVBody.UpdateCurrentRow();
                        GVBody.AddNewRow();
                    }
                    
                    
                }
                //gridCreator.UpdateValue((BindingSource)GCMain.DataSource);
            }
        }

        protected virtual bool BodyCanNewRow()
        {
            return false;
        }

        protected virtual void GVMain_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (GetGridStatu() == GridStatu.GS_Browse)
            {
                for (int i = 0; i < LMCListExMain.Count; i++)
                {
                    LeaveCheckMainFunc(LMCListExMain[i]);
                }
            }
        }

        protected virtual void barPrint_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void GVBody_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            
        }

        private void GVBody_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

        }

        protected virtual void GVBody_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            
        }
    }
}