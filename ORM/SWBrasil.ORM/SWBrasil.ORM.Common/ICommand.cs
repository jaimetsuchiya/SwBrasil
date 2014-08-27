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
        string Description { get; }

        string ApplyTemplate(TableModel table);
    }
}
