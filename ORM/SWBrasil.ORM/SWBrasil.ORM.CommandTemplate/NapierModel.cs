using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public class NapierModel: ICommand
    {
        public string CommandID
        {
            get { return "NapierModel"; }
        }

        public string Description
        {
            get { return "Cria Model´s de Persistência no Padrão Napier"; }
        }

        public string ApplyTemplate(TableModel table)
        {
            /*
             * 0 - Table Name
             * 1 - Columns
             
            [MapperAttribute(Name = "ID", IsKey = true, IsIdentity = true)]
            public int IDTabela { get; set; }

            [MapperAttribute(Name = "Nome")]
            public string NomeTeste { get; set; }
            */

            string columns = "";
            string isPK = "";
            string isIdentity = "";

            foreach (ColumnModel col in table.Columns)
            {
                isPK = col.IsPK ? ", IsKey = true" : "";
                isIdentity = col.IsIdentity ? ", IsIdentity = true" : "";
                
                columns += (columns == "" ? "" : Environment.NewLine);
                columns += col.Required && col.IsIdentity == false ? ("\t\t[Required]" + Environment.NewLine) : "";
                columns += string.Format("\t\t[MapperAttribute(Name = \"{0}\" {1} {2})]\r\n", col.Name, isPK, isIdentity);
                columns += string.Format("\t\tpublic {0} {1}", col.DataType, col.Name) + " { get; set; }";
                columns += Environment.NewLine;
            }

            return Templates.Default.NapierModel.Replace("{0}", table.Name).Replace("{1}", columns);
        }
    }
}
