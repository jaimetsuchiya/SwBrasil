using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public class FacadeClass : CommandBase, ITableTransformation
    {
        public string CommandID
        {
            get { return "FacadeClass"; }
        }

        public string Description
        {
            get { return "Cria Classes de Fachada para os métodos CRUD"; }
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
            string className = table.Name.Replace("tb_", "");
            string DTO = className + "DTO";
            _fileName = className;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("public class " + className + ": " + className + "Base, I" + className );
            sb.AppendLine("{");
            sb.AppendLine("\tpublic " + className + "(ILogger loggerBO): base(loggerBO)");
            sb.AppendLine("\t{");
            sb.AppendLine("\t}");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("\tpublic OutputTransport<" + DTO + "> Salvar(InputTransport<" + DTO + "> model, bool abrirTransacao = true)");
            sb.AppendLine("\t{");
            sb.AppendLine("\t\treturn base.Salvar(model, abrirTransacao);");
            sb.AppendLine("\t}");
            sb.AppendLine("");
            foreach (ColumnModel col in table.Columns)
            {
                string search = "";
                if (col.IsPK)
                {
                    search = "\tpublic " + table.Name.Replace("tb_", "") + "DTO" + " FindById(" + col.DataType + " id)" + Environment.NewLine;
                    search += "\t{" + Environment.NewLine;
                    search += "\t\treturn base.FindById(id);" + Environment.NewLine;
                    search += "\t}" + Environment.NewLine;
                    search += Environment.NewLine;
                }

                if (col.IsUniqueKey)
                {
                    search = "\tpublic " + table.Name.Replace("tb_", "") + "DTO" + " FindBy" + col.Name + "(" + col.DataType + " value)" + Environment.NewLine;
                    search += "\t{" + Environment.NewLine;
                    search += "\t\t" + "return base.FindBy" + col.Name + "(value);" + Environment.NewLine;
                    search += "\t}" + Environment.NewLine;
                    search += Environment.NewLine;
                }

                sb.Append(search);
            }
            sb.AppendLine("}");
            return sb.ToString();
        }


    }
}

