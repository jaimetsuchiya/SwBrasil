using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWBrasil.ORM
{
    public partial class Form1 : Form
    {
        string config = "";
        Common.BaseORM orm = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnReadDataBase_Click(object sender, EventArgs e)
        {
            chkTables.Items.Clear();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            chkAll.Text = (chkAll.Checked ? "UnCheck All" : "Check All");
            for (int i = 0; i < chkTables.Items.Count; i++)
                chkTables.SetItemChecked(i, chkAll.Checked);
        }

        private void chkAll2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Text = (checkBox2.Checked ? "UnCheck All" : "Check All");
            for (int i = 0; i < chkProcedures.Items.Count; i++)
                chkProcedures.SetItemChecked(i, checkBox2.Checked);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            config = Application.ExecutablePath.ToLower().Replace(".exe", ".log");
            if (File.Exists(config))
            {
                string[] lines = File.ReadAllLines(config);
                foreach (string line in lines)
                {
                    if( line.StartsWith("DataSource") )
                        txtDataSource.Text = line.Replace("DataSource=", "");

                    if (line.StartsWith("Initial Catalog"))
                        txtInitialCatalog.Text = line.Replace("Initial Catalog=", "");

                    if (line.StartsWith("User ID"))
                        txtUserID.Text = line.Replace("User ID=", "");

                    if (line.StartsWith("Password"))
                        txtPassword.Text = line.Replace("Password=", "");

                    if (line.StartsWith("OutPut"))
                        txtOutputPath.Text = line.Replace("OutPut=", "");
                }
            }
        }

        private void writeLastExecution()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DataSource=" + txtDataSource.Text);
            sb.AppendLine("Initial Catalog=" + txtInitialCatalog.Text);
            sb.AppendLine("User ID=" + txtUserID.Text);
            sb.AppendLine("Password=" + txtPassword.Text);
            sb.AppendLine("OutPut=" + txtOutputPath.Text);

            File.WriteAllText(config, sb.ToString());
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            orm = new Common.SqlServerORM();
            string connectionString = string.Format("Data Source={0}; Initial Catalog={1}; User Id={2}; Password={3};", txtDataSource.Text, txtInitialCatalog.Text, txtUserID.Text, txtPassword.Text);
            if( checkBox1.Checked )
                connectionString = string.Format("Data Source={0}; Initial Catalog={1}; Trusted_Connection=true;", txtDataSource.Text, txtInitialCatalog.Text);

            if (orm.Connect(connectionString))
            {
                chkTables.Items.Clear();
                foreach (Common.TableModel tabela in orm.Tables)
                    chkTables.Items.Add(tabela.Name);

                chkProcedures.Items.Clear();
                foreach (Common.ProcModel proc in orm.Procedures)
                    chkProcedures.Items.Add(proc.Name);

                tabControl1.SelectedIndex = 1;
            }
            else
                MessageBox.Show("Não foi possível conectar ao Banco de Dados!");
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            if (chkTables.CheckedItems.Count == 0)
                MessageBox.Show("Nenhuma tabela selecionada");
            else
            {
                List<Common.ITableTransformation> lstCmd = orm.AvailableTableTemplates();

                chkTemplates.Items.Clear();
                foreach (Common.ICommand cmd in lstCmd)
                    chkTemplates.Items.Add(cmd.CommandID);
             
                tabControl1.SelectedIndex = 2;
            }
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chkTemplates.SelectedItems.Count == 0)
                MessageBox.Show("Nenhum template selecionado");
            else
                tabControl1.SelectedIndex = 4;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            if (txtOutputPath.Text == "")
            {
                MessageBox.Show("Favor informar o Path de saída!");
                return;
            }
            else if( Directory.Exists(txtOutputPath.Text) == false )
            {
                MessageBox.Show("O Path de saída informado não existe!");
                return;
            }

            if (txtTemplateProject.Text != "")
            {
                if (Directory.Exists(txtTemplateProject.Text) == false)
                {
                    MessageBox.Show("Template não encontrado!");
                    return;
                }
                else
                {
                    if (Directory.Exists(Path.Combine(txtOutputPath.Text, txtProjectName.Text)) == false)
                        DirectoryCopy(txtTemplateProject.Text, Path.Combine(txtOutputPath.Text, txtProjectName.Text), true);
                }
            }

            foreach (var template in chkTemplates.CheckedItems) 
            {
                Common.ITableTransformation cmd = orm.AvailableTableTemplates().Where(t => t.CommandID == template).Single();
                cmd.ProjectName = txtProjectName.Text;
                cmd.NameSpace = txtNameSpace.Text;

                foreach (var table in chkTables.CheckedItems)
                {
                    Common.TableModel tabela = orm.Tables.Where(t => t.Name == table).Single();
                    string tmp = cmd.ApplyTemplate(tabela, orm.Tables);

                    if (Directory.Exists(Path.Combine(txtOutputPath.Text, cmd.CommandID)) == false)
                        Directory.CreateDirectory(Path.Combine(txtOutputPath.Text, cmd.CommandID));

                    File.WriteAllText(Path.Combine(txtOutputPath.Text, cmd.CommandID + "\\" + cmd.FileName + cmd.Extension), tmp);
                }

                //if( chkArquivoUnico.Checked )
                //    File.WriteAllText(Path.Combine(txtOutputPath.Text, cmd.CommandID + ".result"), result);
            }

            if (chkProcedures.CheckedItems.Count > 0)
            {
                Common.IProcedureTransformation cmd = orm.AvailableProcTemplates().SingleOrDefault();
                cmd.ProjectName = txtProjectName.Text;
                cmd.NameSpace = txtNameSpace.Text;

                foreach (var proc in chkProcedures.CheckedItems)
                {
                    Common.ProcModel procedure = orm.Procedures.Where(t => t.Name == proc).Single();
                    string tmp = cmd.ApplyTemplate(procedure);

                    if (Directory.Exists(Path.Combine(txtOutputPath.Text, cmd.CommandID)) == false)
                        Directory.CreateDirectory(Path.Combine(txtOutputPath.Text, cmd.CommandID));

                    File.WriteAllText(Path.Combine(txtOutputPath.Text, cmd.CommandID + "\\" + cmd.FileName + cmd.Extension), tmp);
                }
            }

            writeLastExecution();
            MessageBox.Show("Ok");
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
                txtOutputPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void chkAll_CheckedChanged_1(object sender, EventArgs e)
        {
            chkAll_CheckedChanged(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
                txtTemplateProject.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
    }
}
