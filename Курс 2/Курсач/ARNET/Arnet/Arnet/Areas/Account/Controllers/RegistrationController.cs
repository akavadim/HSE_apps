using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Arnet.Database;
using Arnet.Web.Areas.Account.Models.Registration;
using Microsoft.AspNetCore.Authorization;
using Arnet.Library;
using Arnet.Managers;

namespace Arnet.Web.Areas.Account.Controllers
{
    [Area("Account")]
    public class RegistrationController : Controller
    {
        private ARNETContext db;
        private AccountManager accountManager;
        private SignInManager signInManager;
        private InviteManager inviteManager;

        public RegistrationController(ARNETContext db, AccountManager accountManager, SignInManager signInManager, InviteManager inviteManager)
        {
            this.accountManager = accountManager;
            this.db = db;
            this.signInManager = signInManager;
            this.inviteManager = inviteManager;
        }

        [HttpGet]
        [Route("Account/NewAccount/{md5?}")]
        public IActionResult NewAccount(string md5)
        {
            if (md5 != null)
            {
                CompanyInvite companyInvite = inviteManager.AgentInvites.FirstOrDefault(i => i.Md5 == md5);
                ModeratorInvite moderatorInvite = inviteManager.ModeratorInvites.FirstOrDefault(i => i.Md5 == md5);


                if (companyInvite != null)
                {
                    ViewBag.CompanyName = db.Companies.FirstOrDefault(c => c.CompanyId == companyInvite.CompanyId).Name;
                }
                else if (moderatorInvite == null)
                {
                    return BadRequest();   
                }

                ViewBag.InviteMd5 = md5;
            }
            return View();
        }

        
        [Route("Account/NewAccount/{id?}")]
        public IActionResult NewAccount(NewAccountViewModel accountViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!string.IsNullOrEmpty(accountViewModel.AccountModel.Email) && accountManager.FindByEmail(accountViewModel.AccountModel.Email)!=null)
                return Json(new { invalidEmail = true });

            if (!string.IsNullOrWhiteSpace(accountViewModel.InviteMd5))
                if (db.CompanyInvites.FirstOrDefault(i => i.Md5 == accountViewModel.InviteMd5) == null&&
                    db.ModeratorInvites.FirstOrDefault(i => i.Md5 == accountViewModel.InviteMd5)==null)
                    return BadRequest();

            TempData["accountViewModel"] = JsonSerializer.Serialize(accountViewModel); //TODO: Асинхронно
            return PartialView("_AddPhoneModal");
        }

        [HttpPost]
        public IActionResult SendMessage(PhoneModel phoneModel)
        {
            if (!TempData.ContainsKey("accountViewModel") || !ModelState.IsValid)
                return BadRequest();

            bool isValid = false;
            Phone phone = PhoneConverter.TryCreatePhone(phoneModel.Phone);
            if (accountManager.FindByPhone(phone.Number)!=null)
                return Json(new { isValid });

            //TODO: отправка сообщения
            TempData["phoneModel"] = JsonSerializer.Serialize(phoneModel);  //TODO: Асинхронно
            return Json(new { isValid = true });
        }

        [HttpPost]
        public async Task<IActionResult> Registration(PhoneCode phoneCode)
        {
            if (!TempData.ContainsKey("phoneModel") || !ModelState.IsValid)
                return BadRequest();
            //TODO: Возможность ввести код не более 5 раз, затем занного отправка - js
            //TODO: Сверить код
            if (phoneCode.Code == "111111")
                return Json(new { invalidCode = true });

            NewAccountViewModel accountViewModel = JsonSerializer.Deserialize<NewAccountViewModel>(TempData["accountViewModel"].ToString());
            PhoneModel phoneModel = JsonSerializer.Deserialize<PhoneModel>(TempData["phoneModel"].ToString()); //TODO: Асинхронно

            var account = accountViewModel.AccountModel.ToAccount();
            if (accountViewModel.InviteMd5 != null)
            {
                CompanyInvite companyInvite = inviteManager.AgentInvites.FirstOrDefault(i => i.Md5 == accountViewModel.InviteMd5);
                ModeratorInvite moderatorInvite = inviteManager.ModeratorInvites.FirstOrDefault(i => i.Md5 == accountViewModel.InviteMd5);
                if (companyInvite != null)
                {
                    account.AccountType = db.AccountTypes.First(t => t.Type == AccountTypesEnum.Agent);
                    account.Agents.Add(new Agent()
                    {
                        CompanyId = companyInvite.CompanyId,
                        DateFrom = DateTime.UtcNow
                    });
                }
                else if (moderatorInvite != null)
                {
                    account.AccountType = db.AccountTypes.First(t => t.Type == AccountTypesEnum.Moderator);
                }
                else
                {
                    throw new Exception();
                }
                inviteManager.RemoveInvite(accountViewModel.InviteMd5);
            }
            else if (accountViewModel.CompanyModel != null)
            {
                account.AccountType = db.AccountTypes.First(m => m.Type == AccountTypesEnum.Agency);
                account.Companies.Add(accountViewModel.CompanyModel.ToCompany());
            }
            else account.AccountType = db.AccountTypes.First(m => m.Type == AccountTypesEnum.User);
               
            account.Phones.Add(phoneModel.ToPhone());

            db.Accounts.Add(account);
            db.SaveChanges();
            TempData.Clear();

            await signInManager.LoginByPhoneAsync(account.Phones.First().Number, account.Passwords.First().Value);

            return Json(Url.Action("SuccessRegistration"));
        }

        [HttpGet]
        public IActionResult SuccessRegistration()
        {
            //TODO: проверка, что вход в первый раз и акк зареган
            return View();
        }
    }
}