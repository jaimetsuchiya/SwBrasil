using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public class ImplementationClass : CommandBase, ITableTransformation
    {
        public string CommandID
        {
            get { return "ImplementationClass"; }
        }

        public string Description
        {
            get { return "Cria Classes de Implementação"; }
        }

        public string Extension
        {
            get { return ".cs"; }
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
            string className = table.Name.Replace("tb_", "");
            string DTO = className + "DTO";
            _fileName = className + "Base";
            _directoryName = this.ProjectName + ".Core\\Base\\" + table.Group;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("public class " + className + "Base");
            sb.AppendLine("{");
            sb.AppendLine("\tILogger _loggerBO = null;");
            sb.AppendLine("\tpublic " + className + "(ILogger loggerBO)");
            sb.AppendLine("\t{");
            sb.AppendLine("\t\t_loggerBO = loggerBO;");
            sb.AppendLine("\t}");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("\tprotected virtual OutputTransport<" + DTO + "> Salvar(InputTransport<" + DTO + "> model, bool abrirTransacao = true)");
            sb.AppendLine("\t{");
            sb.AppendLine("\t\tOutputTransport<" + DTO + "> ret = new OutputTransport<" + DTO + ">()");
            sb.AppendLine("\t\t" + DTO + " dto = model.Data;");
            sb.AppendLine("     ");
            sb.AppendLine("\t\ttry");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\tif (abrirTransacao)");
            sb.AppendLine("\t\t\t{");
            sb.AppendLine("\t\t\t\tusing (var c = new TransactionScope(TransactionScopeOption.Required))");
            sb.AppendLine("\t\t\t\t\t{");
            sb.AppendLine("                 ret = Save(dto, model.UserName);");
            sb.AppendLine("                 ");
            sb.AppendLine("                 if (openTransacation)");
            sb.AppendLine("                     c.Complete();");
            sb.AppendLine("\t\t\t\t}");
            sb.AppendLine("\t\t\t}");
            sb.AppendLine("\t\t\telse");
            sb.AppendLine("\t\t\t\tret = Salvar(ref dto, model.UserName);");
            sb.AppendLine("\t\t\t}");
            sb.AppendLine("\t\t\tcatch (Exception err)");
            sb.AppendLine("\t\t\t{");
            sb.AppendLine("\t\t\t\tLoggerDTO log = new LoggerDTO();");
            sb.AppendLine("\t\t\t\tlog.createdBy = model.UserName;");
            sb.AppendLine("\t\t\t\tlog.createdOn = DateTime.Now;");
            sb.AppendLine("\t\t\t\tlog.message = \"" + className + ".Salvar \" + Environment.NewLine + err.Message;");
            sb.AppendLine("\t\t\t\tlog.source = err.StackTrace;");
            sb.AppendLine("\t\t\t\t_loggerBO.AddLog(ref log);");
            sb.AppendLine("\t\t\t}");
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("\tprotected virtual OutputTransport<" + DTO + "> Salvar(" + DTO + " dto, string userID)");
            sb.AppendLine("\t{");
            sb.AppendLine("\t\tthrow new ApplicationException(\"Método não implementado!\");");
            sb.AppendLine("\t}");
            sb.AppendLine("\tprotected virtual " + DTO + " BuildFromNapier(" + table.Name.Replace("tb_", "") + "Model model)");
            sb.AppendLine("\t{");
            sb.AppendLine("\t\t" + DTO + " ret = new " + DTO + "();");
            sb.AppendLine("\t\tHelper.CopyFromNapier<" + DTO + "," + table.Name.Replace("tb_", "") + "Model>(model, ref ret);");
            sb.AppendLine("\t\treturn ret;");
            sb.AppendLine("\t}");
            foreach (ColumnModel col in table.Columns)
            {
                string search = "";
                if (col.IsPK)
                {
                    search = "\tprotected virtual " + table.Name.Replace("tb_", "") + "DTO" + " FindById(" + col.DataType + " id)" + Environment.NewLine;
                    search += "\t{" + Environment.NewLine;
                    search += "\t\t" + table.Name.Replace("tb_", "") + "DTO ret = null;" + Environment.NewLine;
                    search += "\t\t" + table.Name.Replace("tb_", "") + "Model tmp = " + table.Name.Replace("tb_", "") + "Model.FindById(id);" + Environment.NewLine;
                    search += "\t\t" + "if( tmp != null )" + Environment.NewLine;
                    search += "\t\t" + "{" + Environment.NewLine;
                    search += "\t\t" + "  ret = BuildFromNapier(tmp);" + Environment.NewLine;
                    search += "\t\t" + "}" + Environment.NewLine;
                    search += "\t\t" + "return ret;"+ Environment.NewLine;
                    search += "\t}" + Environment.NewLine;
                    search += Environment.NewLine;
                }

                if (col.IsUniqueKey)
                {
                    search = "\tprotected virtual " + table.Name.Replace("tb_", "") + "DTO" + " FindBy" + col.Name + "(" + col.DataType + " value)" + Environment.NewLine;
                    search += "\t{" + Environment.NewLine;
                    search += "\t\t" + table.Name.Replace("tb_", "") + "DTO ret = null;" + Environment.NewLine;
                    search += "\t\t" + table.Name.Replace("tb_", "") + "Model tmp = " + table.Name.Replace("tb_", "") + "Model.FindBy" + col.Name +"(value);" + Environment.NewLine;
                    search += "\t\t" + "if( tmp != null )" + Environment.NewLine;
                    search += "\t\t" + "{" + Environment.NewLine;
                    search += "\t\t" + "  ret = BuildFromNapier(tmp);" + Environment.NewLine;
                    search += "\t\t" + "}" + Environment.NewLine;
                    search += "\t\t" + "return ret;" + Environment.NewLine;
                    search += Environment.NewLine;
                }

                sb.Append(search);
            }
            sb.AppendLine("}");
            return sb.ToString();
        }


    }
}

