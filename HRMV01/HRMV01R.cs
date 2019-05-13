using System;
using System.ComponentModel;
using DevExpress.XtraReports.Parameters;
using System.Collections.Generic;
using DevExpress.DataAccess.Native.Sql;
using static ClassForm.fc;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;

namespace HRMV01
{
    public partial class HRMV01R : DevExpress.XtraReports.UI.XtraReport
    {
        public HRMV01R()
        {
            InitializeComponent();
        }

        private void HRMV01R_ParametersRequestBeforeShow(object sender, ParametersRequestEventArgs e)
        {
            try
            {
                var pCA002 = Parameters["CA002"];
                var pTA001 = Parameters["TA001"];

                List<string> TA001List = new List<string>();

                
                sqlDataSource1.Fill();
                ResultSet rSet = (sqlDataSource1 as IListSource).GetList() as ResultSet;
                ResultTable categoriesTable = rSet["Query"];
                List<ResultColumn> resColTA001 = rSet["Query"].Columns.FindAll((col) => col.Name == "TA001" || col.Name =="TA005");
                ResultColumn resColCA002 = rSet["Query"].Columns.Find((col) => col.Name == "CA002");
                for (int i = 0; i < categoriesTable.Count; i++)
                {
                    ResultRow rr = categoriesTable[i];
                    TA001List.Add(resColTA001[0].GetValue(rr).ToString());
                }
                pTA001.Value = TA001List;
                pCA002.Value = resColCA002.Values[0];
                
                

            }
            catch(Exception ex)
            {               
                Msg(ex.Message, "錯誤",-1);
            }
        }

        private void LookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            
            if (sender is LookUpEdit)
            {
                RepositoryItemLookUpEdit props = (sender as LookUpEdit).Properties;

                if (props != null && (e.Value is int))
                {
                    object row = props.GetDataSourceRowByKeyValue(e.Value);
                    if (row != null)
                    {
                        e.DisplayText = String.Format("{0} {1}", ((DataRowView)row)["TA001"], ((DataRowView)row)["TA005"]);
                    }
                }
            }
        }

        private void HRMV01R_ParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            xrLabel12.Text = (int.Parse(e.ParametersInformation[0].Parameter.Value.ToString()) - 1911).ToString();

        }
    }
}
