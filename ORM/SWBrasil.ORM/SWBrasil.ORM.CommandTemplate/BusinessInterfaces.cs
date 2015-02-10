using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public class BusinessInterfaces : CommandBase, ITableTransformation
    {
        public string CommandID
        {
            get { return "BusinessInterfaces"; }
        }

        public string Description
        {
            get { return "Cria Interfaces para as Classes de Fachada"; }
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
            sb.AppendLine("public interface I" + className);
            sb.AppendLine("{");
            sb.AppendLine("\tOutputTransport<" + DTO + "> Salvar(InputTransport<" + DTO + "> model, bool abrirTransacao = true);");
            sb.AppendLine("");
            sb.AppendLine("\tList<" + DTO + "> Search(" + className + "Args args);");
            sb.AppendLine("");

            foreach (ColumnModel col in table.Columns)
            {
                string search = "";
                if (col.IsPK)
                {
                    search = "\t" + table.Name.Replace("tb_", "") + "DTO" + " FindById(" + col.DataType + " id);";
                    search += Environment.NewLine;
                }

                if (col.IsUniqueKey)
                {
                    search = "\t" + table.Name.Replace("tb_", "") + "DTO" + " FindBy" + col.Name + "(" + col.DataType + " value);";
                    search += Environment.NewLine;
                }

                sb.Append(search);
            }
            sb.AppendLine("}");
            return sb.ToString();
        }


    }
}

