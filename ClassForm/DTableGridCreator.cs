using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;

namespace ClassForm
{
    public class DTableGridCreator : BaseGridCreator
    {
        //緩存的數據
        public BindingSource bindingSource = new BindingSource();
        private DataTable grid_data = new DataTable();
        //當前資料控制項
        private GridControl grid = null;
        private GridView gview = null;
        /// <summary>
        /// 構造函數
        /// </summary>
        public DTableGridCreator(GridControl gridctl)
        {
            grid = gridctl;
            gview = (GridView)grid.MainView;
            //gview.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(GridCreator_CustomDrawCell);
            gview.TopRowChanged += new System.EventHandler(GridCreator_TopRowChanged);
            bindingSource.DataSource = grid_data;
            grid.DataSource = bindingSource;
            //grid.DataSource = grid_data;
        }
        /// <summary>
        /// grid下拉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridCreator_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            int RowIndex = gview.GetFocusedDataSourceRowIndex();
            
            if (grid_data.Rows.Count > RowIndex + 1 || grid_data.Rows.Count >= row_count)
            {
                return;
            }
            if (RowIndex + 1 <= grid_data.Rows.Count)
            {
                page_num++;
                GetData();
            }
        }

        private void GridCreator_TopRowChanged(object sender, EventArgs e)
        {
            if ((gview.IsRowVisible(gview.RowCount - 1) != RowVisibleState.Visible)
                 || grid_data.Rows.Count >= row_count )
            //if (grid_data.Rows.Count > e. + 1 || grid_data.Rows.Count >= row_count)
            {
                return;
            }
            else//if (RowIndex + 1 <= grid_data.Rows.Count)
            {
                int idx = bindingSource.Position;
                page_num++;
                GetData();
                
                bindingSource.ResetBindings(false);
                bindingSource.Position = idx;
            }
        }

        public void PrepareNew()
        {
            grid_data.Rows.Clear();
            page_num = 1;
        }
        /// <summary>
        /// 獲取前兩頁數據
        /// </summary>
        public void PrepareData()
        {
            grid_data.Rows.Clear();
            page_num = 1;
            this.page_size = this.page_size * 2;
            GetData();
            this.page_size = this.page_size / 2;
            if (this.page_size < row_count)
            {
                page_num += 1;
            }
        }

        /// <summary>
        /// 即時的載入資料函數
        /// </summary>
        /// <returns></returns>
        public void GetData()
        {
            var data = GetDataEvent.Invoke(SQLStr, Filter, OrderBy, page_size, page_num, ref row_count, NewQuery, tableName) as DataTable;
            if (data == null) return;
            
            if (grid_data.Columns.Count < 1)
            {
                grid_data.TableName = data.TableName;
                foreach (DataColumn column in data.Columns)
                {                    
                    grid_data.Columns.Add(column.ColumnName).DefaultValue = column.DefaultValue;                    
                }
            }
            foreach (DataRow row in data.Rows)
            {
                grid_data.Rows.Add(row.ItemArray);                
            }

            grid_data.AcceptChanges();
            grid.RefreshDataSource();
            if(gview.Columns.Count <= 0)
              gview.PopulateColumns();
            gview.BestFitColumns();

            for (int i = 0; i < gview.Columns.Count; i++)
            {
                gview.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        //public void UpdateValue(DataTable dt)
        public void UpdateValue(BindingSource dt)
        {
            UpdateDataEvent.Invoke(dt);
        }

        //public void DeleteValue(DataTable dt)
        public void DeleteValue(BindingSource dt)
        {
            DeleteDataEvent.Invoke(dt);
        }
    }
}

