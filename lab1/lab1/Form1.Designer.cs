namespace lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCompName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblSysPath = new System.Windows.Forms.Label();
            this.lblVersionOs = new System.Windows.Forms.Label();
            this.lblSystemMetrics = new System.Windows.Forms.Label();
            this.lblSystemParametrs = new System.Windows.Forms.Label();
            this.cbxSysEl = new System.Windows.Forms.ComboBox();
            this.cbxColor = new System.Windows.Forms.ComboBox();
            this.lblSCs = new System.Windows.Forms.Label();
            this.btnSetSysColor = new System.Windows.Forms.Button();
            this.btnGetColor = new System.Windows.Forms.Button();
            this.btnResetSysCol = new System.Windows.Forms.Button();
            this.lblSystemTime = new System.Windows.Forms.Label();
            this.lblWinAPI = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCompName
            // 
            this.lblCompName.AutoSize = true;
            this.lblCompName.Location = new System.Drawing.Point(22, 33);
            this.lblCompName.Name = "lblCompName";
            this.lblCompName.Size = new System.Drawing.Size(78, 16);
            this.lblCompName.TabIndex = 0;
            this.lblCompName.Text = "compName";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(22, 66);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(70, 16);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "userName";
            // 
            // lblSysPath
            // 
            this.lblSysPath.AutoSize = true;
            this.lblSysPath.Location = new System.Drawing.Point(22, 99);
            this.lblSysPath.Name = "lblSysPath";
            this.lblSysPath.Size = new System.Drawing.Size(77, 16);
            this.lblSysPath.TabIndex = 2;
            this.lblSysPath.Text = "systemPath";
            // 
            // lblVersionOs
            // 
            this.lblVersionOs.AutoSize = true;
            this.lblVersionOs.Location = new System.Drawing.Point(22, 142);
            this.lblVersionOs.Name = "lblVersionOs";
            this.lblVersionOs.Size = new System.Drawing.Size(70, 16);
            this.lblVersionOs.TabIndex = 3;
            this.lblVersionOs.Text = "VersionOs";
            // 
            // lblSystemMetrics
            // 
            this.lblSystemMetrics.AutoSize = true;
            this.lblSystemMetrics.Location = new System.Drawing.Point(22, 170);
            this.lblSystemMetrics.Name = "lblSystemMetrics";
            this.lblSystemMetrics.Size = new System.Drawing.Size(95, 16);
            this.lblSystemMetrics.TabIndex = 4;
            this.lblSystemMetrics.Text = "SystemMetrics";
            // 
            // lblSystemParametrs
            // 
            this.lblSystemParametrs.AutoSize = true;
            this.lblSystemParametrs.Location = new System.Drawing.Point(22, 280);
            this.lblSystemParametrs.Name = "lblSystemParametrs";
            this.lblSystemParametrs.Size = new System.Drawing.Size(114, 16);
            this.lblSystemParametrs.TabIndex = 5;
            this.lblSystemParametrs.Text = "SystemParametrs";
            // 
            // cbxSysEl
            // 
            this.cbxSysEl.FormattingEnabled = true;
            this.cbxSysEl.Location = new System.Drawing.Point(434, 43);
            this.cbxSysEl.Name = "cbxSysEl";
            this.cbxSysEl.Size = new System.Drawing.Size(121, 24);
            this.cbxSysEl.TabIndex = 6;
            // 
            // cbxColor
            // 
            this.cbxColor.FormattingEnabled = true;
            this.cbxColor.Location = new System.Drawing.Point(434, 100);
            this.cbxColor.Name = "cbxColor";
            this.cbxColor.Size = new System.Drawing.Size(121, 24);
            this.cbxColor.TabIndex = 8;
            // 
            // lblSCs
            // 
            this.lblSCs.AutoSize = true;
            this.lblSCs.Location = new System.Drawing.Point(431, 170);
            this.lblSCs.Name = "lblSCs";
            this.lblSCs.Size = new System.Drawing.Size(46, 16);
            this.lblSCs.TabIndex = 9;
            this.lblSCs.Text = "lblSCs";
            // 
            // btnSetSysColor
            // 
            this.btnSetSysColor.Location = new System.Drawing.Point(637, 100);
            this.btnSetSysColor.Name = "btnSetSysColor";
            this.btnSetSysColor.Size = new System.Drawing.Size(140, 23);
            this.btnSetSysColor.TabIndex = 10;
            this.btnSetSysColor.Text = "setSystemColor";
            this.btnSetSysColor.UseVisualStyleBackColor = true;
            this.btnSetSysColor.Click += new System.EventHandler(this.btnSetSysColor_Click);
            // 
            // btnGetColor
            // 
            this.btnGetColor.Location = new System.Drawing.Point(637, 43);
            this.btnGetColor.Name = "btnGetColor";
            this.btnGetColor.Size = new System.Drawing.Size(140, 23);
            this.btnGetColor.TabIndex = 11;
            this.btnGetColor.Text = "getSystemColor";
            this.btnGetColor.UseVisualStyleBackColor = true;
            this.btnGetColor.Click += new System.EventHandler(this.btnGetColor_Click);
            // 
            // btnResetSysCol
            // 
            this.btnResetSysCol.Location = new System.Drawing.Point(637, 163);
            this.btnResetSysCol.Name = "btnResetSysCol";
            this.btnResetSysCol.Size = new System.Drawing.Size(140, 23);
            this.btnResetSysCol.TabIndex = 12;
            this.btnResetSysCol.Text = "Reset";
            this.btnResetSysCol.UseVisualStyleBackColor = true;
            this.btnResetSysCol.Click += new System.EventHandler(this.btnResetSysCol_Click_1);
            // 
            // lblSystemTime
            // 
            this.lblSystemTime.AutoSize = true;
            this.lblSystemTime.Location = new System.Drawing.Point(312, 350);
            this.lblSystemTime.Name = "lblSystemTime";
            this.lblSystemTime.Size = new System.Drawing.Size(83, 16);
            this.lblSystemTime.TabIndex = 13;
            this.lblSystemTime.Text = "SystemTime";
            // 
            // lblWinAPI
            // 
            this.lblWinAPI.AutoSize = true;
            this.lblWinAPI.Location = new System.Drawing.Point(312, 255);
            this.lblWinAPI.Name = "lblWinAPI";
            this.lblWinAPI.Size = new System.Drawing.Size(78, 16);
            this.lblWinAPI.TabIndex = 14;
            this.lblWinAPI.Text = "windowsApi";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblWinAPI);
            this.Controls.Add(this.lblSystemTime);
            this.Controls.Add(this.btnResetSysCol);
            this.Controls.Add(this.btnGetColor);
            this.Controls.Add(this.btnSetSysColor);
            this.Controls.Add(this.lblSCs);
            this.Controls.Add(this.cbxColor);
            this.Controls.Add(this.cbxSysEl);
            this.Controls.Add(this.lblSystemParametrs);
            this.Controls.Add(this.lblSystemMetrics);
            this.Controls.Add(this.lblVersionOs);
            this.Controls.Add(this.lblSysPath);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblCompName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCompName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblSysPath;
        private System.Windows.Forms.Label lblVersionOs;
        private System.Windows.Forms.Label lblSystemMetrics;
        private System.Windows.Forms.Label lblSystemParametrs;
        private System.Windows.Forms.ComboBox cbxSysEl;
        private System.Windows.Forms.ComboBox cbxColor;
        private System.Windows.Forms.Label lblSCs;
        private System.Windows.Forms.Button btnSetSysColor;
        private System.Windows.Forms.Button btnGetColor;
        private System.Windows.Forms.Button btnResetSysCol;
        private System.Windows.Forms.Label lblSystemTime;
        private System.Windows.Forms.Label lblWinAPI;
    }
}

