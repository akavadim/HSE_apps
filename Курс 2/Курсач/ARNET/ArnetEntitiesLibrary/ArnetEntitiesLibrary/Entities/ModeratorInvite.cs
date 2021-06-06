using System;
using System.Collections.Generic;
using System.Text;

namespace Arnet.Database
{
    public class ModeratorInvite
    {
        public int InviteId { get; set; }
        public string Md5 { get; set; }
        public DateTime DateTo { get; set; }
    }
}
