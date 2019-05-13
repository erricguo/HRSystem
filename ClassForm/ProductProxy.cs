using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static ClassForm.fc;

namespace ClassForm
{
    public class ProductProxy : BaseProxy
    {
        /// <summary>
        /// 獲得商品分類的Code
        /// </summary>
        /// <returns></returns>
        /*public string GetCateCodeByTradeId(string cate_id)
        {
            try
            {
                return proxy.GetCateCodeByTradeId(cate_id);
            }
            catch
            {
                return null;
            }
        }*/
        /// <summary>
        /// 判斷是否為搬家訂單
        /// </summary>
        /// <param name="trade_id"></param>
        /// <returns></returns>
        /*public bool IsHouseMove(string trade_id)
        {
            try
            {
                return proxy.IsHouseMoveOrder(trade_id);
            }
            catch
            {
                return false;
            }
        }*/
        /// <summary>
        /// 獲取產品清單
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetDataList(string SQLStr, string Filter, string OrderBy, int page_size, int page_num, ref int row_count, bool NewQuery, string tableName)
        {
            try
            {
                object obj = proxy.GetDataList(SQLStr, Filter, OrderBy, page_size, page_num, ref row_count, NewQuery, tableName) as object;
                return obj;
            }
            catch
            {
                return null;
            }
        }

        //public void UpdateValue(DataTable dt)
        public void UpdateValue(BindingSource dt)
        {
            try
            {
                proxy.UpdateValue(dt);
                
            }
            catch
            {
                
            }
        }
        //public void DeleteValue(DataTable dt)
        public void DeleteValue(BindingSource dt)
        {
            try
            {
                proxy.DeleteValue(dt);

            }
            catch
            {

            }
        }
        /// <summary>
        /// 獲取產品商家清單
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /*public object GetProductShops(string filter, string order_by, int page_size, int page_num, ref int count)
        {
            try
            {
                return proxy.GetProductShopList(filter, order_by, page_size, page_num, ref count) as object;
            }
            catch
            {
                return null;
            }
        }*/
    }
}

