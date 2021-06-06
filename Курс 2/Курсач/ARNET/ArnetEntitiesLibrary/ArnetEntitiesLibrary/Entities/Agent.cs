using System;
using System.Collections.Generic;
using System.Text;

namespace Arnet.Database
{
    public class Agent
    {
        public int AgentId { get; set; }
        public int AccountId { get; set; }
        public int CompanyId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Account Account { get; set; }
        public virtual Company Company { get; set; }
    }
}
