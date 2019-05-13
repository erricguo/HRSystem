using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using static ClassForm.fc;

namespace ClassForm
{
    public partial class F2Form : RootForm
    {
        public F2Form(RootForm RF)
        {
            InitializeComponent();
            FRF = RF;
        }

        private void InitVar()
        {
            MIInfo = new string[2];
            MJInfo = new string[2];
            MIParam = null;
            MJParam = null;
            ResutnValus = null;
            DicMuity = new Dictionary<int, List<string>>();
            IsMuity = false;
            IsShow = true;
            F2 = null;
            FMIField = null;
        }
        string[] MIInfo = new string[2];
        string[] MJInfo = new string[2];
        string[] MIParam = null;
        string[] MJParam = null;
        string[] ResutnValus = null;
        Dictionary<int, List<string>> DicMuity = new Dictionary<int, List<string>>();
        bool IsMuity = false;
        bool IsShow = true;
        F2Object.Rootobject F2 = null;
        int FocusRowIndex = -1;
        RootForm FRF = null;
        string[] FMIField = null;

        public class F2Object
        {
            public class Rootobject
            {
                public string MAINSELECT { get; set; }
                public string[] ORDER { get; set; }
                public string[] RETURN { get; set; }
                public string[] DISPLAY { get; set; }
                public string[] PARAM { get; set; }
                public string[] GROUP { get; set; }
            }
        }

        public bool SetMuity
        {
            set
            {
                IsMuity = value;
                btnAll.Visible = true;
                btnUnAll.Visible = true;
            }
        }
        public string[] SetMI
        {
            set
            {
                InitVar();
                MIInfo = value;
            }
        }
        public string[] SetMJ
        {
            set
            {
                InitVar();
                MJInfo = value;
            }
        }
        public string[] SetMIParam
        {
            set
            {
                MIParam = value;
            }
        }
        public string[] SetMJParam
        {
            set
            {
                MJParam = value;
            }
        }
        public bool SetShowWindow
        {
            set
            {
                IsShow = value;
            }
        }
        public string[] SetMIField
        {
            set
            {
                FMIField = value;
            }
        }
        public string[] GetReturn
        {
            get
            {
                return ResutnValus;
            }
        }

        public Dictionary<int, List<string>> GetMuity
        {
            get
            {
                if (IsShow)
                {
                    return DicMuity;
                }
                else
                {
                    if (!QueryMIMuity(MIInfo))
                    {
                        MessageBox.Show("沒有符合的資料!", "提示");
                    }
                    else
                    {
                        SetAll();
                        GetResult();
                    }
                    return DicMuity;
                }
            }
        }

        public bool GetMI
        {
            get
            {
                if (!IsMuity)
                {
                    if (!QueryMI(MIInfo))
                    {
                        MessageBox.Show("沒有符合的資料!", "提示");
                        return false;
                    }
                    if (IsShow)
                    {
                        if (ShowDialog() == DialogResult.Cancel)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < F2.RETURN.Count(); i++)
                        {
                            ResutnValus[i] = GV_Main.GetRowCellValue(FocusRowIndex, F2.RETURN[i]).ToString();
                        }
                        return true;
                    }
                }
                else
                {
                    if (!QueryMIMuity(MIInfo))
                    {
                        MessageBox.Show("沒有符合的資料!", "提示");
                        return false;
                    }
                    if (IsShow)
                    {
                        if (ShowDialog() == DialogResult.Cancel)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return true;
                }
            }
        }

