using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arnet.Database
{
    public partial class Account
    {
        public Account()
        {
            Apartments = new HashSet<Apartment>();
            Bans = new HashSet<Ban>();
            Companies = new HashSet<Company>();
            Emails = new HashSet<Email>();
            InverseInviters = new HashSet<Account>();
            Passwords = new HashSet<Password>();
            Phones = new HashSet<Phone>();
            Agents = new HashSet<Agent>();
        }

        public int AccountId { get; set; }
        public int AccountTypeId { get; set; }
        public int? ImageId { get; set; }
        public int? InviterId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual AccountTypes AccountType { get; set; }
        public virtual Image Image { get; set; }
        public virtual Account Inviter { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
        public virtual ICollection<Ban> Bans { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Account> InverseInviters { get; set; }
        public virtual ICollection<Password> Passwords { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Agent> Agents { get; set; }
        public virtual ICollection<AccountComplaint> AccountComplaints { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; }
    }
}
