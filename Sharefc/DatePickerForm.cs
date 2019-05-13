using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sharefc
{
    public partial class DatePickerForm : Sharefc.ConfirmForm
    {
        public DatePickerForm()
        {
            InitializeComponent();
        }

        public DatePickerForm(string xMsg = "", string xCaption = "訊息", int xSeconds = -1)
            :base(xMsg,xCaption,xSeconds)
        {
            InitializeComponent();
        }

        public DatePickerForm(string xMsg = "", string xCaption = "訊息", int xSeconds = -1, int xWidth = 462, int xHeight = 279)
            : base(xMsg, xCaption, xSeconds, xWidth, xHeight)
        {
            InitializeComponent();
        }

        public DateTime GetDateTime()
        {
            return dateEdit1.DateTime;
        }

        private void DatePickerForm_Shown(object sender, EventArgs e)
        {
            dateEdit1.DateTime = DateTime.Now;
        }
    }
}
