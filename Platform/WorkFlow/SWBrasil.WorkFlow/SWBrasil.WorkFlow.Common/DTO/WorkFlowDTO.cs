using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWBrasil.WorkFlow.Common
{
    public class WorkFlowDTO
    {
        public string version { get; set; }
        
        public string name { get; set; }

        public string modelStructure { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

        public WorkFlowCommandDTO Commands { get; set; }

        public string[] roles { get; set; }


    }

    public enum enumWorkFlowCommandType
    {
        Void = 0,
        Validate = 1,
        Switch = 2
    }

    public class WorkFlowCommandDTO
    {
        public string key { get; set; }
        public enumWorkFlowCommandType type { get; set; }
        public string progId { get; set; }
    }


}
