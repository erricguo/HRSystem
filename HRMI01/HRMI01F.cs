using System;
using System.Linq;
using Microsoft.Win32;
using ClassForm;

namespace HRMI01
{
    public partial class HRMI01F : DevExpress.XtraEditors.XtraForm
    {
        const string NodeSoftWare = "Software";
        const string NodeHR = "HRMSystem";
        const string NodePath = @"HKEY_CURRENT_USER\Software\" + NodeHR;
        public HRMI01F()
        {
            InitializeComponent();
        }
        private void HRMI01F_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            //打開 子機碼 路徑。
            RegistryKey Reg = Registry.CurrentUser.OpenSubKey(NodeSoftWare, true);
            ////檢查子機碼是否存在，檢查資料夾是否存在。
            if (Reg.GetSubKeyNames().Contains(NodeHR))
            {
                tbID.Text = Registry.GetValue(NodePath, lbID.Tag.ToString(), "").ToString();
                tbPW.Text = Registry.GetValue(NodePath, lbPW.Tag.ToString(), "").ToString();
                tbIP.Text = Registry.GetValue(NodePath, lbIP.Tag.ToString(), "").ToString();
                tbDB.Text = Registry.GetValue(NodePath, lbDB.Tag.ToString(), "").ToString();
            }
            Reg.Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(!dxValidationProvider1.Validate()) return;
            //打開 子機碼 路徑。
            RegistryKey Reg = Registry.CurrentUser.OpenSubKey(NodeSoftWare, true);
            ////檢查子機碼是否存在，檢查資料夾是否存在。
            if (!Reg.GetSubKeyNames().Contains(NodeHR))
            {
                //建立子機碼，建立資料夾。
                Reg.CreateSubKey(NodeHR);                
            }
            
            //寫入資料 Name,Value,"寫入類型"
            RegKey(NodePath, lbID.Tag.ToString(), tbID.Text, RegistryValueKind.String);
            RegKey(NodePath, lbPW.Tag.ToString(), tbPW.Text, RegistryValueKind.String);
            RegKey(NodePath, lbIP.Tag.ToString(), tbIP.Text, RegistryValueKind.String);
            RegKey(NodePath, lbDB.Tag.ToString(), tbDB.Text, RegistryValueKind.String);
            Reg.Close();
        }

        private void RegKey(string xPAth, string xKey,string xValue, RegistryValueKind xKind)
        {
            Registry.SetValue(xPAth, xKey, xValue, xKind);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            Close();
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            //splashScreenManager1.ShowWaitForm();
            string ConnStr;
            ConnStr = $"Data Source = {tbIP.Text} ;Initial catalog = {tbDB.Text} ;" +
                      $"User id = {tbID.Text} ; Password = {tbPW.Text}";
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnStr);
            try
            {
                
                conn.Open();
                MsgForm msg = new MsgForm("連線成功!","訊息",1);
                //MsgForm msg = new MsgForm("C# 6.0 不是 C# 程式設計中的激進革命。不像引入泛型的 C# 2.0、 C# 3.0 和其開創性的方式到程式集合與 LlNQ 或簡化的非同步程式設計模式 5.0 C# 中，C# 6.0 不會改變發展。這就是說，C# 6.0 將改變在特定的場景，特點是效率高太多，你可能會忘了還有另一種方式，他們的代碼編寫 C# 代碼的方式。它介紹了新的語法快捷方式裝瘋賣傻，減少儀式和最終使編寫 C# 代碼的精簡。在這篇文章!", "訊息", 1);
                msg.ShowDialog();
            }
            catch
            {
                
            }
            finally
            {
                
            }
        }
    }
}