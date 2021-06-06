using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class Ban
    {
        public int BanId { get; set; }
        public int AccountId { get; set; }
        public string Comment { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Account Account { get; set; }
    }
}
