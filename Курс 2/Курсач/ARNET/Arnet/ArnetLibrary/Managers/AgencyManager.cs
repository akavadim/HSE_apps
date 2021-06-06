using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Arnet.Database;
using Arnet.Managers;

namespace Arnet.Managers
{
    /// <summary>
    /// Класс для работы с агентствами. 
    /// </summary>
    public class AgencyManager
    {
        private readonly ARNETContext db;
        private readonly AgentManager agentManager;
        private readonly AccountManager accountManager;

        public AgencyManager(ARNETContext db, AgentManager agentManager, AccountManager accountManager)
        {
            this.accountManager = accountManager;
            this.agentManager = agentManager;
            this.db = db;
            accountManager.AccountClosing += AccountManager_AccountClosing;
        }

        public IEnumerable<Company> Companies { get => db.Companies.Where(a => a.DateTo == null || a.DateTo >= DateTime.Now); }

        #region Изменение данных

        /// <summary>
        /// Меняет название компании
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="newName"></param>
        /// <exception cref="ArgumentNullException">Пустое название</exception>
        /// <exception cref="InvalidOperationException">Компания не является активной</exception>
        public void ChangeName(int companyId, string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentNullException(nameof(newName));

            Company company = Companies.First(a => a.CompanyId == companyId);
            company.Name = newName;
            db.SaveChanges();
        }

        #endregion

        #region Получение данных о компании

        /// <summary>
        /// Получает активных агентов
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Компания не является активной</exception>
        public IEnumerable<Account> GetAgents(int companyId)
        {
            Company company = Companies.First(c => c.CompanyId == companyId);
            IEnumerable<Account> agents = agentManager.ActiveAgents
                .Where(a => a.CompanyId == company.CompanyId)
                .Select(a => db.Accounts.Find(a.AccountId));
            return agents;
        }

        /// <summary>
        /// Находит компанию по агенту
        /// </summary>
        /// <param name="accountId">id Аккаунта</param>
        /// <returns></returns>
        public Company FindByAgent(int accountId)
        {
            Company company = null;
            Agent agent = agentManager.ActiveAgents.FirstOrDefault(a => a.AccountId == accountId);

            if (agent != null)
                company = Companies.First(c => c.CompanyId == agent.CompanyId);

            return company;
        }

        /// <summary>
        /// Находит компанию по ее id
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public Company FindById(int companyId)
        {
            Company company = Companies.FirstOrDefault(c => c.CompanyId == companyId);

            return company;
        }

        /// <summary>
        /// Находит компанию по владельцу
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public Company FindByOwner(int ownerId)
        {
            Company company = Companies.FirstOrDefault(c => c.OwnerId == ownerId);

            return company;
        }

        #endregion

        #region закрытие компании

        /// <summary>
        /// Закрывает агентство, владельца агентства, а также всех агентов и все объявления
        /// </summary>
        /// <param name="agencyId"></param>
        /// <returns>true - закрыто</returns>
        public bool CloseAgency(int agencyId)
        {
            Company company = Companies.FirstOrDefault(c => c.CompanyId == agencyId);
            if (company != null)
            {
                return accountManager.CloseAccount(company.OwnerId);
            }
            return false;
        }

        /// <summary>
        /// Закрывает компанию и всех ее агентов (но не закрывает владельца)
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Компания не является активной</exception>
        private void CloseAgencyWithoutOwner(Company company)
        {
            IEnumerable<Account> agents = GetAgents(company.CompanyId);
            foreach (var agent in agents)
            {
                accountManager.CloseAccount(agent.AccountId);
            }

            company.DateTo = DateTime.UtcNow;
            db.SaveChanges();
        }

        #endregion

        private void AccountManager_AccountClosing(object sender, AccountEventArgs args)
        {
            Account account = args.Account;
            if (accountManager.GetAccountType(account.AccountId) == AccountTypesEnum.Agency)
            {
                Company company = Companies.First(c => c.OwnerId == account.AccountId);
                CloseAgencyWithoutOwner(company);
            }
        }
    }
}
