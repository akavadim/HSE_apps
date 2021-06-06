using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Arnet.Database;
using Arnet.Managers;

namespace Arnet.Managers
{
    public class ApartmentManager
    {

        private readonly ARNETContext db;
        private readonly AgencyManager agencyManager;
        private readonly AccountManager accountManager;

        public ApartmentManager(ARNETContext db, AgencyManager agencyManager, AccountManager accountManager)
        {
            this.db = db;
            this.agencyManager = agencyManager;
            this.accountManager = accountManager;
            accountManager.AccountClosing += AccountManager_AccountClosing;
        }

        public IQueryable<Apartment> Apartments { get=> db.Apartments.Where(p => p.DateTo == null || p.DateTo > DateTime.UtcNow); }

        public IQueryable<Publishment> Publishments { get => db.Publishments.Where(p => p.DateTo == null || p.DateTo > DateTime.UtcNow); }

        /// <summary>
        /// Позволяет перемещать апартаменты между агентами в одном агентстве
        /// </summary>
        /// <param name="apartmentId">id апартаментов</param>
        /// <param name="accountId">id аккаунта агента</param>
        /// <param name="companyId">Id компании</param>
        /// <exception cref="InvalidOperationException">Апартаменты с таким id не найдены</exception>
        /// <exception cref="InvalidOperationException">Аккаунт с таким id не является агентом</exception>
        /// <exception cref="InvalidOperationException">Апартаменты не принадлежат агенту</exception>
        /// <exception cref="ArgumentException">Агенты из разных компаний</exception>
        /// <exception cref="ArgumentException">id компании агента отличается от переданного companyId</exception>
        public void MoveApartmentsBetweenAgents(int companyId, int apartmentId, int accountId)
        {
            Apartment apartment = Apartments.First(a => a.ApartmentId == apartmentId);
            Company companyFrom = agencyManager.FindByAgent(apartment.AccountId);
            Company companyTo = agencyManager.FindByAgent(accountId);

            if (companyFrom == null)
                throw new InvalidOperationException("Апартаменты не принадлежат агенту");
            if (companyTo == null)
                throw new InvalidOperationException("Аккаунт с таким id не является агентом");
            if (companyFrom.CompanyId != companyTo.CompanyId)
                throw new ArgumentException("Агенты из разных компаний");
            if (companyFrom.CompanyId != companyId)
                throw new ArgumentException("id компании агента отличается от переданного companyId");

            apartment.AccountId = accountId;
            db.SaveChanges();
        }

        #region Получени апартаментов, объвлений

        /// <summary>
        /// Получает активные объявления для компании
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Компания не является активной</exception>
        public IEnumerable<Publishment> GetPublishmentsByAgency(int companyId)
        {
            IEnumerable<Publishment> publishments = from apartment in GetApartmentsByAgency(companyId)
                                                    join publishment in Publishments on apartment.ApartmentId equals publishment.ApartmentId
                                                    select publishment;
            return publishments;
        }

        /// <summary>
        /// Получает активные апартаменты для компании
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Компания не является активной</exception>
        public IEnumerable<Apartment> GetApartmentsByAgency(int companyId)
        {
            Company company = agencyManager.Companies.First(c => c.CompanyId == companyId);
            IEnumerable<Account> agents = agencyManager.GetAgents(companyId);
            IEnumerable<Apartment> apartments = agents.SelectMany(a => GetApartmentsByAccount(a.AccountId));
            return apartments;
        }

        /// <summary>
        /// Получает активные объявления для аккаунта
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Аккаунт не является активным</exception>
        public IQueryable<Publishment> GetPublishmentsByAccount(int accountId)
        {
            IQueryable<Publishment> publishments = from apartment in GetApartmentsByAccount(accountId)
                                                   join publishment in Publishments on apartment.ApartmentId equals publishment.ApartmentId
                                                   select publishment;
            return publishments;
        }

        /// <summary>
        /// Получает активные апартаменты для акаунта
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Аккаунт не является активным</exception>
        public IQueryable<Apartment> GetApartmentsByAccount(int accountId)
        {
            Account account = accountManager.Accounts.First(a => a.AccountId == accountId);
            IQueryable<Apartment> apartments = Apartments.Where(a => a.AccountId == account.AccountId);
            return apartments;
        }

        /// <summary>
        /// Получает закрытые апартаменты для акаунта
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Аккаунт не является активным</exception>
        public IQueryable<Apartment> GetClosedApartmentsByAccount(int accountId)
        {
            Account account = accountManager.Accounts.First(a => a.AccountId == accountId);
            IQueryable<Apartment> apartments = from apartment in db.Apartments
                                               where apartment.AccountId == account.AccountId
                                               && !Apartments.Any(a => a.ApartmentId == apartment.ApartmentId)
                                               select apartment;
            return apartments;
        }

        #endregion

        /// <summary>
        /// Добавляет апартаменты к аккаунту
        /// </summary>
        /// <param name="accountId"></param>
        /// <exception cref="InvalidOperationException">Аккаунт с таким id не найден</exception>
        /// <exception cref="ArgumentException">Аккаунт должен быть агентом, либо обычныем пользователем"</exception>
        public Apartment AddApartment(int accountId)
        {
            Apartment apartment = new Apartment() { DateFrom = DateTime.UtcNow, AccountId=accountId, AccommodationId=db.Accommodations.First().AccommodationId };
            var accountType = accountManager.GetAccountType(accountId);

            if (accountType != AccountTypesEnum.Agent && accountType != AccountTypesEnum.User)
                throw new ArgumentException("Аккаунт должен быть агентом, либо обычныем пользователем");
            db.Apartments.Add(apartment);
            db.SaveChanges();
            return apartment;
        }

        #region Закрытие

        /// <summary>
        /// Закрывает апаратаменты и связанные publishment
        /// </summary>
        /// <param name="apartmentId"></param>
        /// <returns></returns>
        public bool CloseApartment(int apartmentId)
        {
            Apartment apartment = Apartments.FirstOrDefault(a => a.ApartmentId == apartmentId);
            if (apartment != null)
            {
                IEnumerable<Publishment> publishments = Publishments.Where(p => p.ApartmentId == apartment.ApartmentId);
                foreach (var publishment in publishments)
                    ClosePublishment(publishment.PublishmentId);
                apartment.DateTo = DateTime.UtcNow;
                db.SaveChanges();
            }
            return false;
        }

        /// <summary>
        /// Закрывает публикацию
        /// </summary>
        /// <param name="publishmentId"></param>
        /// <returns>true - удалено</returns>
        public bool ClosePublishment(int publishmentId)
        {
            Publishment publishment = Publishments.FirstOrDefault(p => p.PublishmentId == publishmentId);
            if (publishment != null)
            {
                publishment.DateTo = DateTime.UtcNow;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        private void AccountManager_AccountClosing(object sender, AccountEventArgs args)
        {
            IEnumerable<Apartment> apartments = GetApartmentsByAccount(args.Account.AccountId);

            foreach (var apartment in apartments)
                CloseApartment(apartment.ApartmentId);
        }
    }
}
