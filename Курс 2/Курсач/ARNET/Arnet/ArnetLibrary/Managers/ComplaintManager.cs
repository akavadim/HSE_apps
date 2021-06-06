using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Arnet.Managers;
using Arnet.Database;

namespace ArnetLibrary.Managers
{
    public class ComplaintManager
    {
        private ARNETContext db;
        private AccountManager accountManager;

        /// <summary>
        /// Отпраялет жалобу на аккаунт
        /// </summary>
        /// <param name="accountTo"></param>
        /// <param name="accountFrom"></param>
        /// <param name="reason"></param>
        /// <exception cref="InvalidOperationException">Аккаунт(виновник) с таким id не найден</exception>
        /// <exception cref="ArgumentNullException">Причина не указана</exception>
        public void ComplainAccount(int accountIdTo, string reason, int? accountIdFrom = null)
        {
            if (string.IsNullOrEmpty(reason))
                throw new ArgumentNullException(nameof(reason));

            AccountComplaint accountComplaint = new AccountComplaint() { AccountId = accountIdTo };
            Complaint complaint = new Complaint() 
            {
                DateFrom = DateTime.UtcNow, 
                Reason = reason, 
                SenderId = accountIdFrom, 
                AccountComplaint=accountComplaint 
            };

            db.Complaints.Add(complaint);
            db.SaveChanges();
        }

        /// <summary>
        /// Отпраялет жалобу на комппанию
        /// </summary>
        /// <param name="companyTo"></param>
        /// <param name="accountFrom"></param>
        /// <param name="reason"></param>
        /// <exception cref="InvalidOperationException">Аккаунт(виновник) с таким id не найден</exception>
        /// <exception cref="ArgumentNullException">Причина не указана</exception>
        public void ComplainCompany(int companyIdTo, string reason, int? accountIdFrom = null)
        {
            if (string.IsNullOrEmpty(reason))
                throw new ArgumentNullException(nameof(reason));

            CompanyComplaint companyComplaint = new CompanyComplaint() { CompanyId = companyIdTo };
            Complaint complaint = new Complaint()
            {
                DateFrom = DateTime.UtcNow,
                Reason = reason,
                SenderId = accountIdFrom,
                CompanyComplaint = companyComplaint
            };

            db.Complaints.Add(complaint);
            db.SaveChanges();
        }
    }
}
