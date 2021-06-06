using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arnet.Database;

namespace Arnet.Web.Models.Admin
{
    public class InvitesViewModel
    {
       public ModeratorInvite Invite { get; set; }

        public string Url { get; set; }
    }
}