using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Arnet.Web.Models.Account;
using Arnet.Database;
using Arnet.Library;
using Arnet.Library.Claims;
using Arnet.Managers;

namespace Arnet.Web.Controllers
{
    //TODO: placeholders
    public partial class AccountController : Controller
    {
        private ARNETContext db;
        private AccountManager accountManager;
        private SignInManager signInManager;
        private AgencyManager agencyManager;

        public AccountController(ARNETContext db, AccountManager accountManager, SignInManager signInManager, AgencyManager agencyManager)
        {
            this.accountManager = accountManager;
            this.db = db;
            this.signInManager = signInManager;
            this.agencyManager = agencyManager;
        }

        private int userId { get => int.Parse(HttpContext.User.Claims.First(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value); }

        #region Login/Logout

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await signInManager.LoginByEmailAsync(model.Login, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch { }
                try
                {
                    await signInManager.LoginByPhoneAsync(model.Login, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch 
                {
                    ModelState.AddModelError("", "Неправильный логин и/или пароль");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.Logout();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Manage

        [Authorize]
        public IActionResult Manage()
        {
            int accountId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            ManageViewModel model = new ManageViewModel()
            {
                Account = accountManager.Accounts.Include(a => a.AccountType).First(a => a.AccountId == accountId),
                Email = accountManager.Emails.FirstOrDefault(e => e.AccountId == accountId),
                Phone = accountManager.Phones.First(p => p.AccountId == accountId)
            };

            return View(model);
        }

        [Authorize]
        public IActionResult ChangeEmail()
        {
            int accountId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            ChangeEmailViewModel model = new ChangeEmailViewModel()
            {
                Email = accountManager.Emails.FirstOrDefault(e => e.AccountId == accountId)
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult ChangeEmail(ChangeEmailViewModel model)
        {
            int accountId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

            try
            {
                accountManager.ChangeEmail(accountId, model.NewEmail);
                return RedirectToAction("ChangeEmail");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(model);
            }
        }

        [Authorize]
        public IActionResult ChangeName()
        {
            int accountId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            Account account = accountManager.FindById(accountId);
            return View(account);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ChangeName(Account account)
        {
            int accountId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            try
            {
                accountManager.ChangeName(accountId, account.FirstName, account.SecondName, account.MiddleName);
                return RedirectToAction("ChangeName");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(account);
            }
        }

        #endregion

        public IActionResult Profile(int id)
        {
            Account account = accountManager.Accounts.Include(a=>a.AccountType).First(a => a.AccountId == id);
            ProfileViewModel model = new ProfileViewModel() 
            { 
                Account = account, 
                Ban=accountManager.Bans.FirstOrDefault(b=>b.AccountId==account.AccountId) 
            };
            Account currentAccount = null;

            if (User.Identity.IsAuthenticated)
            {
                currentAccount = accountManager.Accounts.Include(a=>a.AccountType).First(a => a.AccountId == userId);
                Company currentCompany = agencyManager.FindByOwner(currentAccount.AccountId);
                model.Agency = agencyManager.FindByAgent(account.AccountId);
              
                if(currentAccount.AccountType.Type==AccountTypesEnum.Admin||currentAccount.AccountId==account.AccountId
                    ||(currentCompany!=null && currentCompany.CompanyId==model.Agency?.CompanyId))
                {
                    model.Email = accountManager.Emails.FirstOrDefault(e => e.AccountId == account.AccountId);
                    model.Phone = accountManager.Phones.First(p => p.AccountId == account.AccountId);
                }
            }

            return View(model);
        }
    }
}