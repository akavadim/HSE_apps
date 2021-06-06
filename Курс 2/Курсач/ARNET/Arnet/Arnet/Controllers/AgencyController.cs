using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Arnet.Database;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text.Json;
using Arnet.Web.Models.Agency;
using Arnet.Library.Claims;
using Arnet.Managers;

namespace Arnet.Web.Controllers
{
    public class AgencyController : Controller
    {
        private readonly ARNETContext db;
        private readonly AgencyManager agencyManager;
        private readonly AccountManager accountManager;
        private readonly ApartmentManager apartmentManager;

        public AgencyController(ARNETContext db, AgencyManager agencyManager, AccountManager accountManager, ApartmentManager apartmentManager)
        {
            this.accountManager = accountManager;
            this.db = db;
            this.agencyManager = agencyManager;
            this.apartmentManager = apartmentManager;
        }

        private int userId { get => int.Parse(User.Claims.First(m => m.Type == ClaimTypes.NameIdentifier).Value); }

        #region Info

        [Route("Agency/{companyId}")]
        public IActionResult Info(int companyId)
        {
            var company = agencyManager.Companies.FirstOrDefault(m => m.CompanyId == companyId);
            if (company == null)
                return NotFound();

            InfoViewModel infoModelView = new InfoViewModel()
            {
                AgencyName = company.Name,
                AgentCount = agencyManager.GetAgents(company.CompanyId).Count(),
                SoldCount = 0,   //TODO: сделать
                IsOwner = IsOwner(company)
            };

            SetViewBag(company);
            return View(infoModelView);
        }

        [HttpPost]
        [Route("Agency/{companyId}")]
        [Authorize(Roles ="Agency")]
        public IActionResult Info(int companyId, InfoViewModel model)
        {
            var company = agencyManager.Companies.FirstOrDefault(m => m.CompanyId == companyId);

            if (company == null)
                return NotFound();
            if (!IsOwner(company))
                return BadRequest();

            try
            {
                agencyManager.ChangeName(companyId, model.AgencyName);
            }
            catch
            {
                ModelState.AddModelError("", "Недопустимое название");
            }

            SetViewBag(company);
            return View(model);
        }

        #endregion

        #region Agents

        [Route("Agency/{companyId}/Agents")]
        public IActionResult Agents(int companyId)
        {
            var company = agencyManager.FindById(companyId);
            if (company == null)
                return NotFound();
            IEnumerable<AgentsViewModel> model = from agent in agencyManager.GetAgents(companyId)
                                                 select new AgentsViewModel()
                                                 {
                                                     Agent = agent,
                                                     ClosedApartments = apartmentManager.GetClosedApartmentsByAccount(agent.AccountId),
                                                     OpenedApartments = apartmentManager.GetApartmentsByAccount(agent.AccountId)
                                                 };

            ViewData["isOwner"] = IsOwner(company);
            SetViewBag(company);
            return View(model);
        }

        [Route("Agency/{companyId}/AddAgent")]
        public IActionResult AddAgent(int companyId)
        {
            if (agencyManager.FindById(companyId)?.OwnerId != userId)
                return BadRequest();
            string md5;
            do
            {
                md5 = RandomMd5();
            } while (db.CompanyInvites.FirstOrDefault(i => i.Md5 == md5) != null);
            db.CompanyInvites.Add(new CompanyInvite() { CompanyId = companyId, Md5 = md5, DateTo = DateTime.UtcNow.AddDays(1) });
            db.SaveChanges();

            return Json(Url.ActionLink("NewAccount", "Account", new { id = md5 }));
        }

        [Route("Agency/{companyId}/Invites")]
        public IActionResult Invites(int companyId)
        {
            var company = agencyManager.FindById(companyId);
            if (company?.OwnerId != userId)
                return BadRequest();

            var model = from invite in db.CompanyInvites
                        where invite.CompanyId == companyId && invite.DateTo>DateTime.UtcNow
                        select new InvitesViewModel()
                        {
                            InviteId = invite.InviteId,
                            Url = Url.ActionLink("NewAccount", "Account", new { id = invite.Md5 }, null, null, null),
                            DateTo = invite.DateTo
                        };

            SetViewBag(company);
            return View(model.ToArray());
        }

