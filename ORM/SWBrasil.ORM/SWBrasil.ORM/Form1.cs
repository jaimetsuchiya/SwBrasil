using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWBrasil.ORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtConnectionString.Text = @"Data Source=SWBRASIL-02\PREPAGO; User Id=sa; Password=S!sTeM@s; Initial Catalog=Lotecando;";
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

        }



    }
}
