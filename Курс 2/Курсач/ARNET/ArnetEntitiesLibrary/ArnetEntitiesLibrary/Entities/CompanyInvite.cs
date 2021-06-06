using System;
using System.Collections.Generic;
using System.Text;

namespace Arnet.Database
{
    public class CompanyInvite
    {
        public int InviteId { get; set; }
        public int CompanyId { get; set; }
        public string Md5 { get; set; }
        public DateTime DateTo { get; set; }

        public virtual Company Company { get; set; }
    }
}
