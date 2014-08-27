namespace SWBrasil.ORM
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.btnNext1 = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInitialCatalog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDataBase = new System.Windows.Forms.ComboBox();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.btnReadDataBase = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.tabTables = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack1 = new System.Windows.Forms.Button();
            this.btnNext2 = new System.Windows.Forms.Button();
            this.chkTables = new System.Windows.Forms.CheckedListBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.tabTemplates = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBack2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.chkTemplates = new System.Windows.Forms.CheckedListBox();
            this.tabBuild = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGerar = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.tabTables.SuspendLayout();
            this.tabTemplates.SuspendLayout();
            this.tabBuild.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSetup);
            this.tabControl1.Controls.Add(this.tabTables);
            this.tabControl1.Controls.Add(this.tabTemplates);
            this.tabControl1.Controls.Add(this.tabBuild);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(497, 518);
            this.tabControl1.TabIndex = 4;
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.btnNext1);
            this.tabSetup.Controls.Add(this.lblPassword);
            this.tabSetup.Controls.Add(this.txtPassword);
            this.tabSetup.Controls.Add(this.lblUserId);
            this.tabSetup.Controls.Add(this.txtUserID);
            this.tabSetup.Controls.Add(this.label2);
            this.tabSetup.Controls.Add(this.txtInitialCatalog);
            this.tabSetup.Controls.Add(this.label1);
            this.tabSetup.Controls.Add(this.cboDataBase);
            this.tabSetup.Controls.Add(this.lblDataSource);
            this.tabSetup.Controls.Add(this.txtDataSource);
            this.tabSetup.Controls.Add(this.btnReadDataBase);
            this.tabSetup.Controls.Add(this.txtConnectionString);
            this.tabSetup.Location = new System.Drawing.Point(4, 25);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(489, 489);
            this.tabSetup.TabIndex = 0;
            this.tabSetup.Text = "Setup";
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // btnNext1
            // 
            this.btnNext1.Location = new System.Drawing.Point(376, 444);
            this.btnNext1.Name = "btnNext1";
            this.btnNext1.Size = new System.Drawing.Size(92, 23);
            this.btnNext1.TabIndex = 5;
            this.btnNext1.Text = "Next »";
            this.btnNext1.UseVisualStyleBackColor = true;
            this.btnNext1.Click += new System.EventHandler(this.btnNext1_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(96, 254);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(171, 251);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(206, 22);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "S!sTeM@s";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(114, 213);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(53, 17);
            this.lblUserId.TabIndex = 11;
            this.lblUserId.Text = "User Id";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(171, 210);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(206, 22);
            this.txtUserID.TabIndex = 3;
            this.txtUserID.Text = "sa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Initial Catalog";
            // 
            // txtInitialCatalog
            // 
            this.txtInitialCatalog.Location = new System.Drawing.Point(171, 168);
            this.txtInitialCatalog.Name = "txtInitialCatalog";
            this.txtInitialCatalog.Size = new System.Drawing.Size(206, 22);
            this.txtInitialCatalog.TabIndex = 2;
            this.txtInitialCatalog.Text = "Lotecando";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "DataBase Type";
            // 
            // cboDataBase
            // 
            this.cboDataBase.FormattingEnabled = true;
            this.cboDataBase.Items.AddRange(new object[] {
            "SQL Server"});
            this.cboDataBase.Location = new System.Drawing.Point(171, 81);
            this.cboDataBase.Name = "cboDataBase";
            this.cboDataBase.Size = new System.Drawing.Size(225, 24);
            this.cboDataBase.TabIndex = 0;
            this.cboDataBase.Text = "SQL Server";
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(80, 128);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(87, 17);
            this.lblDataSource.TabIndex = 5;
            this.lblDataSource.Text = "Data Source";
            // 
            // txtDataSource
            // 
            this.txtDataSource.Location = new System.Drawing.Point(171, 125);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(206, 22);
            this.txtDataSource.TabIndex = 1;
            this.txtDataSource.Text = "SWBRASIL-02\\PREPAGO";
            // 
            // btnReadDataBase
            // 
            this.btnReadDataBase.Location = new System.Drawing.Point(73, 290);
            this.btnReadDataBase.Name = "btnReadDataBase";
            this.btnReadDataBase.Size = new System.Drawing.Size(92, 23);
            this.btnReadDataBase.TabIndex = 3;
            this.btnReadDataBase.Text = "Refresh";
            this.btnReadDataBase.UseVisualStyleBackColor = true;
            this.btnReadDataBase.Visible = false;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(171, 290);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(206, 22);
            this.txtConnectionString.TabIndex = 1;
            this.txtConnectionString.Visible = false;
            // 
            // tabTables
            // 
            this.tabTables.Controls.Add(this.label3);
            this.tabTables.Controls.Add(this.btnBack1);
            this.tabTables.Controls.Add(this.btnNext2);
            this.tabTables.Controls.Add(this.chkTables);
            this.tabTables.Controls.Add(this.chkAll);
            this.tabTables.Location = new System.Drawing.Point(4, 25);
            this.tabTables.Name = "tabTables";
            this.tabTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabTables.Size = new System.Drawing.Size(489, 489);
            this.tabTables.TabIndex = 1;
            this.tabTables.Text = "Tables";
            this.tabTables.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Selecione a(s) tabela(s) a processar.";
            // 
            // btnBack1
            // 
            this.btnBack1.Location = new System.Drawing.Point(27, 444);
            this.btnBack1.Name = "btnBack1";
            this.btnBack1.Size = new System.Drawing.Size(92, 23);
            this.btnBack1.TabIndex = 16;
            this.btnBack1.Text = "« Back";
            this.btnBack1.UseVisualStyleBackColor = true;
            this.btnBack1.Click += new System.EventHandler(this.btnBack1_Click);
            // 
            // btnNext2
            // 
            this.btnNext2.Location = new System.Drawing.Point(376, 444);
            this.btnNext2.Name = "btnNext2";
            this.btnNext2.Size = new System.Drawing.Size(92, 23);
            this.btnNext2.TabIndex = 15;
            this.btnNext2.Text = "Next »";
            this.btnNext2.UseVisualStyleBackColor = true;
            this.btnNext2.Click += new System.EventHandler(this.btnNext2_Click);
            // 
            // chkTables
            // 
            this.chkTables.FormattingEnabled = true;
            this.chkTables.Location = new System.Drawing.Point(27, 71);
            this.chkTables.Name = "chkTables";
            this.chkTables.Size = new System.Drawing.Size(441, 327);
            this.chkTables.TabIndex = 2;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(27, 405);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(88, 21);
            this.chkAll.TabIndex = 4;
            this.chkAll.Text = "Check All";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // tabTemplates
            // 
            this.tabTemplates.Controls.Add(this.label4);
            this.tabTemplates.Controls.Add(this.btnBack2);
            this.tabTemplates.Controls.Add(this.button3);
            this.tabTemplates.Controls.Add(this.chkTemplates);
            this.tabTemplates.Location = new System.Drawing.Point(4, 25);
            this.tabTemplates.Name = "tabTemplates";
            this.tabTemplates.Size = new System.Drawing.Size(489, 489);
            this.tabTemplates.TabIndex = 2;
            this.tabTemplates.Text = "Templates";
            this.tabTemplates.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Selecione o(s) template(s) a aplicar.";
            // 
            // btnBack2
            // 
            this.btnBack2.Location = new System.Drawing.Point(24, 445);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.Size = new System.Drawing.Size(92, 23);
            this.btnBack2.TabIndex = 19;
            this.btnBack2.Text = "« Back";
            this.btnBack2.UseVisualStyleBackColor = true;
            this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(373, 445);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Next »";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chkTemplates
            // 
            this.chkTemplates.FormattingEnabled = true;
            this.chkTemplates.Location = new System.Drawing.Point(24, 72);
            this.chkTemplates.Name = "chkTemplates";
            this.chkTemplates.Size = new System.Drawing.Size(441, 327);
            this.chkTemplates.TabIndex = 17;
            // 
            // tabBuild
            // 
            this.tabBuild.Controls.Add(this.btnGerar);
            this.tabBuild.Controls.Add(this.button1);
            this.tabBuild.Controls.Add(this.label5);
            this.tabBuild.Controls.Add(this.txtOutputPath);
            this.tabBuild.Location = new System.Drawing.Point(4, 25);
            this.tabBuild.Name = "tabBuild";
            this.tabBuild.Size = new System.Drawing.Size(489, 489);
            this.tabBuild.TabIndex = 3;
            this.tabBuild.Text = "Build";
            this.tabBuild.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Output Path";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(153, 90);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(206, 22);
            this.txtOutputPath.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(365, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(373, 445);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(92, 23);
            this.btnGerar.TabIndex = 19;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 552);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "SWBrasil ORM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.tabSetup.PerformLayout();
            this.tabTables.ResumeLayout(false);
            this.tabTables.PerformLayout();
            this.tabTemplates.ResumeLayout(false);
            this.tabTemplates.PerformLayout();
            this.tabBuild.ResumeLayout(false);
            this.tabBuild.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.Button btnNext1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInitialCatalog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDataBase;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.Button btnReadDataBase;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.TabPage tabTables;
        private System.Windows.Forms.Button btnNext2;
        private System.Windows.Forms.CheckedListBox chkTables;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.TabPage tabTemplates;
        private System.Windows.Forms.TabPage tabBuild;
        private System.Windows.Forms.Button btnBack1;
        private System.Windows.Forms.Button btnBack2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckedListBox chkTemplates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

    }
}

