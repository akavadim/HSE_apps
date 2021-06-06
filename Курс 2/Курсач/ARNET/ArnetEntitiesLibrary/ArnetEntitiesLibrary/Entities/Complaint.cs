using System;
using System.Collections.Generic;
using System.Text;

namespace Arnet.Database
{
    public class Complaint
    {
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public string Reason { get; set; }
        public string Response { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual AccountComplaint AccountComplaint { get; set; }
        public virtual CompanyComplaint CompanyComplaint { get; set; }
        public virtual Account Sender { get; set; }
    }
}
