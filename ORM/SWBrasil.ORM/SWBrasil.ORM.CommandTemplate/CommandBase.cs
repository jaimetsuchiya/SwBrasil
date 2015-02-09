using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public abstract class CommandBase
    {
        protected string _fileName = "";
        protected ColumnModel RelatedColumn(ColumnModel column, List<TableModel> tables)
        {
            ColumnModel ret= null;
            if (tables != null)
            {
                var rTable = tables.Where(t => t.Name == column.RelatedTable).FirstOrDefault();
                if (rTable != null)
                {
                    var key = rTable.Columns.Where(c => c.IsPK == true).FirstOrDefault();
                    if (key != null)
                    {
                        if (column.DataType == key.DataType)
                            ret = key;
                        else
                        {
                            key = rTable.Columns.Where(c => c.IsUniqueKey == true).FirstOrDefault();
                            if (key != null && column.DataType == key.DataType)
                                ret = key;
                        }
                    }
                }
            }

            return ret;
        }

        protected TableModel RelatedTable(ColumnModel column, List<TableModel> tables)
        {
            TableModel ret = null;
            if (tables != null)
            {
                var rTable = tables.Where(t => t.Name == column.RelatedTable).FirstOrDefault();
                if (rTable != null)
                    ret = rTable;
            }

            return ret;
        }
    }
}
