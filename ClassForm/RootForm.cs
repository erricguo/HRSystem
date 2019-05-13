using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace ClassForm
{
    public partial class RootForm : DevExpress.XtraEditors.XtraForm
    {
        public GridStatu FGridStatu { get; set; } = GridStatu.GS_Browse;
        public F2Form f2 = null;
        public enum GridStatu : int
        {
            GS_Browse = 1,
            GS_Add = 2,
            GS_Edit = 3,
            GS_Save = 4
        }

        public enum GCNum : int
        {
            GCN_None = 0,
            GCN_Main = 1,
            GCN_Body = 2
        }

        public enum GCEdit : int
        {
            GCE_None = 0,
            GCE_Button = 1,
            GCE_Date = 2,
            GCE_Time = 3,
            GCE_Check = 4,
            GCE_Num = 5,
            GCE_PW = 6,
            GCE_RadioGroup = 7
        }

        public enum GCData : int
        {
            GCD_String = 0,
            GCD_Int = 1,
            GCD_Double = 2,
            GCD_Check = 3,
            GCD_Combo = 4            
        }

        public RootForm()
        {
            InitializeComponent();
        }

        protected virtual void CheckGridStatu(GridStatu gs, bool SetValue = true)
        {
            
        }

        public virtual GridControl GetGC(GCNum xGCNum)
        {
            return null;
        }
        public virtual GridView GetGV(GCNum xGCNum)
        {
            return null;
        }

    }
}