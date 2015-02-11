using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public class NapierXML : CommandBase, ITableTransformation
    {
        public string CommandID
        {
            get { return "NapierXML"; }
        }

        public string Description
        {
            get { return "NapierXML"; }
        }

        public string Extension
        {
            get { return ".xml"; }
        }

        public string FileName
        {
            get { return _fileName; }
        }

        public string Directory
        {
            get { return _directoryName; }
        }

        public string ApplyTemplate(TableModel table, List<TableModel> tables = null)
        {
            /*
             * 0 - Table Name
             * 1 - All Fields
             * 2 - Non PK Fields
             * 3 - PK Fields
             */
            _fileName = table.Name;
            _directoryName = this.ProjectName + ".Data\\NapierXML\\" + table.Group;

            string allFields = "";
            foreach (ColumnModel col in table.Columns)
                allFields += string.Format("\t\t<Input>{0}</Input>", col.Name) + Environment.NewLine;
            
            string pkFields = "";
            foreach (ColumnModel col in table.Columns.Where(c=>c.IsPK == true).ToList())
                pkFields += string.Format("\t\t<Input>{0}</Input>", col.Name) + Environment.NewLine;

            string nPkFields = "";
            foreach (ColumnModel col in table.Columns.Where(c => c.IsPK == false).ToList())
                nPkFields += string.Format("\t\t<Input>{0}</Input>", col.Name) + Environment.NewLine;

            return string.Format( Templates.Default.Napier_Execution_XML, table.Name, allFields, nPkFields, pkFields);
        }
    }
}
