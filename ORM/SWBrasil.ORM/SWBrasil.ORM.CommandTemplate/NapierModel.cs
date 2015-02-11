using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public class NapierModel : CommandBase, ITableTransformation
    {
        public string CommandID
        {
            get { return "NapierModel"; }
        }

        public string Description
        {
            get { return "Cria Model´s de Persistência no Padrão Napier"; }
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
            /*
             * 0 - Table Name
             * 1 - Columns
             
            [MapperAttribute(Name = "ID", IsKey = true, IsIdentity = true)]
            public int IDTabela { get; set; }

            [MapperAttribute(Name = "Nome")]
            public string NomeTeste { get; set; }
            */
            string className = table.Name.Replace("tb_", "") + "Model";
            _fileName = className;
            _directoryName = this.ProjectName + ".Data\\Models\\" + table.Group;

            string columns = "";
            string isPK = "";
            string isIdentity = "";
            string search = "";
            foreach (ColumnModel col in table.Columns)
            {
                isPK = col.IsPK ? ", IsKey = true" : "";
                isIdentity = col.IsIdentity ? ", IsIdentity = true" : "";
                
                columns += (columns == "" ? "" : Environment.NewLine);
                columns += col.Required && col.IsIdentity == false ? ("\t\t[Required]" + Environment.NewLine) : "";
                columns += string.Format("\t\t[MapperAttribute(Name = \"{0}\" {1} {2})]", col.Name, isPK, isIdentity) + Environment.NewLine;
                columns += string.Format("\t\tpublic {0} {1}", col.DataType, col.Name) + " { get; set; }" + Environment.NewLine;
                columns += Environment.NewLine;

                if (col.IsPK)
                {
                    search = "\t\tpublic static " + table.Name.Replace("tb_", "") + "Model" + " FindById(" + col.DataType + " id)" + Environment.NewLine;
                    search += "\t\t{" + Environment.NewLine;
                    search += "\t\t\t" + "return " + table.Name.Replace("tb_", "") + "Model.Find<" + table.Name.Replace("tb_", "") + "_Model>(\"SEL\", \"" + col.Name + "='\" + id + \"'\");" + Environment.NewLine;
                    search += "\t\t}" + Environment.NewLine;
                    search += Environment.NewLine;
                }

                if (col.IsUniqueKey)
                {
                    search = "\t\tpublic static " + table.Name.Replace("tb_", "") + "Model" + " FindBy" + col.Name + "(" + col.DataType + " value)" + Environment.NewLine;
                    search += "\t\t{" + Environment.NewLine;
                    search += "\t\t\t" + "return " + table.Name.Replace("tb_", "") + "Model.Find<" + table.Name.Replace("tb_", "") + "_Model>(\"SEL\", \"" + col.Name + "='\" + value + \"'\");" + Environment.NewLine;
                    search += "\t\t}" + Environment.NewLine;
                    search += Environment.NewLine;
                }
            }

            return Templates.Default.NapierModel.Replace("{0}", className).Replace("{1}", columns).Replace("{2}", search).Replace("{3}", base.NameSpace);
        }
    }
}
