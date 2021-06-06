using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arnet.Database
{
    public partial class Email
    {
        public int EmailId { get; set; }
        public int AccountId { get; set; }
        public string Value { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Account Account { get; set; }


        //В EmailValidator?
        public bool IsEmail()
        {
            return IsEmail(Value);
        }

        public static bool IsEmail(string email)
        {
            try
            {
                System.Net.Mail.MailAddress mailAddress = new System.Net.Mail.MailAddress(email);
                return email == mailAddress.Address;
            }
            catch
            {
                return false;
            }
        }
    }
}
