using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public class SearchArguments: CommandBase, ITableTransformation
    {
        public string CommandID
        {
            get { return "SearchArguments"; }
        }

        public string Description
        {
            get { return "Create DTO Search Arguments Structure"; }
        }

        public string Extension
        {
            get { return ".cs"; }
        }

        public string FileName
        {
            get { return _fileName; }
        }

        public string ApplyTemplate(TableModel table, List<TableModel> tables = null)
        {
            _fileName = table.Name.Replace("tb_", "");
            string template = @"
public class {0}Args
{
{1}
}";
            StringBuilder columns = new StringBuilder();
            foreach (ColumnModel col in table.Columns)
            {
                string dataType = col.DataType;
                if (dataType != "string")
                    dataType += "?";

                columns.AppendLine("\tpublic " + dataType + " " + col.Name + " { get; set; }");
                columns.AppendLine("");
            }

            return template.Replace("{0}", _fileName).Replace("{1}", columns.ToString());
        }
    }
}
