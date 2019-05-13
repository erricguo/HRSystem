using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.Data.SqlClient;
using static ClassForm.fc;
using System.Windows.Forms;

namespace ClassForm
{
                                               
    public delegate object GetDataListDelegate(string SQLStr, string Filter, string OrderBy, int page_size, int page_num, ref int row_count, bool NewQuery, string tableName);
    //public delegate void UpdateValueDelegate(DataTable dt);
    public delegate void UpdateValueDelegate(BindingSource dt);
    //public delegate void DeleteValueDelegate(DataTable dt);
    public delegate void DeleteValueDelegate(BindingSource dt);
    public class BaseGridCreator
    {
        //一頁有多少條數據
        protected int page_size = 20;
        public int PageSize
        {
            get { return page_size; }
            set { page_size = value; }
        }
        /// <summary>
        /// 過濾條件
        /// </summary>
        public string Filter
        {
            get;
            set;
        }
        /// <summary>
        /// SQL
        /// </summary>
        public string SQLStr
        {
            get;
            set;
        }

        /// <summary>
        /// 排序條件
        /// </summary>
        public string OrderBy
        {
            get;
            set;
        }
        /// <summary>
        /// 數據存取方法
        /// </summary>
        public GetDataListDelegate GetDataEvent
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public UpdateValueDelegate UpdateDataEvent
        {
            get;
            set;
        }

        public DeleteValueDelegate DeleteDataEvent
        {
            get;
            set;
        }
        protected int row_count;
        /// <summary>
        /// 總行數
        /// </summary>
        public int RowCount
        {
            get { return row_count; }
        }
        protected int page_num = 1;
        /// <summary>
        /// 當前的資料頁
        /// </summary>
        public int PageNum
        {
            get { return page_num; }
        }
        /// <summary>
        /// 新查詢
        /// </summary>
        public bool NewQuery
        {
            get;
            set;
        }
        /// <summary>
        /// 新增修改刪除的指令
        /// </summary>
        public CommandBuilderEx cmdBuilder
        {
            get;
            set;
        }

        public string tableName
        {
            get;
            set;
        }
    }
}

