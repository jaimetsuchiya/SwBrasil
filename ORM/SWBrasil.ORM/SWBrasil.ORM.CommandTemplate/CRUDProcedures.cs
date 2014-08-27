using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public class CRUDProcedures: ICommand
    {
        public string CommandID { get { return "CRUDProcedures"; } }
        public string Description { get { return "Gera as Procedures de CRUD para a Tabela Informada!"; } }

        public string ApplyTemplate(TableModel table)
        {
            string ret = "";
            string pDelete = @"
    CREATE PROC dbo.pDel{0}
    (
	    {1}
    ) AS
    BEGIN

        DELETE FROM {0} WHERE {2}

    END
    GO

";
            string indexFields = "";
            string whereFields = "";

            foreach (ColumnModel col in table.Columns.Where(c => c.IsPK == true).ToList())
            {
                indexFields += (indexFields != "" ? (Environment.NewLine + ",") : "");
                indexFields += "@" + col.Name + " \t" + col.DbType + (col.Size.HasValue ? "(" + col.Size.ToString() + ")" : "");
                whereFields += (whereFields != "" ? " AND " : "");
                whereFields += col.Name + " = @" + col.Name;
            }

            ret = string.Format(pDelete, table.Name, indexFields, whereFields);

            string pSave = @"
    CREATE PROC dbo.pSave{0}
    (
	    {1}
    ) AS
    BEGIN

        IF EXISTS(SELECT 1 FROM {0} WHERE {2})
        BEGIN
            UPDATE 
                {0}
            SET
                {3}
            WHERE
                {2}
        END
        ELSE
        BEGIN
            
            INSERT INTO {0}
            (
                {4}
            )
            VALUES
            (
                {5}
            )

            SET {6} = {7}

        END
    END
    GO

";
           
            return ret;
        }

        
    }
}
