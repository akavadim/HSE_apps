using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arnet.Database
{
    public partial class Company
    {
        public Company()
        {
            Agents = new HashSet<Agent>();
            CompanyInvites = new HashSet<CompanyInvite>();
        }

        public int CompanyId { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Account Owner { get; set; }

        public virtual HashSet<Agent> Agents { get; set; }
        public virtual HashSet<CompanyInvite> CompanyInvites { get; set; }
        public virtual HashSet<CompanyComplaint> CompanyComplaints { get; set; }
    }
}
