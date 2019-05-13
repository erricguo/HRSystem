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
using System.Reflection;

namespace HRMB01
{
    public partial class HRMB01F : BanchForm
    {
        //DataGridView dataGridView1 = new DataGridView();
        public HRMB01F()
        {
            InitializeComponent();
        }

        private void HRMB01F_Load(object sender, EventArgs e)
        {
            de01.Properties.VistaCalendarViewStyle = VistaCalendarViewStyle.YearsGroupView;
            de01.DateTime = DateTime.Now;
            
            
        }

        protected override void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnOK.Enabled = false;
            btnCancel.Enabled = false;
            try
            {
                //base.btnOK_ItemClick(sender,e);
                string SQLStr = "SELECT TA001 工號,TA005 姓名,TA002 到職日,'' 特休時數 FROM HRMTA WHERE TA017 ='N' ";

                SqlConnection conn = new SqlConnection(makeConnectString());
                SqlDataAdapter da = new SqlDataAdapter(SQLStr, conn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                DataTable dt = new DataTable("HRMTA");
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                ProgressForm pf = new ProgressForm(0, dataGridView1.Rows.Count, 0, 1);
                pf.Show();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    pf.Msg($"處理中..工號[{dataGridView1.Rows[i].Cells[0].Value.ToString()}] {dataGridView1.Rows[i].Cells[1].Value.ToString()}");
                    dataGridView1.Rows[i].Cells[3].Value = Calc(dataGridView1.Rows[i].Cells[2].Value.ToString(),
                                                                dataGridView1.Rows[i].Cells[0].Value.ToString(),
                                                                dataGridView1.Rows[i].Cells[1].Value.ToString());
                    pf.Step();
                }
                pf.Close();
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 130;
                dataGridView1.Columns[3].Width = 130;

                //刪掉舊資料
                DeleteOldTable($"DELETE FROM HRMCA WHERE CA002='{de01.Text}'");
                //SAVE
                DataTable dt2 = (DataTable)dataGridView1.DataSource;
                var query = dt2.AsEnumerable()
                            .Select(row => new
                            {
                                CA001 = row.Field<string>("工號"),
                                CA002 = de01.Text,
                                CA003 = row.Field<string>("到職日"),
                                CA004 = row.Field<string>("特休時數")
                            });


                DataTable table2 = ToDataTable(query.ToList(), "HRMCA");
                InsertV4(table2);
                Msg("執行成功!");
            }
            catch(Exception ex)
            {

            }
            finally
            {
                btnOK.Enabled = true; 
                btnCancel.Enabled = true;
            }
        }

