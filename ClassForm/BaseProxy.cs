using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClassForm
{
    public class BaseProxy
    {
        protected CallCenterClient proxy = null;
        /// <summary>
        /// 构造函数初始化服务代理
        /// </summary>
        protected BaseProxy()
        {
            if (proxy == null)
            {
                proxy = new CallCenterClient();
            }
        }
        /// <summary>
        /// 释放当前的代理类
        /// </summary>
        public void Close()
        {
            try
            {
                proxy.Close();
            }
            catch
            {
                proxy.Abort();
            }
        }
        public void Open()
        {
            proxy.Open();
        }

        public SqlCommand InserCmd { get; set; } = null;
        public SqlCommand UpdateCmd { get; set; } = null;
        public SqlCommand DeleteCmd { get; set; } = null;

        public void SetSqlCmd()
        {
            proxy.InserCmd = InserCmd;
            proxy.UpdateCmd = UpdateCmd;
            proxy.DeleteCmd = DeleteCmd;
        }
        //轮询登录暂时没用
        #region 轮询登录
        /// <summary>
        /// 重新登录
        /// </summary>
        //protected void PollingLogin(string user_name,string pass_word)
        //{
        //    System.Timers.Timer timer = new System.Timers.Timer();
        //    timer.Interval = 1000 * 56;
        //    this.user_name = user_name;
        //    this.pass_word = pass_word;
        //    timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        //    timer.Enabled = true;
        //    timer.Start();

        //}
        //string user_name;
        //string pass_word;
        //void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    try
        //    {
        //        proxy.CheckLogin(user_name, pass_word);
        //    }
        //    catch
        //    {

        //    }
        //}
        #endregion
    }
}
