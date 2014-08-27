using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWBrasil.ORM
{
    public abstract class BaseORM
    {
        public abstract bool Connect(string connectionString);

        public string ApplyTemplate(TableModel table, string template)
        {
            return null;
        }

        public abstract string ConvertDataType(string dataBaseType);

        public List<TableModel> Tables { get; set; }
    }
}
