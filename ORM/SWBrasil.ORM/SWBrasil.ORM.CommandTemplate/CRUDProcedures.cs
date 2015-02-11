using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public class CRUDProcedures : CommandBase, ITableTransformation
    {
        public string CommandID { get { return "CRUDProcedures"; } }
        public string Description { get { return "Gera as Procedures de CRUD para a Tabela Informada!"; } }

        public string Extension
        {
            get { return ".sql"; }
        }

        public string FileName
        {
            get { return _fileName; }
        }

        public string Directory
        {
            get { return null; }
        }

        public string ApplyTemplate(TableModel table, List<TableModel> tables = null)
        {            
            string indexFields = "";
            string saveFields = "";
            string whereFields = "";
            string nonIndexFields = "";
            string nonIFValues = "";
            string updFields = "";
            string identity = "";
            _fileName = table.Name.Replace("tb_", "") + "_scripts";

            foreach (ColumnModel col in table.Columns.Where(c => c.IsPK == true).ToList())
            {
                indexFields += (indexFields != "" ? (Environment.NewLine + ",") : "");
                indexFields += "@" + col.Name + " \t" + col.DbType + (col.Size.HasValue ? "(" + col.Size.ToString() + ")" : "");
                if (col.IsIdentity)
                    indexFields += " = null output";

                whereFields += (whereFields != "" ? " AND " : "");
                whereFields += col.Name + " = @" + col.Name;

                nonIndexFields += (nonIndexFields != "" ? ", " : "");
                nonIndexFields += col.Name;

                nonIFValues += (nonIFValues != "" ? ", " : "");
                nonIFValues += "@" + col.Name;
            }
            foreach (ColumnModel col in table.Columns.Where(c => c.IsPK == false).ToList())
            {
                nonIndexFields += (nonIndexFields != "" ? ", " : "");
                nonIndexFields += col.Name;

                nonIFValues += (nonIFValues != "" ? ", " : "");
                nonIFValues += "@" + col.Name;

                updFields += (updFields != "" ? ", " : "");
                updFields+= col.Name + " = @" + col.Name;

                saveFields += (Environment.NewLine + ",");
                saveFields += "@" + col.Name + " \t" + col.DbType + (col.Size.HasValue ? "(" + col.Size.ToString() + ")" : "");
                if (col.Required == false)
                    saveFields += " = null";

            }
            ColumnModel identityColumn = table.Columns.Where(c => c.IsIdentity == true).SingleOrDefault();
            if (identityColumn != null)
                identity = "SET @" + identityColumn.Name + " = SCOPE_IDENTITY()";

            string deleteCmd = string.Format(Templates.Default.Procedure_Delete, table.Name, whereFields);
            string saveCmd = string.Format(Templates.Default.Procedure_Save, table.Name, whereFields, updFields, nonIndexFields, nonIFValues, identity);
            string selectCmd = string.Format(Templates.Default.Procedure_Select, nonIndexFields, table.Name, whereFields);

            string ret = string.Format(Templates.Default.Procedure_Base, ("pDel" + table.Name), indexFields.Replace(" = null output", ""), deleteCmd);
                   ret += string.Format(Templates.Default.Procedure_Base, ("pSel" + table.Name), indexFields.Replace(" = null output", ""), selectCmd);
                   ret += string.Format(Templates.Default.Procedure_Base, ("pSave" + table.Name), (indexFields + saveFields), saveCmd);

            return ret;
        }

        
    }
}