        [Route("Agency/{companyId}/RemoveInvite/{inviteId}")]
        public IActionResult RemoveInvite(int companyId, int inviteId)
        {
            var invite = db.CompanyInvites.FirstOrDefault(i => i.InviteId == inviteId);
            if (invite == null || agencyManager.FindById(invite.CompanyId).OwnerId != userId)
                return BadRequest();

            db.CompanyInvites.Remove(invite);
            db.SaveChanges();
            return Redirect(Url.Action("Invites", "Agency", new { companyId = companyId }));
        }

        [Route("Agency/{companyId}/RemoveAgent/{accountId}")]
        public IActionResult RemoveAgent(int companyId, int accountId)
        {
            var agent = db.Agents.FirstOrDefault(a => a.AccountId == accountId);
            if (agent == null || agencyManager.FindById(agent.CompanyId).OwnerId != userId)
                return BadRequest();
            var account = db.Accounts.Find(agent.AccountId);
            accountManager.CloseAccount(account.AccountId);
            db.SaveChanges();
            return Redirect(Url.Action("Agents", "Agency", new {companyId=companyId }));
        }

        #endregion

        #region Перемещение объявлений

        [Authorize(Roles ="Agency")]
        [Route("Agency/Agent/{accountId}")]
        public IActionResult AgentApartments(int accountId)
        {
            Company agency = agencyManager.FindByOwner(userId);
            Account agent = agencyManager.GetAgents(agency.CompanyId).First(a => a.AccountId == accountId);
            AgentApartmentsViewModel model = new AgentApartmentsViewModel() { Agent = agent };
            model.SelectApartments = (from apartment in apartmentManager.GetApartmentsByAccount(agent.AccountId)
                                      select new SelectApartment { Apartment = apartment }).ToArray();

            SetViewBag(agency);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Agency")]
        public IActionResult MoveToAgent(AgentApartmentsViewModel model)
        {
            Company agency = agencyManager.FindByOwner(userId);
            Apartment firstApartment = apartmentManager.Apartments.First(a => a.ApartmentId == model.SelectApartments[0].Apartment.ApartmentId);
            Account selectedAgent = accountManager.FindById(firstApartment.AccountId);
            IEnumerable<Account> agents = agencyManager.GetAgents(agency.CompanyId).Where(a=>a.AccountId!=selectedAgent.AccountId);
            string serializedModel = JsonSerializer.Serialize(model.SelectApartments);

            TempData["AgentApartments"] = serializedModel;
            SetViewBag(agency);

            return View(agents);
        }

        [Authorize(Roles = "Agency")]
        public IActionResult MoveToAgent(int id)
        {
            Company agency = agencyManager.FindByOwner(userId);
            var model = JsonSerializer.Deserialize<SelectApartment[]>(TempData["AgentApartments"].ToString());

            foreach (var m in model)
                if (m.IsSelected)
                    apartmentManager.MoveApartmentsBetweenAgents(agency.CompanyId, m.Apartment.ApartmentId, id);

            Apartment randomApartment = apartmentManager.Apartments.First(a => a.ApartmentId == model.First().Apartment.ApartmentId);

            SetViewBag(agency);
            return RedirectToAction("AgentApartments", new { accountId = randomApartment.AccountId });
        }

        #endregion

        private bool IsOwner(Company company)
        {
            if (company == null)
                return false;
            if (!User.Identity.IsAuthenticated)
                return false;
            if (!User.IsInRole("Agency"))
                return false;

            return User.FindFirst(ArnetClaimTypes.CompanyId).Value == company.CompanyId.ToString();
        }

        private string RandomMd5()
        {
            var bytes = new byte[16];
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        private void SetViewBag(Company company)
        {
            ViewBag.CompanyId = company.CompanyId;
            ViewBag.CompanyName = company.Name;
        }
    }
}