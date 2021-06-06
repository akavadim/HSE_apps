using System;
using System.Collections.Generic;
using System.Text;

namespace Arnet.Database
{
    public class CompanyComplaint
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ComplaintId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Complaint Complaint { get; set; }
    }
}
