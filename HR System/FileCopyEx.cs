using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using static ClassForm.fc;

namespace HR_System
{
    public partial class FileCopyEx : DevExpress.XtraEditors.XtraForm
    {
        public FileCopyEx()
        {
            InitializeComponent();
        }

        List<string> FileLockedList = new List<string>();
        int FType = 0;
        List<string[]> P1 = null;//new List<string>(); 來原路徑及目的路徑
        List<string[]> P2 = null;//new List<string>(); 檔案名稱
        List<string[]> FFiles = null;//new List<string>(); 檔案名稱 //一般檔案用 [0] 來源 [1] 目的
        string Fmsg = "";
        public List<string[]> SetP1
        {
            set
            {
                P1 = value;
            }
        }
        public List<string[]> SetP2
        {
            set
            {
                P2 = value;
            }
        }
        public List<string[]> SetFile
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
            CheckVersionUpdate();
            timer1.Enabled = true;
            lb_Destination.Text = "";
            lb_Source.Text = "";
        }

        private void DoCopy()
        {

            try
            {
                /*if (P2[1].Length > 0) //20130904 ADD 新增只下載MODI
                {
                    if (!isDirectory(P1[3][1]))
                    {
                        Directory.CreateDirectory(P1[3][1]);
                    }
                    string[] s = Directory.GetFiles(P1[3][1]);
                    string error = "";
                    if (s.Length > 0)
                    {
                        //if (fc.ShowBoxMessage("是否刪除MODI下檔案?", "詢問", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                foreach (string str in s)
                                {
                                    File.Delete(str);
                                    error = str;
                                    Fmsg += "[" + DateTime.Now.ToString() + "] " + "已刪除 " + error + "\r\n";
                                }
                                Fmsg += "[" + DateTime.Now.ToString() + "] " + P1[3][1] + " 已打掃乾淨!\r\n";
                            }
                            catch (System.Exception ex)
                            {
                                Fmsg += "[" + DateTime.Now.ToString() + "] " + "刪除MODI檔案發生錯誤 <<" + error + ">>" + ex.Message + "\r\n";
                                Msg("刪除MODI檔案發生錯誤 <<" + error + ">>" + ex.Message + "\r\n","錯誤");
                                timer2.Enabled = true;

                                //throw;
                            }
                        }
                    }
                }*/
                SetPBC2(PBC1, P1);
                SetPBC2(PBC2, P2);
                int i = 0;
                int j = 0;
                int max = 0;
                if (P2[0].Length > 0) max++;
                if (P2[1].Length > 0) max++;
                if (P2[2].Length > 0) max++;
                if (P2[3].Length > 0) max++;
                PBC1.Properties.Maximum = max;
                /*if (CheckFileIsLock())//檢查是否有被LOCK的檔案
                {
                    BoxListBox b = new BoxListBox();
                    b.SetListBox = FileLockedList;
                    if (b.ShowDialog() == DialogResult.OK)
                    {
                        Fmsg = b.GetMsg;
                    }
                    else
                    {
                        Fmsg = "[" + DateTime.Now.ToString() + "] " + "有檔案正在使用中，停止下載程序!";
                        return;
                    }
                }
                */
                for (i = 0; i < P1.Count; i++)//0:安裝資料夾 1:PKG 2:System 3:MODI
                {
                    PBC2.Properties.Maximum = P2[i].Length;
                    PBC2.Position = 0;
                    for (j = 0; j < P2[i].Length; j++)
                    {

                        if (!Directory.Exists(P1[i][1]))
                        {
                            Directory.CreateDirectory(P1[i][1]);
                        }
                        lb_Source.Text = P1[i][0] + @"\" + P2[i][j];
                        lb_Destination.Text = P1[i][1] + @"\" + P2[i][j];
                        System.IO.File.Copy(lb_Source.Text, lb_Destination.Text, true);

                        Application.DoEvents();
                        PBC2.PerformStep();
                    }
                    if (P2[i].Length > 0)
                    {
                        Application.DoEvents();
                        PBC1.PerformStep();
                    }

                }
                Fmsg += "[" + DateTime.Now.ToString() + "] " + "打包成功!!\r\n";
            }
            catch (System.Exception ex)
            {
                Fmsg = "[" + DateTime.Now.ToString() + "] " + ex.Message+ "\r\n";
                Msg(ex.Message + "\r\n","錯誤");
                timer2.Enabled = true;

                //throw;
            }

        }
        private void SetPBC2(ProgressBarControl p, List<string[]> m)
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
        private void DoCopy2()
        {
            SetPBC2(PBC2, FFiles[0]);
            //for (i = 0; i < P1.Count; i++)//0:安裝資料夾 1:PKG 2:System 3:MODI
            {
                PBC2.Properties.Maximum = FFiles[0].Length;
                PBC2.Position = 0;
                for (int j = 0; j < FFiles[0].Length; j++)
                {
                    lb_Source.Text = FFiles[0][j];
                    lb_Destination.Text = FFiles[1][j];
                    System.IO.File.Copy(lb_Source.Text, lb_Destination.Text, true);
                    Application.DoEvents();
                    PBC2.PerformStep();
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (FType == 1)//複製對外區檔案到本機
            {
                DoCopy();
            }
            else if (FType == 2) //一般檔案複製 單純資料 無資料夾
            {
                PBC1.Visible = false;
                DoCopy2();
            }

            timer2.Enabled = true;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            this.DialogResult = DialogResult.OK;
        }

        private bool CheckFileIsLock()
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
        }

        private void CheckVersionUpdate()
        {
            try
            {
                string text = "";
                WebClient wc = new WebClient();
                UpdateInfo uflocal = null;
                UpdateInfo ufNew = null;
                if (File.Exists(Application.StartupPath + @"\AutoUpdater.json"))
                {
                    text = File.ReadAllText(Application.StartupPath + @"\AutoUpdater.json");
                    uflocal = (UpdateInfo)(JsonConvert.DeserializeObject(text, typeof(UpdateInfo)));
                    text = wc.DownloadString(uflocal.URL + @"\AutoUpdater.json");
                }

                if (!string.IsNullOrEmpty(text))
                {
                    //text = File.ReadAllText(Application.StartupPath + @"\AutoUpdater.json");
                    ufNew = (UpdateInfo)(JsonConvert.DeserializeObject(text, typeof(UpdateInfo)));
                }

                //ufNew = (UpdateInfo)(JsonConvert.DeserializeObject(text, typeof(UpdateInfo)));
                if (uflocal.Version != "")
                {
                    //如果客戶端將升級的應用程式的更新日期大於伺服器端升級的應用程式的更新日期 
                    if (!IsNewer(uflocal.Version, ufNew.Version))
                    {
                        //Msg("當前軟體已經是最新的，無需更新！", "系統提示");
                    }
                    else
                    {
                        //Msg("有新版本! 請按確定更新!", "系統提示");
                    }
                }
            }
            catch
            {

            }
            finally
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\" + "HR System.exe");
                Close();
            }
        }

    }
}
