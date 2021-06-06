using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Arnet.Database;
using Arnet.Library;
using System.Net.Mail;
using Arnet.Library.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;

namespace Arnet.Managers
{
    public class SignInManager
    {
        private readonly AccountManager accountManager;
        private readonly AgencyManager agencyManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SignInManager(AccountManager accountManager, AgencyManager agencyManager, IHttpContextAccessor httpContextAccessor)
        {
            this.accountManager = accountManager;
            this.agencyManager = agencyManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        private HttpContext HttpContext { get => httpContextAccessor.HttpContext; }

        /// <summary>
        /// Вход по email
        /// </summary>
        /// <param name="email">почта</param>
        /// <param name="password">Пароль</param>
        /// <exception cref="Exception">Ошибка входа</exception>
        public async Task LoginByEmailAsync(string email, string password)
        {
            Account account = accountManager.FindByEmail(email);

            if (account == null)
                throw new Exception("Аккаунт с таким email не найден");

            await LoginAsync(account, password);
        }

        /// <summary>
        /// Вход по телефону
        /// </summary>
        /// <param name="phone">телефон</param>
        /// <param name="password">пароль</param>
        /// <exception cref="Exception">Ошибка входа</exception>
        public async Task LoginByPhoneAsync(string phone, string password)
        {
            Account account = accountManager.FindByPhone(phone);
            if (account == null)
                throw new Exception("Аккаунт с таким телефоном не найден");

            await LoginAsync(account, password);
        }

        /// <summary>
        /// Выходит из аккаунта
        /// </summary>
        /// <returns></returns>
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// Авторизует указанный аккаунт
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <exception cref="ArgumentNullException">Account is null</exception>
        /// <exception cref="InvalidOperationException">AccountId not found</exception>
        private async Task LoginAsync(Account account, string password)
        {
            Password passwordClass = accountManager.Passwords.First(p => p.AccountId == account.AccountId);

            if (accountManager.BannedAccounts.FirstOrDefault(b => b.AccountId == account.AccountId) != null)
                throw new Exception("Аккаунт забанен");

            if (passwordClass.Value != password)
                throw new Exception("Некорректный пароль");

            await AuthenticateAsync(account);
        }

        /// <summary>
        /// Устанавливает claims и проводит аутентификацию для указанного аккаунта
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Аккаунт с таким id не существует</exception>
        private async Task AuthenticateAsync(Account account)
        {
            AccountTypesEnum accountType = accountManager.GetAccountType(account.AccountId);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, account.FirstName),
                new Claim(ClaimTypes.NameIdentifier, account.AccountId.ToString()),
                new Claim(ClaimTypes.Role, accountType.ToString()),
            };

            if (accountType==AccountTypesEnum.Agency)
            {
                var agency = agencyManager.Companies.First(c => c.OwnerId == account.AccountId);
                claims.Add(new Claim(ArnetClaimTypes.CompanyId, agency.CompanyId.ToString()));
            }

            ClaimsIdentity id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
