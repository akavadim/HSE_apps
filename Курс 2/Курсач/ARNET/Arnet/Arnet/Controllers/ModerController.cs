using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Arnet.Web.Models.Admin;
using Arnet.Database;
using Arnet.Managers;

namespace Arnet.Web.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class ModerController : Controller
    {
        private AccountManager accountManager;

        public ModerController(AccountManager accountManager)
        {
            this.accountManager = accountManager;
        }

        #region Пользователи 

        public IActionResult Users()
        {
            IEnumerable<UserViewModel> userViewModel = from account in accountManager.Accounts.Include(t => t.AccountType)
                                                       join phone in accountManager.Phones on account.AccountId equals phone.AccountId
                                                       join ban in accountManager.Bans on account.AccountId equals ban.AccountId into pban
                                                       from subres in pban.DefaultIfEmpty()
                                                       select new UserViewModel()
                                                       {
                                                           Account = account,
                                                           Phone = phone,
                                                           Ban = subres
                                                       };

            return View(userViewModel);
        }

        public IActionResult BanAccount(int id)
        {
            accountManager.Ban(id);
            return RedirectToAction("Users");
        }

        public IActionResult UnbanAccount(int id)
        {
            accountManager.Unban(id);
            return RedirectToAction("Users");
        }

        #endregion
    }
}