﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public class RESTController : CommandBase, ITableTransformation
    {
        public string CommandID
        {
            get { return "RESTCommand"; }
        }

        public string Description
        {
            get { return "Cria os métodos básicos de um controller REST"; }
        }

        public string Extension
        {
            get { return ".cs"; }
        }

        public string ApplyTemplate(TableModel table, List<TableModel> tables = null)
        {
            _fileName = table.Name.Replace("tb_", "");
            if( string.IsNullOrEmpty(table.Group))
                return "";

            return Templates.Default.RESTController.Replace("{GROUP}", table.Group).Replace("{TABLE_NAME}", _fileName);
        }

        public string FileName
        {
            get { return _fileName; }
        }
    }
}
