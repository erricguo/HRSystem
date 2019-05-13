using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Reflection;
using System.IO;
using static ClassForm.fc;
using System.Runtime.InteropServices;
using System.Threading;
using DevExpress.XtraSplashScreen;
using Newtonsoft.Json;

namespace HR_System
{
    public partial class HRM_System : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        [DllImport("gdi32")]
        public static extern int AddFontResource(string lpFileName);
        string FProjectName = "HR System";
        Assembly FAssembly = null;
        int tabCount = 1;
        public HRM_System()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));           
            InitializeComponent();
            //Thread.Sleep(2000);
            for(int i=0;i<ribbonControl1.Pages.Count;i++)
            {
                for(int j=0;j<ribbonControl1.Pages[i].Groups.Count;j++)
                {
                    for(int k=0;k< ribbonControl1.Pages[i].Groups[j].ItemLinks.Count;k++)
                    {
                        if(ribbonControl1.Pages[i].Groups[j].ItemLinks[k].Item is BarButtonItem)
                        {
                            (ribbonControl1.Pages[i].Groups[j].ItemLinks[k].Item as BarButtonItem).ItemClick += barButtonItem_ItemClick;
                        }
                    }
                    
                }
            }
            installFont("YaHei Consolas Hybrid 1.12.ttf", "雅黑1.12");
            SplashScreenManager.CloseForm();

            //檢查更新
            //CheckVersionUpdate();
            


        }



        public static bool installFont(string FontFileName, string FontName)
        {
            string WinFontDir = System.Environment.GetEnvironmentVariable("WINDIR") + "\\fonts";
            int Ret;
            int Res;
            string FontPath;
            string FromFontPath = @"\http://kupoautos.com/HRM_System/YaHei Consolas Hybrid 1.12.ttf";
            //string FromFontPath = "http://abay1012.myweb.hinet.net/YaHei Consolas Hybrid 1.12.ttf";
            FontPath = WinFontDir + "\\" + FontFileName;
            try
            {
                if (!File.Exists(FontPath))
                {
                    File.Copy(FromFontPath, FontPath); //font是程序目录下放字体的文件夹
                    /*File.Copy(System.Windows.Forms.Application.StartupPath +
                        "\\font\\" + FontFileName, FontPath); //font是程序目录下放字体的文件夹*/
                    Ret = AddFontResource(FontPath);

                    //Res = SendMessage(HWND_BROADCAST, WM_FONTCHANGE, 0, 0); 
                    //WIN7下编译会出错，不清楚什么问题。注释就行了。  
                    //Ret = WriteProfileString("fonts", FontName + "(TrueType)", FontFileName);
                    Application.ExitThread();
                    Restart(Application.ExecutablePath);
                }
                /*else
                {
                    //fc.ErrorLog("[ " + FontName + " ]字体安装失败！原因：已安裝過該字型");
                }*/
            }
            catch (Exception ex)
            {
                ErrorLog("[ " + FontName + " ]字体安装失败！原因：" + ex.Message);
                return false;
            }
            return true;
        }

        private void barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ribbonControl1.Minimized = true;
            AddPageMdi(e.Item);
        }

        private void AddPageMdi(BarItem item)
        {
            
            if (!splashScreenManager1.IsSplashFormVisible)
            {
                //navBarControl1.Enabled = false;
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormDescription(item.Caption + "\r\n正在初始化.....");
                Application.DoEvents();
                //string path = FProjectName;//專案的Assembly選項名稱
                string[] name = item.Tag.ToString().Split('.');
                FAssembly = Assembly.Load(name[0]);
                Form doc = (Form)FAssembly.CreateInstance($"{name[0]}.{name[1]}");
                //doc.Show();
                doc.MdiParent = this;
                // 子窗体的 Text  就是 Tab页中的标题 ,我这里是直接取 navItem中的标题作为 tab页的标题
                doc.Text = item.Caption + " [" + name[0] + "]-" + String.Format("{0:D2}",tabCount++) ;
                // 显示  
                doc.Show();
                splashScreenManager1.SetWaitFormDescription(item.Caption + "\r\n正在初始化.....完成!");
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void HRM_System_Load(object sender, EventArgs e)
        {

        }
    }
}