        public bool GetMJ
        {
            get
            {
                return QueryMJ(MJInfo);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            /*if (!IsMuity)
            {
                if (!QueryMI(MIInfo))
                {
                    MessageBox.Show("沒有符合的資料!", "提示");
                    this.DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
            else
            {
                QueryMIMuity(MIInfo);
            }   */
        }

        public bool QueryMJ(string[] xMJInfo)
        {
            String JsonStr = "";
            try
            { // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (SqlConnection conn = new SqlConnection(makeConnectString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT MJ003 FROM ADMMJ WHERE MJ001=@MJ001 AND MJ002=@MJ002", conn))
                    {
                        cmd.Parameters.AddWithValue("@MJ001", xMJInfo[0]);
                        cmd.Parameters.AddWithValue("@MJ002", xMJInfo[1]);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                JsonStr = dr["MJ003"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                ErrorLog(ex.Message);
                return false;
            }
            F2 = JsonConvert.DeserializeObject<F2Object.Rootobject>(JsonStr.Trim());

            if (F2 == null)
                return false;

            ResutnValus = new String[F2.RETURN.Length];

            using (SqlConnection conn = new SqlConnection(makeConnectString()))
            {
                try
                {
                    conn.Open();

                    for (int i = 0; i < F2.PARAM.Count(); i++)
                    {
                        F2.MAINSELECT = F2.MAINSELECT.Replace(F2.PARAM[i], "'" + MJParam[i] + "'");
                    }
                    using (SqlCommand cmd = new SqlCommand(F2.MAINSELECT, conn))
                    {
                        using (SqlDataAdapter sqldataadpt = new SqlDataAdapter(cmd))
                        {
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    for (int i = 0; i < F2.RETURN.Length; i++)
                                    {
                                        ResutnValus[i] = dr[i].ToString();
                                    }
                                    //JsonStr = dr[0].ToString();
                                }
                                else
                                {
                                    //JsonStr = "";
                                    return false;
                                }
                            }
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    ErrorLog(ex.Message);
                    return false;
                }
            }

        }
        public bool QueryMI(string[] xMIInfo)
        {
            GV_Main.Columns.Clear();
            String JsonStr = "";
            try
            { // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (SqlConnection conn = new SqlConnection(makeConnectString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT MI003 FROM ADMMI WHERE MI001=@MI001 AND MI002=@MI002", conn))
                    {
                        cmd.Parameters.AddWithValue("@MI001", xMIInfo[0]);
                        cmd.Parameters.AddWithValue("@MI002", xMIInfo[1]);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                JsonStr = dr["MI003"].ToString();
                            }
                        }
                    }
                }

                /*using (StreamReader sr = new StreamReader(xPath.Trim()))     //小寫TXT
                {
                    JsonStr = sr.ReadToEnd();
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                ErrorLog(ex.Message);
                return false;
            }

            if (JsonStr == "")
            {
                return false;
            }

            F2 = JsonConvert.DeserializeObject<F2Object.Rootobject>(JsonStr.Trim());
            ResutnValus = new String[F2.RETURN.Length];

            using (SqlConnection conn = new SqlConnection(makeConnectString()))
            {
                try
                {
                    conn.Open();
                    string OrderStr = "";
                    foreach (string s in F2.ORDER)
                    {
                        OrderStr += s + ",";
                    }
                    OrderStr = OrderStr.Substring(0, OrderStr.Length - 1);
                    if (F2.PARAM[0] != "0")
                    {
                        for (int i = 0; i < F2.PARAM.Count(); i++)
                        {
                            F2.MAINSELECT = F2.MAINSELECT.Replace(F2.PARAM[i], "'" + MIParam[i] + "'");
                        }
                    }

                    if (FMIField != null)
                    {
                        string mFilter = "";
                        DevExpress.XtraGrid.Views.Grid.GridView gv = FRF.GetGV(RootForm.GCNum.GCN_Body);
                        if (gv != null)
                        {
                            for (int i = 0; i < gv.RowCount; i++)
                            {
                                if (i == gv.FocusedRowHandle)
                                {
                                    continue;
                                }
                                object mvalue = gv.GetRowCellValue(i, FMIField[0]);
                                if (mvalue != null && mvalue.ToString() != "")
                                {
                                    if (i == 0)
                                    {
                                        if (F2.MAINSELECT.ToUpper().Contains("WHERE"))
                                            mFilter = " AND ";
                                        else
                                            mFilter = " WHERE ";
                                    }
                                    else
                                    {
                                        mFilter += " AND ";
                                    }
                                    mFilter += " " + FMIField[1] + " <> '" + mvalue.ToString() + "' ";
                                }
                            }
                            F2.MAINSELECT += mFilter;
                        }
                    }

                    if (F2.GROUP != null)
                    {
                        if (F2.GROUP.Count() > 0)
                        {
                            F2.MAINSELECT += " GROUP BY ";
                            for (int i = 0; i < F2.GROUP.Count(); i++)
                            {
                                F2.MAINSELECT += F2.GROUP[i] + ",";
                            }
                            if (F2.MAINSELECT.EndsWith(","))
                            {
                                F2.MAINSELECT = F2.MAINSELECT.Substring(0, F2.MAINSELECT.Length - 1);
                            }
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand(F2.MAINSELECT + " ORDER BY " + OrderStr, conn))
                    {
                        //myCommand = new SqlCommand(F2.MAINSELECT + " ORDER BY " + OrderStr, conn);
                        using (SqlDataAdapter sqldataadpt = new SqlDataAdapter(cmd))
                        {
                            //SqlDataAdapter sqldataadpt = new SqlDataAdapter(myCommand);  
                            DataTable dt1 = new DataTable();
                            sqldataadpt.Fill(dt1);
                            if (dt1.Rows.Count == 0)
                            {
                                return false;
                            }
                            else
                            {
                                GC_Main.DataSource = dt1;
                                for (int i = 0; i < GV_Main.Columns.Count; i++)
                                {
                                    GV_Main.Columns[i].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                                    GV_Main.Columns[i].Caption = F2.DISPLAY[i];
                                }
                                tbName.Properties.Items.Clear();
                                for (int i = 0; i < F2.DISPLAY.Count(); i++)
                                {
                                    tbName.Properties.Items.Add(GV_Main.Columns[i].FieldName + " " + F2.DISPLAY[i]);
                                }
                                if (tbName.Properties.Items.Count > 0)
                                {
                                    tbName.SelectedIndex = 0;
                                }
                                GV_Main.BestFitColumns();
                                return true;
                            }
                        }
                    }
                    //conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    ErrorLog(ex.Message);
                    return false;
                }
            }

        }



        public bool QueryMIMuity(string[] xMIInfo)
        {
            GV_Main.Columns.Clear();
            String JsonStr = "";
            try
            { // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (SqlConnection conn = new SqlConnection(makeConnectString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT MI003 FROM ADMMI WHERE MI001=@MI001 AND MI002=@MI002", conn))
                    {
                        cmd.Parameters.AddWithValue("@MI001", xMIInfo[0]);
                        cmd.Parameters.AddWithValue("@MI002", xMIInfo[1]);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                JsonStr = dr["MI003"].ToString();
                            }
                        }
                    }
                }

                /*using (StreamReader sr = new StreamReader(xPath.Trim()))     //小寫TXT
                {
                    JsonStr = sr.ReadToEnd();
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                ErrorLog(ex.Message);
                return false;
            }

            if (JsonStr == "")
            {
                return false;
            }
            F2 = JsonConvert.DeserializeObject<F2Object.Rootobject>(JsonStr.Trim());
            ResutnValus = new String[F2.RETURN.Length];

            if (F2.PARAM[0] != "0")
            {
                for (int i = 0; i < F2.PARAM.Count(); i++)
                {
                    F2.MAINSELECT = F2.MAINSELECT.Replace(F2.PARAM[i], "'" + MIParam[i] + "'");
                }
            }

            using (SqlConnection conn = new SqlConnection(makeConnectString()))
            {
                try
                {
                    conn.Open();
                    string OrderStr = "";
                    foreach (string s in F2.ORDER)
                    {
                        OrderStr += s + ",";
                    }
                    OrderStr = OrderStr.Substring(0, OrderStr.Length - 1);
                    using (SqlCommand cmd = new SqlCommand(F2.MAINSELECT + " ORDER BY " + OrderStr, conn))
                    {
                        //myCommand = new SqlCommand(F2.MAINSELECT + " ORDER BY " + OrderStr, conn);
                        using (SqlDataAdapter sqldataadpt = new SqlDataAdapter(cmd))
                        {
                            //SqlDataAdapter sqldataadpt = new SqlDataAdapter(myCommand);
                            DataTable dt1 = new DataTable();
                            sqldataadpt.Fill(dt1);
                            if (dt1.Rows.Count == 0)
                            {
                                return false;
                            }
                            else
                            {
                                dt1.Columns.Add("Select", typeof(string));
                                GC_Main.DataSource = dt1;

                                GV_Main.PopulateColumns();
                                GV_Main.Columns["Select"].VisibleIndex = 0;
                                GV_Main.Columns["Select"].Caption = "選擇";
                                RepositoryItemCheckEdit selectnew = new RepositoryItemCheckEdit();
                                GV_Main.Columns["Select"].ColumnEdit = selectnew;
                                selectnew.NullText = "";
                                selectnew.ValueChecked = "Y";
                                selectnew.ValueUnchecked = "N";
                                selectnew.ValueGrayed = "-";

                                //selectnew.QueryCheckStateByValue += new DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventHandler(QueryCheckStateByValue);
                                GV_Main.Columns["Select"].OptionsColumn.ReadOnly = false;
                                GV_Main.OptionsBehavior.Editable = true;
                                GV_Main.OptionsBehavior.ReadOnly = false;
                                GV_Main.OptionsSelection.MultiSelect = true;

                                for (int i = 0; i < GV_Main.Columns.Count - 1; i++)
                                {
                                    GV_Main.Columns[i].Caption = F2.DISPLAY[i];
                                }
                                tbName.Properties.Items.Clear();
                                for (int i = 0; i < F2.DISPLAY.Count(); i++)
                                {
                                    tbName.Properties.Items.Add(GV_Main.Columns[i].FieldName + " " + F2.DISPLAY[i]);
                                }
                                if (tbName.Properties.Items.Count > 0)
                                {
                                    tbName.SelectedIndex = 0;
                                }
                                GV_Main.BestFitColumns();
                                return true;
                            }
                        }
                    }
                    //conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    ErrorLog(ex.Message);
                    return false;
                }
            }

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (tbValue.Text == "")
            {
                GV_Main.ActiveFilterEnabled = false;
                GV_Main.ActiveFilterString = "";
                GV_Main.ActiveFilterEnabled = true;
                return;
            }
            string s = tbName.Text.Trim().Substring(0, 5);
            switch (tbFilter.SelectedIndex)
            {
                case 6: //%LIKE%
                    s += " Like " + " '%" + tbValue.Text + "%'";
                    break;
                case 7: //LIKE%
                    s += " Like " + " '" + tbValue.Text + "%'";
                    break;
                case 8: //%LIKE
                    s += " Like " + " '%" + tbValue.Text + "'";
                    break;
                default:
                    s += " " + tbFilter.Text + " '" + tbValue.Text + "'";
                    break;

            }
            string FilterStr = s;
            GV_Main.ActiveFilterEnabled = false;
            GV_Main.ActiveFilterString = FilterStr;
            GV_Main.ActiveFilterEnabled = true;
            GV_Main.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbValue.Text = "";
            GV_Main.ActiveFilterEnabled = false;
            GV_Main.ActiveFilterString = "";
            GV_Main.ActiveFilterEnabled = true;
        }

        private void GetResult()
        {
            DicMuity.Clear();
            if (GV_Main.RowCount > 0)
            {
                if (!IsMuity)
                {
                    for (int i = 0; i < F2.RETURN.Count(); i++)
                    {
                        ResutnValus[i] = GV_Main.GetRowCellValue(FocusRowIndex, F2.RETURN[i]).ToString();
                    }
                }
                else
                {
                    for (int i = 0; i < GV_Main.RowCount; i++)
                    {
                        if (GV_Main.GetRowCellValue(i, "Select").ToString() == "Y")
                        {
                            List<string> ls = new List<string>();
                            for (int j = 0; j < F2.RETURN.Length; j++)
                            {
                                ls.Add(GV_Main.GetRowCellValue(i, F2.RETURN[j]).ToString());
                            }
                            DicMuity.Add(i, ls);
                        }
                    }
                }
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (GV_Main.RowCount > 0)
            {
                GetResult();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void GV_Main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            FocusRowIndex = e.FocusedRowHandle;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            if (IsMuity)
            {
                tbValue.Focus();
            }
            else
            {
                btnOK.Focus();
            }
            if (GV_Main.Columns["XR005"] != null)
            {
                GV_Main.RowHeight = 32;
                GV_Main.Columns["XR005"].Width = 163;
                GV_Main.Columns["XR005"].MaxWidth = 163;
                GV_Main.Columns["XR005"].MinWidth = 163;
            }
        }

        DateTime mouseDownTime = DateTime.MinValue;
        GridCell mouseDownCell = new GridCell(GridControl.InvalidRowHandle, null);
        TimeSpan DoubleClickInterval = new TimeSpan(0, 0, 0, 0, 100);
        private void GV_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsMuity)
            {
                GridHitInfo hitInfo = GV_Main.CalcHitInfo(e.Location);
                if (hitInfo == null || hitInfo.Column == null)
                {
                    return;
                }
                if (hitInfo.InRowCell)
                {
                    if (hitInfo.Column.RealColumnEdit is RepositoryItemCheckEdit)
                    {
                        GV_Main.FocusedColumn = hitInfo.Column;
                        GV_Main.FocusedRowHandle = hitInfo.RowHandle;
                        GV_Main.ShowEditor();
                        CheckEdit edit = GV_Main.ActiveEditor as CheckEdit;
                        if (edit == null) return;
                        edit.Toggle();
                        DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                        GV_Main.CloseEditor();
                    }
                }
            }
            else
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    GridHitInfo hi = GV_Main.CalcHitInfo(e.Location);
                    if (hi == null || hi.Column == null)
                    {
                        return;
                    }
                    if (hi.InRowCell)
                    {
                        if (hi.RowHandle == mouseDownCell.RowHandle && hi.Column == mouseDownCell.Column && mouseDownTime - DateTime.Now < DoubleClickInterval)
                            DoRowDoubleClick(sender as GridView, e.Location);
                    }
                    mouseDownCell = new GridCell(hi.RowHandle, hi.Column);
                    mouseDownTime = DateTime.Now;
                }
            }
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                btnOK.PerformClick();
            }
        }

        private void SetAll()
        {
            for (int i = 0; i < GV_Main.RowCount; i++)
            {
                GV_Main.SetRowCellValue(i, "Select", "Y");
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            SetAll();
        }

        private void SetUnAll()
        {
            for (int i = 0; i < GV_Main.RowCount; i++)
            {
                GV_Main.SetRowCellValue(i, "Select", "N");
            }
        }

        private void btnUnAll_Click(object sender, EventArgs e)
        {
            SetUnAll();
        }

        private void F2Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnOK.PerformClick();
            }
            else if (e.KeyData == Keys.Escape)
            {
                btnCancel.PerformClick();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void tbValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnQuery.PerformClick();
            }
            else if (e.KeyData == Keys.Escape)
            {
                tbValue.Text = "";
            }
        }

        /*private void GV_Main_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "XR005")
            {
                if (GV_Main.GetRowCellValue(e.RowHandle, "XR005") != null)
                {
                    Bitmap img = new Bitmap(Properties.Resources.Grades0);
                    Bitmap img2 = null;
                    float mGrade = 0;
                    float.TryParse(GV_Main.GetRowCellValue(e.RowHandle, "XR005").ToString(), out mGrade);
                    if (mGrade >= 0)
                    {
                        img2 = new Bitmap(Properties.Resources.Grades50);
                    }
                    else
                    {
                        img2 = new Bitmap(Properties.Resources.Grades_50);
                    }
                    mGrade = Math.Abs(mGrade);
                    int mXR005 = (int)(mGrade / 5 * 160);
                    //int mXR005 = (int)(float.Parse(GV_Main.GetRowCellValue(e.RowHandle, "XR005").ToString()) / 5 * 160);
                    Graphics g = Graphics.FromImage(img);
                    g.DrawImage(img2, new Rectangle(0, 0, mXR005, 32), new Rectangle(0, 0, mXR005, 32), GraphicsUnit.Pixel);
                    e.Cache.Paint.DrawImage(e.Graphics, img, new Rectangle(e.Bounds.X, e.Bounds.Y, 160, 32));
                    e.Handled = true;
                }
            }
        }*/

        private void panelControl8_SizeChanged(object sender, EventArgs e)
        {
            panelControl9.Width = panelControl8.Width / 2;
        }
    }
}
