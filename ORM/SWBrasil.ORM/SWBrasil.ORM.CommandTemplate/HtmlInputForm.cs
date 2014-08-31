using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public class HtmlInputForm: ICommand
    {
        public string CommandID
        {
            get { return "HtmlInputForm"; }
        }

        public string Description
        {
            get { return "HtmlInputForm"; }
        }

        public string ApplyTemplate(TableModel table)
        {
            string ret = "";
            foreach (ColumnModel col in table.Columns)
            {
                ret += ret == "" ?"" : Environment.NewLine;
                ret += string.Format(Templates.Default.HtmlInput, col.Name, "");
            }

            return ret;
        }
    }
}
