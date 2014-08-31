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
            if (orm.Connect(string.Format("Data Source={0}; Initial Catalog={1}; User Id={2}; Password={3};", txtDataSource.Text, txtInitialCatalog.Text, txtUserID.Text, txtPassword.Text)))
            {
                chkTables.Items.Clear();
                foreach (Common.TableModel tabela in orm.Tables)
                    chkTables.Items.Add(tabela.Name);

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
            if (chkTables.SelectedItems.Count == 0)
                MessageBox.Show("Nenhuma tabela selecionada");
            else
            {
                List<Common.ICommand> lstCmd = orm.AvailableTemplates();

                chkTemplates.Items.Clear();
                foreach (Common.ICommand cmd in lstCmd)
                    chkTemplates.Items.Add(cmd.CommandID);
             
                tabControl1.SelectedIndex = 2;
            }
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chkTemplates.SelectedItems.Count == 0)
                MessageBox.Show("Nenhum template selecionado");
            else
                tabControl1.SelectedIndex = 3;
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

            foreach (var template in chkTemplates.CheckedItems) 
            {
                Common.ICommand cmd = orm.AvailableTemplates().Where(t => t.CommandID == template).Single();
                string result = "";
                foreach (var table in chkTables.CheckedItems)
                {
                    Common.TableModel tabela = orm.Tables.Where(t => t.Name == table).Single();
                    result += cmd.ApplyTemplate(tabela);
                    result += Environment.NewLine;
                    result += Environment.NewLine;
                }

                File.WriteAllText(Path.Combine(txtOutputPath.Text, cmd.CommandID + ".result"), result);
            }

            writeLastExecution();
            MessageBox.Show("Ok");
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
    }
}
