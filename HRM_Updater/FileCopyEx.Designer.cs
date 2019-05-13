namespace HRM_Updater
{
    partial class FileCopyEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileCopyEx));
            this.PBC2 = new DevExpress.XtraEditors.ProgressBarControl();
            this.PBC1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelControl61 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl62 = new DevExpress.XtraEditors.LabelControl();
            this.lb_Source = new DevExpress.XtraEditors.LabelControl();
            this.lb_Destination = new DevExpress.XtraEditors.LabelControl();
            this.tbCount = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.PBC2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBC1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // PBC2
            // 
            this.PBC2.Location = new System.Drawing.Point(14, 174);
            this.PBC2.Margin = new System.Windows.Forms.Padding(5);
            this.PBC2.Name = "PBC2";
            this.PBC2.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PBC2.Properties.ShowTitle = true;
            this.PBC2.Size = new System.Drawing.Size(362, 20);
            this.PBC2.TabIndex = 137;
            // 
            // PBC1
            // 
            this.PBC1.Location = new System.Drawing.Point(14, 144);
            this.PBC1.Margin = new System.Windows.Forms.Padding(5);
            this.PBC1.Name = "PBC1";
            this.PBC1.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PBC1.Properties.ShowTitle = true;
            this.PBC1.Size = new System.Drawing.Size(362, 20);
            this.PBC1.TabIndex = 136;
            // 
            // labelControl61
            // 
            this.labelControl61.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl61.Appearance.BackColor2 = System.Drawing.Color.SteelBlue;
            this.labelControl61.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelControl61.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl61.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl61.Location = new System.Drawing.Point(14, 18);
            this.labelControl61.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.labelControl61.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl61.Name = "labelControl61";
            this.labelControl61.Size = new System.Drawing.Size(86, 22);
            this.labelControl61.TabIndex = 139;
            this.labelControl61.Text = "下載檔案";
            // 
            // labelControl62
            // 
            this.labelControl62.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl62.Appearance.BackColor2 = System.Drawing.Color.SeaGreen;
            this.labelControl62.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelControl62.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl62.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl62.Location = new System.Drawing.Point(14, 80);
            this.labelControl62.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.labelControl62.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl62.Name = "labelControl62";
            this.labelControl62.Size = new System.Drawing.Size(86, 22);
            this.labelControl62.TabIndex = 138;
            this.labelControl62.Tag = "ERP1";
            this.labelControl62.Text = "檔案大小";
            // 
            // lb_Source
            // 
            this.lb_Source.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lb_Source.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_Source.Appearance.ForeColor = System.Drawing.Color.White;
            this.lb_Source.Location = new System.Drawing.Point(14, 49);
            this.lb_Source.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.lb_Source.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lb_Source.Name = "lb_Source";
            this.lb_Source.Size = new System.Drawing.Size(68, 22);
            this.lb_Source.TabIndex = 141;
            this.lb_Source.Text = "來源路徑";
            // 
            // lb_Destination
            // 
            this.lb_Destination.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lb_Destination.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_Destination.Appearance.ForeColor = System.Drawing.Color.White;
            this.lb_Destination.Location = new System.Drawing.Point(14, 111);
            this.lb_Destination.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.lb_Destination.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lb_Destination.Name = "lb_Destination";
            this.lb_Destination.Size = new System.Drawing.Size(68, 22);
            this.lb_Destination.TabIndex = 140;
            this.lb_Destination.Tag = "ERP1";
            this.lb_Destination.Text = "目的路徑";
            // 
            // tbCount
            // 
            this.tbCount.EditValue = "1/3";
            this.tbCount.Location = new System.Drawing.Point(294, 116);
            this.tbCount.Name = "tbCount";
            this.tbCount.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.tbCount.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbCount.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.tbCount.Properties.Appearance.Options.UseBackColor = true;
            this.tbCount.Properties.Appearance.Options.UseFont = true;
            this.tbCount.Properties.Appearance.Options.UseForeColor = true;
            this.tbCount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tbCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbCount.Size = new System.Drawing.Size(82, 26);
            this.tbCount.TabIndex = 142;
            // 
            // FileCopyEx
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 210);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.lb_Source);
            this.Controls.Add(this.lb_Destination);
            this.Controls.Add(this.labelControl61);
            this.Controls.Add(this.labelControl62);
            this.Controls.Add(this.PBC2);
            this.Controls.Add(this.PBC1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FileCopyEx";
            this.Text = "FileCopyEx";
            this.Load += new System.EventHandler(this.FileCopyEx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBC2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBC1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl PBC2;
        private DevExpress.XtraEditors.ProgressBarControl PBC1;
        private DevExpress.XtraEditors.LabelControl labelControl61;
        private DevExpress.XtraEditors.LabelControl labelControl62;
        private DevExpress.XtraEditors.LabelControl lb_Source;
        private DevExpress.XtraEditors.LabelControl lb_Destination;
        private DevExpress.XtraEditors.TextEdit tbCount;
    }
}

