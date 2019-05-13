using System;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
using ClassForm;

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
            InitData(" SELECT * FROM HRMGA ", "1=2", "GA001", "HRMGA");
        }
        protected override void InitUI()
        {
            f2 = new F2Form(this);

            //可編輯欄位
            FGExList.Add(new FieldGridEx(tbaGA001, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "GA001", "編號", 0, true, true));
            FGExList.Add(new FieldGridEx(tbaGA002, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "GA002", "設定檔名稱", 0, true, true));
            FGExList.Add(new FieldGridEx(tbaGA003, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "GA003", "備註", 0, true, true));
            /*FGExList.Add(new FieldGridEx(btnaGA003, GCEdit.GCE_Button, GCNum.GCN_Main, GCData.GCD_String, "TA003", "職稱", 2));
            FGExList.Add(new FieldGridEx(btnaTA004, GCEdit.GCE_Button, GCNum.GCN_Main, GCData.GCD_String, "TA004", "部門", 3));
            FGExList.Add(new FieldGridEx(tbaTA005, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "TA005", "姓名", 4));
            FGExList.Add(new FieldGridEx(tbaTA006, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "TA006", "英文暱稱", 5));*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FDT = DateTime.Now;
            HRMV02R report = new HRMV02R(FDT);
            Parameter param1 = new Parameter();
            param1.Name = "TA001";

            // Specify other parameter properties.
            param1.Visible = false;
            param1.MultiValue = true;
            param1.Type = typeof(System.String);
            FIDs.AddRange(new string[] { "001", "002" });
            param1.Value = FIDs.ToArray();// new string[] { "001", "002" };
            
            

           /* param1.LookUpSettings = new StaticListLookUpSettings();
            ((StaticListLookUpSettings)param1.LookUpSettings).LookUpValues.AddRange(new LookUpValue[] {
            new LookUpValue("001", "Chai"),
            new LookUpValue("002", "Chang"),
            new LookUpValue("003", "Aniseed Syrup")
            });*/

            
            // Add the parameter to the report.
            report.Parameters.Add(param1);

            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                // Invoke the Ribbon Print Preview form modally, 
                // and load the report document into it.
                printTool.ShowRibbonPreviewDialog();

                // Invoke the Ribbon Print Preview form
                // with the specified look and feel setting.
                //printTool.ShowRibbonPreviewDialog(UserLookAndFeel.Default);
            }
        }
    }
}