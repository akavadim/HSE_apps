using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class Password
    {
        public int PasswordId { get; set; }
        public int AccountId { get; set; }
        public string Value { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Account Account { get; set; }
    }
}
