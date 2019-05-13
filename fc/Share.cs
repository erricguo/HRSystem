using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fc
{
    public class Share
    {
        public static string MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string HRMDIR = MyDocumentsPath + "\\HRMSystem";
        const string NodeSoftWare = "Software";
        const string NodeHR = "HRMSystem";
        const string NodePath = @"HKEY_CURRENT_USER\Software\" + NodeHR;

        public class UpdateFileList
        {
            public string Name { get; set; }
            public string Version { get; set; }
        }

        public class UpdateInfo
        {
            public string URL { get; set; }
            public string Date { get; set; }
            public string Version { get; set; }
            public UpdateFileList UpdateFileList { get; set; }
        }



        public class CommandBuilderEx
        {
            public SqlCommand InserCmd { get; set; } = null;
            public SqlCommand UpdateCmd { get; set; } = null;
            public SqlCommand DeleteCmd { get; set; } = null;
        }
        public class SchemaList
        {

            public string FieldName { get; set; } = "";
            public string FieldCaption { get; set; } = "";
            public GCData GCDataType { get; set; } = GCData.GCD_String;

            public ComboBoxItemCollection ValueDisplay { get; set; } = null;

            public SchemaList(GCData xGCDataType, string xFieldName, string xFieldCaption)
            {
                FieldName = xFieldName;
                FieldCaption = xFieldCaption;
                GCDataType = xGCDataType;
            }

            public SchemaList(GCData xGCDataType, string xFieldName, string xFieldCaption, ComboBoxItemCollection xValueDisplay)
            {
                FieldName = xFieldName;
                FieldCaption = xFieldCaption;
                ValueDisplay = xValueDisplay;
                GCDataType = xGCDataType;
            }
        }

        public static bool IsNewer(string xOldVersion, string xNewVersion)
        {
            bool mResult = false;
            string[] oldVersion = xOldVersion.Split('.');
            string[] newVersion = xNewVersion.Split('.');

            for (int i = 0; i < oldVersion.Length; i++)
            {
                if (Int32.Parse(newVersion[i]) > Int32.Parse(oldVersion[i]))
                {
                    mResult = true;
                }
            }

            return mResult;
        }

        public static object iif(bool xBool, object Obja, object Objb)
        {
            if (xBool)
                return Obja;
            else
                return Objb;
        }

        public static void Msg(string xMsg = "", string xCaption = "訊息")
        {
            MsgForm msg = new MsgForm(xMsg, xCaption, -1);
            msg.ShowDialog();
        }

        public static void Msg(string xMsg = "", string xCaption = "訊息", int xSeconds = -1)
        {
            MsgForm msg = new MsgForm(xMsg, xCaption, xSeconds);
            msg.ShowDialog();
        }

        public static void Msg(string xMsg = "", string xCaption = "訊息", int xSeconds = -1, int xWidth = 462, int xHeight = 279)
        {
            MsgForm msg = new MsgForm(xMsg, xCaption, xSeconds, xWidth, xHeight);
            msg.ShowDialog();
        }

        public static void ErrorLog(string xStr)
        {
            try
            {
                string filepath = HRMDIR + "\\Log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                if (!File.Exists(filepath))
                {
                    if (!Directory.Exists(fc.HRMDIR))
                    {
                        Directory.CreateDirectory(fc.HRMDIR);
                    }
                    /*if (!Directory.Exists(fc.COSMOSRESDIR))
                    {
                        Directory.CreateDirectory(fc.COSMOSRESDIR);
                    }*/
                    File.Create(filepath).Close();
                }
                // 建立檔案串流（@ 可取消跳脫字元 escape sequence）
                StreamWriter sw = new StreamWriter(filepath, true, Encoding.Default);
                string mStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\t\t" + xStr;
                sw.WriteLine(mStr);
                sw.Close();
            }
            catch (Exception ex)
            {
                Msg(ex.Message.ToString(), "錯誤");
                fc.ErrorLog(ex.Message);
            }
        }

        public static void Restart(string appName)
        {
            System.Threading.Thread thtmp = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(run));
            //object appName = Application.ExecutablePath;
            //System.Threading.Thread.Sleep(2000);
            thtmp.Start(appName);
        }
        private static void run(Object obj)
        {
            System.Diagnostics.Process ps = new System.Diagnostics.Process();
            ps.StartInfo.FileName = obj.ToString();
            ps.Start();
        }

        public static string makeConnectString()
        {
            string mID = "";
            string mPW = "";
            string mIP = "";
            string mDB = "";

            //打開 子機碼 路徑。
            RegistryKey Reg = Registry.CurrentUser.OpenSubKey(NodeSoftWare, true);
            ////檢查mDB子機碼是否存在，檢查資料夾是否存在。
            if (Reg.GetSubKeyNames().Contains(NodeHR))
            {
                mID = Registry.GetValue(NodePath, "ID", "").ToString();
                mPW = Registry.GetValue(NodePath, "PW", "").ToString();
                mIP = Registry.GetValue(NodePath, "IP", "").ToString();
                mDB = Registry.GetValue(NodePath, "DB", "").ToString();
            }
            Reg.Close();

            string ConnStr = $"Data Source = {mIP} ;Initial catalog = {mDB} ;" +
                             $"User id = {mID} ; Password = {mPW}";

            return ConnStr;
            //return new SqlConnection(ConnStr);
        }
    }
}