        private bool DeleteOldTable(string xSQL)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(makeConnectString()))
                {
                    conn.Close();
                    var cmd = new SqlCommand(xSQL, conn);
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (i > 0)
                    {
                        ErrorLog($"{xSQL}，執行成功!");
                        return true;
                    }
                    else
                    {
                        ErrorLog($"{xSQL}，沒有可刪除的資料!");
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                ErrorLog(ex.Message);
                return false;
            }
        }

        private int Calc(string xDate, string id, string name)
        {
            
            DateTime dt = DateTime.Parse(xDate);
            if (id == "006")
            {
                dt = dt.AddYears(-4);
                dt = dt.AddMonths(-3);
            }
            //de01.Value = new DateTime(de01.Value.Year, de01.Value.Month, de01.Value.Day);
            int m_Year = 0;
            int m_Month = dt.Month;
            int mResult = 0;
            //MsgLog($"[{id}] {name}");
            if (de01.DateTime.Year == 2017)
            {
                if (dt <= new DateTime(2016, 1, 1))
                {
                    m_Year = 2017 - dt.Year;

                    //MsgLog($"{de01.Value.ToString("yyyy/MM/dd")} ~ {de01.Value.AddYears(m_Year).ToString("yyyy/MM/dd")} = {GetVacationDays(m_Year)}");
                    mResult = GetVacationDays(m_Year, m_Month);
                }
                else if (dt > new DateTime(2016, 1, 1) &&
                        dt <= new DateTime(2016, 6, 30))
                {
                    //MsgLog($"{de01.Value.ToString("yyyy/MM/dd")} ~ {new DateTime(2017, 1, 1).ToString("yyyy/MM/dd")} = 24");
                    //MsgLog($"{de01.Value.ToString("yyyy/MM/dd")} ~ {de01.Value.AddYears(1).ToString("yyyy/MM/dd")} = 56");
                    mResult = 80;
                }
                else if (dt >= new DateTime(2016, 7, 1) &&
                         dt <= new DateTime(2016, 12, 31))
                {
                    //MsgLog($"{de01.Value.ToString("yyyy/MM/dd")} ~ {de01.Value.AddMonths(6).ToString("yyyy/MM/dd")} = 24");
                    //MsgLog($"{de01.Value.ToString("yyyy/MM/dd")} ~ {de01.Value.AddYears(1).ToString("yyyy/MM/dd")} = 56");
                    mResult = 80;
                }
                else // >= 2017/1/1
                {
                    if (dt.AddMonths(6).Year == dt.Year)  //20170710 mark 20170821 unmark
                    //if (dt.Year == dt.Year)  //20170710 MODI  EX:201707以後進來的人，天數會變成0                                        
                    {
                        //MsgLog($"{de01.Value.ToString("yyyy/MM/dd")} ~ {de01.Value.AddMonths(6).ToString("yyyy/MM/dd")} = 24");
                        mResult = 24;
                    }

                }
            }
            else if (de01.DateTime.Year > 2017)
            {
                if (dt.Year == de01.DateTime.Year) //等於 EX: 2018 = 2018
                {
                    //MsgLog($"{de01.Value.ToString("yyyy/MM/dd")} ~ {de01.Value.AddMonths(6).ToString("yyyy/MM/dd")} = 24");
                    mResult = 24;
                }
                else //小於 EX: 2017 = 2018 ， 2016 = 2018
                {
                   /* if (dt.Year == de01.DateTime.Year - 1) //2017  2018
                    {
                        //MsgLog($"{de01.Value.ToString("yyyy/MM/dd")} ~ {de01.Value.AddMonths(6).ToString("yyyy/MM/dd")} = 24");
                        //MsgLog($"{de01.Value.ToString("yyyy/MM/dd")} ~ {de01.Value.AddYears(1).ToString("yyyy/MM/dd")} = 56");
                        mResult = 80;
                    }
                    else //到職日2年以上*/
                    {
                        m_Year = de01.DateTime.Year - dt.Year;               
                        //MsgLog($"{de01.Value.ToString("yyyy/MM/dd")} ~ {de01.Value.AddYears(m_Year).ToString("yyyy/MM/dd")} = {GetVacationDays(m_Year)}");
                        mResult = GetVacationDays(m_Year, m_Month);
                    }
                }
            }

            //MsgLog($"                     合計:{mResult}");
            //MsgLog("一一一一一一一一一一一一一一一");
            return mResult;
        }

        private int GetVacationDays(int xyear,int xmonth)
        {
            int days = 0;
            int hours = 0;

            if (xyear < 0.5)
                days = 0;
            else if (xyear >= 0.5 && xyear < 1)
                days = 3;
            else if (xyear >= 1 && xyear < 2)
            {
                days = 7;
                if (xmonth >= 7)
                {
                    days += 3;
                }                
            }
            else if (xyear >= 2 && xyear < 3)
                days = 10;
            else if (xyear >= 3 && xyear < 5)
                days = 14;
            else if (xyear >= 5 && xyear < 10)
                days = 15;
            else if (xyear >= 10 && xyear < 11)
                days = 16;
            else if (xyear >= 11 && xyear < 12)
                days = 17;
            else if (xyear >= 12 && xyear < 13)
                days = 18;
            else if (xyear >= 13 && xyear < 14)
                days = 19;
            else if (xyear >= 14 && xyear < 15)
                days = 20;
            else if (xyear >= 15 && xyear < 16)
                days = 21;
            else if (xyear >= 16 && xyear < 17)
                days = 22;
            else if (xyear >= 17 && xyear < 18)
                days = 23;
            else if (xyear >= 18 && xyear < 19)
                days = 24;
            else if (xyear >= 19 && xyear < 20)
                days = 25;
            else if (xyear >= 20 && xyear < 21)
                days = 26;
            else if (xyear >= 21 && xyear < 22)
                days = 27;
            else if (xyear >= 22 && xyear < 23)
                days = 28;
            else if (xyear >= 23 && xyear < 24)
                days = 29;
            else if (xyear >= 24)
                days = 30;

            hours = days * 8;
            return hours;

        }

        private void InsertV4(DataTable srcdata)
        {
            using (SqlConnection conn = new SqlConnection(makeConnectString()))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    //SqlBulkCopy批次處理新增 沒有檢驗比對處理
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity, trans))
                    {
                        bulkCopy.DestinationTableName = "dbo.HRMCA";
                        bulkCopy.WriteToServer(srcdata);
                    }

                    trans.Commit();
                    ErrorLog("InsertV4 儲存資料成功!");
                }
                catch(Exception ex)
                {
                    ErrorLog(ex.Message);
                    trans.Rollback();
                }

            }
        }

        private DataTable ToDataTable<T>(List<T> items, string xTableName)
        {
            //var tb = new DataTable(typeof(T).Name);
            var tb = new DataTable(xTableName);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }


            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }


            return tb;
        }
        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }
    }
}