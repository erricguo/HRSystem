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
using static ClassForm.fc;
using static ClassForm.RootForm;

namespace ClassForm
{
    public partial class QueryForm : DevExpress.XtraEditors.XtraForm
    {
        private List<SchemaList> Schemas = null;
        BaseEdit tb = new TextEdit();
        BaseEdit chk = new CheckEdit();
        BaseEdit cbo = new ComboBoxEdit();
        List<BaseEdit> BeList = new List<BaseEdit>();
        BaseEdit NowEdit = null;
        int OldEditIndex = -1;
        int ge = 1;
        public QueryForm()
        {
            InitializeComponent();
            BeList.Add(tb);
            BeList.Add(chk);
            BeList.Add(cbo);

            ((CheckEdit)chk).Properties.ValueChecked = "Y";
            ((CheckEdit)chk).Properties.ValueUnchecked = "N";
            ((CheckEdit)chk).Properties.PictureChecked = Properties.Resources.Checked1;
            ((CheckEdit)chk).Properties.PictureGrayed = Properties.Resources.Grayed1;
            ((CheckEdit)chk).Properties.PictureUnchecked = Properties.Resources.Unchecked1;
            ((CheckEdit)chk).CheckState = CheckState.Indeterminate;
            ((CheckEdit)chk).Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;

            for (int i = 0; i < BeList.Count; i++)
            {
                BeList[i].Name = $"Be{i}";
                BeList[i].Parent = panelControl4;
                BeList[i].Properties.AutoHeight = false;
                BeList[i].Size = new Size(192, 28);
                BeList[i].Location = new Point(332, 6);
                BeList[i].Font = new Font("YaHei Consolas Hybrid", 12);
                BeList[i].Visible = false;
                BeList[i].Text = "";
            }

        }

        public QueryForm(string xCaption)
        {
            InitializeComponent();
            Text = xCaption;
        }

        public string Filter { get; set; } = "";

        public void SetSchemas(List<SchemaList> sh)
        {
            Schemas = sh;

            if (cboColumn.Properties.Items.Count > 0)
            {
                return;
            }

            for (int i=0;i< Schemas.Count;i++)            
            {
                cboColumn.Properties.Items.Add($"{Schemas[i].FieldName} {Schemas[i].FieldCaption}");
            }

            if (cboColumn.Properties.Items.Count > 0)
            {
                cboColumn.SelectedIndex = 0;
            }

            

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboColumn_SelectedIndexChanged(object sender, EventArgs e)
        {            
            var s = Schemas.ElementAt(cboColumn.SelectedIndex);
            EditShow(s);
        }

        private void EditShow(SchemaList sh)
        {            
            switch (sh.GCDataType)
            {
                case GCData.GCD_String:
                case GCData.GCD_Int:
                case GCData.GCD_Double:
                    if (OldEditIndex != 0)
                    {
                        BeList[0].Visible = true;
                        BeList[1].Visible = false;
                        BeList[2].Visible = false;
                    }
                    NowEdit = BeList[0];
                    OldEditIndex = 0;
                    break;
                case GCData.GCD_Check:
                    if (OldEditIndex != 1)
                    {
                        BeList[1].Visible = true;
                        BeList[0].Visible = false;
                        BeList[2].Visible = false;
                    }
                    NowEdit = BeList[1];
                    OldEditIndex = 1;
                    break;
                case GCData.GCD_Combo:
                    if (OldEditIndex != 2)
                    {
                        ((ComboBoxEdit)BeList[2]).Properties.Items.Clear();
                        ((ComboBoxEdit)BeList[2]).Properties.Items.Add(sh.ValueDisplay);
                        BeList[2].Visible = true;
                        BeList[0].Visible = false;
                        BeList[1].Visible = false;
                    }
                    NowEdit = BeList[2];
                    OldEditIndex = 2;
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            memoSQL.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (memoSQL.Text != "")
            {
                memoSQL.Text += $" {rg01.Properties.Items[rg01.SelectedIndex].Description} ";
            }

            string paBegin = "";
            string paEnd = "";

            if(cboMix.SelectedIndex == 6)
            {
                paEnd = "%";
            }
            else if (cboMix.SelectedIndex == 7)
            {
                paBegin = "%";
            }
            else if (cboMix.SelectedIndex == 8)
            {
                paBegin = "%";
                paEnd = "%";
            }

            if (NowEdit is CheckEdit)
            {
                string mCheck = ((CheckEdit)NowEdit).Checked ? "Y" : "N";
                if (cboMix.SelectedIndex >= 6)
                {
                    memoSQL.Text += $"{Schemas[cboColumn.SelectedIndex].FieldName} Like N'{paBegin}{mCheck}{paEnd}' \r\n";
                }
                else
                {
                    memoSQL.Text += $"{Schemas[cboColumn.SelectedIndex].FieldName} {cboMix.Text} N'{mCheck}' \r\n";
                }
            }
            else
            {
                if (cboMix.SelectedIndex >= 6)
                {
                    memoSQL.Text += $"{Schemas[cboColumn.SelectedIndex].FieldName} Like N'{paBegin}{NowEdit.Text}{paEnd}' \r\n";
                }
                else
                {
                    memoSQL.Text += $"{Schemas[cboColumn.SelectedIndex].FieldName}  {cboMix.Text}  N'{NowEdit.Text}' \r\n";
                }
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Filter = memoSQL.Text;
        }
    }
}