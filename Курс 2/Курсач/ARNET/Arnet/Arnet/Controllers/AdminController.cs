using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Arnet.Web.Models.Admin;
using Arnet.Reports;
using Arnet.Managers;
using Arnet.Database;
using Arnet.Library;


namespace Arnet.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ReportCreator reportCreator;
        private AccountManager accountManager;
        private readonly InviteManager inviteManager;
        private ARNETContext db;

        public AdminController(ReportCreator reportCreator, AccountManager accountManager, InviteManager inviteManager, ARNETContext db)
        {
            this.inviteManager = inviteManager;
            this.reportCreator = reportCreator;
            this.accountManager = accountManager;
            this.db = db;
        }

        #region Пользователи 

        public IActionResult Users()
        {
            IEnumerable<UserViewModel> userViewModel = from account in accountManager.Accounts.Include(t => t.AccountType)
                                                       join phone in accountManager.Phones on account.AccountId equals phone.AccountId
                                                       join ban in accountManager.Bans on account.AccountId equals ban.AccountId into pban
                                                       from subban in pban.DefaultIfEmpty()
                                                       select new UserViewModel()
                                                       {
                                                           Account = account,
                                                           Phone = phone,
                                                           Ban = subban
                                                       };

            return View(userViewModel);
        }
        
        public IActionResult RemoveAccount(int id)
        {
            accountManager.CloseAccount(id);

            return RedirectToAction("Users");
        }

        public IActionResult EditAccount(int id)
        {
            Account account = accountManager.Accounts.Include(a=>a.AccountType).First(a => a.AccountId == id);

            EditAccountViewModel model = new EditAccountViewModel()
            {
                Account = account,
                Email = accountManager.Emails.FirstOrDefault(a => a.AccountId == account.AccountId),
                Phone = accountManager.Phones.First(a => a.AccountId == account.AccountId),
                Password = accountManager.Passwords.First(a => a.AccountId == account.AccountId)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditAccount(EditAccountViewModel model)
        {
            int accountId = model.Account.AccountId;   
            try
            {
                accountManager.ChangeName(accountId, model.Account.FirstName, model.Account.SecondName, model.Account.MiddleName);
                if (!string.IsNullOrWhiteSpace(model?.Email?.Value))
                    accountManager.ChangeEmail(accountId, model.Email.Value);
                accountManager.ChangePhone(accountId, model.Phone.Number);
                accountManager.ChangePassword(accountId, model.Password.Value);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(model);
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

        #region Модераторы

        public IActionResult Moderators()
        {
            IEnumerable<ModeratorViewModel> res = from moder in accountManager.Moderators
                                                  join phone in accountManager.Phones on moder.AccountId equals phone.AccountId
                                                  select new ModeratorViewModel
                                                  {
                                                      Phone = phone,
                                                      Account = moder
                                                  };
            return View(res);
        }

        public IActionResult RemoveModerator(int id)
        {
            Account moderator = accountManager.Moderators.First(m => m.AccountId == id);

            accountManager.CloseAccount(moderator.AccountId);

            return RedirectToAction("Moderators");
        }

        public IActionResult AddModerator()
        {
            var invite = inviteManager.CreateModerInvite();

            return Json(Url.ActionLink("NewAccount", "Account", new { id = invite.Md5 }));
        }

        public IActionResult Invites()
        {
            IEnumerable<ModeratorInvite> invites = inviteManager.ModeratorInvites;

            return View(invites);
        }

        public bool RemoveInvite(int id)
        {
            return inviteManager.RemoveModerInvite(id);
        }

        #endregion

        //TODO: в отдельный контрл
        #region Отчеты

        public IActionResult Reports()
        {
            ReportsViewModel model = new ReportsViewModel()
            {
                NewPublishmetns = reportCreator.NewPublishmentsReport(),
                NewUsers = reportCreator.NewUsersReport()
            };

            return View(model);
        }

        public IActionResult DownloadReport(string id)
        {
            DataTable table = null;
            string fileName = null,
                fileType = "text/plain";
            switch (id)
            {
                case "AllUsers": 
                    table = reportCreator.AllUsersReport();
                    fileName = "AllUsers.csv";
                    break;
                case "NewUsers": 
                    table = reportCreator.NewUsersReport();
                    fileName = "NewUsers.csv";
                    break;
                case "NewPublishments": 
                    table = reportCreator.NewPublishmentsReport();
                    fileName = "NewPublishments.csv";
                    break;
                default: return BadRequest();
            }
            byte[] bytes = table.ToCsv();
            return File(bytes, fileType, fileName);
        }

        #endregion
    }
}