using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sharefc.fc;


namespace HRM_Updater
{
    public partial class FileCopyEx : DevExpress.XtraEditors.XtraForm
    {
        public FileCopyEx()
        {
            InitializeComponent();
        }
        string tempFile = "";
        //private WebClient webClient;
        UpdateInfo uflocal = null;
        UpdateInfo ufNew = null;
        List<string> FileLockedList = new List<string>();
        int FType = 0;
        List<string> P1 = null;//new List<string>(); 來原路徑及目的路徑
        List<string> P2 = null;//new List<string>(); 檔案名稱
        List<string> FFiles = null;//new List<string>(); 檔案名稱 //一般檔案用 [0] 來源 [1] 目的
        string Fmsg = "";
        public List<string> SetP1
        {
            set
            {
                P1 = value;
            }
        }
        public List<string> SetP2
        {
            set
            {
                P2 = value;
            }
        }
        public List<string> SetFile
        {
            set
            {
                FFiles = value;
            }
        }
        public string GetMsgInfo
        {
            get { return Fmsg; }
        }
        public int SetType
        {
            set { FType = value; }
        }

        private void FileCopyEx_Load(object sender, EventArgs e)
        {
            lb_Destination.Text = "";
            lb_Source.Text = "";
            tbCount.Text = "";
            CheckVersionUpdate();
        }

