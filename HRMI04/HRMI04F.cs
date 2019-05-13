using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ClassForm;
using System.Data.SqlClient;
using static Sharefc.fc;
using DevExpress.XtraBars;

namespace HRMI04
{
    public partial class HRMI04F : BaseF
    {
        public HRMI04F()
        {
            InitializeComponent();
            InitUI();
            InitDataMain(" SELECT * FROM HRMDE ", "1=1", "DE001", "HRMDE");
            btnEdit.Enabled = true;
            btnEdit.PerformClick();
        }

        protected override void InitUI()
        {
            f2 = new F2Form(this);
            //TP02.PageVisible = false;

            //可編輯欄位
            FGExListMain.Add(new FieldGridEx(tbaDE001, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE001", "工號", 0));
            FGExListMain.Add(new FieldGridEx(tbaDE002, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE002", "到職日", 1));
            FGExListMain.Add(new FieldGridEx(tbaDE003, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE003", "職稱", 2));
            FGExListMain.Add(new FieldGridEx(tbaDE004, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE004", "部門", 3));
            FGExListMain.Add(new FieldGridEx(tbaDE005, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE005", "姓名", 4));
            FGExListMain.Add(new FieldGridEx(tbaDE006, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE006", "英文暱稱", 5));
            FGExListMain.Add(new FieldGridEx(tbaDE007, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE007", "Email", 6));
            FGExListMain.Add(new FieldGridEx(tbaDE008, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE008", "分機", 7));
            FGExListMain.Add(new FieldGridEx(tbaDE009, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE009", "身分證字號", 8));
            FGExListMain.Add(new FieldGridEx(tbaDE010, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE010", "出生年月日", 9));
            FGExListMain.Add(new FieldGridEx(tbaDE011, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE011", "家用電話", 10));
            FGExListMain.Add(new FieldGridEx(tbaDE012, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE012", "手機", 11));
            FGExListMain.Add(new FieldGridEx(tbaDE013, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE013", "通訊地址", 12));
            FGExListMain.Add(new FieldGridEx(tbaDE014, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE014", "戶籍地址", 13));
            FGExListMain.Add(new FieldGridEx(tbaDE015, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE015", "護照英文拼音", 14));
            FGExListMain.Add(new FieldGridEx(tbaDE016, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE016", "離職日", 15));
            FGExListMain.Add(new FieldGridEx(tbaDE017, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE017", "離職", 16));
            FGExListMain.Add(new FieldGridEx(tbaDE018, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_Double, "DE018", "性別", 17));
            FGExListMain.Add(new FieldGridEx(ckaDE019, GCEdit.GCE_Check, GCNum.GCN_Main, GCData.GCD_String, "DE019", "婚姻狀況", 18));
            FGExListMain.Add(new FieldGridEx(luaDE020, GCEdit.GCE_None, GCNum.GCN_Main, GCData.GCD_String, "DE020", "身分別", 19));


            //Format 
            FMListMain.Add(tbaDE006, "p");
            FMListMain.Add(tbaDE007, "p");
            FMListMain.Add(tbaDE008, "p");
            FMListMain.Add(tbaDE011, "p");
            FMListMain.Add(tbaDE012, "p");
            FMListMain.Add(tbaDE013, "p");
            FMListMain.Add(tbaDE016, "p");
            FMListMain.Add(tbaDE017, "p");
            FMListMain.Add(tbaDE018, "p");

            List<LUDE020> luDE020 = new List<LUDE020>();

            luDE020.Add(new LUDE020("1", "1.實際時數"));
            luDE020.Add(new LUDE020("2", "2.加班單"));
            luDE020.Add(new LUDE020("3", "3.兩者取小"));
            
            luaDE020.Properties.DataSource = luDE020;
            luaDE020.Properties.DisplayMember = "display";
            luaDE020.Properties.ValueMember = "id";
            luaDE020.Properties.ShowHeader = false;
            luaDE020.Properties.ShowFooter = false;
        }

        protected override void InitDataMain(string SQLStr, string Filter, string OrderBy, string tableName)
        {
            /*SqlConnection Conn = new SqlConnection(makeConnectString());
            var da2 = new SqlDataAdapter("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'HRMDE'", Conn);
            DataTable dd = new DataTable();
            da2.Fill(dd);*/

            //List<string> columns = new List<string>();
            string UpdateStr = "UPDATE HRMDE SET DE001=@DE001,DE002=@DE002,DE003=@DE003,DE004=@DE004,DE005=@DE005," +
                                                "DE006=@DE006,DE007=@DE007,DE008=@DE008,DE009=@DE009,DE010=@DE010," +
                                                "DE011=@DE011,DE012=@DE012,DE013=@DE013,DE014=@DE014,DE015=@DE015," +
                                                "DE016=@DE016,DE017=@DE017,DE018=@DE018,DE019=@DE019,DE020=@DE020";
            /*for (int i=1;i<=20;i++)
            {
                UpdateStr += $"DE+ {(i+1).ToString().PadLeft(3,'0')}=@{(i + 1).ToString().PadLeft(3, '0')}";
                //columns.Add($"DE+ {(i + 1).ToString().PadLeft(3, '0')}");
            }*/
            cmdBuilder.UpdateCmd = new SqlCommand(UpdateStr);
            cmdBuilder.UpdateCmd.Parameters.Add("@DE001", SqlDbType.Float, -1, "DE001");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE002", SqlDbType.Float, -1, "DE002");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE003", SqlDbType.Float, -1, "DE003");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE004", SqlDbType.Float, -1, "DE004");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE005", SqlDbType.Float, -1, "DE005");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE006", SqlDbType.Float, -1, "DE006");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE007", SqlDbType.Float, -1, "DE007");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE008", SqlDbType.Float, -1, "DE008");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE009", SqlDbType.Float, -1, "DE009");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE010", SqlDbType.Float, -1, "DE010");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE011", SqlDbType.Float, -1, "DE011");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE012", SqlDbType.Float, -1, "DE012");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE013", SqlDbType.Float, -1, "DE013");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE014", SqlDbType.Float, -1, "DE014");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE015", SqlDbType.Float, -1, "DE015");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE016", SqlDbType.Float, -1, "DE016");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE017", SqlDbType.Float, -1, "DE017");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE018", SqlDbType.Float, -1, "DE018");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE019", SqlDbType.Char, -1, "DE019");
            cmdBuilder.UpdateCmd.Parameters.Add("@DE020", SqlDbType.Char, -1, "DE020");
            cmdBuilder.DeleteCmd = new SqlCommand("");
            /*for(int i=0;i<columns.Count;i++)
            {

            }*/

            base.InitDataMain(SQLStr, Filter, OrderBy, tableName);
        }

        protected override void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {            
            if (FGridStatu == GridStatu.GS_Browse)
            {
                if (GVMain.RowCount == 0)
                {
                    GVMain.AddNewRow();
                }
                base.btnEdit_ItemClick(sender, e);                           
            }
        }
        protected override void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        protected override void btnSaveAndNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            base.btnSaveAndNew_ItemClick(sender, e);
            Close();
        }

        private void tbaDE_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit tb = (TextEdit)sender;
            if (tb.Name == "tbaDE004")
            {
                tb05_1.EditValue = tbaDE004.EditValue;
            }
            else if(tb.Name == "tbaDE005")
            {
                tb05_4.EditValue = tbaDE005.EditValue;
            }
            else if (tb.Name == "tbaDE009")
            {
                tb10_1.EditValue = tbaDE009.EditValue;
            }
            else if (tb.Name == "tbaDE010")
            {
                tb10_4.EditValue = tbaDE010.EditValue;
            }
            else if (tb.Name == "tbaDE014")
            {
                tb15_1.EditValue = tbaDE014.EditValue;
            }
            else if (tb.Name == "tbaDE015")
            {
                tb15_4.EditValue = tbaDE015.EditValue;
            }
        }
    }

    internal class LUDE020
    {
        public string id { get; set; }
        public string display { get; set; }

        public LUDE020(string xId,string xDisplay)
        {
            id = xId;
            display = xDisplay;
        }
    }
}