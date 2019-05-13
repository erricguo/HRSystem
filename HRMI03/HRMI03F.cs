using ClassForm;
using DevExpress.XtraGrid.Views.Base;

namespace HRMI03
{
    public partial class HRMI03F : BaseF
    {
        public HRMI03F()
        {
            InitializeComponent();
            InitUI();
            InitDataMain(" SELECT * FROM HRMDD ", "1=2", "DD001", "HRMDD");
        }

        protected override void InitUI()
        {


            //可編輯欄位
            FGExListMain.Add(new FieldGridEx(tbaDD001, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "DD001", "假別代號", 0, true, true));
            FGExListMain.Add(new FieldGridEx(tbaDD002, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "DD002", "假別名稱", 1));
            FGExListMain.Add(new FieldGridEx(ckaDD003, GCEdit.GCE_Check, GCNum.GCN_Main, GCData.GCD_String, "DD003", "須扣款", 2));
            FGExListMain.Add(new FieldGridEx(rgaDD004, GCEdit.GCE_RadioGroup, GCNum.GCN_Main, GCData.GCD_String, "DD004", "請假計算單位", 3));
            FGExListMain.Add(new FieldGridEx(rgaDD005, GCEdit.GCE_RadioGroup, GCNum.GCN_Main, GCData.GCD_String, "DD005", "請假數量之累計方式", 4));
            FGExListMain.Add(new FieldGridEx(tbaDD006, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DD006", "允許不扣款之累計數量", 5));
            FGExListMain.Add(new FieldGridEx(tbaDD007, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DD007", "年度允許請假數量", 6));
            FGExListMain.Add(new FieldGridEx(tbaDD008, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DD008", "日薪者每單位扣款比率", 7));
            FGExListMain.Add(new FieldGridEx(tbaDD009, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DD009", "月薪者每單位扣款比率", 8));
            FGExListMain.Add(new FieldGridEx(ckaDD010, GCEdit.GCE_Check, GCNum.GCN_Main, GCData.GCD_String, "DD010", "扣全勤獎金", 9));
            FGExListMain.Add(new FieldGridEx(tbaDD011, GCEdit.GCE_Check, GCNum.GCN_Main, GCData.GCD_Double, "DD011", "每月允許請假數量", 10));
            FGExListMain.Add(new FieldGridEx(null, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "DD012", "併入假別計算", 11));

            //Format 
            FMListMain.Add(tbaDD008, "p");
            FMListMain.Add(tbaDD009, "p");            
        }

        protected override void GVMain_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                if (e.Column.FieldName == "DD004")
                {
                    switch (e.Value.ToString())
                    {
                        case "1": e.DisplayText = "1.天數"; break;
                        case "2": e.DisplayText = "2.時數"; break;
                    }
                }
                else if (e.Column.FieldName == "DD005")
                {
                    switch (e.Value.ToString())
                    {
                        case "1": e.DisplayText = "1.月"; break;
                        case "2": e.DisplayText = "2.年"; break;
                    }
                }
            }
        }
    }
}