using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWBrasil.ORM.Common;

namespace SWBrasil.ORM.CommandTemplate
{
    public class RESTController:ICommand
    {
        public string CommandID
        {
            get { return "RESTCommand"; }
        }

        public string Description
        {
            get { return "Cria os métodos básicos de um controller REST"; }
        }

        public string ApplyTemplate(TableModel table)
        {
            string restService = @"
";
            return "";
        }
    }
}
