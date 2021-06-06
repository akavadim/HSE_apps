using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Arnet.Database;
using Arnet.Managers;
using Arnet.Web.Models.Apartment;

namespace Arnet.Web.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly ApartmentManager apartmentManager;
        private readonly AccountManager accountManager;

        public ApartmentController(ApartmentManager apartmentManager, AccountManager accountManager)
        {
            this.accountManager = accountManager;
            this.apartmentManager = apartmentManager;
        }

        [Authorize(Roles ="Agent, User")]
        public IActionResult MyApartments()
        {
            Account account = GetCurrentAccount();
            IEnumerable<Apartment> apartments = apartmentManager.GetApartmentsByAccount(account.AccountId);

            return View(apartments);
        }

        [Authorize(Roles = "Agent, User")]
        public IActionResult AddApartment()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Agent, User")]
        public IActionResult AddApartment(AddApartmentViewModel model)
        {
            Account account = GetCurrentAccount();
            apartmentManager.AddApartment(account.AccountId);
            return View();
        }


        private Account GetCurrentAccount()
        {
            Account account = null;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                int id = int.Parse(HttpContext.User.Claims.First(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);
                account = accountManager.FindById(id);
            }
            return account;
        }
    }
}