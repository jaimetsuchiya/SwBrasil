﻿namespace SWBrasil.ORM
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabProcedures = new System.Windows.Forms.TabPage();
            this.tabBuild = new System.Windows.Forms.TabPage();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGerar = new System.Windows.Forms.Button();
            this.chkArquivoUnico = new System.Windows.Forms.CheckBox();
            this.txtTemplateProject = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tabTemplates = new System.Windows.Forms.TabPage();
            this.chkTemplates = new System.Windows.Forms.CheckedListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnBack2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabTables = new System.Windows.Forms.TabPage();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkTables = new System.Windows.Forms.CheckedListBox();
            this.btnNext2 = new System.Windows.Forms.Button();
            this.btnBack1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.btnReadDataBase = new System.Windows.Forms.Button();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.cboDataBase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInitialCatalog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnNext1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.chkProcedures = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tabProcedures.SuspendLayout();
            this.tabBuild.SuspendLayout();
            this.tabTemplates.SuspendLayout();
            this.tabTables.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabProcedures
            // 
            this.tabProcedures.Controls.Add(this.button4);
            this.tabProcedures.Controls.Add(this.button5);
            this.tabProcedures.Controls.Add(this.checkBox2);
            this.tabProcedures.Controls.Add(this.label9);
            this.tabProcedures.Controls.Add(this.chkProcedures);
            this.tabProcedures.Location = new System.Drawing.Point(4, 22);
            this.tabProcedures.Name = "tabProcedures";
            this.tabProcedures.Padding = new System.Windows.Forms.Padding(3);
            this.tabProcedures.Size = new System.Drawing.Size(365, 395);
            this.tabProcedures.TabIndex = 4;
            this.tabProcedures.Text = "Procedures";
            this.tabProcedures.UseVisualStyleBackColor = true;
            // 
            // tabBuild
            // 
            this.tabBuild.Controls.Add(this.button2);
            this.tabBuild.Controls.Add(this.label7);
            this.tabBuild.Controls.Add(this.txtTemplateProject);
            this.tabBuild.Controls.Add(this.txtOutputPath);
            this.tabBuild.Controls.Add(this.chkArquivoUnico);
            this.tabBuild.Controls.Add(this.btnGerar);
            this.tabBuild.Controls.Add(this.button1);
            this.tabBuild.Controls.Add(this.label5);
            this.tabBuild.Location = new System.Drawing.Point(4, 22);
            this.tabBuild.Margin = new System.Windows.Forms.Padding(2);
            this.tabBuild.Name = "tabBuild";
            this.tabBuild.Size = new System.Drawing.Size(365, 395);
            this.tabBuild.TabIndex = 3;
            this.tabBuild.Text = "Build";
            this.tabBuild.UseVisualStyleBackColor = true;
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(118, 97);
            this.txtOutputPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(156, 20);
            this.txtOutputPath.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Output Path";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 97);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 19);
            this.button1.TabIndex = 8;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(280, 362);
            this.btnGerar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(69, 19);
            this.btnGerar.TabIndex = 19;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // chkArquivoUnico
            // 
            this.chkArquivoUnico.AutoSize = true;
            this.chkArquivoUnico.Location = new System.Drawing.Point(118, 132);
            this.chkArquivoUnico.Name = "chkArquivoUnico";
            this.chkArquivoUnico.Size = new System.Drawing.Size(93, 17);
            this.chkArquivoUnico.TabIndex = 20;
            this.chkArquivoUnico.Text = "Arquivo Único";
            this.chkArquivoUnico.UseVisualStyleBackColor = true;
            this.chkArquivoUnico.Visible = false;
            // 
            // txtTemplateProject
            // 
            this.txtTemplateProject.Location = new System.Drawing.Point(118, 64);
            this.txtTemplateProject.Margin = new System.Windows.Forms.Padding(2);
            this.txtTemplateProject.Name = "txtTemplateProject";
            this.txtTemplateProject.Size = new System.Drawing.Size(156, 20);
            this.txtTemplateProject.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 67);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Template Project Path";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(277, 64);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 19);
            this.button2.TabIndex = 23;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabTemplates
            // 
            this.tabTemplates.Controls.Add(this.label4);
            this.tabTemplates.Controls.Add(this.btnBack2);
            this.tabTemplates.Controls.Add(this.button3);
            this.tabTemplates.Controls.Add(this.chkTemplates);
            this.tabTemplates.Location = new System.Drawing.Point(4, 22);
            this.tabTemplates.Margin = new System.Windows.Forms.Padding(2);
            this.tabTemplates.Name = "tabTemplates";
            this.tabTemplates.Size = new System.Drawing.Size(365, 395);
            this.tabTemplates.TabIndex = 2;
            this.tabTemplates.Text = "Templates";
            this.tabTemplates.UseVisualStyleBackColor = true;
            // 
            // chkTemplates
            // 
            this.chkTemplates.FormattingEnabled = true;
            this.chkTemplates.Location = new System.Drawing.Point(18, 58);
            this.chkTemplates.Margin = new System.Windows.Forms.Padding(2);
            this.chkTemplates.Name = "chkTemplates";
            this.chkTemplates.Size = new System.Drawing.Size(332, 259);
            this.chkTemplates.TabIndex = 17;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(280, 362);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 19);
            this.button3.TabIndex = 18;
            this.button3.Text = "Next »";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnBack2
            // 
            this.btnBack2.Location = new System.Drawing.Point(18, 362);
            this.btnBack2.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.Size = new System.Drawing.Size(69, 19);
            this.btnBack2.TabIndex = 19;
            this.btnBack2.Text = "« Back";
            this.btnBack2.UseVisualStyleBackColor = true;
            this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Selecione o(s) template(s) a aplicar.";
            // 
            // tabTables
            // 
            this.tabTables.Controls.Add(this.label3);
            this.tabTables.Controls.Add(this.btnBack1);
            this.tabTables.Controls.Add(this.btnNext2);
            this.tabTables.Controls.Add(this.chkTables);
            this.tabTables.Controls.Add(this.chkAll);
            this.tabTables.Location = new System.Drawing.Point(4, 22);
            this.tabTables.Margin = new System.Windows.Forms.Padding(2);
            this.tabTables.Name = "tabTables";
            this.tabTables.Padding = new System.Windows.Forms.Padding(2);
            this.tabTables.Size = new System.Drawing.Size(365, 395);
            this.tabTables.TabIndex = 1;
            this.tabTables.Text = "Tables";
            this.tabTables.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(20, 329);
            this.chkAll.Margin = new System.Windows.Forms.Padding(2);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(71, 17);
            this.chkAll.TabIndex = 4;
            this.chkAll.Text = "Check All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged_1);
            // 
            // chkTables
            // 
            this.chkTables.FormattingEnabled = true;
            this.chkTables.Location = new System.Drawing.Point(20, 58);
            this.chkTables.Margin = new System.Windows.Forms.Padding(2);
            this.chkTables.Name = "chkTables";
            this.chkTables.Size = new System.Drawing.Size(332, 259);
            this.chkTables.TabIndex = 2;
            // 
            // btnNext2
            // 
            this.btnNext2.Location = new System.Drawing.Point(282, 361);
            this.btnNext2.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext2.Name = "btnNext2";
            this.btnNext2.Size = new System.Drawing.Size(69, 19);
            this.btnNext2.TabIndex = 15;
            this.btnNext2.Text = "Next »";
            this.btnNext2.UseVisualStyleBackColor = true;
            this.btnNext2.Click += new System.EventHandler(this.btnNext2_Click);
            // 
            // btnBack1
            // 
            this.btnBack1.Location = new System.Drawing.Point(20, 361);
            this.btnBack1.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack1.Name = "btnBack1";
            this.btnBack1.Size = new System.Drawing.Size(69, 19);
            this.btnBack1.TabIndex = 16;
            this.btnBack1.Text = "« Back";
            this.btnBack1.UseVisualStyleBackColor = true;
            this.btnBack1.Click += new System.EventHandler(this.btnBack1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Selecione a(s) tabela(s) a processar.";
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.label8);
            this.tabSetup.Controls.Add(this.txtNameSpace);
            this.tabSetup.Controls.Add(this.txtProjectName);
            this.tabSetup.Controls.Add(this.txtPassword);
            this.tabSetup.Controls.Add(this.txtUserID);
            this.tabSetup.Controls.Add(this.txtInitialCatalog);
            this.tabSetup.Controls.Add(this.txtDataSource);
            this.tabSetup.Controls.Add(this.txtConnectionString);
            this.tabSetup.Controls.Add(this.label6);
            this.tabSetup.Controls.Add(this.checkBox1);
            this.tabSetup.Controls.Add(this.btnNext1);
            this.tabSetup.Controls.Add(this.lblPassword);
            this.tabSetup.Controls.Add(this.lblUserId);
            this.tabSetup.Controls.Add(this.label2);
            this.tabSetup.Controls.Add(this.label1);
            this.tabSetup.Controls.Add(this.cboDataBase);
            this.tabSetup.Controls.Add(this.lblDataSource);
            this.tabSetup.Controls.Add(this.btnReadDataBase);
            this.tabSetup.Location = new System.Drawing.Point(4, 22);
            this.tabSetup.Margin = new System.Windows.Forms.Padding(2);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(2);
            this.tabSetup.Size = new System.Drawing.Size(365, 395);
            this.tabSetup.TabIndex = 0;
            this.tabSetup.Text = "Setup";
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(135, 270);
            this.txtConnectionString.Margin = new System.Windows.Forms.Padding(2);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(156, 20);
            this.txtConnectionString.TabIndex = 1;
            this.txtConnectionString.Visible = false;
            // 
            // btnReadDataBase
            // 
            this.btnReadDataBase.Location = new System.Drawing.Point(62, 270);
            this.btnReadDataBase.Margin = new System.Windows.Forms.Padding(2);
            this.btnReadDataBase.Name = "btnReadDataBase";
            this.btnReadDataBase.Size = new System.Drawing.Size(69, 19);
            this.btnReadDataBase.TabIndex = 3;
            this.btnReadDataBase.Text = "Refresh";
            this.btnReadDataBase.UseVisualStyleBackColor = true;
            this.btnReadDataBase.Visible = false;
            // 
            // txtDataSource
            // 
            this.txtDataSource.Location = new System.Drawing.Point(135, 136);
            this.txtDataSource.Margin = new System.Windows.Forms.Padding(2);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(156, 20);
            this.txtDataSource.TabIndex = 1;
            this.txtDataSource.Text = "SWBRASIL-02\\PREPAGO";
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(67, 138);
            this.lblDataSource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(67, 13);
            this.lblDataSource.TabIndex = 5;
            this.lblDataSource.Text = "Data Source";
            // 
            // cboDataBase
            // 
            this.cboDataBase.FormattingEnabled = true;
            this.cboDataBase.Items.AddRange(new object[] {
            "SQL Server"});
            this.cboDataBase.Location = new System.Drawing.Point(135, 100);
            this.cboDataBase.Margin = new System.Windows.Forms.Padding(2);
            this.cboDataBase.Name = "cboDataBase";
            this.cboDataBase.Size = new System.Drawing.Size(170, 21);
            this.cboDataBase.TabIndex = 0;
            this.cboDataBase.Text = "SQL Server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "DataBase Type";
            // 
            // txtInitialCatalog
            // 
            this.txtInitialCatalog.Location = new System.Drawing.Point(135, 170);
            this.txtInitialCatalog.Margin = new System.Windows.Forms.Padding(2);
            this.txtInitialCatalog.Name = "txtInitialCatalog";
            this.txtInitialCatalog.Size = new System.Drawing.Size(156, 20);
            this.txtInitialCatalog.TabIndex = 2;
            this.txtInitialCatalog.Text = "Lotecando";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 173);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Initial Catalog";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(135, 205);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(156, 20);
            this.txtUserID.TabIndex = 3;
            this.txtUserID.Text = "sa";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(93, 207);
            this.lblUserId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(41, 13);
            this.lblUserId.TabIndex = 11;
            this.lblUserId.Text = "User Id";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(135, 238);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(156, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "S!sTeM@s";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(79, 240);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "Password";
            // 
            // btnNext1
            // 
            this.btnNext1.Location = new System.Drawing.Point(282, 361);
            this.btnNext1.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext1.Name = "btnNext1";
            this.btnNext1.Size = new System.Drawing.Size(69, 19);
            this.btnNext1.TabIndex = 5;
            this.btnNext1.Text = "Next »";
            this.btnNext1.UseVisualStyleBackColor = true;
            this.btnNext1.Click += new System.EventHandler(this.btnNext1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(135, 296);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 17);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Trusted Connection";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(135, 39);
            this.txtProjectName.Margin = new System.Windows.Forms.Padding(2);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(156, 20);
            this.txtProjectName.TabIndex = 15;
            this.txtProjectName.Text = "SW";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Project Name";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(135, 63);
            this.txtNameSpace.Margin = new System.Windows.Forms.Padding(2);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(156, 20);
            this.txtNameSpace.TabIndex = 17;
            this.txtNameSpace.Text = "SW";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 66);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "NameSpace";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSetup);
            this.tabControl1.Controls.Add(this.tabTables);
            this.tabControl1.Controls.Add(this.tabProcedures);
            this.tabControl1.Controls.Add(this.tabTemplates);
            this.tabControl1.Controls.Add(this.tabBuild);
            this.tabControl1.Location = new System.Drawing.Point(9, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 421);
            this.tabControl1.TabIndex = 4;
            // 
            // chkProcedures
            // 
            this.chkProcedures.FormattingEnabled = true;
            this.chkProcedures.Location = new System.Drawing.Point(17, 51);
            this.chkProcedures.Margin = new System.Windows.Forms.Padding(2);
            this.chkProcedures.Name = "chkProcedures";
            this.chkProcedures.Size = new System.Drawing.Size(332, 259);
            this.chkProcedures.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 22);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Selecione a(s) procedure(s) a processar.";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(18, 359);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(69, 19);
            this.button4.TabIndex = 21;
            this.button4.Text = "« Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(280, 359);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(69, 19);
            this.button5.TabIndex = 20;
            this.button5.Text = "Next »";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(18, 327);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(71, 17);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "Check All";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.chkAll2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 448);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "SWBrasil ORM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabProcedures.ResumeLayout(false);
            this.tabProcedures.PerformLayout();
            this.tabBuild.ResumeLayout(false);
            this.tabBuild.PerformLayout();
            this.tabTemplates.ResumeLayout(false);
            this.tabTemplates.PerformLayout();
            this.tabTables.ResumeLayout(false);
            this.tabTables.PerformLayout();
            this.tabSetup.ResumeLayout(false);
            this.tabSetup.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabPage tabProcedures;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox chkProcedures;
        private System.Windows.Forms.TabPage tabBuild;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTemplateProject;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.CheckBox chkArquivoUnico;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabTemplates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBack2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckedListBox chkTemplates;
        private System.Windows.Forms.TabPage tabTables;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBack1;
        private System.Windows.Forms.Button btnNext2;
        private System.Windows.Forms.CheckedListBox chkTables;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtInitialCatalog;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnNext1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDataBase;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.Button btnReadDataBase;
        private System.Windows.Forms.TabControl tabControl1;

    }
}

