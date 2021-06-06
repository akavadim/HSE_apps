using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arnet.Database
{
    public partial class Phone
    {

        //БД
        public int PhoneId { get; set; }
        public int AccountId { get; set; }
        public string Number { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Account Account { get; set; }
    }
}
