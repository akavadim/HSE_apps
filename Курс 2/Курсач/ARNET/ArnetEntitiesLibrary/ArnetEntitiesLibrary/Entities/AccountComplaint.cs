using System;
using System.Collections.Generic;
using System.Text;

namespace Arnet.Database
{
    public class AccountComplaint
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int ComplaintId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Complaint Complaint { get; set; }
    }
}
