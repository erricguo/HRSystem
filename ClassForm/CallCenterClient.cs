using Microsoft.Win32;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static ClassForm.fc;



namespace ClassForm
{
    public class CallCenterClient
    {
        SqlConnection Conn = null;
        SqlDataAdapter dataAdapter = null;
        DataTable table = new DataTable();
        const string NodeSoftWare = "Software";
        const string NodeHR = "HRMSystem";
        const string NodePath = @"HKEY_CURRENT_USER\Software\" + NodeHR;

        public SqlCommand InserCmd { get; set; } = null;
        public SqlCommand UpdateCmd { get; set; } = null;
        public SqlCommand DeleteCmd { get; set; } = null;
        public bool CustomCmd { get; set; } = false; 
        public CallCenterClient()
        {

        }
        internal void Close()
        {
            throw new NotImplementedException();
        }

        internal void Abort()
        {
            throw new NotImplementedException();
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }

        private SqlDbType GetDBType(System.Type theType)
        {
            System.Data.SqlClient.SqlParameter p1;
            System.ComponentModel.TypeConverter tc;
            p1 = new System.Data.SqlClient.SqlParameter();
            tc = System.ComponentModel.TypeDescriptor.GetConverter(p1.DbType);
            if (tc.CanConvertFrom(theType))
            {
                p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
            }
            else
            {
                //Try brute force
                try
                {
                    p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
                }
                catch (Exception)
                {
                    //Do Nothing; will return NVarChar as default
                }
            }
            return p1.SqlDbType;
        }

        //internal void DeleteValue(DataTable dt)
        internal void DeleteValue(BindingSource bs)
        {
            Conn.Open();
            SqlTransaction trans = Conn.BeginTransaction();
            try
            {
                DataTable dt = ((DataTable)bs.DataSource);

                if (dataAdapter.InsertCommand != null)
                    dataAdapter.InsertCommand.Transaction = trans;
                if (dataAdapter.UpdateCommand != null)
                    dataAdapter.UpdateCommand.Transaction = trans;
                if (dataAdapter.DeleteCommand != null)
                    dataAdapter.DeleteCommand.Transaction = trans;

                dt = dt.GetChanges();
                if (dt.Rows.Count > 0)
                {
                    dataAdapter.Update(dt);
                    trans.Commit();
                }
            }
            catch (Exception ex)
            {
                ErrorLog(ex.Message);
                trans.Rollback();
            }
            finally
            {
                Conn.Close();
            }
        }
        //internal void UpdateValue(DataTable dt)
        internal void UpdateValue(BindingSource bs)
        {
            
            Conn.Open();
            SqlTransaction trans = Conn.BeginTransaction();
            try
            {
                DataTable dt = ((DataTable)bs.DataSource);
                if (dataAdapter.InsertCommand != null)
                    dataAdapter.InsertCommand.Transaction = trans;
                if (dataAdapter.UpdateCommand != null)
                    dataAdapter.UpdateCommand.Transaction = trans;
                if (dataAdapter.DeleteCommand != null)
                    dataAdapter.DeleteCommand.Transaction = trans;

                dt = dt.GetChanges();
                if (dt.Rows.Count > 0)
                {
                    dataAdapter.Update(dt);
                    trans.Commit();
                }
            }
            catch(Exception ex)
            {
                ErrorLog(ex.Message);
                trans.Rollback();
            }
            finally
            {
                Conn.Close();
            }

        }

