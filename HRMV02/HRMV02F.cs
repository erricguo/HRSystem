using ClassForm;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
using Sharefc;

namespace HRMV02
{
    public partial class HRMV02F : ClassForm.BaseF
    {
        DateTime FDT = new DateTime();
        List<string> FIDs = new List<string>();
        public HRMV02F()
        {
            InitializeComponent();
            InitUI();
            InitDataMain(" SELECT * FROM HRMGA ", "1=2", "GA001", "HRMGA");
            InitDataBody(" SELECT * FROM HRMGB ", "1=2", "GB001", "HRMGB");
            InitFunc();
        }

        private void InitFunc()
        {
            //F2
           // ((RepositoryItemButtonEdit)GVBody.Columns["GB002"].ColumnEdit).ButtonClick += btnF2_ButtonClick;

        }

        

        protected override void InitUI()
        {
            f2 = new F2Form(this);

            //可編輯欄位
            FGExListMain.Add(new FieldGridEx(tbaGA001, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "GA001", "編號", 0, true, true));
            FGExListMain.Add(new FieldGridEx(tbaGA002, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "GA002", "設定檔名稱", 1));
            FGExListMain.Add(new FieldGridEx(tbaGA003, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "GA003", "備註", 2));

            FGExListBody.Add(new FieldGridEx(new TextEdit(), GCEdit.GCE_None, GCNum.GCN_Body, GCData.GCD_String, "GB001", "編號", 0));
            FGExListBody.Add(new FieldGridEx(new ButtonEdit(), GCEdit.GCE_Button, GCNum.GCN_Body, GCData.GCD_String, "GB002", "員工代號", 1));
            FGExListBody.Add(new FieldGridEx(new TextEdit(), GCEdit.GCE_None, GCNum.GCN_Body, GCData.GCD_String, "GB003", "員工姓名", 2));

            FMListBody.Add(FGExListBody[1].BEdit, "");

            barPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        protected override void GVMain_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            base.GVMain_FocusedRowChanged(sender, e);
            if (gridCreatorBody != null)
            {
                if (GVMain.FocusedRowHandle < 0)
                    return;

                if (FGridStatu == GridStatu.GS_Save)
                {
                    return;
                }

                gridCreatorBody.NewQuery = true;
                gridCreatorBody.Filter = "GB001="+GVMain.GetRowCellValue(GVMain.FocusedRowHandle, "GA001").ToString().Trim();
                gridCreatorBody.PrepareData();
                gridCreatorBody.NewQuery = false;
                //CheckGridStatu(GridStatu.GS_Browse);
            }
        }

        protected override bool BodyCanNewRow()
        {
            if (FGridStatu != GridStatu.GS_Edit &&
                FGridStatu != GridStatu.GS_Add)
            {
                return false;
            }

            if (GVBody.GetRowCellValue(GVBody.FocusedRowHandle, "GB002").ToString().Trim() != "")
            {
                return true;
            }
            else
                return base.BodyCanNewRow();
        }

        private void btnF2_ButtonClick(  object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (FGridStatu != GridStatu.GS_Browse)
            {
                RepositoryItemButtonEdit btn = (RepositoryItemButtonEdit)GVBody.FocusedColumn.ColumnEdit;
                //ButtonEdit btn = ((ButtonEdit)sender);
                if (btn.Name == "GB002")
                {
                    //LabelControl lb = null;
                    if (DicDisplsy.ContainsKey("GB002"))
                    {
                        //lb = (LabelControl)(btn.Parent.Controls.Find(DicDisplsy["GB003"], true)[0]);
                    }
                    f2.SetMI = new string[] { "HRMDA", "001" };
                    if (f2.GetMI)
                    {
                        
                       // btn.Text = f2.GetReturn[0];
                       // lb.Text = f2.GetReturn[1];
                    }
                }
            }
        }

        protected override void barPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DatePickerForm dpf = new DatePickerForm();
            dpf.ShowDialog();
            
            FDT = dpf.GetDateTime();
            HRMV02R report = new HRMV02R(FDT);
            Parameter param1 = new Parameter();
            param1.Name = "TA001";

            // Specify other parameter properties.
            param1.Visible = false;
            param1.MultiValue = true;
            param1.Type = typeof(System.String);

            for (int i = 0; i <= GVBody.RowCount - 1; i++)
            {
                string mValue = GVBody.GetRowCellValue(i, "GB002").ToString().Trim();
                if (mValue != "")
                {
                    FIDs.Add(mValue);
                }
            }
            
            param1.Value = FIDs.ToArray();// new string[] { "001", "002" };
            report.Parameters.Add(param1);
            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }

        protected override void GVBody_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            base.GVBody_ValidateRow(sender, e);
            if (GVBody.GetRowCellValue(GVBody.FocusedRowHandle, "GB002").ToString().Trim() == "")
            {
                e.Valid = false;
            }
        }
    }
}
