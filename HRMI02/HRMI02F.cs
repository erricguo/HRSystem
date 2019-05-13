using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using ClassForm;
using System;
using System.Collections.Generic;
using DevExpress.XtraBars;

namespace HRMI02
{
    public partial class HRMI02F : ClassForm.BaseF
    {
        
        public HRMI02F()
        {
            InitializeComponent();
            InitUI();            
            InitDataMain(" SELECT * FROM HRMTA ","1=2","TA001", "HRMTA");
        }
        protected override void InitUI()
        {
            f2 = new F2Form(this);
            TCMain.TabPages.Move(0, CTP01);
            TP01.PageVisible = false;

            //可編輯欄位
            FGExListMain.Add(new FieldGridEx(tbaTA001, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "TA001", "工號", 0, true, true));
            FGExListMain.Add(new FieldGridEx(debTA002, GCEdit.GCE_Date, GCNum.GCN_Main, GCData.GCD_String, "TA002", "到職日",  1));
            FGExListMain.Add(new FieldGridEx(btnaTA003, GCEdit.GCE_Button, GCNum.GCN_Main, GCData.GCD_String, "TA003", "職稱",  2));
            FGExListMain.Add(new FieldGridEx(btnaTA004, GCEdit.GCE_Button, GCNum.GCN_Main, GCData.GCD_String, "TA004", "部門",  3));
            FGExListMain.Add(new FieldGridEx(tbaTA005, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "TA005", "姓名",  4));
            FGExListMain.Add(new FieldGridEx(tbaTA006, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "TA006", "英文暱稱",  5));
            FGExListMain.Add(new FieldGridEx(tbbTA007, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "TA007", "Email",  6));
            FGExListMain.Add(new FieldGridEx(tbbTA008, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "TA008", "分機",  7));
            FGExListMain.Add(new FieldGridEx(tbaTA009, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "TA009", "身分證字號",  8));
            FGExListMain.Add(new FieldGridEx(debTA010, GCEdit.GCE_Date, GCNum.GCN_Main, GCData.GCD_String, "TA010", "出生年月日",  9));
            FGExListMain.Add(new FieldGridEx(tbbTA011, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "TA011", "家用電話",  10));
            FGExListMain.Add(new FieldGridEx(tbbTA012, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "TA012", "手機",  11));
            FGExListMain.Add(new FieldGridEx(tbbTA013, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "TA013", "通訊地址",  12));
            FGExListMain.Add(new FieldGridEx(tbbTA014, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "TA014", "戶籍地址",  13));
            FGExListMain.Add(new FieldGridEx(tbaTA015, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "TA015", "護照英文拼音",  14));
            FGExListMain.Add(new FieldGridEx(debTA016, GCEdit.GCE_Date, GCNum.GCN_Main, GCData.GCD_String, "TA016", "離職日",  15));
            FGExListMain.Add(new FieldGridEx(chkTA017, GCEdit.GCE_Check, GCNum.GCN_Main, GCData.GCD_Check, "TA017", "離職",  16));
            FGExListMain.Add(new FieldGridEx(rgbTA018, GCEdit.GCE_RadioGroup, GCNum.GCN_Main, GCData.GCD_String, "TA018", "性別", 17));
            FGExListMain.Add(new FieldGridEx(rgbTA019, GCEdit.GCE_RadioGroup, GCNum.GCN_Main, GCData.GCD_String, "TA019", "婚姻狀況", 18));
            FGExListMain.Add(new FieldGridEx(rgbTA020, GCEdit.GCE_RadioGroup, GCNum.GCN_Main, GCData.GCD_String, "TA020", "身分別", 19));

            //顯示欄位
            DicDisplsy.Add("btnaTA003", "lbaTA003C");
            DicDisplsy.Add("btnaTA004", "lbaTA004C");
            

            //清空
            lbaTA004C.Text = "";
            lbaTA003C.Text = "";

            //F2
            btnaTA003.ButtonClick += btnF2_ButtonClick;
            btnaTA004.ButtonClick += btnF2_ButtonClick;

            //Leave
            LMCListExMain.Add(new LMC(btnaTA003,
                                new string[] { "HRMDB", "001" },
                                new List<BaseControl>() { btnaTA004,btnaTA003 },
                                lbaTA003C,1));
            LMCListExMain.Add(new LMC(btnaTA004,
                                new string[] { "HRMDA", "001" },
                                new List<BaseControl>() { btnaTA004 },
                                lbaTA004C, 1));

        }

        protected override void GVMain_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                if (e.Column.FieldName == "TA018")
                {
                    switch (e.Value.ToString())
                    {
                        case "1": e.DisplayText = "1.男"; break;
                        case "2": e.DisplayText = "2.女"; break;
                    }
                }
                else if (e.Column.FieldName == "TA019")
                {
                    switch (e.Value.ToString())
                    {
                        case "1": e.DisplayText = "1.未婚"; break;
                        case "2": e.DisplayText = "2.已婚"; break;
                    }
                }
                else if (e.Column.FieldName == "TA020")
                {
                    switch (e.Value.ToString())
                    {
                        case "1": e.DisplayText = "1.本國人"; break;
                        case "2": e.DisplayText = "2.外國人"; break;
                    }
                }
            }
        }

        private void btnF2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (FGridStatu != GridStatu.GS_Browse)
            {
                ButtonEdit btn = ((ButtonEdit)sender);
                if (btn.Name == "btnaTA004")
                {
                    LabelControl lb = null;
                    if (DicDisplsy.ContainsKey("btnaTA004"))
                    {
                         lb = (LabelControl)(btn.Parent.Controls.Find(DicDisplsy["btnaTA004"], true)[0]);
                    }                   
                    f2.SetMI = new string[] { "HRMDA", "001" };
                    if (f2.GetMI)
                    {
                        btn.Text = f2.GetReturn[0];
                        lb.Text = f2.GetReturn[1];
                    }
                }
                else if (btn.Name == "btnaTA003")
                {
                    LabelControl lb = null;
                    if (DicDisplsy.ContainsKey("btnaTA003"))
                    {
                        lb = (LabelControl)(btn.Parent.Controls.Find(DicDisplsy["btnaTA003"], true)[0]);
                    }
                    f2.SetMI = new string[] { "HRMDB", "001" };
                    f2.SetMIParam = new string[] { btnaTA004.Text };
                    if (f2.GetMI)
                    {
                        btn.Text = f2.GetReturn[0];
                        lb.Text = f2.GetReturn[1];
                    }
                }
            }
        }

        public override void MainControl_Leave(object sender, EventArgs e)
        {
            if (GetGridStatu() != GridStatu.GS_Browse)
            {
                base.MainControl_Leave(sender, e);


            }
        }

        private void btnaTA004_EditValueChanged(object sender, EventArgs e)
        {
            if (GetGridStatu() != GridStatu.GS_Browse)
            {
                if ((sender as TextEdit).Name == "btnaTA004")
                {
                    btnaTA003.Text = "";
                    lbaTA003C.Text = "";
                }
            }
        }

        protected override void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            base.btnCancel_ItemClick(sender, e);
            lbaTA003C.Text = "";
            lbaTA004C.Text = "";
        }
    }
}
