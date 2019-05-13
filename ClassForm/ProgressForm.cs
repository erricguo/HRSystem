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

namespace ClassForm
{
    public partial class ProgressForm : DevExpress.XtraEditors.XtraForm
    {
        public ProgressForm()
        {
            InitializeComponent();
            SetPC(0, 100, 0, 1);
        }

        public ProgressForm(string xMsg)
        {
            InitializeComponent();
            SetPC(0, 100, 0, 1);
            Msg(xMsg);
        }

        public ProgressForm(int xMin = 0, int xMax = 100, int xPosition = 0, int xStepRange = 1)
        {
            InitializeComponent();
            SetPC(xMin, xMax, xPosition, xStepRange);
        }

        public void Msg(string xMsg)
        {
            lb_Destination.Text = xMsg;
        }

        public void SetPC(int xMin=0,int xMax=100,int xPosition=0,int xStepRange=1)
        {
            PBC1.Properties.Minimum = xMin;
            PBC1.Properties.Maximum = xMax;
            PBC1.Position = xPosition;
            PBC1.Properties.Step = xStepRange;
        }

        public void Step()
        {
            //System.Threading.Thread.Sleep(100);
            PBC1.PerformStep();
            Application.DoEvents();
        }
    }
}