        internal object GetDataList(string SQLStr,string Filter, string OrderBy, int page_size, int page_num, ref int row_count,bool NewQuery, string tableName)
        {
            DataTable table2 = new DataTable();
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSchema = new StringBuilder();
            //strSchema.Append($"SELECT TABLE_NAME, COLUMN_NAME, COLUMN_DEFAULT FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'");
            strSchema.Append($"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'");
            int row_begin = (page_size * (page_num - 1) + 1);
            int row_end = page_size * page_num;
            if (table.Rows.Count <= 0 || NewQuery)
            {
                try
                {
                    table.Clear();
                    /*string mID = "";
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
                                     $"User id = {mID} ; Password = {mPW}";*/

                    
                    strSql.Append(" SELECT * FROM ( ");
                    strSql.Append(" SELECT ROW_NUMBER() OVER ( ");
                    if (!string.IsNullOrEmpty(OrderBy.Trim()))
                    {
                        strSql.Append("order by " + OrderBy + " ) AS Rowss");
                    }
                    if (!string.IsNullOrEmpty(SQLStr.Trim()))
                    {
                        string mSQL = SQLStr.TrimStart().Substring(6);
                        if (!string.IsNullOrEmpty(Filter.Trim()))
                        {
                            if (mSQL.ToUpper().Contains("WHERE"))
                            {
                                mSQL += $" AND {Filter} ";
                            }
                            else
                            {
                                mSQL += $" WHERE {Filter} ";
                            }
                        }
                        strSql.Append($",{mSQL} ) TT ");
                    }

                    //strSql.Append($" WHERE TT.Rowss between {row_begin} and {row_end}");

                    //SqlConnection Conn = new SqlConnection(ConnStr);
                    Conn = new SqlConnection(makeConnectString());

                    // Create a new data adapter based on the specified query.
                    dataAdapter = new SqlDataAdapter(strSql.ToString(), Conn);
                    var da2 = new SqlDataAdapter(strSchema.ToString(), Conn);
                    DataTable dd = new DataTable();
                    da2.Fill(dd);

                    // Create a command builder to generate SQL update, insert, and
                    // delete commands based on selectCommand. These are used to
                    // update the database.
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    SqlDataAdapter da = new SqlDataAdapter($"SELECT TOP 1 * FROM {tableName}", Conn);
                    SqlCommandBuilder commandBuilder2 = new SqlCommandBuilder(da);
                    // Populate a new data table and bind it to the BindingSource.
                    //DataTable table = new DataTable();
                    //table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    commandBuilder2.ConflictOption = ConflictOption.OverwriteChanges; //Update的Where會變成PrimaryKey
                    dataAdapter.Fill(table);


                    if (InserCmd != null)
                    {
                        CustomCmd = true;
                        dataAdapter.InsertCommand = InserCmd;
                    }
                    else
                        dataAdapter.InsertCommand = commandBuilder2.GetInsertCommand().Clone();

                    if (UpdateCmd != null)
                    {
                        CustomCmd = true;
                        dataAdapter.UpdateCommand = UpdateCmd;
                    }
                    else
                        dataAdapter.UpdateCommand = commandBuilder2.GetUpdateCommand().Clone();

                    if (DeleteCmd != null)
                    {
                        CustomCmd = true;
                        dataAdapter.DeleteCommand = DeleteCmd;
                    }
                    else
                        dataAdapter.DeleteCommand = commandBuilder2.GetDeleteCommand().Clone();
                                       

                    foreach (DataColumn c in table.Columns)
                    {
                        foreach (DataRow r in dd.Rows)
                        {
                            if (r["COLUMN_NAME"].ToString() == c.ColumnName)
                            {
                                if(!string.IsNullOrEmpty(r["COLUMN_DEFAULT"].ToString()))
                                {
                                    string dvalue = r["COLUMN_DEFAULT"].ToString().Replace("('", "").Replace("')","");
                                    c.DefaultValue = dvalue;
                                }                                
                            }
                        }
                    }

                    row_count = table.Rows.Count;


                }
                catch (SqlException ex)
                {
                    ErrorLog(strSql.ToString());
                    ErrorLog(ex.ToString());
                    return null;
                }
            }

            try
            {
                if (table.Rows.Count > 0)
                {
                    var query = from row in table.AsEnumerable()
                                where (row.Field<long>("Rowss") >= row_begin && row.Field<long>("Rowss") <= row_end)
                                select row;


                    table2 = query.CopyToDataTable();
                    //table2.Columns.Remove("Rowss");                  
                 
                }
                else
                {
                    table2 = table.Clone();
                }
                table2.TableName = tableName;
                return table2;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
    }
}