using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public class CRUDServiceProxy : CommandBase, ITableTransformation
    {
        public string CommandID
        {
            get { return "CRUDServiceProxy"; }
        }

        public string Description
        {
            get { return "Cria os métodos de Proxy para realização do CRUD (Serviço)"; }
        }

        public string Extension
        {
            get { return ".html"; }
        }

        public string Directory
        {
            get { return _directoryName; }
        }

        public string ApplyTemplate(TableModel table, List<TableModel> tables = null)
        {
            _fileName = table.Name.Replace("tb_", "") + "s";
            _directoryName = this.NameSpace + ".UI\\Views\\" + table.Group;

            if( string.IsNullOrEmpty(table.Group))
                return "";

            return Templates.Default.PROXYMethods.Replace("{GROUP}", table.Group).Replace("{TABLE_NAME}", _fileName);
        }

        public string FileName
        {
            get { return _fileName; }
        }
    }
}
