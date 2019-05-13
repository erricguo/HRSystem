using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Updater
{
    class fc
    {
        public static string MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string HRMDIR = MyDocumentsPath + "\\HRMSystem";
        public class UpdateFile
        {
            public string Name { get; set; }
            public string Version { get; set; }
        }

        public class UpdateInfo
        {
            public string URL { get; set; }
            public string Date { get; set; }
            public string Version { get; set; }
            public List<UpdateFile> UpdateFile { get; set; }
        }

        public static bool IsFileLocked(string file)
        {
            try
            {
                using (File.Open(file, FileMode.Open, FileAccess.Write, FileShare.None))
                {
                    return false;
                }
            }
            catch (IOException exception)
            {
                var errorCode = Marshal.GetHRForException(exception) & 65535;
                return errorCode == 32 || errorCode == 33;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void Msg(string xMsg = "")
        {
            MsgForm msg = new MsgForm(xMsg, "訊息", -1);
            msg.ShowDialog();
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

        public static List<string> GetFiles(string xPath,int xtype)//xtype 0.shortpath 1.fullpath
        {
            List<string> myList = new List<string>();

            // 執行檔路徑下的 MyDir 資料夾
            //string folderName = System.Windows.Forms.Application.StartupPath + @xPath;

            // 取得資料夾內所有檔案
            foreach (string fname in Directory.GetFiles(xPath))
            {
                if (xtype == 0)
                    myList.Add(Path.GetFileName(fname));
                else
                    myList.Add(fname);
               /* string line;

                // 一次讀取一行
                StreamReader file = new StreamReader(fname);
                while ((line = file.ReadLine()) != null)
                {
                    myList.Add(line.Trim());
                }

                file.Close();*/
            }
            return myList;
        }

        public static Dictionary<string,string> GetFiles(string xPath)//xtype 0.shortpath 1.fullpath
        {
            Dictionary<string, string> myList = new Dictionary<string, string>();

            // 執行檔路徑下的 MyDir 資料夾
            //string folderName = System.Windows.Forms.Application.StartupPath + @xPath;

            // 取得資料夾內所有檔案
            foreach (string fname in Directory.GetFiles(xPath))
            {
                myList.Add(Path.GetFileName(fname), fname);

                /* string line;

                 // 一次讀取一行
                 StreamReader file = new StreamReader(fname);
                 while ((line = file.ReadLine()) != null)
                 {
                     myList.Add(line.Trim());
                 }

                 file.Close();*/
            }
            return myList;
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
                //fc.ErrorLog(ex.Message);
            }
        }
    }
}
