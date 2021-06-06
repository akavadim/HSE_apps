using System;
using System.Collections.Generic;

namespace Arnet.Database
{
    public partial class AccountTypes
    {
        public AccountTypes()
        {
            Accounts = new HashSet<Account>();
        }

        public int AccountTypeId { get; set; }
        public AccountTypesEnum Type { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }

    public enum AccountTypesEnum { User, Agency, Agent, Admin, Moderator};
}
