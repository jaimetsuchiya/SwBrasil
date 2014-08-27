using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWBrasil.ORM
{
    public class TableModel
    {
        public string Name { get; set; }
        public List<ColumnModel> Columns { get; set; }
    }

    public class ColumnModel
    {
        public string Name { get; set; }
        
        public bool Required { get; set; }
        public string DataType { get; set; }
        public string DbType { get; set; }
        public int? Size { get; set; }
        public int? Precision { get; set; }

        public bool IsPK { get; set; }
        public string RelatedTable{get;set;}
    }
}
