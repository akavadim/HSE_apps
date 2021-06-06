using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arnet.Web.Models.Agency
{
    public class InvitesViewModel
    {
        public int InviteId { get; set; }
        public string Url { get; set; }
        public DateTime DateTo { get; set; }
    }
}
