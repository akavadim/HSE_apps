using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arnet.Database;

namespace Arnet.Web.Areas.Account.Models.Manage
{
    public class ProfileModel
    {
        public ProfileModel(ARNETContext db, Database.Account account)
        {
            this.Account = account;
            this.db = db;
        }

        private ARNETContext db { get; }

        public Database.Account Account { get; }

        public Email Email { get => db.Emails.FirstOrDefault(m => m.AccountId == Account.AccountId);  }

        public Phone Phone { get => db.Phones.First(m => m.AccountId == Account.AccountId); }

        public string AccountType { 
            get 
            {
                switch(db.AccountTypes.First(m=>m.AccountTypeId==Account.AccountTypeId).Type)
                {
                    case AccountTypesEnum.Admin: return "Администратор";
                    case AccountTypesEnum.Agency: return "Агентство";
                    case AccountTypesEnum.Agent: return "Агент";
                    case AccountTypesEnum.User: return null;
                    default: return null;
                }
            } 
        }
    }
}
