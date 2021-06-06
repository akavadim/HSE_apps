using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Arnet.Database;
using Microsoft.EntityFrameworkCore;

namespace Arnet.Managers
{

    public class AccountEventArgs : EventArgs
    {
        public AccountEventArgs() { }

        public AccountEventArgs(Account account)
        {
            this.Account = account;
        }

        public Account Account { get; set; }
    }

    public class AccountManager
    {
        public delegate void AccountEventHandler(object sender, AccountEventArgs args);

        public event AccountEventHandler AccountClosing;

        private ARNETContext db;

        public AccountManager(ARNETContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Действуюшие аккаунты, включая заблокированных
        /// </summary>
        public IQueryable<Account> Accounts { get => db.Accounts
                .Where(a => (a.DateTo == null || a.DateTo >= DateTime.Now)); }

        #region Аккаунты по типам

        
        public IQueryable<Account> Agents { get => Accounts.Include(a=>a.AccountType).Where(a=>a.AccountType.Type==AccountTypesEnum.Agency); }
        public IQueryable<Account> Agencies { get => Accounts.Include(a => a.AccountType).Where(a => a.AccountType.Type == AccountTypesEnum.Agency); }
        public IQueryable<Account> Admins { get => Accounts.Include(a => a.AccountType).Where(a => a.AccountType.Type == AccountTypesEnum.Admin); }
        public IQueryable<Account> Users { get => Accounts.Include(a => a.AccountType).Where(a => a.AccountType.Type == AccountTypesEnum.User); }
        public IQueryable<Account> Moderators { get => Accounts.Include(a => a.AccountType).Where(a => a.AccountType.Type == AccountTypesEnum.Moderator); }

        public IQueryable<Account> ActiveAccounts { get => Accounts.Where(a => !BannedAccounts.Any(b => b.AccountId == a.AccountId)); }
        public IQueryable<Account> BannedAccounts { get => Bans.Select(b => db.Accounts.First(a => a.AccountId == b.AccountId)); }
        #endregion

        #region Активные почта, телефоны, пароли, баны

        public IQueryable<Email> Emails { get => db.Emails.Where(a => a.DateTo == null || a.DateTo >= DateTime.UtcNow); }
        public IQueryable<Phone> Phones { get => db.Phones.Where(a => a.DateTo == null || a.DateTo >= DateTime.UtcNow); }
        public IQueryable<Password> Passwords { get => db.Passwords.Where(a => a.DateTo == null || a.DateTo >= DateTime.UtcNow); }
        public IQueryable<Ban> Bans { get => db.Bans.Where(b => b.DateTo == null || b.DateTo >= DateTime.UtcNow); }

        #endregion

        #region Телефон, Email

        /// <summary>
        /// Находит аккаунт по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Account</returns>
        public Account FindById(int id)
        {
            return Accounts.FirstOrDefault(a => a.AccountId == id);
        }

        /// <summary>
        /// Находит аккаунт по номеру телефона
        /// </summary>
        /// <param name="phone">номер телефона</param>
        /// <returns>Найденный аккаунт</returns>
        public Account FindByPhone(string phone)
        {
            Account account = null;
            Phone phoneClass = Arnet.Library.PhoneConverter.TryCreatePhone(phone);

            if (phoneClass != null)
            {
                Phone foundPhone = Phones.FirstOrDefault(p => p.Number == phoneClass.Number);
                if (foundPhone != null)
                    account = FindById(foundPhone.AccountId);
            }
            return account;
        }

        /// <summary>
        /// Находит аккаунт по почте
        /// </summary>
        /// <param name="email">почта</param>
        /// <returns>Аккаунт</returns>
        public Account FindByEmail(string email)
        {
            try
            {
                System.Net.Mail.MailAddress mail = new System.Net.Mail.MailAddress(email);
                Email foundMail = Emails.FirstOrDefault(e => e.Value == mail.Address);
                Account account = null;
                if (foundMail != null)
                    account = Accounts.FirstOrDefault(a => a.AccountId == foundMail.AccountId);
                return account;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Получение информации об аккаунте

        /// <summary>
        /// Находит тип аккаунта
        /// </summary>
        /// <param name="accountId">id аккаунта</param>
        /// <returns>Тип аккаунта</returns>
        /// <exception cref="InvalidOperationException">Аккаунт с таким id не существует</exception>
        public AccountTypesEnum GetAccountType(int accountId)
        {
            Account account = db.Accounts.First(a=>a.AccountId==accountId);
            AccountTypes accountType = db.AccountTypes.Find(account.AccountTypeId);
            return accountType.Type;
        }

        #endregion

        #region Изменение аккаунта

        /// <summary>
        /// Меняет email
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="email"></param>
        /// <returns>True - email изменен, false - новый email совпадает с старым</returns>
        /// <exception cref="FormatException">email is not in a recognized format.</exception>
        /// <exception cref="InvalidOperationException">не найден аккаунта с acountId.</exception>
        /// <exception cref="ArithmeticException">Email занят</exception>
        public bool ChangeEmail(int accountId, string email)
        {
            Account account = Accounts.First(a => a.AccountId == accountId);
            Email currentEmail = Emails.FirstOrDefault(e => e.AccountId == account.AccountId);
            System.Net.Mail.MailAddress mailAddress = null;
            Email newEmail = null;

            try
            {
                mailAddress = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                throw new FormatException("Email is not a recognized format.");
            }

            if (mailAddress.Address == currentEmail?.Value)
                return false;

            if (FindByEmail(mailAddress.Address) != null)
                throw new ArgumentException("Email уже занят", nameof(email));

            if (currentEmail != null)
                currentEmail.DateTo = DateTime.UtcNow;

            newEmail = new Email() { DateFrom = DateTime.UtcNow, Value = mailAddress.Address };
            account.Emails.Add(newEmail);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Устанавливает телефон для аккаунта
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="phone"></param>
        /// <returns>True - телефон изменен, false - новый телефон совпадает с старым</returns>
        /// <exception cref="InvalidOperationException">Аккаунт с таким id не найден</exception>
        /// <exception cref="FormatException">Некорректный номер телефона</exception>
        /// <exception cref="ArgumentException">Телефон уже занят</exception>
        public bool ChangePhone(int accountId, string phone)
        {
            Account account = Accounts.First(a => a.AccountId == accountId);
            Phone currentPhone = Phones.First(p => p.AccountId == account.AccountId);
            Phone newPhone =  Arnet.Library.PhoneConverter.TryCreatePhone(phone);

            if (newPhone == null)
                throw new Exception("Некорректный формат телефона");

            if (currentPhone.Number == newPhone.Number)
                return false;

            if (FindByPhone(newPhone.Number) != null)
                throw new ArgumentException("Телефон уже занят", nameof(phone));

            currentPhone.DateTo = DateTime.UtcNow;
            newPhone.DateFrom = DateTime.UtcNow;
            account.Phones.Add(newPhone);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Меняет пароль
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="password"></param>
        /// <returns>True - пароль изменен, False - новое значение идентично старому</returns>
        /// <exception cref="InvalidOperationException">Аккаунт с таким id не найден</exception>
        public bool ChangePassword(int accountId, string password)
        {
            Account account = Accounts.First(a => a.AccountId == accountId);
            Password currentPassword = Passwords.First(p => p.AccountId == account.AccountId);
            Password newPassword = new Password() { Value = password };

            if (currentPassword.Value == newPassword.Value)
                return false;
            
            currentPassword.DateTo = DateTime.UtcNow;
            newPassword.DateFrom = DateTime.UtcNow;

            account.Passwords.Add(newPassword);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Меняет имя для аккаунта
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="middleName"></param>
        /// <exception cref="InvalidOperationException">Аккаунт с таким id не найден</exception>
        /// <exception cref="Exception">Не указано имя/фамилия</exception>
        public void ChangeName(int accountId, string firstName, string secondName, string middleName=null)
        {
            Account account = Accounts.First(a => a.AccountId == accountId);

            if (string.IsNullOrWhiteSpace(firstName))
                throw new Exception("Не указано имя");
            if (string.IsNullOrWhiteSpace(secondName))
                throw new Exception("Не указана фамилия");

            account.FirstName = firstName;
            account.SecondName = secondName;
            account.MiddleName = middleName;

            db.SaveChanges();
        }

        #endregion

        #region Блокировка/разблокировка/закрытие

        /// <summary>
        /// Блокирует активный аккаунт, создает Ban
        /// </summary>
        /// <param name="accountId">id аккаунта</param>
        /// <param name="duration">длительность блокировки, null - навсегда</param>
        /// <param name="reason">Причина</param>
        /// <exception cref="InvalidOperationException">Аккаунт с таким Id не является активным</exception>
        /// <exception cref="TimeoutException">duration отрицательная</exception>
        public bool Ban(int accountId, TimeSpan? duration=null, string reason=null)
        {
            if (duration?.Ticks < 0)
                throw new TimeoutException("duration отрицательная");

            Account account = ActiveAccounts.FirstOrDefault(a => a.AccountId == accountId);
            DateTime? dateTo = null;
            
            if (account == null)
                return false;

            if (duration != null)
                dateTo = DateTime.UtcNow.Add(duration.Value);

            Arnet.Database.Ban ban = new Ban() { AccountId = accountId, Comment = reason, DateFrom = DateTime.Now };
            db.Bans.Add(ban);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Разбанивает аккаунт с указанным id
        /// </summary>
        /// <param name="accountId">id аккаунта</param>
        public bool Unban(int accountId)
        {
            var ban = Bans.FirstOrDefault(a => a.AccountId == accountId);
            if (ban == null)
                return false;

            ban.DateTo = DateTime.UtcNow;
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Закрывает аккаунт с данным id
        /// </summary>
        /// <param name="accountId">id аккаунта</param>
        public bool CloseAccount(int accountId)
        {
            Account account = Accounts.FirstOrDefault(a => a.AccountId == accountId);
            if (account != null)
            {
                AccountClosing?.Invoke(this, new AccountEventArgs(account));
                account.DateTo = DateTime.UtcNow;
                db.SaveChanges();
                return true;
            }

            return false;
        }

        #endregion
    }
}