        private async Task DoCopy()
        {
            try
            {
                SetPBC2(PBC2, P2);
                PBC1.Properties.Maximum = 0;



                PBC2.Position = 0;
                for (int i = 0; i < P2.Count; i++)
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanger);
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                    //lb_Source.Text = $"[{i + 1}/{P2.Count}]  {P2[i]}";
                    lb_Source.Text = P2[i];
                    tbCount.Text = $"[{i + 1}/{P2.Count}]";
                    Uri mUri = new Uri(uflocal.URL + P2[i]);
                    
                    try
                    {
                        if (IsUriFileExist(mUri))
                        {
                            ErrorLog("下載:" + P2[i] + "，位置:" + uflocal.URL + P2[i]);
                            if (P2[i].ToUpper().EndsWith("HRM_UPDATER.EXE"))
                            {
                                tempFile = Path.GetTempFileName();
                                await webClient.DownloadFileTaskAsync(mUri, tempFile);
                            }
                            else
                            {                                
                                await webClient.DownloadFileTaskAsync(mUri, Application.StartupPath + "\\" + P2[i]);
                            }
                            //await webClient.DownloadFileTaskAsync(new Uri("http://tpdb.speed2.hinet.net/test_010m.zip"), Application.StartupPath + "\\" + P2[i]);
                        }
                        else
                        {
                            PBC2.PerformStep();
                            Application.DoEvents();
                            ErrorLog("[檔案不存在]:" + P2[i] + "，位置:" + uflocal.URL + P2[i]);
                            
                        }
                    }
                    catch(Exception ex)
                    {
                        PBC2.PerformStep();
                        Application.DoEvents();
                        ErrorLog($"[{ex.Message}]:" + P2[i] + "，位置:" + uflocal.URL + P2[i] + "，"+ex.Message);
                        
                    }
                }
            }
            catch (System.Exception ex)
            {
                PBC2.PerformStep();
                Application.DoEvents();
                Msg(ex.Message + "\r\n", "錯誤");
                ErrorLog(ex.Message);
            }
        }

        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            PBC2.PerformStep();
            ErrorLog("檔案名稱:" + lb_Source.Text);
            if (e.Error != null)
            {
                lb_Destination.Text = "下載檔案錯誤!";
                ErrorLog("下載檔案錯誤 e.Error" + e.Error.ToString());
                //this.DialogResult = DialogResult.No;
                //this.Close();
            }
            else if (e.Cancelled)
            {
                lb_Destination.Text = "取消下載";
                ErrorLog("取消下載 e.Cancelled");
                //this.DialogResult = DialogResult.Abort;
                //this.Close();
            }
            else
            {
                lb_Destination.Text = "更新檔案中...";
                ErrorLog("更新檔案中");               
                /*if(lb_Source.Text.ToUpper().EndsWith("HRM_UPDATER.EXE"))
                {
                    string currentPath = Assembly.GetExecutingAssembly().Location;
                    string newPath = Path.GetDirectoryName(currentPath) + "\\" + lb_Source.Text;
                    UpdateAoolication(tempFile, currentPath, newPath, "");
                    Close();
                }*/
            }
            
        }

        private void UpdateAoolication(string tempFilePath, string currentPath, string newPath, string launchArgs)
        {
            string argument = "/C Choice /C Y /N /D Y /T 4 & Del /F /Q \"{0}\" & Choice /C Y /N /D Y /T 2 & Move /Y \"{1}\" \"{2}\" & Start \"\" /D \"{3}\" \"{4}\" {5}";

            ProcessStartInfo info = new ProcessStartInfo();
            info.Arguments = string.Format(argument, currentPath, tempFilePath, newPath, Path.GetDirectoryName(newPath), Path.GetFileName(newPath), launchArgs);
            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.CreateNoWindow = true;
            info.FileName = "cmd.exe";
            Process.Start(info);
        }
        private void webClient_DownloadProgressChanger(object sender, DownloadProgressChangedEventArgs e)
        {
            PBC1.EditValue = (int)e.BytesReceived;
            PBC1.Properties.Maximum = (int)e.TotalBytesToReceive;
            Application.DoEvents();
            lb_Destination.Text = string.Format("下載 {0}/{1}", FormatBytes(e.BytesReceived, 1, true), FormatBytes(e.TotalBytesToReceive, 1, true));
        }
        private string FormatBytes(long bytes, int decimalPlaces, bool showByteType)
        {
            double newBytes = bytes;
            string formatString = "{0";
            string byteType = "B";

            if (newBytes > 1024 && newBytes < 1048576)
            {
                newBytes /= 1024;
                byteType = "KB";
            }
            else if (newBytes > 1048576 && newBytes < 1073741824)
            {
                newBytes /= 1048576;
                byteType = "MB";
            }
            else
            {
                newBytes /= 1073741824;
                byteType = "GB";
            }

            if (decimalPlaces > 0)
                formatString += ":0.";

            for (int i = 0; i < decimalPlaces; i++)
                formatString += "0";

            formatString += "}";

            if (showByteType)
                formatString += byteType;

            return string.Format(formatString, newBytes);

        }

        //private void SetPBC2(ProgressBarControl p, List<string[]> m)
        private void SetPBC2(ProgressBarControl p, List<string> m)
        {
            //设置一个最小值
            p.Properties.Minimum = 0;
            //设置一个最大值
            p.Properties.Maximum = m.Count;
            //设置步长，即每次增加的数
            p.Properties.Step = 1;
            //设置进度条的样式
            p.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            p.Position = 0;
        }
        private void SetPBC1(ProgressBarControl p, List<string> m)
        {
            //设置一个最小值
            p.Properties.Minimum = 0;
            //设置一个最大值
            p.Properties.Maximum = m.Count;
            //设置步长，即每次增加的数
            p.Properties.Step = 1;
            //设置进度条的样式
            p.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            p.Position = 0;
        }
        private void SetPBC2(ProgressBarControl p, string[] m)
        {
            //设置一个最小值
            p.Properties.Minimum = 0;
            //设置一个最大值
            p.Properties.Maximum = m.Length;
            //设置步长，即每次增加的数
            p.Properties.Step = 1;
            //设置进度条的样式
            p.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            p.Position = 0;
        }

       /* private bool CheckFileIsLock()
        {
            for (int i = 0; i < P1.Count; i++)//0:安裝資料夾 1:PKG 2:System 3:MODI
            {
                for (int j = 0; j < P2[i].Length; j++)
                {
                    if (!Directory.Exists(P1[i][1]))
                    {
                        continue;
                    }
                    lb_Destination.Text = P1[i][1] + @"\" + P2[i][j];
                    if (!File.Exists(lb_Destination.Text))
                    {
                        continue;
                    }
                    if (IsFileLocked(lb_Destination.Text))
                    {
                        FileLockedList.Add(lb_Destination.Text);
                    }
                }
            }
            if (FileLockedList.Count > 0)
            {
                return true;
            }
            else
                return false;
        }*/

        private async void CheckVersionUpdate()
        {
            bool isUpdateTools = false;
            try
            {
                string text = "";
                WebClient wc = new WebClient();
                if (File.Exists(Application.StartupPath + @"\AutoUpdater.json"))
                {
                    text = File.ReadAllText(Application.StartupPath + @"\AutoUpdater.json");
                    uflocal = (UpdateInfo)(JsonConvert.DeserializeObject(text, typeof(UpdateInfo)));
                    text = wc.DownloadString(uflocal.URL + @"\AutoUpdater.json");


                   
                    if (!string.IsNullOrEmpty(text))
                    {
                        ufNew = (UpdateInfo)(JsonConvert.DeserializeObject(text, typeof(UpdateInfo)));

                        List<string> downloadList = new List<string>();
                        //如果客戶端將升級的應用程式的更新日期大於伺服器端升級的應用程式的更新日期 
                        for (int i = 0; i < ufNew.UpdateFile.Count; i++)
                        {
                            Dictionary<string, string> dicfiles = GetFiles(Application.StartupPath);
                            if (ufNew.UpdateFile[i].Name.ToUpper().Contains("AutoUpdater.json".ToUpper()))
                            {
                                if (IsNewer(uflocal.Version, ufNew.UpdateFile[i].Version))
                                {
                                    ErrorLog("[加入下載]:" + ufNew.URL + ufNew.UpdateFile[i].Name);
                                    downloadList.Add(ufNew.UpdateFile[i].Name);
                                }
                            }
                            else
                            {
                                if (dicfiles.ContainsKey(ufNew.UpdateFile[i].Name))
                                {
                                    try
                                    {
                                        //如果存在檔案就比較版本
                                        FileVersionInfo info = FileVersionInfo.GetVersionInfo(dicfiles[ufNew.UpdateFile[i].Name]);

                                        if (!IsNewer(info.FileVersion, ufNew.UpdateFile[i].Version))
                                        {
                                            //Msg("當前軟體已經是最新的，無需更新！", "系統提示");
                                        }
                                        else
                                        {
                                            ErrorLog("[加入下載]:" + ufNew.URL + ufNew.UpdateFile[i].Name);
                                            downloadList.Add(ufNew.UpdateFile[i].Name);
                                            if (ufNew.UpdateFile[i].Name == "HRM_Updater.exe")
                                            {
                                                isUpdateTools = true;
                                                //break;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        ErrorLog($"取得檔案資訊錯誤:{ufNew.UpdateFile[i].Name} " + ex.Message);
                                    }
                                }
                                else //如果本機不存在檔案就下載
                                {
                                    ErrorLog("[加入下載]:" + ufNew.URL + ufNew.UpdateFile[i].Name);
                                    downloadList.Add(ufNew.UpdateFile[i].Name);
                                    if (ufNew.UpdateFile[i].Name == "HRM_Updater.exe")
                                    {
                                        isUpdateTools = true;
                                        //break;
                                    }
                                }
                            }
                        }
                        /*if(downloadList.Count > 0 && !isUpdateTools)
                            downloadList.Add("AutoUpdater.json");*/

                        SetP2 = downloadList;
                        await DoCopy();
                    }
                }
                else
                {
                    ErrorLog(Application.StartupPath + @"\AutoUpdater.json 檔案不存在!");
                }
            }
            catch(Exception ex)
            {
                ErrorLog(ex.Message);
            }
            finally
            {
                if (isUpdateTools)
                {
                    string currentPath = Assembly.GetExecutingAssembly().Location;
                    string newPath = Path.GetDirectoryName(currentPath) + "\\HRM_Updater.exe";
                    UpdateAoolication(tempFile, currentPath, newPath, "");
                    Close();
                }
                else
                {
                    //Msg("OK!");
                    if (File.Exists(Application.StartupPath + "\\" + "HR System.exe"))
                    {
                        ErrorLog("重新啟動HRM");
                        Process.Start(Application.StartupPath + "\\" + "HR System.exe");
                    }
                    Close();
                }
            }
        }

        public bool IsUriFileExist(Uri xuri)
        {
            bool result = false;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = WebRequest.Create(xuri) as HttpWebRequest;
                request.Proxy = null;//不使用代理 .NET4.0中的默认代理是开启的
                request.KeepAlive = false;//不建立持久性连接
                request.Timeout = 3000;//连接网址的超时时间
                request.ReadWriteTimeout = 3000;//读取网址内容的超时时间      
                response = request.GetResponse() as HttpWebResponse;
                long length = response.ContentLength;
                response.Close();
                result = true;
                return result;
            }
            catch (WebException webEx)
            {
                response.Close();
                return result;
            }
        }
    }
}
