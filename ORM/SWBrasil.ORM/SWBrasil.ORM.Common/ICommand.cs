using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWBrasil.ORM.Common
{
    public interface ICommand
    {
        string CommandID { get; }
        string Extension { get; }
        string Description { get; }
        string FileName { get; }

        string Directory { get; }
        string ProjectName { get; set; }
        string NameSpace { get; set; }
    }

    public interface ITableTransformation: ICommand
    {
        string ApplyTemplate(TableModel table, List<TableModel> tables = null);
    }

    public interface IProcedureTransformation : ICommand
    {
        string ApplyTemplate(ProcModel procedure);
    }
}
