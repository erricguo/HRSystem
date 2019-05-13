namespace ClassForm
{
    partial class ProgressForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_Destination = new DevExpress.XtraEditors.LabelControl();
            this.PBC1 = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.PBC1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Destination
            // 
            this.lb_Destination.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lb_Destination.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_Destination.Appearance.ForeColor = System.Drawing.Color.White;
            this.lb_Destination.Location = new System.Drawing.Point(12, 12);
            this.lb_Destination.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.lb_Destination.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lb_Destination.Name = "lb_Destination";
            this.lb_Destination.Size = new System.Drawing.Size(68, 22);
            this.lb_Destination.TabIndex = 142;
            this.lb_Destination.Tag = "ERP1";
            this.lb_Destination.Text = "目的路徑";
            // 
            // PBC1
            // 
            this.PBC1.Location = new System.Drawing.Point(12, 56);
            this.PBC1.Margin = new System.Windows.Forms.Padding(5);
            this.PBC1.Name = "PBC1";
            this.PBC1.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PBC1.Properties.ShowTitle = true;
            this.PBC1.Size = new System.Drawing.Size(487, 20);
            this.PBC1.TabIndex = 141;
            // 
            // ProgressForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.Appearance.ForeColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 94);
            this.Controls.Add(this.lb_Destination);
            this.Controls.Add(this.PBC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressForm";
            this.Text = "ProgressForm";
            ((System.ComponentModel.ISupportInitialize)(this.PBC1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lb_Destination;
        private DevExpress.XtraEditors.ProgressBarControl PBC1;
    }
}